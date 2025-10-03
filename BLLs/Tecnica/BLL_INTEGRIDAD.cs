using BEs;
using MPPs;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLLs
{
    /// <summary>
    /// BLL para la gestión de integridad de datos (orquesta MPP y Seguridad)
    /// </summary>
    public class BLL_INTEGRIDAD
    {
        private readonly MPP_INTEGRIDAD _mppIntegridad;

        public BLL_INTEGRIDAD()
        {
            _mppIntegridad = new MPP_INTEGRIDAD();
        }

        /// <summary>
        /// Verifica la integridad completa de la base de datos
        /// </summary>
        /// <param name="inconsistencias">Lista de inconsistencias encontradas</param>
        /// <returns>True si la integridad es correcta</returns>
        public bool VerificarIntegridadBaseDatos(out List<InconsistenciaIntegridad> inconsistencias)
        {
            inconsistencias = new List<InconsistenciaIntegridad>();

            try
            {

                VerificarEntidades("Usuario", inconsistencias);
                VerificarEntidades("Producto", inconsistencias);
                VerificarEntidades("Venta", inconsistencias);
                // VerificarDigitosVerticales(inconsistencias); // DVV deshabilitado


                return inconsistencias.Count == 0;
            }
            catch (Exception ex)
            {
                // En caso de error crítico, agregar como inconsistencia
                inconsistencias.Add(new InconsistenciaIntegridad
                {
                    TipoEntidad = "Sistema",
                    EntidadId = 0,
                    Descripcion = $"Error crítico durante verificación: {ex.Message}",
                    DVEsperado = "-",
                    DVActual = "-",
                    TipoError = "Error Crítico"
                });
                return false;
            }
        }

        /// <summary>
        /// Verifica la integridad de todas las entidades de un tipo específico
        /// </summary>
        private void VerificarEntidades(string tipoEntidad, List<InconsistenciaIntegridad> inconsistencias)
        {
            try
            {
                DataTable tabla = _mppIntegridad.ObtenerEntidadesPorTipo(tipoEntidad);

                if (tabla != null && tabla.Rows.Count > 0)
                {
                    foreach (DataRow row in tabla.Rows)
                    {
                        int id = Convert.ToInt32(row["Id"]);
                        string dvAlmacenado = row["DigitoVerificador"]?.ToString() ?? string.Empty;

                        string dvEsperado = CalcularDVHUsandoAlgoritmoLogin(tipoEntidad, id);

                        // Si no se puede calcular, saltar esta entidad
                        if (string.IsNullOrEmpty(dvEsperado))
                            continue;

                        if (!string.Equals(dvAlmacenado, dvEsperado, StringComparison.OrdinalIgnoreCase))
                        {
                            string descripcion = SeguridadExtendida.ObtenerDescripcionEntidad(tipoEntidad, row);

                            inconsistencias.Add(new InconsistenciaIntegridad
                            {
                                TipoEntidad = tipoEntidad,
                                EntidadId = id,
                                Descripcion = descripcion,
                                DVEsperado = dvEsperado,
                                DVActual = dvAlmacenado,
                                TipoError = "DV Horizontal"
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar entidades de tipo {tipoEntidad}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Calcula DVH usando exactamente el mismo algoritmo que funciona para el login
        /// </summary>
        private string CalcularDVHUsandoAlgoritmoLogin(string tipoEntidad, int entidadId)
        {
            try
            {
                switch (tipoEntidad.ToUpper())
                {
                    case "USUARIO":
                    case "USUARIOS":
                        var bllUsuario = new BLL_USUARIO();
                        var usuarios = bllUsuario.Listar();
                        var usuario = usuarios.FirstOrDefault(u => u.Id == entidadId);

                        if (usuario != null)
                        {
                            string dvhCalculado = Seguridad.Seguridad.CalcularDigitoVerificadorHorizontal(usuario);
                            System.Diagnostics.Debug.WriteLine($"DVH para Usuario ID {entidadId}: {dvhCalculado}");
                            return dvhCalculado;
                        }
                        break;

                    case "PRODUCTO":
                    case "PRODUCTOS":
                        var bllProducto = new BLLs.Negocio.BLL_PRODUCTO();
                        var productos = bllProducto.ObtenerTodos();
                        var producto = productos.FirstOrDefault(p => p.Id == entidadId);

                        if (producto != null)
                        {
                            return Seguridad.Seguridad.CalcularDigitoVerificadorHorizontal(producto);
                        }
                        break;

                    case "VENTA":
                    case "VENTAS":
                        DataRow filaVenta = _mppIntegridad.ObtenerDetalleEntidad("Venta", entidadId);
                        if (filaVenta != null)
                        {
                            return SeguridadExtendida.CalcularDVHorizontal("Venta", filaVenta);
                        }
                        break;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al calcular DVH con algoritmo login: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Calcula DVV usando exactamente la misma lógica que el script SQL
        /// </summary>
        private string CalcularDVVConMismaLogicaQueSQL(string tipoEntidad)
        {
            try
            {
                string consulta = string.Empty;

                switch (tipoEntidad.ToUpper())
                {
                    case "USUARIOS":
                        consulta = "SELECT COALESCE(STRING_AGG(ISNULL(DigitoVerificador, ''), '') WITHIN GROUP (ORDER BY Id), '') FROM Usuarios WHERE Activo = 1";
                        break;
                    case "PRODUCTO":
                    case "PRODUCTOS":
                        consulta = "SELECT COALESCE(STRING_AGG(ISNULL(DigitoVerificador, ''), '') WITHIN GROUP (ORDER BY Id), '') FROM Producto WHERE Estado = 1";
                        break;
                    case "VENTA":
                    case "VENTAS":
                        consulta = "SELECT COALESCE(STRING_AGG(ISNULL(DigitoVerificador, ''), '') WITHIN GROUP (ORDER BY Id), '') FROM Venta";
                        break;
                    default:
                        return string.Empty;
                }

                // Ejecutar consulta para obtener concatenación
                DataTable resultado = _mppIntegridad.EjecutarConsultaDirecta(consulta);

                if (resultado != null && resultado.Rows.Count > 0 && resultado.Rows[0][0] != DBNull.Value)
                {
                    string concatenacion = resultado.Rows[0][0].ToString();

                    if (!string.IsNullOrEmpty(concatenacion))
                    {
                        return Seguridad.Seguridad.Hash(concatenacion);
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al calcular DVV con lógica SQL: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Verifica los dígitos verificadores verticales
        /// </summary>
        private void VerificarDigitosVerticales(List<InconsistenciaIntegridad> inconsistencias)
        {
            try
            {
                DataTable dvVerticales = _mppIntegridad.ObtenerDigitosVerticales();

                if (dvVerticales != null && dvVerticales.Rows.Count > 0)
                {
                    foreach (DataRow dvRow in dvVerticales.Rows)
                    {
                        string tipoEntidad = dvRow["TipoEntidad"].ToString();
                        string columna = dvRow["Columna"].ToString();
                        string dvAlmacenado = dvRow["DigitoVerificador"]?.ToString() ?? string.Empty;

                        DataTable tablaEntidad = _mppIntegridad.ObtenerEntidadesPorTipo(tipoEntidad);

                        if (tablaEntidad != null && tablaEntidad.Columns.Contains(columna))
                        {
                            string dvEsperado = CalcularDVVConMismaLogicaQueSQL(tipoEntidad);

                            if (!string.Equals(dvAlmacenado, dvEsperado, StringComparison.OrdinalIgnoreCase))
                            {
                                inconsistencias.Add(new InconsistenciaIntegridad
                                {
                                    TipoEntidad = tipoEntidad,
                                    EntidadId = 0,
                                    Descripcion = $"Columna: {columna}",
                                    DVEsperado = dvEsperado,
                                    DVActual = dvAlmacenado,
                                    TipoError = "DV Vertical",
                                    ColumnaVertical = columna
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar dígitos verticales: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Restaura un dígito verificador específico
        /// </summary>
        public bool RestaurarDigitoVerificador(InconsistenciaIntegridad inconsistencia)
        {
            try
            {
                if (inconsistencia.TipoError == "DV Horizontal")
                {
                    return _mppIntegridad.ActualizarDVHDirecto(
                        inconsistencia.TipoEntidad, 
                        inconsistencia.EntidadId, 
                        inconsistencia.DVEsperado
                    );
                }
                else if (inconsistencia.TipoError == "DV Vertical")
                {
                    System.Diagnostics.Debug.WriteLine($"DVV inconsistente para {inconsistencia.TipoEntidad} - No se corrige automáticamente");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al restaurar dígito verificador: {ex.Message}", ex);
            }
        }


        /// <summary>
        /// Restaura todos los dígitos verificadores de una lista de inconsistencias
        /// </summary>
        public (int exitosos, int fallidos) RestaurarTodosDigitosVerificadores(List<InconsistenciaIntegridad> inconsistencias)
        {
            int exitosos = 0;
            int fallidos = 0;

            foreach (var inconsistencia in inconsistencias)
            {
                try
                {
                    if (RestaurarDigitoVerificador(inconsistencia))
                    {
                        exitosos++;
                    }
                    else
                    {
                        fallidos++;
                    }
                }
                catch
                {
                    fallidos++;
                }
            }

            return (exitosos, fallidos);
        }


        /// <summary>
        /// Obtiene el detalle formateado de una entidad para mostrar en la UI
        /// </summary>
        public string ObtenerDetalleEntidadFormateado(InconsistenciaIntegridad inconsistencia)
        {
            try
            {
                if (inconsistencia.TipoError == "DV Vertical")
                {
                    return $"Tipo: {inconsistencia.TipoEntidad}\n" +
                           $"Columna: {inconsistencia.ColumnaVertical}\n" +
                           $"Tipo Error: {inconsistencia.TipoError}\n\n" +
                           $"DV Esperado: {inconsistencia.DVEsperado}\n" +
                           $"DV Actual: {inconsistencia.DVActual}\n\n" +
                           $"Este es un error de integridad vertical que afecta\n" +
                           $"a toda la columna '{inconsistencia.ColumnaVertical}' de la tabla {inconsistencia.TipoEntidad}.";
                }
                else
                {
                    var detalle = _mppIntegridad.ObtenerDetalleEntidad(inconsistencia.TipoEntidad, inconsistencia.EntidadId);

                    if (detalle != null)
                    {
                        string info = $"Tipo: {inconsistencia.TipoEntidad}\n" +
                                     $"ID: {inconsistencia.EntidadId}\n" +
                                     $"Tipo Error: {inconsistencia.TipoError}\n\n" +
                                     $"Descripción: {inconsistencia.Descripcion}\n\n" +
                                     $"DV Esperado: {inconsistencia.DVEsperado}\n" +
                                     $"DV Actual: {inconsistencia.DVActual}\n\n" +
                                     $"Datos de la entidad:\n";

                        // Agregar información de las columnas según el tipo
                        switch (inconsistencia.TipoEntidad)
                        {
                            case "Usuario":
                                info += $"Email: {detalle["Email"]}\n";
                                info += $"Activo: {detalle["Activo"]}\n";
                                break;
                            case "Producto":
                                info += $"Código: {detalle["Codigo"]}\n";
                                info += $"Nombre: {detalle["Nombre"]}\n";
                                info += $"Precio: {detalle["PrecioVenta"]}\n";
                                info += $"Stock: {detalle["Stock"]}\n";
                                info += $"Estado: {detalle["Estado"]}\n";
                                break;
                            case "Venta":
                                info += $"Monto Total: {Convert.ToDecimal(detalle["MontoTotal"]):C}\n";
                                info += $"Estado: {detalle["EstadoVenta"]}\n";
                                info += $"Fecha: {Convert.ToDateTime(detalle["Fecha"]):dd/MM/yyyy}\n";
                                break;
                        }

                        return info;
                    }
                }

                return inconsistencia.ToString();
            }
            catch (Exception ex)
            {
                return $"Error al obtener detalle: {ex.Message}\n\n{inconsistencia.ToString()}";
            }
        }
    }
}

