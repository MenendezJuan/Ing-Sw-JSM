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

        private Conexion oCnx;
        private readonly MPP_DETALLECOTIZACION detalleCotizacionRepositorio;
        private readonly MPP_PROVEEDOR proveedorRepository;
        public MPP_COTIZACION()
        {
            oCnx = Conexion.Instance;
            detalleCotizacionRepositorio = new MPP_DETALLECOTIZACION();
            proveedorRepository = new MPP_PROVEEDOR();
        }


        public void Insertar(Cotizacion cotizacion)
        {
            var parametros = new Hashtable
            {
                { "@FechaCotizacion", cotizacion.FechaCotizacion },
                { "@ProveedorId", cotizacion.ProveedorId },
                { "@EstadoCotizacion", (int)cotizacion.EstadoCotizacionEnum }
            };

            int cotizacionId = Convert.ToInt32(oCnx.GuardarConRetorno("InsertarCotizacion", parametros));

            foreach (var detalle in cotizacion.DetallesCotizacion)
            {
                detalle.CotizacionId = cotizacionId;
                detalleCotizacionRepositorio.Insertar(detalle);
            }
        }

        public bool CambiarEstadoCotizacion(int cotizacionId, EstadoCotizacion nuevoEstado)
        {
            var parametros = new Hashtable
            {
                { "@Id", cotizacionId },
                { "@Estado", (int)nuevoEstado }
            };

            return oCnx.Guardar("ActualizarEstadoCotizacion", parametros);
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
            cotizacion.DetallesCotizacion = detalleCotizacionRepositorio.ObtenerPorCotizacionId(cotizacion.Id);
            return cotizacion;
        }

        public List<Cotizacion> ObtenerTodos()
        {
            DataTable dt = oCnx.Leer("ObtenerTodasLasCotizaciones", null);
            List<Cotizacion> cotizaciones = new List<Cotizacion>();

            foreach (DataRow row in dt.Rows)
            {
                Cotizacion cotizacion = Map(row);
                cotizacion.DetallesCotizacion = detalleCotizacionRepositorio.ObtenerPorCotizacionId(cotizacion.Id);
                int proveedorId = (int)row["ProveedorId"];
                cotizacion.Proveedor = proveedorRepository.ObtenerPorId(proveedorId);
                cotizaciones.Add(cotizacion);
            }
            return cotizaciones;
        }

        public List<Cotizacion> ObtenerCotizacionesPorFecha(DateTime desde, DateTime hasta)
        {
            var parametros = new Hashtable
    {
        { "@FechaDesde", desde },
        { "@FechaHasta", hasta }
    };

            DataTable dt = oCnx.Leer("ObtenerCotizacionesPorFecha", parametros);
            List<Cotizacion> cotizaciones = new List<Cotizacion>();

            foreach (DataRow row in dt.Rows)
            {
                Cotizacion cotizacion = Map(row);
                cotizacion.DetallesCotizacion = detalleCotizacionRepositorio.ObtenerPorCotizacionId(cotizacion.Id);
                int proveedorId = (int)row["ProveedorId"];
                cotizacion.Proveedor = proveedorRepository.ObtenerPorId(proveedorId);
                cotizaciones.Add(cotizacion);
            }

            return cotizaciones;
        }

        // En MPP_COTIZACION:

        public List<Cotizacion> ObtenerPorEstado(EstadoCotizacion estado)
        {
            var parametros = new Hashtable
            {
                { "@EstadoCotizacion", (int)estado }
            };
            DataTable dt = oCnx.Leer("ObtenerCotizacionesPorEstado", parametros);
            return MapearCotizaciones(dt);
        }

        public List<Cotizacion> ObtenerPorEstados(List<EstadoCotizacion> estados)
        {
            string estadosParametros = string.Join(",", estados.Select(e => (int)e));
            var parametros = new Hashtable
            {
                { "@Estados", estadosParametros }
            };
            DataTable dt = oCnx.Leer("ObtenerCotizacionesPorEstados", parametros);
            return MapearCotizaciones(dt);
        }

        private List<Cotizacion> MapearCotizaciones(DataTable dt)
        {
            List<Cotizacion> cotizaciones = new List<Cotizacion>();
            foreach (DataRow row in dt.Rows)
            {
                Cotizacion cotizacion = Map(row);
                cotizacion.DetallesCotizacion = detalleCotizacionRepositorio.ObtenerPorCotizacionId(cotizacion.Id);
                cotizacion.Proveedor = proveedorRepository.ObtenerPorId(cotizacion.ProveedorId);
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
