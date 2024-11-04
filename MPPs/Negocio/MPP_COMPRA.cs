using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Compras.Enums;
using MPPs.Negocio;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MPPs
{
    public class MPP_COMPRA : IRepositorio<Compra>
    {
        public MPP_COMPRA()
        {
            oCnx = Conexion.Instance;
        }
        private Conexion oCnx;

        private readonly MPP_PRODUCTO productoRepositorio = new MPP_PRODUCTO();
        private readonly MPP_DETALLECOMPRA detalleCompraRepositorio = new MPP_DETALLECOMPRA();

        public void Insertar(Compra compra)
        {
            var parametros = new Hashtable
            {
                { "@Comentario", compra.Comentario },
                { "@MontoTotal", compra.MontoTotal },
                { "@Fecha", compra.Fecha },
                { "@TipoPagoEnum", (int)compra.TipoPagoEnum },
                { "@ProveedorId", compra.oProveedor.Id },
                { "@EstadoCompra", (int)compra.EstadoCompraEnum }
            };

            int compraId = Convert.ToInt32(oCnx.GuardarConRetorno("InsertarCompra", parametros));

            // Insertar detalles de la compra
            foreach (var detalle in compra.oDetalleCompra)
            {
                detalle.CompraId = compraId;
                detalleCompraRepositorio.Insertar(detalle);
            }
        }

        public void Actualizar(Compra compra)
        {
            var parametros = new Hashtable
            {
                { "@Id", compra.Id },
                { "@Comentario", compra.Comentario },
                { "@MontoTotal", compra.MontoTotal },
                { "@Fecha", compra.Fecha },
                { "@TipoPagoEnum", (int)compra.TipoPagoEnum },
                { "@ProveedorId", compra.oProveedor.Id },
                { "@EstadoCompra", (int)compra.EstadoCompraEnum }
            };

            oCnx.Guardar("ActualizarCompra", parametros);

            var detallesActuales = detalleCompraRepositorio.ObtenerPorCompraId(compra.Id);

            var detallesAActualizar = compra.oDetalleCompra.Where(d => detallesActuales.Any(da => da.Id == d.Id)).ToList();
            var detallesAEliminar = detallesActuales.Where(da => !compra.oDetalleCompra.Any(d => d.Id == da.Id)).ToList();
            var detallesAAgregar = compra.oDetalleCompra.Where(d => d.Id == 0).ToList();

            foreach (var detalle in detallesAEliminar)
            {
                detalleCompraRepositorio.Eliminar(detalle.Id);
            }

            foreach (var detalle in detallesAActualizar)
            {
                detalleCompraRepositorio.Actualizar(detalle);
            }

            foreach (var detalle in detallesAAgregar)
            {
                detalle.CompraId = compra.Id;
                detalleCompraRepositorio.Insertar(detalle);
            }
        }

        public void Eliminar(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };
            oCnx.Guardar("EliminarCompra", parametros);
        }

        public Compra ObtenerPorId(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            DataTable dt = oCnx.Leer("ObtenerCompraPorId", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]);
        }

        public List<Compra> ObtenerTodos()
        {
            DataTable dt = oCnx.Leer("ObtenerTodasLasCompras", null);
            List<Compra> compras = new List<Compra>();

            foreach (DataRow row in dt.Rows)
            {
                compras.Add(Map(row));
            }
            return compras;
        }

        public List<Compra> ObtenerComprasPorProveedorId(int proveedorId)
        {
            var parametros = new Hashtable
            {
                { "@ProveedorId", proveedorId }
            };

            DataTable dt = oCnx.Leer("ObtenerComprasPorProveedorId", parametros);
            List<Compra> compras = new List<Compra>();

            foreach (DataRow row in dt.Rows)
            {
                compras.Add(Map(row));
            }
            return compras;
        }

        public List<DetalleCompra> ObtenerDetallesPorCompraId(int compraId)
        {
            return detalleCompraRepositorio.ObtenerPorCompraId(compraId);
        }

        private Compra Map(DataRow row)
        {
            Compra compra = new Compra
            {
                Id = Convert.ToInt32(row["Id"]),
                Comentario = row["Comentario"].ToString(),
                MontoTotal = Convert.ToDecimal(row["MontoTotal"]),
                Fecha = Convert.ToDateTime(row["Fecha"]),
                TipoPagoEnum = (TipoPago)Enum.Parse(typeof(TipoPago), row["TipoPagoEnum"].ToString()),
                EstadoCompraEnum = (EstadoCompra)Enum.Parse(typeof(EstadoCompra), row["EstadoCompra"].ToString()),
                oProveedor = new Proveedor { Id = Convert.ToInt32(row["ProveedorId"]) },
                oDetalleCompra = detalleCompraRepositorio.ObtenerPorCompraId(Convert.ToInt32(row["Id"]))
            };

            return compra;
        }
    }
}