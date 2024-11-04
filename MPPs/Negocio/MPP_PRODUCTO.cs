using BEs.Clases.Negocio;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MPPs.Negocio
{
    public class MPP_PRODUCTO
    {
        private readonly Conexion oCnx;

        public MPP_PRODUCTO()
        {
            oCnx = Conexion.Instance; // Instancia de conexión
        }

        // Método para insertar un producto y asociarlo a un proveedor
        public int Insertar(Producto producto, int proveedorId)
        {
            // Validación de existencia del proveedor
            if (!ProveedorExiste(proveedorId))
            {
                throw new ArgumentException("El proveedor especificado no existe.");
            }

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

            int productoId = Convert.ToInt32(oCnx.GuardarConRetorno("InsertarProducto", parametros)); // Se espera que el SP devuelva el ID
            AsociarProductoAProveedor(productoId, proveedorId); // Asociar producto con proveedor
            return productoId;
        }

        // Método para actualizar un producto y su asociación a un proveedor
        public void Actualizar(Producto producto, int nuevoProveedorId)
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

            oCnx.Guardar("ActualizarProducto", parametros); // Actualizar producto

            // Verificar y actualizar la relación con el proveedor
            int proveedorActualId = ObtenerProveedorIdPorProducto(producto.Id);
            if (proveedorActualId != nuevoProveedorId)
            {
                DesasociarProductoDeProveedor(producto.Id, proveedorActualId);
                AsociarProductoAProveedor(producto.Id, nuevoProveedorId);
            }
        }

        // Método para eliminar un producto y su asociación con el proveedor
        public void Eliminar(int productoId)
        {
            // Desasociar el producto de su proveedor en la tabla intermedia
            int proveedorId = ObtenerProveedorIdPorProducto(productoId);
            if (proveedorId > 0)
            {
                DesasociarProductoDeProveedor(productoId, proveedorId);
            }

            // Eliminar el producto
            var parametros = new Hashtable { { "@Id", productoId } };
            oCnx.Guardar("EliminarProducto", parametros);
        }

        // Método para obtener un producto por su ID
        public Producto ObtenerPorId(int id)
        {
            var parametros = new Hashtable { { "@Id", id } };
            DataTable dt = oCnx.Leer("ObtenerProductoPorId", parametros);
            if (dt.Rows.Count == 0) return null;

            return Map(dt.Rows[0]); // Mapear el DataRow a un objeto Producto
        }

        // Método para obtener todos los productos
        public List<Producto> ObtenerTodos()
        {
            DataTable dt = oCnx.Leer("ObtenerTodosProductos", null);
            List<Producto> productos = new List<Producto>();
            foreach (DataRow row in dt.Rows)
            {
                productos.Add(Map(row)); // Mapear cada fila a un objeto Producto
            }
            return productos;
        }

        // Método para verificar si un proveedor existe
        private bool ProveedorExiste(int proveedorId)
        {
            var parametros = new Hashtable { { "@Id", proveedorId } };
            DataTable dt = oCnx.Leer("ObtenerProveedorPorId", parametros);
            return dt.Rows.Count > 0;
        }

        // Método auxiliar para asociar un producto a un proveedor
        private void AsociarProductoAProveedor(int productoId, int proveedorId)
        {
            var parametros = new Hashtable
            {
                { "@ProductoId", productoId },
                { "@ProveedorId", proveedorId }
            };
            oCnx.Guardar("InsertarProductoProveedor", parametros);
        }

        // Método para obtener productos por categoría
        public List<Producto> ObtenerProductosPorCategoria(Categoria categoria)
        {
            var parametros = new Hashtable { { "@Categoria", (int)categoria } };
            DataTable dt = oCnx.Leer("ObtenerProductosPorCategoria", parametros);

            List<Producto> productos = new List<Producto>();
            foreach (DataRow row in dt.Rows)
            {
                productos.Add(Map(row));
            }

            return productos;
        }

        // Método para obtener productos de un proveedor por categoría
        public List<Producto> ObtenerProductosProveedorPorCategoria(int proveedorId, Categoria categoria)
        {
            var parametros = new Hashtable
    {
        { "@ProveedorId", proveedorId },
        { "@Categoria", (int)categoria }
    };
            DataTable dt = oCnx.Leer("ObtenerProductosProveedorPorCategoria", parametros);

            List<Producto> productos = new List<Producto>();
            foreach (DataRow row in dt.Rows)
            {
                productos.Add(Map(row));
            }

            return productos;
        }


        // Método auxiliar para desasociar un producto de un proveedor
        private void DesasociarProductoDeProveedor(int productoId, int proveedorId)
        {
            var parametros = new Hashtable
            {
                { "@ProductoId", productoId },
                { "@ProveedorId", proveedorId }
            };
            oCnx.Guardar("EliminarProductoProveedor", parametros);
        }

        // Método para obtener el proveedor asociado a un producto
        private int ObtenerProveedorIdPorProducto(int productoId)
        {
            var parametros = new Hashtable { { "@ProductoId", productoId } };
            DataTable dt = oCnx.Leer("ObtenerProveedorPorProductoId", parametros);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["ProveedorId"]);
            }
            return 0;
        }

        public List<Producto> ObtenerProductosPorProveedorId(int proveedorId)
        {
            var parametros = new Hashtable { { "@ProveedorId", proveedorId } };
            DataTable dt = oCnx.Leer("ObtenerProductosPorProveedorId", parametros);

            List<Producto> productos = new List<Producto>();
            foreach (DataRow row in dt.Rows)
            {
                productos.Add(Map(row));
            }

            return productos;
        }

        //public List<string> ObtenerCategoriasPorProveedor(int proveedorId)
        //{
        //    var categorias = new List<string>();

        //    var parametros = new Hashtable { { "@ProveedorId", proveedorId } };
        //    DataTable dt = oCnx.Leer("ObtenerCategoriasPorProveedor", parametros);

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        categorias.Add(row["Categoria"].ToString());
        //    }

        //    return categorias;
        //}

        public List<string> ObtenerCategoriasPorProveedor(int proveedorId)
        {
            var categorias = new List<string>();

            var parametros = new Hashtable { { "@ProveedorId", proveedorId } };
            DataTable dt = oCnx.Leer("ObtenerCategoriasPorProveedor", parametros);

            // Verificar si el DataTable tiene filas
            if (dt != null && dt.Rows.Count > 0)
            {
                // Usar LINQ para agregar las categorías directamente a la lista
                categorias.AddRange(dt.AsEnumerable().Select(row => row["Categoria"].ToString()).Distinct());
            }

            return categorias;
        }

        // Método para mapear un DataRow a un objeto Producto
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
