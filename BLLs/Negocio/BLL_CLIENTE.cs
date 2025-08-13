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

        /// <summary>
        /// Busca clientes por un criterio y texto de búsqueda. Filtra en memoria para evitar lógica en la UI.
        /// Criterios soportados: CUIT, Nombre, Apellido, Direccion, Email, Telefono, Estado
        /// </summary>
        public List<Cliente> BuscarClientes(string criterio, string texto, bool incluirInactivos = true)
        {
            var todos = ObtenerTodos();

            if (!incluirInactivos)
            {
                todos = todos.Where(c => c.Estado).ToList();
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
                    return todos.Where(c => !string.IsNullOrEmpty(c.CUIT) &&
                                             c.CUIT.Replace("-", string.Empty).Replace(" ", string.Empty)
                                                 .Contains(cuitLimpio)).ToList();
                case "nombre":
                    return todos.Where(c => (c.Nombre ?? string.Empty).ToLowerInvariant().Contains(valorNorm)).ToList();
                case "apellido":
                    return todos.Where(c => (c.Apellido ?? string.Empty).ToLowerInvariant().Contains(valorNorm)).ToList();
                case "direccion":
                    return todos.Where(c => (c.Direccion ?? string.Empty).ToLowerInvariant().Contains(valorNorm)).ToList();
                case "email":
                case "mail":
                    return todos.Where(c => (c.Mail ?? string.Empty).ToLowerInvariant().Contains(valorNorm)).ToList();
                case "telefono":
                case "teléfono":
                    return todos.Where(c => (c.Telefono ?? string.Empty).ToLowerInvariant().Contains(valorNorm)).ToList();
                case "estado":
                    bool? estado = null;
                    if (valorNorm == "activo") estado = true;
                    if (valorNorm == "inactivo") estado = false;
                    return estado.HasValue ? todos.Where(c => c.Estado == estado.Value).ToList() : todos;
                default:
                    // Si el criterio no coincide, buscar de forma amplia en varios campos
                    return todos.Where(c =>
                        (c.CUIT ?? string.Empty).ToLowerInvariant().Contains(valorNorm) ||
                        (c.Nombre ?? string.Empty).ToLowerInvariant().Contains(valorNorm) ||
                        (c.Apellido ?? string.Empty).ToLowerInvariant().Contains(valorNorm) ||
                        (c.Mail ?? string.Empty).ToLowerInvariant().Contains(valorNorm) ||
                        (c.Telefono ?? string.Empty).ToLowerInvariant().Contains(valorNorm) ||
                        (c.Direccion ?? string.Empty).ToLowerInvariant().Contains(valorNorm)
                    ).ToList();
            }
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

        // Método auxiliar para validar el formato del CUIT (reglas Argentina)
        private bool EsCUITValido(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                return false;

            // Remover guiones si los tiene
            cuit = cuit.Replace("-", "").Replace(" ", "");

            // Verificar que tenga 11 dígitos
            if (cuit.Length != 11)
                return false;

            // Verificar que todos sean números
            if (!cuit.All(char.IsDigit))
                return false;

            // Obtener los primeros dos dígitos para validar el tipo
            string prefijo = cuit.Substring(0, 2);

            // Validar según tipo de persona/entidad
            switch (prefijo)
            {
                case "20": // Hombre
                    return cuit.EndsWith("2");
                case "27": // Mujer
                    return cuit.EndsWith("4");
                case "30": // Empresa
                case "33":
                case "34":
                    return true;
                default:
                    return false;
            }
        }
    }
} 