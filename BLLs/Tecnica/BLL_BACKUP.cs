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
        /// IMPORTANTE: Verifica ANTES si el usuario actual existe en el backup para prevenir inconsistencias
        /// </summary>
        /// <param name="rutaBackup">Ruta completa del archivo .bak a restaurar</param>
        /// <param name="idUsuarioActual">ID del usuario actualmente logueado (0 si no hay usuario)</param>
        /// <returns>True si la restauración fue exitosa</returns>
        /// <exception cref="UsuarioNoExisteException">Se lanza si el usuario actual NO existe en el backup (ANTES de restaurar)</exception>
        public bool RestaurarBackup(string rutaBackup, int idUsuarioActual = 0)
        {
            // Validaciones de negocio
            ValidarArchivoBackup(rutaBackup);

            try
            {
                if (idUsuarioActual > 0)
                {
                    bool usuarioExisteActualmente = _backupRepository.VerificarExistenciaUsuario(idUsuarioActual);

                    if (!usuarioExisteActualmente)
                    {
                        throw new UsuarioNoExisteException(
                            $"El usuario actual (ID: {idUsuarioActual}) no existe en la base de datos.\n\n" +
                            $"No se puede proceder con la restauración."
                        );
                    }

                    System.Diagnostics.Debug.WriteLine($"⚠ Restaurando backup sin verificar existencia de usuario en backup");
                }

                // Proceder con el restore
                bool exitoso = _backupRepository.EjecutarRestore(rutaBackup);

                if (!exitoso)
                {
                    throw new InvalidOperationException("El restore no se completó exitosamente.");
                }

                if (idUsuarioActual > 0)
                {
                    bool usuarioExisteDespuesDeRestore = _backupRepository.VerificarExistenciaUsuario(idUsuarioActual);

                    if (!usuarioExisteDespuesDeRestore)
                    {
                        throw new UsuarioNoExisteException(
                            $"⚠️ ATENCIÓN: Restore completado exitosamente, pero el usuario actual (ID: {idUsuarioActual}) no existe en los datos restaurados.\n\n" +
                            $"Esto indica que el usuario fue creado después de que se generó este backup.\n\n" +
                            $"La sesión se cerrará automáticamente por seguridad.\n\n" +
                            $"Para continuar, inicie sesión con un usuario que exista en los datos restaurados."
                        );
                    }
                }

                return true;
            }
            catch (UsuarioNoExisteException)
            {
                // Re-lanzar sin envolver
                throw;
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

        /// <summary>
        /// Obtiene información detallada de un archivo de backup
        /// </summary>
        /// <param name="rutaBackup">Ruta del archivo de backup</param>
        /// <returns>Información del backup (tamaño, fecha, checksum)</returns>
        public InfoBackup ObtenerInformacionBackup(string rutaBackup)
        {
            try
            {
                if (!File.Exists(rutaBackup))
                    throw new FileNotFoundException("El archivo de backup no existe", rutaBackup);

                FileInfo fileInfo = new FileInfo(rutaBackup);

                return new InfoBackup
                {
                    NombreArchivo = fileInfo.Name,
                    RutaCompleta = rutaBackup,
                    TamañoBytes = fileInfo.Length,
                    TamañoFormateado = FormatearTamaño(fileInfo.Length),
                    FechaCreacion = fileInfo.CreationTime,
                    FechaModificacion = fileInfo.LastWriteTime,
                    Checksum = CalcularChecksumMD5(rutaBackup)
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener información del backup: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Calcula el checksum MD5 de un archivo de backup
        /// </summary>
        private string CalcularChecksumMD5(string rutaArchivo)
        {
            try
            {
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    using (var stream = File.OpenRead(rutaArchivo))
                    {
                        byte[] hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }
            }
            catch
            {
                return "N/A";
            }
        }

        /// <summary>
        /// Formatea un tamaño en bytes a una representación legible (KB, MB, GB)
        /// </summary>
        private string FormatearTamaño(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB" };
            int suffixIndex = 0;
            double size = bytes;

            while (size >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                size /= 1024;
                suffixIndex++;
            }

            return $"{size:N2} {suffixes[suffixIndex]}";
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

        #endregion Validaciones Privadas
    }

    /// <summary>
    /// Excepción personalizada que se lanza cuando el usuario actual no existe en el backup restaurado
    /// </summary>
    public class UsuarioNoExisteException : Exception
    {
        public UsuarioNoExisteException(string message) : base(message)
        {
        }

        public UsuarioNoExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Clase que contiene información detallada de un archivo de backup
    /// </summary>
    public class InfoBackup
    {
        public string NombreArchivo { get; set; }
        public string RutaCompleta { get; set; }
        public long TamañoBytes { get; set; }
        public string TamañoFormateado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Checksum { get; set; }

        public override string ToString()
        {
            return $"{NombreArchivo} ({TamañoFormateado})";
        }
    }
}