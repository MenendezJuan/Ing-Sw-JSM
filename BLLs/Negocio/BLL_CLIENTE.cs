using BEs.Clases.Negocio.Ventas;
using MPPs.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLLs.Negocio
{
    public class BLL_CLIENTE
    {
        private readonly MPP_CLIENTE clienteRepository;

        public BLL_CLIENTE()
        {
            clienteRepository = new MPP_CLIENTE();
        }

        // Método para insertar un nuevo cliente
        public void Insertar(Cliente cliente)
        {
            ValidarCliente(cliente);
            clienteRepository.Insertar(cliente);
        }

        // Método para actualizar un cliente existente
        public void Actualizar(Cliente cliente)
        {
            ValidarExistenciaCliente(cliente.Id);
            ValidarCliente(cliente);
            clienteRepository.Actualizar(cliente);
        }

        // Método para eliminar (desactivar) un cliente
        public void Eliminar(int id)
        {
            ValidarExistenciaCliente(id);
            clienteRepository.Eliminar(id);
        }

        // Método para obtener un cliente por su Id
        public Cliente ObtenerPorId(int id)
        {
            return clienteRepository.ObtenerPorId(id);
        }

        // Método para obtener todos los clientes
        public List<Cliente> ObtenerTodos()
        {
            return clienteRepository.ObtenerTodos();
        }

        // Método para obtener clientes inactivos
        public List<Cliente> ObtenerClientesInactivos()
        {
            return clienteRepository.ObtenerClientesInactivos();
        }

        // Método para reactivar un cliente
        public void ReactivarCliente(int id)
        {
            ValidarExistenciaCliente(id);
            clienteRepository.ReactivarCliente(id);
        }

        /// <summary>
        /// Busca un cliente por su CUIT
        /// </summary>
        /// <param name="cuit">CUIT del cliente a buscar (se limpia automáticamente)</param>
        /// <returns>Cliente encontrado o null si no existe</returns>
        public Cliente BuscarPorCUIT(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return null;

            // Limpiar el CUIT (remover guiones y espacios)
            string cuitLimpio = cuit.Replace("-", "").Replace(" ", "").Trim();
            
            if (string.IsNullOrEmpty(cuitLimpio))
                return null;

            return clienteRepository.BuscarPorCUIT(cuitLimpio);
        }

        // Método de validación para verificar la integridad del cliente antes de insertar o actualizar
        private void ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException("El cliente no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
                throw new ArgumentException("El apellido del cliente es obligatorio.");

            if (!string.IsNullOrWhiteSpace(cliente.Mail) && !EsEmailValido(cliente.Mail))
                throw new ArgumentException("El formato del email no es válido.");

            // Validar CUIT si se proporciona
            if (!string.IsNullOrWhiteSpace(cliente.CUIT) && !EsCUITValido(cliente.CUIT))
                throw new ArgumentException("El formato del CUIT no es válido.");
        }

        // Método de validación para verificar la existencia de un cliente antes de actualizar o eliminar
        private void ValidarExistenciaCliente(int clienteId)
        {
            var cliente = clienteRepository.ObtenerPorId(clienteId);
            if (cliente == null)
                throw new ArgumentException($"El cliente con Id {clienteId} no existe.");
        }

        // Método auxiliar para validar el formato del email
        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Método auxiliar para validar el formato del CUIT (básico)
        private bool EsCUITValido(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return false;

            // Remover guiones si los tiene
            cuit = cuit.Replace("-", "");

            // Verificar que tenga 11 dígitos
            if (cuit.Length != 11)
                return false;

            // Verificar que todos sean números
            return cuit.All(char.IsDigit);
        }
    }
} 