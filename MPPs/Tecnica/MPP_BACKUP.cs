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
    }
} 