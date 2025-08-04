using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BLLs.Tecnica
{
    public static class BLL_VALIDACION
    {
        #region Validaciones de CUIT

        /// <summary>
        /// Valida el formato y dígito verificador de un CUIT argentino
        /// </summary>
        /// <param name="cuit">CUIT a validar (puede contener guiones)</param>
        /// <returns>True si el CUIT es válido</returns>
        public static bool ValidarCUIT(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return false;

            // Limpiar formato
            string cuitLimpio = LimpiarCUIT(cuit);

            // Validar longitud
            if (cuitLimpio.Length != 11)
                return false;

            // Validar que sean solo números
            if (!cuitLimpio.All(char.IsDigit))
                return false;

            // Validar dígito verificador
            return ValidarDigitoVerificadorCUIT(cuitLimpio);
        }

        /// <summary>
        /// Limpia un CUIT eliminando guiones y espacios
        /// </summary>
        /// <param name="cuit">CUIT con formato</param>
        /// <returns>CUIT sin formato</returns>
        public static string LimpiarCUIT(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return string.Empty;

            return cuit.Replace("-", "").Replace(" ", "").Trim();
        }

        /// <summary>
        /// Formatea un CUIT agregando guiones
        /// </summary>
        /// <param name="cuit">CUIT sin formato</param>
        /// <returns>CUIT formateado XX-XXXXXXXX-X</returns>
        public static string FormatearCUIT(string cuit)
        {
            string cuitLimpio = LimpiarCUIT(cuit);
            
            if (cuitLimpio.Length != 11)
                return cuit; // Devolver original si no tiene 11 dígitos

            return $"{cuitLimpio.Substring(0, 2)}-{cuitLimpio.Substring(2, 8)}-{cuitLimpio.Substring(10, 1)}";
        }

        /// <summary>
        /// Valida el dígito verificador de un CUIT argentino
        /// </summary>
        /// <param name="cuitLimpio">CUIT de 11 dígitos sin formato</param>
        /// <returns>True si el dígito verificador es correcto</returns>
        private static bool ValidarDigitoVerificadorCUIT(string cuitLimpio)
        {
            try
            {
                // Factores de multiplicación para el cálculo del dígito verificador
                int[] factores = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                
                int suma = 0;
                for (int i = 0; i < 10; i++)
                {
                    suma += int.Parse(cuitLimpio[i].ToString()) * factores[i];
                }

                int resto = suma % 11;
                int digitoVerificador = resto < 2 ? resto : 11 - resto;
                
                return digitoVerificador == int.Parse(cuitLimpio[10].ToString());
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Validaciones de Email

        /// <summary>
        /// Valida el formato de un email
        /// </summary>
        /// <param name="email">Email a validar</param>
        /// <returns>True si el formato es válido</returns>
        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Patrón básico para email
                string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, patron, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Validaciones de Campos Requeridos

        /// <summary>
        /// Valida que un campo no esté vacío
        /// </summary>
        /// <param name="valor">Valor a validar</param>
        /// <param name="nombreCampo">Nombre del campo para el mensaje de error</param>
        /// <param name="mensajeError">Mensaje de error si falla la validación</param>
        /// <returns>True si el campo es válido</returns>
        public static bool ValidarCampoRequerido(string valor, string nombreCampo, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (string.IsNullOrWhiteSpace(valor))
            {
                mensajeError = $"Por favor, ingrese {nombreCampo}.";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida que un valor numérico sea mayor a cero
        /// </summary>
        /// <param name="valor">Valor a validar</param>
        /// <param name="nombreCampo">Nombre del campo para el mensaje de error</param>
        /// <param name="mensajeError">Mensaje de error si falla la validación</param>
        /// <returns>True si el valor es válido</returns>
        public static bool ValidarValorPositivo(decimal valor, string nombreCampo, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (valor <= 0)
            {
                mensajeError = $"Por favor, ingrese un {nombreCampo} válido (mayor a cero).";
                return false;
            }

            return true;
        }

        #endregion

        #region Validaciones de Teléfono

        /// <summary>
        /// Valida el formato básico de un teléfono argentino
        /// </summary>
        /// <param name="telefono">Teléfono a validar</param>
        /// <returns>True si el formato es válido</returns>
        public static bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            // Limpiar formato
            string telefonoLimpio = telefono.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");

            // Validar que tenga entre 8 y 15 dígitos (incluyendo código de área)
            if (telefonoLimpio.Length < 8 || telefonoLimpio.Length > 15)
                return false;

            // Validar que sean solo números
            return telefonoLimpio.All(char.IsDigit);
        }

        /// <summary>
        /// Formatea un teléfono agregando guiones para mejor legibilidad
        /// </summary>
        /// <param name="telefono">Teléfono sin formato</param>
        /// <returns>Teléfono formateado</returns>
        public static string FormatearTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return telefono;

            string telefonoLimpio = telefono.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
            
            // Formato básico para teléfonos argentinos
            if (telefonoLimpio.Length >= 10)
            {
                // Formato: (011) XXXX-XXXX o similar
                return $"({telefonoLimpio.Substring(0, 3)}) {telefonoLimpio.Substring(3, 4)}-{telefonoLimpio.Substring(7)}";
            }
            else if (telefonoLimpio.Length >= 8)
            {
                // Formato: XXXX-XXXX
                return $"{telefonoLimpio.Substring(0, 4)}-{telefonoLimpio.Substring(4)}";
            }

            return telefono; // Devolver original si no coincide con formatos esperados
        }

        #endregion

        #region Validaciones de Resultados

        /// <summary>
        /// Resultado de una validación con mensaje
        /// </summary>
        public class ResultadoValidacion
        {
            public bool EsValido { get; set; }
            public string MensajeError { get; set; }

            public ResultadoValidacion(bool esValido, string mensajeError = "")
            {
                EsValido = esValido;
                MensajeError = mensajeError;
            }

            public static ResultadoValidacion Exitoso => new ResultadoValidacion(true);
            public static ResultadoValidacion Error(string mensaje) => new ResultadoValidacion(false, mensaje);
        }

        #endregion
    }
}