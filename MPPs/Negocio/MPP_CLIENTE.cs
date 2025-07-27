using BEs.Clases.Negocio.Ventas;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs.Negocio
{
    public class MPP_CLIENTE : IRepositorio<Cliente>
    {
        private Conexion oCnx;

        public MPP_CLIENTE()
        {
            oCnx = Conexion.Instance;
        }

        public void Insertar(Cliente cliente)
        {
            var parametros = new Hashtable
            {
                { "@CUIT", cliente.CUIT },
                { "@Nombre", cliente.Nombre },
                { "@Apellido", cliente.Apellido },
                { "@Direccion", cliente.Direccion },
                { "@Mail", cliente.Mail },
                { "@Telefono", cliente.Telefono },
                { "@Estado", cliente.Estado },
                { "@FechaRegistro", cliente.FechaRegistro }
            };

            oCnx.Guardar("InsertarCliente", parametros);
        }

        public void Actualizar(Cliente cliente)
        {
            var parametros = new Hashtable
            {
                { "@Id", cliente.Id },
                { "@CUIT", cliente.CUIT },
                { "@Nombre", cliente.Nombre },
                { "@Apellido", cliente.Apellido },
                { "@Direccion", cliente.Direccion },
                { "@Mail", cliente.Mail },
                { "@Telefono", cliente.Telefono },
                { "@Estado", cliente.Estado },
                { "@FechaRegistro", cliente.FechaRegistro }
            };

            oCnx.Guardar("ActualizarCliente", parametros);
        }

        public void Eliminar(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            oCnx.Guardar("EliminarCliente", parametros);
        }

        public Cliente ObtenerPorId(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            DataTable dt = oCnx.Leer("ObtenerClientePorId", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]);
        }

        public List<Cliente> ObtenerTodos()
        {
            DataTable dt = oCnx.Leer("ObtenerTodosLosClientes", null);
            List<Cliente> clientes = new List<Cliente>();

            foreach (DataRow row in dt.Rows)
            {
                clientes.Add(Map(row));
            }
            return clientes;
        }

        public List<Cliente> ObtenerClientesInactivos()
        {
            DataTable dt = oCnx.Leer("ObtenerClientesInactivos", null);
            List<Cliente> clientes = new List<Cliente>();

            foreach (DataRow row in dt.Rows)
            {
                clientes.Add(Map(row));
            }
            return clientes;
        }

        public void ReactivarCliente(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            oCnx.Guardar("ReactivarCliente", parametros);
        }

        /// <summary>
        /// Busca un cliente por su CUIT
        /// </summary>
        /// <param name="cuit">CUIT del cliente a buscar</param>
        /// <returns>Cliente encontrado o null si no existe</returns>
        public Cliente BuscarPorCUIT(string cuit)
        {
            var parametros = new Hashtable
            {
                { "@CUIT", cuit }
            };

            DataTable dt = oCnx.Leer("ObtenerClientePorCUIT", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]);
        }

        private Cliente Map(DataRow row)
        {
            Cliente cliente = new Cliente
            {
                Id = Convert.ToInt32(row["Id"]),
                CUIT = row["CUIT"]?.ToString(),
                Nombre = row["Nombre"].ToString(),
                Apellido = row["Apellido"].ToString(),
                Direccion = row["Direccion"]?.ToString(),
                Mail = row["Mail"]?.ToString(),
                Telefono = row["Telefono"]?.ToString(),
                Estado = Convert.ToBoolean(row["Estado"]),
                FechaRegistro = Convert.ToDateTime(row["FechaRegistro"])
            };

            return cliente;
        }
    }
} 