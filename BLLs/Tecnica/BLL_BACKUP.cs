using MPPs.Tecnica;
using System;
using System.IO;

namespace BLLs.Tecnica
{
    public class BLL_BACKUP
    {
        private readonly MPP_BACKUP _backupRepository;

        public BLL_BACKUP()
        {
            _backupRepository = new MPP_BACKUP();
        }

        /// <summary>
        /// Crea un backup de la base de datos con validaciones de negocio
        /// </summary>
        /// <param name="nombreBackup">Nombre del backup (sin extensión)</param>
        /// <param name="directorioBackup">Directorio donde guardar el backup</param>
        /// <returns>Ruta completa del archivo creado</returns>
        public string CrearBackup(string nombreBackup, string directorioBackup)
        {
            // Validaciones de negocio
            ValidarNombreBackup(nombreBackup);
            ValidarDirectorioBackup(directorioBackup);

            try
            {
                // Agregar fecha al nombre del archivo (ddmmaaaa)
                string fechaActual = DateTime.Now.ToString("ddMMyyyy");
                string nombreCompleto = $"{nombreBackup}_{fechaActual}";
                string rutaCompleta = Path.Combine(directorioBackup, $"{nombreCompleto}.bak");

                // Verificar si ya existe
                if (File.Exists(rutaCompleta))
                {
                    throw new InvalidOperationException($"Ya existe un backup con el nombre '{nombreCompleto}' en la fecha actual.");
                }

                // Ejecutar backup a través de la MPP
                bool exitoso = _backupRepository.EjecutarBackup(rutaCompleta, nombreCompleto);

                if (!exitoso)
                {
                    throw new InvalidOperationException("El backup no se completó exitosamente.");
                }

                return rutaCompleta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear backup: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Restaura un backup de la base de datos con validaciones de negocio
        /// </summary>
        /// <param name="rutaBackup">Ruta completa del archivo .bak a restaurar</param>
        /// <returns>True si la restauración fue exitosa</returns>
        public bool RestaurarBackup(string rutaBackup)
        {
            // Validaciones de negocio
            ValidarArchivoBackup(rutaBackup);

            try
            {
                // Ejecutar restore a través de la MPP
                return _backupRepository.EjecutarRestore(rutaBackup);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al restaurar backup: {ex.Message}", ex);
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
                return _backupRepository.ObtenerNombreBaseDatos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener información de la base de datos: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifica si un archivo de backup existe y es válido
        /// </summary>
        /// <param name="rutaBackup">Ruta del archivo de backup</param>
        /// <returns>True si el archivo existe y es válido</returns>
        public bool ValidarExistenciaBackup(string rutaBackup)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rutaBackup))
                    return false;

                if (!File.Exists(rutaBackup))
                    return false;

                // Verificar que sea un archivo .bak
                if (!rutaBackup.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                    return false;

                // Verificar que el archivo no esté vacío
                FileInfo fileInfo = new FileInfo(rutaBackup);
                return fileInfo.Length > 0;
            }
            catch
            {
                return false;
            }
        }

        #region Validaciones Privadas

        private void ValidarNombreBackup(string nombreBackup)
        {
            if (string.IsNullOrWhiteSpace(nombreBackup))
            {
                throw new ArgumentException("El nombre del backup no puede estar vacío.");
            }

            if (nombreBackup.Length < 3)
            {
                throw new ArgumentException("El nombre del backup debe tener al menos 3 caracteres.");
            }

            if (nombreBackup.Length > 50)
            {
                throw new ArgumentException("El nombre del backup no puede superar los 50 caracteres.");
            }

            char[] caracteresInvalidos = Path.GetInvalidFileNameChars();
            if (nombreBackup.IndexOfAny(caracteresInvalidos) >= 0)
            {
                throw new ArgumentException("El nombre del backup contiene caracteres no válidos.");
            }
        }

        private void ValidarDirectorioBackup(string directorioBackup)
        {
            if (string.IsNullOrWhiteSpace(directorioBackup))
            {
                throw new ArgumentException("El directorio de backup no puede estar vacío.");
            }

            try
            {
                if (!Directory.Exists(directorioBackup))
                {
                    Directory.CreateDirectory(directorioBackup);
                }

                string archivoTest = Path.Combine(directorioBackup, "test_permissions.tmp");
                File.WriteAllText(archivoTest, "test");
                File.Delete(archivoTest);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"No se puede acceder al directorio de backup: {ex.Message}", ex);
            }
        }

        private void ValidarArchivoBackup(string rutaBackup)
        {
            if (string.IsNullOrWhiteSpace(rutaBackup))
            {
                throw new ArgumentException("La ruta del archivo de backup no puede estar vacía.");
            }

            if (!File.Exists(rutaBackup))
            {
                throw new FileNotFoundException($"El archivo de backup no existe: {rutaBackup}");
            }

            if (!rutaBackup.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("El archivo debe tener extensión .bak");
            }

            FileInfo fileInfo = new FileInfo(rutaBackup);
            if (fileInfo.Length == 0)
            {
                throw new InvalidOperationException("El archivo de backup está vacío o corrupto.");
            }

            try
            {
                using (FileStream fs = File.OpenRead(rutaBackup))
                {

                }
            }
            catch (IOException ex)
            {
                throw new InvalidOperationException($"El archivo de backup está en uso: {ex.Message}", ex);
            }
        }

        #endregion
    }
}