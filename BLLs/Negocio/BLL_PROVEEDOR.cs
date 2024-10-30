using BEs.Clases.Negocio;
using BLLs.Abstracciones;
using MPPs;
using System;
using System.Collections.Generic;

namespace BLLs.Negocio
{
    public class BLL_PROVEEDOR : IBLL<Proveedor>
    {
        private readonly MPP_PROVEEDOR proveedorRepository;

        public BLL_PROVEEDOR()
        {
            proveedorRepository = new MPP_PROVEEDOR();
        }

        // Método para insertar un nuevo proveedor
        public void Insertar(Proveedor proveedor)
        {
            ValidarProveedor(proveedor);
            proveedorRepository.Insertar(proveedor);
        }

        // Método para actualizar un proveedor existente
        public void Actualizar(Proveedor proveedor)
        {
            ValidarExistenciaProveedor(proveedor.Id);
            ValidarProveedor(proveedor);
            proveedorRepository.Actualizar(proveedor);
        }

        // Método para eliminar un proveedor
        public void Eliminar(int id)
        {
            ValidarExistenciaProveedor(id);
            proveedorRepository.Eliminar(id);
        }

        // Método para obtener un proveedor por su ID
        public Proveedor ObtenerPorId(int id)
        {
            return proveedorRepository.ObtenerPorId(id);
        }

        // Método para obtener todos los proveedores
        public List<Proveedor> ObtenerTodos()
        {
            return proveedorRepository.ObtenerTodos();
        }

        // Validación de datos del proveedor antes de insertarlo o actualizarlo
        private void ValidarProveedor(Proveedor proveedor)
        {
            if (proveedor == null)
                throw new ArgumentNullException("El proveedor no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(proveedor.CUIT))
                throw new ArgumentException("El CUIT del proveedor es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedor.Descripcion))
                throw new ArgumentException("La descripción del proveedor es obligatoria.");

            if (string.IsNullOrWhiteSpace(proveedor.Direccion))
                throw new ArgumentException("La dirección del proveedor es obligatoria.");

            if (string.IsNullOrWhiteSpace(proveedor.Mail))
                throw new ArgumentException("El email del proveedor es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedor.Telefono))
                throw new ArgumentException("El teléfono del proveedor es obligatorio.");

            if (!proveedor.Mail.Contains("@"))
                throw new ArgumentException("El email del proveedor debe tener un formato válido.");
        }

        // Validación para verificar que el proveedor exista antes de actualizar o eliminar
        private void ValidarExistenciaProveedor(int proveedorId)
        {
            var proveedor = proveedorRepository.ObtenerPorId(proveedorId);
            if (proveedor == null)
                throw new ArgumentException($"El proveedor con Id {proveedorId} no existe.");
        }
    }
}