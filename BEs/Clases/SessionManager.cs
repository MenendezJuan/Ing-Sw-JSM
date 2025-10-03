using BEs.Clases;
using BEs.Interfaces;
using System;
using System.Collections.Generic;

namespace BEs
{
    public class SessionManager : IObservado
    {
        public IList<IObservador> ObservadoresRegistrados { get; set; }
        public Usuario oUsuario { get; set; }
        public List<Componente> Permisos { get; set; }
        public DateTime FechaSesion { get; set; }

        private static SessionManager Sesion;
        public IIdioma Idioma { get; set; }

        private SessionManager()
        {
            ObservadoresRegistrados = new List<IObservador>();
            Permisos = new List<Componente>();
        }

        public static SessionManager GetInstance()
        {
            if (Sesion == null)
            {
                Sesion = new SessionManager(); // Se crea una nueva instancia si no existe.
            }
            return Sesion; // Siempre devuelve la instancia existente.
        }

        public void Login(Usuario user)
        {
            // Inicia sesión si no hay un usuario ya conectado.
            if (oUsuario == null)
            {
                oUsuario = user;
                FechaSesion = DateTime.Now;
                
                VerificarIntegridadBaseDatos();
            }
            else
            {
                throw new InvalidOperationException("Ya hay un usuario conectado. Inicie sesión antes de intentar nuevamente.");
            }
        }

        /// <summary>
        /// Verifica la integridad de la base de datos (DVH y DVV) al iniciar sesión
        /// </summary>
        private void VerificarIntegridadBaseDatos()
        {
            try
            {
                // Nota: Para evitar referencias circulares, esta verificación
                // se delega a la BLL que será llamada desde el formulario de login
                // Este método queda como placeholder para futuras implementaciones
                
                System.Diagnostics.Debug.WriteLine("SessionManager: Sesión iniciada, verificación DV pendiente");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en verificación DV: {ex.Message}");
                // No lanzar excepción para no interrumpir el login
            }
        }

        public static void Logout()
        {
            if (Sesion != null)
            {
                Sesion.oUsuario = null;
            }
            else
            {
                throw new Exception("Sesion no iniciada");
            }
        }

        public void RegistrarObservador(IObservador observador)
        {
            ObservadoresRegistrados.Add(observador);
        }

        public void DesregistrarObservador(IObservador observador)
        {
            if (ObservadoresRegistrados.Contains(observador))
            {
                ObservadoresRegistrados.Remove(observador);
            }
        }

        public void NotificarObservadores()
        {
            foreach (var observador in ObservadoresRegistrados)
            {
                observador.Actualizar(Idioma);
            }
        }

        public void CambiarIdioma(IIdioma nuevoIdioma)
        {
            Idioma = nuevoIdioma;
            NotificarObservadores();
        }
    }
}