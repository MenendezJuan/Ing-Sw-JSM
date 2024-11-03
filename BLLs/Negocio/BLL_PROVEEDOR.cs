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

        public Proveedor ObtenerPorId(int id)
        {
            return _proveedorRepository.ObtenerPorId(id);
        }

        public List<Proveedor> ObtenerTodos()
        {
            return _proveedorRepository.ObtenerTodos();
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