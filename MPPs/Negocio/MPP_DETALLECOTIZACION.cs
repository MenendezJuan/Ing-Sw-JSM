using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Compras;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs.Negocio
{
    public class MPP_DETALLECOTIZACION : IRepositorio<DetalleCotizacion>
    {
        private readonly Conexion oCnx;
        private readonly MPP_PRODUCTO productoRepositorio;

        public MPP_DETALLECOTIZACION()
        {
            oCnx = Conexion.Instance;
            productoRepositorio = new MPP_PRODUCTO();
        }

        public void Insertar(DetalleCotizacion detalleCotizacion)
        {
            var parametros = new Hashtable
            {
                { "@CotizacionId", detalleCotizacion.CotizacionId },
                { "@ProductoId", detalleCotizacion.oProducto.Id },
                { "@Cantidad", detalleCotizacion.Cantidad },
                { "@Fecha", detalleCotizacion.Fecha }
            };

            oCnx.Guardar("InsertarDetalleCotizacion", parametros);
        }

        public void Actualizar(DetalleCotizacion detalleCotizacion)
        {
            var parametros = new Hashtable
            {
                { "@Id", detalleCotizacion.Id },
                { "@CotizacionId", detalleCotizacion.CotizacionId },
                { "@ProductoId", detalleCotizacion.oProducto.Id },
                { "@Cantidad", detalleCotizacion.Cantidad },
                { "@Fecha", detalleCotizacion.Fecha }
            };

            oCnx.Guardar("ActualizarDetalleCotizacion", parametros);
        }

        public void Eliminar(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            oCnx.Guardar("EliminarDetalleCotizacion", parametros);
        }

        public DetalleCotizacion ObtenerPorId(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            DataTable dt = oCnx.Leer("ObtenerDetalleCotizacionPorId", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]);
        }

        public List<DetalleCotizacion> ObtenerTodos()
        {
            DataTable dt = oCnx.Leer("ObtenerTodosDetallesCotizacion", null);
            List<DetalleCotizacion> detalles = new List<DetalleCotizacion>();
            foreach (DataRow row in dt.Rows)
            {
                detalles.Add(Map(row));
            }
            return detalles;
        }

        public List<DetalleCotizacion> ObtenerPorCotizacionId(int cotizacionId)
        {
            var parametros = new Hashtable
            {
                { "@CotizacionId", cotizacionId }
            };

            DataTable dt = oCnx.Leer("ObtenerDetallesCotizacionPorCotizacionId", parametros);
            List<DetalleCotizacion> detalles = new List<DetalleCotizacion>();
            foreach (DataRow row in dt.Rows)
            {
                detalles.Add(Map(row));
            }
            return detalles;
        }

        private DetalleCotizacion Map(DataRow row)
        {
            Producto producto = productoRepositorio.ObtenerPorId(Convert.ToInt32(row["ProductoId"]));
            DetalleCotizacion detalleCotizacion = new DetalleCotizacion
            {
                Id = Convert.ToInt32(row["Id"]),
                CotizacionId = Convert.ToInt32(row["CotizacionId"]),
                oProducto = producto,
                Cantidad = Convert.ToDecimal(row["Cantidad"]),
                Fecha = Convert.ToDateTime(row["Fecha"])
            };
            return detalleCotizacion;
        }
    }
}
