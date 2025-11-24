using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using Servicios;
using System.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MPPs
{
    public class MPP_DEVOLUCION
    {
        public MPP_DEVOLUCION()
        {
            oCnx = Conexion.Instance;
        }

        private Conexion oCnx;
        private readonly MPP_VENTA ventaRepositorio = new MPP_VENTA();
        private readonly MPPs.Negocio.MPP_PRODUCTO productoRepositorio = new MPPs.Negocio.MPP_PRODUCTO();
        private readonly MPP_USUARIO usuarioRepositorio = new MPP_USUARIO();

        public int Crear(Devolucion devolucion, List<DevolucionDetalle> detalles)
        {
            try
            {
                // Insertar cabecera
                var parametrosCabecera = new Hashtable
                {
                    { "@VentaId", devolucion.VentaId },
                    { "@FechaSolicitud", devolucion.FechaSolicitud },
                    { "@Estado", (int)devolucion.Estado },
                    { "@Motivo", devolucion.Motivo },
                    { "@ObservacionesGerente", devolucion.ObservacionesGerente },
                    { "@FechaDecision", devolucion.FechaDecision },
                    { "@UsuarioGerenteId", devolucion.UsuarioGerenteId },
                    { "@ObservacionesDeposito", devolucion.ObservacionesDeposito },
                    { "@FechaProcesamiento", devolucion.FechaProcesamiento },
                    { "@UsuarioDepositoId", devolucion.UsuarioDepositoId },
                    { "@DigitoVerificador", devolucion.DV }
                };

                int devolucionId = Convert.ToInt32(oCnx.GuardarConRetorno("CrearDevolucion", parametrosCabecera));
                devolucion.Id = devolucionId;

                // Insertar detalles
                foreach (var detalle in detalles)
                {
                    var parametrosDetalle = new Hashtable
                    {
                        { "@DevolucionId", devolucionId },
                        { "@ProductoId", detalle.ProductoId },
                        { "@Cantidad", detalle.Cantidad },
                        { "@DigitoVerificador", detalle.DV }
                    };

                    oCnx.Guardar("CrearDevolucionDetalle", parametrosDetalle);
                }

                return devolucionId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear devolución: {ex.Message}", ex);
            }
        }

        public void ActualizarEstadoEvaluacion(int id, EstadoDevolucion estado, string observacionesGerente, int usuarioGerenteId, DateTime fechaDecision)
        {
            var parametros = new Hashtable
            {
                { "@Id", id },
                { "@Estado", (int)estado },
                { "@ObservacionesGerente", (object)(observacionesGerente ?? string.Empty) },
                { "@UsuarioGerenteId", usuarioGerenteId },
                { "@FechaDecision", fechaDecision }
            };

            oCnx.Guardar("ActualizarDevolucionEvaluacion", parametros);
        }

        public void Procesar(int id, string observacionesDeposito, int usuarioDepositoId, DateTime fechaProcesamiento)
        {
            var parametros = new Hashtable
            {
                { "@Id", id },
                { "@ObservacionesDeposito", observacionesDeposito },
                { "@UsuarioDepositoId", usuarioDepositoId },
                { "@FechaProcesamiento", fechaProcesamiento }
            };

            oCnx.Guardar("ProcesarDevolucion", parametros);
        }

        public List<Devolucion> Listar(int? clienteId = null, int? ventaId = null, EstadoDevolucion? estado = null)
        {
            var parametros = new Hashtable();

            if (clienteId.HasValue)
                parametros.Add("@ClienteId", clienteId.Value);
            if (ventaId.HasValue)
                parametros.Add("@VentaId", ventaId.Value);
            if (estado.HasValue)
                parametros.Add("@Estado", (int)estado.Value);

            DataTable dt = oCnx.Leer("ListarDevoluciones", parametros);
            List<Devolucion> devoluciones = new List<Devolucion>();

            foreach (DataRow row in dt.Rows)
            {
                devoluciones.Add(Map(row));
            }

            return devoluciones;
        }

        public Devolucion ObtenerPorId(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            DataTable dt = oCnx.Leer("ObtenerDevolucionPorId", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]);
        }

        public decimal ObtenerCantidadDevueltaAcumulada(int ventaId, int productoId)
        {
            var parametros = new Hashtable
            {
                { "@VentaId", ventaId },
                { "@ProductoId", productoId }
            };

            DataTable dt = oCnx.Leer("ObtenerCantidadDevueltaAcumulada", parametros);

            if (dt.Rows.Count > 0 && dt.Rows[0]["TotalDevuelto"] != DBNull.Value)
            {
                return Convert.ToDecimal(dt.Rows[0]["TotalDevuelto"]);
            }

            return 0;
        }

        public List<DevolucionDetalle> ObtenerDetallesPorDevolucionId(int devolucionId)
        {
            var parametros = new Hashtable
            {
                { "@DevolucionId", devolucionId }
            };

            DataTable dt = oCnx.Leer("ObtenerDetallesDevolucionPorId", parametros);
            List<DevolucionDetalle> detalles = new List<DevolucionDetalle>();

            foreach (DataRow row in dt.Rows)
            {
                detalles.Add(MapDetalle(row));
            }

            return detalles;
        }

        private Devolucion Map(DataRow row)
        {
            Devolucion devolucion = new Devolucion
            {
                Id = Convert.ToInt32(row["Id"]),
                VentaId = Convert.ToInt32(row["VentaId"]),
                FechaSolicitud = Convert.ToDateTime(row["FechaSolicitud"]),
                Estado = (EstadoDevolucion)Convert.ToInt32(row["Estado"]),
                Motivo = row["Motivo"]?.ToString(),
                ObservacionesGerente = row["ObservacionesGerente"]?.ToString(),
                FechaDecision = row["FechaDecision"] != DBNull.Value ? Convert.ToDateTime(row["FechaDecision"]) : (DateTime?)null,
                UsuarioGerenteId = row["UsuarioGerenteId"] != DBNull.Value ? Convert.ToInt32(row["UsuarioGerenteId"]) : (int?)null,
                ObservacionesDeposito = row["ObservacionesDeposito"]?.ToString(),
                FechaProcesamiento = row["FechaProcesamiento"] != DBNull.Value ? Convert.ToDateTime(row["FechaProcesamiento"]) : (DateTime?)null,
                UsuarioDepositoId = row["UsuarioDepositoId"] != DBNull.Value ? Convert.ToInt32(row["UsuarioDepositoId"]) : (int?)null,
                DV = row["DigitoVerificador"]?.ToString()
            };

            // Cargar objetos relacionados
            try
            {
                devolucion.oVenta = ventaRepositorio.ObtenerPorId(devolucion.VentaId);
            }
            catch (Exception)
            {
                devolucion.oVenta = null;
            }

            if (devolucion.UsuarioGerenteId.HasValue)
            {
                try
                {
                    devolucion.oUsuarioGerente = usuarioRepositorio.ObtenerPorId(devolucion.UsuarioGerenteId.Value);
                }
                catch (Exception)
                {
                    devolucion.oUsuarioGerente = null;
                }
            }

            if (devolucion.UsuarioDepositoId.HasValue)
            {
                try
                {
                    devolucion.oUsuarioDeposito = usuarioRepositorio.ObtenerPorId(devolucion.UsuarioDepositoId.Value);
                }
                catch (Exception)
                {
                    devolucion.oUsuarioDeposito = null;
                }
            }

            // Cargar detalles
            devolucion.oDetalles = ObtenerDetallesPorDevolucionId(devolucion.Id);

            return devolucion;
        }

        private DevolucionDetalle MapDetalle(DataRow row)
        {
            DevolucionDetalle detalle = new DevolucionDetalle
            {
                Id = Convert.ToInt32(row["Id"]),
                DevolucionId = Convert.ToInt32(row["DevolucionId"]),
                ProductoId = Convert.ToInt32(row["ProductoId"]),
                Cantidad = Convert.ToDecimal(row["Cantidad"]),
                DV = row["DigitoVerificador"]?.ToString()
            };

            // Cargar producto relacionado
            try
            {
                detalle.oProducto = productoRepositorio.ObtenerPorId(detalle.ProductoId);
            }
            catch (Exception)
            {
                detalle.oProducto = null;
            }

            return detalle;
        }
    }
}