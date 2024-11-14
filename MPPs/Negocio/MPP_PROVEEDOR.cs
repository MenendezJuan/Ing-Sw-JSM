using BEs.Clases.Negocio;
using MPPs.Negocio;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs
{
    public class MPP_PROVEEDOR : IRepositorio<Proveedor>
    {
        private readonly Conexion oCnx;
        private readonly MPP_PRODUCTO mppProducto;
        public MPP_PROVEEDOR()
        {
            oCnx = Conexion.Instance;
            mppProducto = new MPP_PRODUCTO();
        }

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

            proveedor.Id = Convert.ToInt32(oCnx.GuardarConRetorno("InsertarProveedor", parametros));
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
            if (HayProductosAsociados(id))
            {
                throw new InvalidOperationException("No se puede eliminar el proveedor porque tiene productos asociados.");
            }

            // Si no hay productos asociados, procede con la eliminación
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            oCnx.Guardar("EliminarProveedor", parametros);
        }

        public void Reactivar(int id)
        {
            var parametros = new Hashtable
                {
                    { "@Id", id }
                };

            oCnx.Guardar("ReactivarProveedor", parametros); // Reactivación lógica
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

        public List<Proveedor> ObtenerProveedoresInactivos()
        {
            var proveedoresInactivos = new List<Proveedor>();

            DataTable dt = oCnx.Leer("ObtenerProveedoresInactivos", null);

            foreach (DataRow row in dt.Rows)
            {
                proveedoresInactivos.Add(Map(row));
            }

            return proveedoresInactivos;
        }

        public List<Proveedor> ObtenerProveedoresPorCategoriaProducto(Categoria categoria)
        {
            var parametros = new Hashtable { { "@Categoria", (int)categoria } };
            DataTable dt = oCnx.Leer("ObtenerProveedoresPorCategoriaProducto", parametros);

            List<Proveedor> proveedores = new List<Proveedor>();
            foreach (DataRow row in dt.Rows)
            {
                proveedores.Add(Map(row));
            }

            return proveedores;
        }


        private bool HayProductosAsociados(int proveedorId)
        {
            return mppProducto.ObtenerProductosPorProveedorId(proveedorId).Count > 0;
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
