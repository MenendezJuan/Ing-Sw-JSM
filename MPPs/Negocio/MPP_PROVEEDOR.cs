using BEs.Clases.Negocio;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs
{
    public class MPP_PROVEEDOR : IRepositorio<Proveedor>
    {
        private readonly Conexion oCnx = Conexion.Instance;

        public void Insertar(Proveedor proveedor)
        {
            var parametros = new Hashtable
            {
                { "@CUIT", proveedor.CUIT },
                { "@Descripcion", proveedor.Descripcion },
                { "@Direccion", proveedor.Direccion },
                { "@Mail", proveedor.Mail },
                { "@Telefono", proveedor.Telefono },
                { "@Estado", proveedor.Estado },
                { "@FechaRegistro", proveedor.FechaRegistro }
            };

            proveedor.Id = Convert.ToInt32(oCnx.Guardar("InsertarProveedor", parametros));
        }

        public void Actualizar(Proveedor proveedor)
        {
            var parametros = new Hashtable
            {
                { "@Id", proveedor.Id },
                { "@CUIT", proveedor.CUIT },
                { "@Descripcion", proveedor.Descripcion },
                { "@Direccion", proveedor.Direccion },
                { "@Mail", proveedor.Mail },
                { "@Telefono", proveedor.Telefono },
                { "@Estado", proveedor.Estado },
                { "@FechaRegistro", proveedor.FechaRegistro }
            };

            oCnx.Guardar("ActualizarProveedor", parametros);
        }

        public void Eliminar(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            oCnx.Guardar("EliminarProveedor", parametros);
        }

        public Proveedor ObtenerPorId(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            DataTable dt = oCnx.Leer("ObtenerProveedorPorId", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]);
        }

        public List<Proveedor> ObtenerTodos()
        {
            DataTable dt = oCnx.Leer("ObtenerTodosLosProveedores", null);
            var proveedores = new List<Proveedor>();

            foreach (DataRow row in dt.Rows)
            {
                proveedores.Add(Map(row));
            }
            return proveedores;
        }

        private Proveedor Map(DataRow row)
        {
            return new Proveedor
            {
                Id = Convert.ToInt32(row["Id"]),
                CUIT = row["CUIT"].ToString(),
                Descripcion = row["Descripcion"].ToString(),
                Direccion = row["Direccion"].ToString(),
                Mail = row["Mail"].ToString(),
                Telefono = row["Telefono"].ToString(),
                Estado = Convert.ToBoolean(row["Estado"]),
                FechaRegistro = Convert.ToDateTime(row["FechaRegistro"])
            };
        }
    }
}
