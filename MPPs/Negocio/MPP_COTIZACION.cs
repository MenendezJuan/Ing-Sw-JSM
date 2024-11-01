using BEs.Clases.Negocio;
using BEs.Clases.Negocio.Compras;
using BEs.Clases.Negocio.Enums;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MPPs.Negocio
{
    public class MPP_COTIZACION : IRepositorio<Cotizacion>
    {
        public MPP_COTIZACION()
        {
            oCnx = Conexion.Instance;
        }

        private Conexion oCnx;
        private readonly MPP_DETALLECOMPRA detalleCompraRepositorio = new MPP_DETALLECOMPRA();

        public void Insertar(Cotizacion cotizacion)
        {
            var parametros = new Hashtable
            {
                { "@FechaCotizacion", cotizacion.FechaCotizacion },
                { "@ProveedorId", cotizacion.ProveedorId },
                { "@EstadoCotizacion", (int)cotizacion.EstadoCotizacionEnum }
            };

            int cotizacionId = Convert.ToInt32(oCnx.Guardar("InsertarCotizacion", parametros));

            foreach (var detalle in cotizacion.DetallesCompra)
            {
                detalle.CotizacionId = cotizacionId;
                detalleCompraRepositorio.Insertar(detalle);
            }
        }

        public void CambiarEstadoCotizacion(int cotizacionId, EstadoCotizacion nuevoEstado)
        {
            var parametros = new Hashtable
            {
                { "@Id", cotizacionId },
                { "@Estado", (int)nuevoEstado }
            };

            oCnx.Guardar("ActualizarEstadoCotizacion", parametros);
        }

        public void Actualizar(Cotizacion cotizacion)
        {
            var parametros = new Hashtable
            {
                { "@Id", cotizacion.Id },
                { "@FechaCotizacion", cotizacion.FechaCotizacion },
                { "@ProveedorId", cotizacion.ProveedorId },
                { "@EstadoCotizacion", (int)cotizacion.EstadoCotizacionEnum }
            };

            oCnx.Guardar("ActualizarCotizacion", parametros);

            var detallesActuales = detalleCompraRepositorio.ObtenerPorCotizacionId(cotizacion.Id);

            var detallesAActualizar = cotizacion.DetallesCompra.Where(d => detallesActuales.Any(da => da.Id == d.Id)).ToList();
            var detallesAEliminar = detallesActuales.Where(da => !cotizacion.DetallesCompra.Any(d => d.Id == da.Id)).ToList();
            var detallesAAgregar = cotizacion.DetallesCompra.Where(d => d.Id == 0).ToList();

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
                detalle.CotizacionId = cotizacion.Id;
                detalleCompraRepositorio.Insertar(detalle);
            }
        }

        public void Eliminar(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            oCnx.Guardar("EliminarCotizacion", parametros);
        }

        public Cotizacion ObtenerPorId(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            DataTable dt = oCnx.Leer("ObtenerCotizacionPorId", parametros);
            if (dt.Rows.Count == 0) return null;

            Cotizacion cotizacion = Map(dt.Rows[0]);
            cotizacion.DetallesCompra = detalleCompraRepositorio.ObtenerPorCotizacionId(cotizacion.Id);
            return cotizacion;
        }

        public List<Cotizacion> ObtenerTodos()
        {
            DataTable dt = oCnx.Leer("ObtenerTodasLasCotizaciones", null);
            List<Cotizacion> cotizaciones = new List<Cotizacion>();

            foreach (DataRow row in dt.Rows)
            {
                Cotizacion cotizacion = Map(row);
                cotizacion.DetallesCompra = detalleCompraRepositorio.ObtenerPorCotizacionId(cotizacion.Id);
                cotizaciones.Add(cotizacion);
            }
            return cotizaciones;
        }

        private Cotizacion Map(DataRow row)
        {
            return new Cotizacion
            {
                Id = Convert.ToInt32(row["Id"]),
                FechaCotizacion = Convert.ToDateTime(row["FechaCotizacion"]),
                ProveedorId = Convert.ToInt32(row["ProveedorId"]),
                EstadoCotizacionEnum = (EstadoCotizacion)Enum.Parse(typeof(EstadoCotizacion), row["EstadoCotizacion"].ToString()),
                Proveedor = new Proveedor { Id = Convert.ToInt32(row["ProveedorId"]) }
            };
        }
    }

}
