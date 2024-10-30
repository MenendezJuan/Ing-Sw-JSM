using System;

namespace BEs.Clases
{
    public class HistorialUsuario : Entidad
    {
        public HistorialUsuario()
        {
        }

        public HistorialUsuario(DateTime fecha, string email, bool activo, int id, string dv)
        {
            Fecha = fecha;
            Email = email;
            Activo = activo;
            Id = id;
            DV = dv;
        }

        public DateTime Fecha { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public string DV { get; set; }
    }
}