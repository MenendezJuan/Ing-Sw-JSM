using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Ventas;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs.Negocio
{
    public class MPP_DETALLEVENTA : IRepositorio<DetalleVenta>
    {
        private Conexion oCnx;
        private readonly MPP_PRODUCTO productoRepositorio;

        public MPP_DETALLEVENTA()
        {
            oCnx = Conexion.Instance;
            productoRepositorio = new MPP_PRODUCTO();
        }

        public void Insertar(DetalleVenta detalleVenta)
        {
            var parametros = new Hashtable
            {
                { "@VentaId", detalleVenta.VentaId },
                { "@ProductoId", detalleVenta.oProducto.Id },
                { "@Cantidad", detalleVenta.Cantidad },
                { "@Precio", detalleVenta.Precio },
                { "@SubTotal", detalleVenta.SubTotal },
                { "@Fecha", detalleVenta.Fecha }
            };

            oCnx.Guardar("InsertarDetalleVenta", parametros);
        }

        public void Actualizar(DetalleVenta detalleVenta)
        {
            var parametros = new Hashtable
            {
                { "@Id", detalleVenta.Id },
                { "@ProductoId", detalleVenta.oProducto.Id },
                { "@Cantidad", detalleVenta.Cantidad },
                { "@Precio", detalleVenta.Precio },
                { "@SubTotal", detalleVenta.SubTotal },
                { "@Fecha", detalleVenta.Fecha }
            };

            oCnx.Guardar("ActualizarDetalleVenta", parametros);
        }

        public void Eliminar(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            oCnx.Guardar("EliminarDetalleVenta", parametros);
        }

        public DetalleVenta ObtenerPorId(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            DataTable dt = oCnx.Leer("ObtenerDetalleVentaPorId", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]);
        }

        public List<DetalleVenta> ObtenerTodos()
        {
            DataTable dt = oCnx.Leer("ObtenerTodosDetallesVenta", null);
            List<DetalleVenta> detalles = new List<DetalleVenta>();

            foreach (DataRow row in dt.Rows)
            {
                detalles.Add(Map(row));
            }
            return detalles;
        }

        public List<DetalleVenta> ObtenerPorVentaId(int ventaId)
        {
            var parametros = new Hashtable
            {
                { "@VentaId", ventaId }
            };

            DataTable dt = oCnx.Leer("ObtenerDetallesVentaPorVentaId", parametros);
            List<DetalleVenta> detalles = new List<DetalleVenta>();

            foreach (DataRow row in dt.Rows)
            {
                detalles.Add(Map(row));
            }
            return detalles;
        }

        private DetalleVenta Map(DataRow row)
        {
            DetalleVenta detalleVenta = new DetalleVenta
            {
                Id = Convert.ToInt32(row["Id"]),
                VentaId = Convert.ToInt32(row["VentaId"]),
                ProductoId = Convert.ToInt32(row["ProductoId"]),
                Precio = Convert.ToDecimal(row["Precio"]),
                Cantidad = Convert.ToDecimal(row["Cantidad"]),
                SubTotal = Convert.ToDecimal(row["SubTotal"]),
                Fecha = Convert.ToDateTime(row["Fecha"])
            };

            // Cargar el producto relacionado
            detalleVenta.oProducto = productoRepositorio.ObtenerPorId(detalleVenta.ProductoId);

            return detalleVenta;
        }
    }
} 