using BEs.Clases.Negocio;
using BLLs.Abstracciones;
using MPPs.Negocio;
using System;
using System.Collections.Generic;

namespace BLLs.Negocio
{
    public class BLL_PRODUCTO : IBLL<Producto>
    {
        private readonly MPP_PRODUCTO productoRepository;
        public BLL_PRODUCTO()
        {
            productoRepository = new MPP_PRODUCTO();
        }

        // Método para insertar un nuevo producto
        public void Insertar(Producto producto)
        {
            ValidarProducto(producto);
            productoRepository.Insertar(producto);
        }

        // Método para actualizar un producto existente
        public void Actualizar(Producto producto)
        {
            ValidarExistenciaProducto(producto.Id);
            ValidarProducto(producto);
            productoRepository.Actualizar(producto);
        }

        // Método para eliminar un producto
        public void Eliminar(int id)
        {
            ValidarExistenciaProducto(id);
            productoRepository.Eliminar(id);
        }

        // Método para obtener un producto por su ID
        public Producto ObtenerPorId(int id)
        {
            return productoRepository.ObtenerPorId(id);
        }

        // Método para obtener todos los productos
        public List<Producto> ObtenerTodos()
        {
            return productoRepository.ObtenerTodos();
        }

        // Método de validación para verificar la integridad del producto antes de insertarlo o actualizarlo
        private void ValidarProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException("El producto no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(producto.Codigo))
                throw new ArgumentException("El código del producto es obligatorio.");

            if (producto.Stock < 0)
                throw new ArgumentException("El stock del producto no puede ser negativo.");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");

            if (producto.PrecioCompra <= 0)
                throw new ArgumentException("El precio de compra debe ser mayor a cero.");

            if (producto.PrecioVenta <= 0)
                throw new ArgumentException("El precio de venta debe ser mayor a cero.");

            if (producto.PrecioVenta < producto.PrecioCompra)
                throw new ArgumentException("El precio de venta no puede ser menor que el precio de compra.");
        }

        // Método de validación para verificar la existencia del producto antes de actualizar o eliminar
        private void ValidarExistenciaProducto(int productoId)
        {
            var producto = productoRepository.ObtenerPorId(productoId);
            if (producto == null)
                throw new ArgumentException($"El producto con Id {productoId} no existe.");
        }
    }
}
