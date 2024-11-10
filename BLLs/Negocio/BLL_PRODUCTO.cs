using BEs.Clases.Negocio;
using MPPs;
using MPPs.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLLs.Negocio
{
    public class BLL_PRODUCTO
    {
        private readonly MPP_PRODUCTO _productoRepository;
        private readonly MPP_PROVEEDOR _proveedorRepository;

        public BLL_PRODUCTO()
        {
            _productoRepository = new MPP_PRODUCTO();
            _proveedorRepository = new MPP_PROVEEDOR(); ;
        }

        public void Insertar(Producto producto, int proveedorId)
        {
            ValidarProducto(producto);
            ValidarProveedor(proveedorId);
            _productoRepository.Insertar(producto, proveedorId);
        }

        public void Actualizar(Producto producto, int nuevoProveedorId)
        {
            ValidarExistenciaProducto(producto.Id);
            ValidarProducto(producto);
            ValidarProveedor(nuevoProveedorId);
            _productoRepository.Actualizar(producto, nuevoProveedorId);
        }

        public void Eliminar(int id)
        {
            ValidarExistenciaProducto(id);
            _productoRepository.Eliminar(id);
        }

        public Producto ObtenerPorId(int id)
        {
            return _productoRepository.ObtenerPorId(id);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productoRepository.ObtenerTodos();
        }

        public List<Producto> ObtenerProductosPorCategoria(Categoria categoria)
        {
            return _productoRepository.ObtenerProductosPorCategoria(categoria);
        }

        public List<Producto> ObtenerProductosProveedorPorCategoria(int proveedorId, Categoria categoria)
        {
            ValidarProveedor(proveedorId);
            return _productoRepository.ObtenerProductosProveedorPorCategoria(proveedorId, categoria);
        }

        public List<Categoria> ObtenerCategoriasPorProveedor(int proveedorId)
        {
            ValidarProveedor(proveedorId);
            var categoriasStrings = _productoRepository.ObtenerCategoriasPorProveedor(proveedorId);

            var categorias = categoriasStrings
                .Select(categoriaString => Enum.TryParse<Categoria>(categoriaString, out var categoria) ? categoria : (Categoria?)null)
                .Where(categoria => categoria.HasValue)
                .Select(categoria => categoria.Value)
                .ToList();

            return categorias;
        }

        private void ValidarProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(producto.Codigo))
                throw new ArgumentException("El código del producto es obligatorio.", nameof(producto.Codigo));

            if (producto.Stock < 0)
                throw new ArgumentException("El stock del producto no puede ser negativo.", nameof(producto.Stock));

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.", nameof(producto.Nombre));

            if (producto.PrecioCompra <= 0)
                throw new ArgumentException("El precio de compra debe ser mayor a cero.", nameof(producto.PrecioCompra));

            if (producto.PrecioVenta <= 0)
                throw new ArgumentException("El precio de venta debe ser mayor a cero.", nameof(producto.PrecioVenta));

            if (producto.PrecioVenta < producto.PrecioCompra)
                throw new ArgumentException("El precio de venta no puede ser menor que el precio de compra.", nameof(producto.PrecioVenta));

            if (_productoRepository.ExisteCodigoProducto(producto.Codigo))
            {
                throw new ArgumentException($"El código de producto {producto.Codigo} ya existe.", nameof(producto.Codigo));
            }
        }

        private void ValidarProveedor(int proveedorId)
        {
            var proveedor = _proveedorRepository.ObtenerPorId(proveedorId);
            if (proveedor == null)
                throw new ArgumentException("El proveedor especificado no existe o no está activo.", nameof(proveedorId));
        }

        private void ValidarExistenciaProducto(int productoId)
        {
            var producto = _productoRepository.ObtenerPorId(productoId);
            if (producto == null)
                throw new ArgumentException($"El producto con Id {productoId} no existe.", nameof(productoId));
        }
    }
}
