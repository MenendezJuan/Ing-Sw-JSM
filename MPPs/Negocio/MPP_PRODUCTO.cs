using BEs.Clases.Negocio;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs.Negocio
{
    public class MPP_PRODUCTO
    {
        public MPP_PRODUCTO()
        {
            oCnx = Conexion.Instance; // Instancia de conexión
        }

        private readonly Conexion oCnx;

        public int Insertar(Producto producto)
        {
            var parametros = new Hashtable
            {
                { "@Codigo", producto.Codigo },
                { "@CategoriaEnum", (int)producto.CategoriaEnum }, // Convertir enum a int
                { "@Stock", producto.Stock },
                { "@Nombre", producto.Nombre },
                { "@Descripcion", producto.Descripcion },
                { "@PrecioCompra", producto.PrecioCompra },
                { "@PrecioVenta", producto.PrecioVenta },
                { "@Estado", producto.Estado },
                { "@Fecha", producto.Fecha }
            };

            oCnx.Guardar("InsertarProducto", parametros);
            // En este caso, deberías hacer que el procedimiento almacenado retorne el ID del nuevo producto.
            return Convert.ToInt32(parametros["@Id"]); // Aquí necesitas ajustar según cómo se maneje el ID en tu base de datos.
        }

        public void Actualizar(Producto producto)
        {
            var parametros = new Hashtable
            {
                { "@Id", producto.Id },
                { "@Codigo", producto.Codigo },
                { "@CategoriaEnum", (int)producto.CategoriaEnum }, // Convertir enum a int
                { "@Stock", producto.Stock },
                { "@Nombre", producto.Nombre },
                { "@Descripcion", producto.Descripcion },
                { "@PrecioCompra", producto.PrecioCompra },
                { "@PrecioVenta", producto.PrecioVenta },
                { "@Estado", producto.Estado },
                { "@Fecha", producto.Fecha }
            };

            // Llamar al método Guardar para actualizar
            oCnx.Guardar("ActualizarProducto", parametros);
        }

        public void Eliminar(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            // Llamar al método Guardar para eliminar
            oCnx.Guardar("EliminarProducto", parametros);
        }

        public Producto ObtenerPorId(int id)
        {
            var parametros = new Hashtable
            {
                { "@Id", id }
            };

            // Llamar al método Leer para obtener el producto por ID
            DataTable dt = oCnx.Leer("ObtenerProductoPorId", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]);
        }

        public List<Producto> ObtenerTodos()
        {
            // Llamar al método Leer para obtener todos los productos
            DataTable dt = oCnx.Leer("ObtenerTodosProductos", null);
            List<Producto> productos = new List<Producto>();
            foreach (DataRow row in dt.Rows)
            {
                productos.Add(Map(row));
            }
            return productos;
        }

        private Producto Map(DataRow row)
        {
            return new Producto
            {
                Id = Convert.ToInt32(row["Id"]),
                Codigo = row["Codigo"].ToString(),
                CategoriaEnum = (Categoria)Enum.ToObject(typeof(Categoria), Convert.ToInt32(row["CategoriaEnum"])), // Convertir int a enum
                Stock = Convert.ToDecimal(row["Stock"]),
                Nombre = row["Nombre"].ToString(),
                Descripcion = row["Descripcion"].ToString(),
                PrecioCompra = Convert.ToDecimal(row["PrecioCompra"]),
                PrecioVenta = Convert.ToDecimal(row["PrecioVenta"]),
                Estado = Convert.ToBoolean(row["Estado"]),
                Fecha = Convert.ToDateTime(row["Fecha"])
            };
        }
    }
}
