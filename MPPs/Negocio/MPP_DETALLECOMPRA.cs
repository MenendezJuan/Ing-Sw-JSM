using BEs.Clases.Negocio;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs.Negocio
{
    public class MPP_DETALLECOMPRA : IRepositorio<DetalleCompra>
    {
        public MPP_DETALLECOMPRA()
        {
            oCnx = Conexion.Instance;
        }

        private Conexion oCnx;
        private readonly MPP_PRODUCTO productoRepositorio = new MPP_PRODUCTO();

        public void Insertar(DetalleCompra detalleCompra)
        {
            detalleCompra.SubTotal = detalleCompra.Cantidad * detalleCompra.oProducto.PrecioCompra;

            var parametros = new Hashtable
            {
                { "@ProductoId", detalleCompra.oProducto.Id },
                { "@Cantidad", detalleCompra.Cantidad },
                { "@CompraId", detalleCompra.oCompra.Id },
                { "@Precio", detalleCompra.Precio },
                { "@SubTotal", detalleCompra.SubTotal },
                { "@Fecha", detalleCompra.Fecha }
            };

            oCnx.Guardar("InsertarDetalleCompra", parametros);
        }

        public void Actualizar(DetalleCompra detalleCompra)
        {
            detalleCompra.SubTotal = detalleCompra.Cantidad * detalleCompra.oProducto.PrecioCompra;

            var parametros = new Hashtable
            {
                { "@Id", detalleCompra.Id },
                { "@ProductoId", detalleCompra.oProducto.Id },
                { "@Cantidad", detalleCompra.Cantidad },
                { "@Precio", detalleCompra.Precio },
                { "@SubTotal", detalleCompra.SubTotal },
                { "@Fecha", detalleCompra.Fecha }
            };

            oCnx.Guardar("ActualizarDetalleCompra", parametros);
        }

        public void Eliminar(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            oCnx.Guardar("EliminarDetalleCompra", parametros);
        }

        public DetalleCompra ObtenerPorId(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            DataTable dt = oCnx.Leer("ObtenerDetalleCompraPorId", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]);
        }

        public List<DetalleCompra> ObtenerTodos()
        {
            DataTable dt = oCnx.Leer("ObtenerTodosDetallesCompra", null);
            List<DetalleCompra> detalles = new List<DetalleCompra>();
            foreach (DataRow row in dt.Rows)
            {
                detalles.Add(Map(row));
            }
            return detalles;
        }

        public List<DetalleCompra> ObtenerPorCompraId(int compraId)
        {
            var parametros = new Hashtable
            {
                { "@CompraId", compraId }
            };

            DataTable dt = oCnx.Leer("ObtenerDetallesCompraPorCompraId", parametros);
            List<DetalleCompra> detalles = new List<DetalleCompra>();
            foreach (DataRow row in dt.Rows)
            {
                detalles.Add(Map(row));
            }
            return detalles;
        }

        private DetalleCompra Map(DataRow row)
        {
            Producto producto = productoRepositorio.ObtenerPorId(Convert.ToInt32(row["ProductoId"]));
            DetalleCompra detalleCompra = new DetalleCompra
            {
                Id = Convert.ToInt32(row["Id"]),
                oProducto = producto,
                Cantidad = Convert.ToDecimal(row["Cantidad"]),
                CompraId = Convert.ToInt32(row["CompraId"]),
                Precio = Convert.ToDecimal(row["Precio"]),
                SubTotal = Convert.ToDecimal(row["SubTotal"]),
                Fecha = Convert.ToDateTime(row["Fecha"])
            };
            return detalleCompra;
        }
    }
}
