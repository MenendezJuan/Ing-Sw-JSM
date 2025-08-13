using BEs.Clases.Negocio;
using BLLs.Abstracciones;
using MPPs;
using System;
using System.Collections.Generic;

namespace BLLs.Negocio
{
    public class BLL_PROVEEDOR : IBLL<Proveedor>
    {
        private readonly MPP_PROVEEDOR _proveedorRepository;

        public BLL_PROVEEDOR()
        {
            _proveedorRepository = new MPP_PROVEEDOR();
        }

        public void Insertar(Proveedor proveedor)
        {
            ValidarProveedor(proveedor);
            _proveedorRepository.Insertar(proveedor);
        }

        public void Actualizar(Proveedor proveedor)
        {
            ValidarExistenciaProveedor(proveedor.Id);
            ValidarProveedor(proveedor);
            _proveedorRepository.Actualizar(proveedor);
        }

        public void Eliminar(int id)
        {
            ValidarExistenciaProveedor(id);
            _proveedorRepository.Eliminar(id);
        }

        public void Reactivar(int id)
        {
            ValidarExistenciaProveedor(id);
            _proveedorRepository.Reactivar(id);
        }

        public Proveedor ObtenerPorId(int id)
        {
            return _proveedorRepository.ObtenerPorId(id);
        }

        public List<Proveedor> ObtenerTodos()
        {
            return _proveedorRepository.ObtenerTodos();
        }
        public List<Proveedor> ObtenerProveedoresInactivos()
        {
            return _proveedorRepository.ObtenerProveedoresInactivos();
        }

        public List<Proveedor> ObtenerProveedoresPorCategoriaProducto(Categoria categoria)
        {
            return _proveedorRepository.ObtenerProveedoresPorCategoriaProducto(categoria);
        }

        /// <summary>
        /// Busca proveedores por criterio y texto. Criterios: CUIT, Descripcion, Direccion, Email, Telefono, Estado
        /// </summary>
        public List<Proveedor> BuscarProveedores(string criterio, string texto, bool incluirInactivos = true)
        {
            var todos = ObtenerTodos();

            if (!incluirInactivos)
            {
                todos = todos.FindAll(p => p.Estado);
            }

            if (string.IsNullOrWhiteSpace(criterio) || string.IsNullOrWhiteSpace(texto))
            {
                return todos;
            }

            string criterioNorm = criterio.Trim().ToLowerInvariant();
            string valor = texto.Trim();
            string valorNorm = valor.ToLowerInvariant();

            switch (criterioNorm)
            {
                case "cuit":
                    string cuitLimpio = valor.Replace("-", string.Empty).Replace(" ", string.Empty);
                    return todos.FindAll(p => !string.IsNullOrEmpty(p.CUIT) &&
                                              p.CUIT.Replace("-", string.Empty).Replace(" ", string.Empty)
                                                  .Contains(cuitLimpio));
                case "descripcion":
                    return todos.FindAll(p => (p.Descripcion ?? string.Empty).ToLowerInvariant().Contains(valorNorm));
                case "direccion":
                    return todos.FindAll(p => (p.Direccion ?? string.Empty).ToLowerInvariant().Contains(valorNorm));
                case "email":
                case "mail":
                    return todos.FindAll(p => (p.Mail ?? string.Empty).ToLowerInvariant().Contains(valorNorm));
                case "telefono":
                case "teléfono":
                    return todos.FindAll(p => (p.Telefono ?? string.Empty).ToLowerInvariant().Contains(valorNorm));
                case "estado":
                    bool? estado = null;
                    if (valorNorm == "activo") estado = true;
                    if (valorNorm == "inactivo") estado = false;
                    return estado.HasValue ? todos.FindAll(p => p.Estado == estado.Value) : todos;
                default:
                    // Búsqueda amplia
                    return todos.FindAll(p =>
                        (p.CUIT ?? string.Empty).ToLowerInvariant().Contains(valorNorm) ||
                        (p.Descripcion ?? string.Empty).ToLowerInvariant().Contains(valorNorm) ||
                        (p.Direccion ?? string.Empty).ToLowerInvariant().Contains(valorNorm) ||
                        (p.Mail ?? string.Empty).ToLowerInvariant().Contains(valorNorm) ||
                        (p.Telefono ?? string.Empty).ToLowerInvariant().Contains(valorNorm)
                    );
            }
        }

        private void ValidarProveedor(Proveedor proveedor)
        {
            if (proveedor == null)
                throw new ArgumentNullException(nameof(proveedor), "El proveedor no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(proveedor.CUIT))
                throw new ArgumentException("El CUIT del proveedor es obligatorio.", nameof(proveedor.CUIT));

            if (string.IsNullOrWhiteSpace(proveedor.Descripcion))
                throw new ArgumentException("La descripción del proveedor es obligatoria.", nameof(proveedor.Descripcion));

            if (string.IsNullOrWhiteSpace(proveedor.Direccion))
                throw new ArgumentException("La dirección del proveedor es obligatoria.", nameof(proveedor.Direccion));

            if (string.IsNullOrWhiteSpace(proveedor.Mail))
                throw new ArgumentException("El email del proveedor es obligatorio.", nameof(proveedor.Mail));

            if (string.IsNullOrWhiteSpace(proveedor.Telefono))
                throw new ArgumentException("El teléfono del proveedor es obligatorio.", nameof(proveedor.Telefono));

            if (!proveedor.Mail.Contains("@"))
                throw new ArgumentException("El email del proveedor debe tener un formato válido.", nameof(proveedor.Mail));
        }

        private void ValidarExistenciaProveedor(int proveedorId)
        {
            var proveedor = _proveedorRepository.ObtenerPorId(proveedorId);
            if (proveedor == null)
                throw new ArgumentException($"El proveedor con Id {proveedorId} no existe.", nameof(proveedorId));
        }
    }
}