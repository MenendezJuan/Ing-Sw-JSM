using Servicios;
using System;
using System.IO;

namespace MPPs.Tecnica
{
    public class MPP_BACKUP
    {
        private Conexion oCnx;

        public MPP_BACKUP()
        {
            oCnx = Conexion.Instance;
        }

        /// <summary>
        /// Ejecuta un backup completo de la base de datos
        /// </summary>
        /// <param name="rutaArchivo">Ruta completa donde guardar el archivo .bak</param>
        /// <param name="nombreBackup">Nombre descriptivo del backup</param>
        /// <returns>True si el backup fue exitoso</returns>
        public bool EjecutarBackup(string rutaArchivo, string nombreBackup)
        {
            try
            {
                string nombreBD = oCnx.ObtenerNombreBaseDatos();

                string comandoBackup = $@"
                    BACKUP DATABASE [{nombreBD}]
                    TO DISK = '{rutaArchivo}'
                    WITH FORMAT, INIT, NAME = '{nombreBackup}', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

                return oCnx.EjecutarComandoSQL(comandoBackup, 5); // 5 minutos timeout
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al ejecutar backup: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Ejecuta un restore completo de la base de datos
        /// </summary>
        /// <param name="rutaArchivo">Ruta completa del archivo .bak a restaurar</param>
        /// <returns>True si el restore fue exitoso</returns>
        public bool EjecutarRestore(string rutaArchivo)
        {
            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    throw new FileNotFoundException($"El archivo de backup no existe: {rutaArchivo}");
                }

                string nombreBD = oCnx.ObtenerNombreBaseDatos();

                // Paso 1: Poner la base en modo single user
                string comandoSingleUser = $@"
                    ALTER DATABASE [{nombreBD}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";

                oCnx.EjecutarComandoSQL(comandoSingleUser, 2);

                // Paso 2: Ejecutar restore
                string comandoRestore = $@"
                    RESTORE DATABASE [{nombreBD}]
                    FROM DISK = '{rutaArchivo}'
                    WITH REPLACE, STATS = 10";

                oCnx.EjecutarComandoSQL(comandoRestore, 10); // 10 minutos timeout

                // Paso 3: Volver a modo multi user
                string comandoMultiUser = $@"
                    ALTER DATABASE [{nombreBD}] SET MULTI_USER";

                oCnx.EjecutarComandoSQL(comandoMultiUser, 1);

                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    // Intentar volver a multi-user si algo falla
                    string nombreBD = oCnx.ObtenerNombreBaseDatos();
                    string comandoMultiUser = $@"ALTER DATABASE [{nombreBD}] SET MULTI_USER";
                    oCnx.EjecutarComandoSQL(comandoMultiUser, 1);
                }
                catch
                {
                    // Si no puede volver a multi-user, al menos registrar el error original
                }

                throw new Exception($"Error al ejecutar restore: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene el nombre de la base de datos actual
        /// </summary>
        /// <returns>Nombre de la base de datos</returns>
        public string ObtenerNombreBaseDatos()
        {
            try
            {
                return oCnx.ObtenerNombreBaseDatos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener nombre de base de datos: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifica si un usuario existe en la base de datos actual por su ID
        /// </summary>
        /// <param name="idUsuario">ID del usuario a verificar</param>
        /// <returns>True si el usuario existe, False en caso contrario</returns>
        public bool VerificarExistenciaUsuario(int idUsuario)
        {
            try
            {
                string consulta = $"SELECT COUNT(*) FROM Usuarios WHERE Id = {idUsuario} AND Activo = 1";
                return oCnx.VerificarExistenciaRegistro(consulta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar existencia de usuario: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifica si un usuario existe en un archivo de backup SIN afectar la BD actual
        /// Crea una BD temporal, restaura el backup ahí, verifica el usuario, y elimina la BD temporal
        /// </summary>
        /// <param name="rutaBackup">Ruta del archivo .bak</param>
        /// <param name="idUsuario">ID del usuario a verificar</param>
        /// <returns>True si el usuario existe en el backup, False en caso contrario</returns>
        public bool VerificarUsuarioEnBackup(string rutaBackup, int idUsuario)
        {
            string nombreBDTemporal = $"TempVerify_{Guid.NewGuid().ToString("N").Substring(0, 8)}";
            
            try
            {
                // Paso 1: Obtener el nombre lógico de los archivos del backup
                string consultaFileList = $@"RESTORE FILELISTONLY FROM DISK = '{rutaBackup}'";
                var archivos = oCnx.LeerConConsulta(consultaFileList, null);
                
                if (archivos.Rows.Count < 2)
                {
                    throw new InvalidOperationException("El archivo de backup no contiene la estructura esperada.");
                }

                string nombreLogicoData = archivos.Rows[0]["LogicalName"].ToString();
                string nombreLogicoLog = archivos.Rows[1]["LogicalName"].ToString();

                // Paso 2: Crear rutas temporales para los archivos de la BD temporal
                string rutaTempData = Path.Combine(Path.GetTempPath(), $"{nombreBDTemporal}.mdf");
                string rutaTempLog = Path.Combine(Path.GetTempPath(), $"{nombreBDTemporal}_log.ldf");

                // Paso 3: Restaurar el backup en la BD temporal
                string comandoRestoreTemp = $@"
                    RESTORE DATABASE [{nombreBDTemporal}]
                    FROM DISK = '{rutaBackup}'
                    WITH 
                        MOVE '{nombreLogicoData}' TO '{rutaTempData}',
                        MOVE '{nombreLogicoLog}' TO '{rutaTempLog}',
                        REPLACE";

                oCnx.EjecutarComandoSQL(comandoRestoreTemp, 10);

                // Paso 4: Verificar si el usuario existe en la BD temporal
                string consultaUsuario = $@"
                    SELECT COUNT(*) 
                    FROM [{nombreBDTemporal}].dbo.Usuarios 
                    WHERE Id = {idUsuario} AND Activo = 1";

                bool usuarioExiste = oCnx.VerificarExistenciaRegistro(consultaUsuario);

                // Paso 5: Limpiar - Eliminar la BD temporal
                try
                {
                    string comandoDropDB = $@"
                        ALTER DATABASE [{nombreBDTemporal}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        DROP DATABASE [{nombreBDTemporal}]";
                    oCnx.EjecutarComandoSQL(comandoDropDB, 2);
                }
                catch
                {
                    // Si no puede eliminar la BD temporal, intentar al menos desconectar
                    try
                    {
                        string comandoDetach = $@"
                            USE master;
                            ALTER DATABASE [{nombreBDTemporal}] SET OFFLINE WITH ROLLBACK IMMEDIATE;
                            EXEC sp_detach_db @dbname = '{nombreBDTemporal}', @skipchecks = 'true'";
                        oCnx.EjecutarComandoSQL(comandoDetach, 2);
                    }
                    catch { }
                }

                // Paso 6: Limpiar archivos físicos temporales
                try
                {
                    if (File.Exists(rutaTempData)) File.Delete(rutaTempData);
                    if (File.Exists(rutaTempLog)) File.Delete(rutaTempLog);
                }
                catch { }

                return usuarioExiste;
            }
            catch (Exception ex)
            {
                // Intentar limpiar la BD temporal en caso de error
                try
                {
                    string comandoDropDB = $@"
                        USE master;
                        IF EXISTS (SELECT 1 FROM sys.databases WHERE name = '{nombreBDTemporal}')
                        BEGIN
                            ALTER DATABASE [{nombreBDTemporal}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                            DROP DATABASE [{nombreBDTemporal}];
                        END";
                    oCnx.EjecutarComandoSQL(comandoDropDB, 2);
                }
                catch { }

                throw new Exception($"Error al verificar usuario en backup: {ex.Message}", ex);
            }
        }
    }
}