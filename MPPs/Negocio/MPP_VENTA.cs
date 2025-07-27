using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Enums;
using BEs.Clases.Negocio.Ventas;
using MPPs.Negocio;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MPPs
{
    public class MPP_VENTA
    {
        public MPP_VENTA()
        {
            oCnx = Conexion.Instance;
        }
        private Conexion oCnx;

        private readonly MPP_PRODUCTO productoRepositorio = new MPP_PRODUCTO();
        private readonly MPP_DETALLEVENTA detalleVentaRepositorio = new MPP_DETALLEVENTA();
        private readonly MPP_CLIENTE clienteRepositorio = new MPP_CLIENTE();

        public int Insertar(Venta venta)
        {
            var parametros = new Hashtable
            {
                { "@Comentario", venta.Comentario },
                { "@MontoTotal", venta.MontoTotal },
                { "@Fecha", venta.Fecha },
                { "@TipoPagoEnum", (int)venta.TipoPagoEnum },
                { "@ClienteId", venta.oCliente?.Id },
                { "@EstadoVenta", (int)venta.EstadoVentaEnum },
                { "@UsuarioVendedorId", venta.UsuarioVendedorId }
            };

            int ventaId = Convert.ToInt32(oCnx.GuardarConRetorno("InsertarVenta", parametros));

            venta.Id = ventaId;

            foreach (var detalle in venta.oDetalleVenta)
            {
                detalle.VentaId = ventaId;
                detalleVentaRepositorio.Insertar(detalle);
            }

            return ventaId;
        }

        public void Actualizar(Venta venta)
        {
            var parametros = new Hashtable
            {
                { "@Id", venta.Id },
                { "@Comentario", venta.Comentario },
                { "@MontoTotal", venta.MontoTotal },
                { "@Fecha", venta.Fecha },
                { "@TipoPagoEnum", (int)venta.TipoPagoEnum },
                { "@ClienteId", venta.oCliente?.Id },
                { "@EstadoVenta", (int)venta.EstadoVentaEnum },
                { "@UsuarioVendedorId", venta.UsuarioVendedorId }
            };

            oCnx.Guardar("ActualizarVenta", parametros);
        }

        public void Eliminar(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            oCnx.Guardar("EliminarVenta", parametros);
        }

        public Venta ObtenerPorId(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            DataTable dt = oCnx.Leer("ObtenerVentaPorId", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]);
        }

        public List<Venta> ObtenerTodos()
        {
            DataTable dt = oCnx.Leer("ObtenerTodasLasVentas", null);
            List<Venta> ventas = new List<Venta>();

            foreach (DataRow row in dt.Rows)
            {
                ventas.Add(Map(row));
            }
            return ventas;
        }

        public void CambiarEstadoVenta(int ventaId, EstadoVenta nuevoEstado)
        {
            var parametros = new Hashtable
            {
                { "@Id", ventaId },
                { "@EstadoVenta", (int)nuevoEstado }
            };

            oCnx.Guardar("CambiarEstadoVenta", parametros);
        }

        public List<Venta> ObtenerVentasPorClienteId(int clienteId)
        {
            var parametros = new Hashtable
            {
                { "@ClienteId", clienteId }
            };

            DataTable dt = oCnx.Leer("ObtenerVentasPorClienteId", parametros);
            List<Venta> ventas = new List<Venta>();

            foreach (DataRow row in dt.Rows)
            {
                ventas.Add(Map(row));
            }
            return ventas;
        }

        public List<DetalleVenta> ObtenerDetallesPorVentaId(int ventaId)
        {
            return detalleVentaRepositorio.ObtenerPorVentaId(ventaId);
        }

        private Venta Map(DataRow row)
        {
            Venta venta = new Venta
            {
                Id = Convert.ToInt32(row["Id"]),
                Comentario = row["Comentario"]?.ToString(),
                MontoTotal = Convert.ToDecimal(row["MontoTotal"]),
                Fecha = Convert.ToDateTime(row["Fecha"]),
                TipoPagoEnum = (TipoPago)Enum.Parse(typeof(TipoPago), row["TipoPagoEnum"].ToString()),
                EstadoVentaEnum = (EstadoVenta)Enum.Parse(typeof(EstadoVenta), row["EstadoVenta"].ToString()),
                ClienteId = row["ClienteId"] != DBNull.Value ? Convert.ToInt32(row["ClienteId"]) : (int?)null,
                UsuarioVendedorId = row["UsuarioVendedorId"] != DBNull.Value ? Convert.ToInt32(row["UsuarioVendedorId"]) : (int?)null,
                oDetalleVenta = detalleVentaRepositorio.ObtenerPorVentaId(Convert.ToInt32(row["Id"]))
            };

            // Cargar cliente si existe
            if (venta.ClienteId.HasValue)
            {
                venta.oCliente = clienteRepositorio.ObtenerPorId(venta.ClienteId.Value);
            }

            // Cargar vendedor si existe (asumiendo que tienes MPP_USUARIO)
            // if (venta.UsuarioVendedorId.HasValue)
            // {
            //     venta.oVendedor = usuarioRepositorio.ObtenerPorId(venta.UsuarioVendedorId.Value);
            // }

            return venta;
        }
    }
} 