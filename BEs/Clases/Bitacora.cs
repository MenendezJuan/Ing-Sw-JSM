using System;

namespace BEs
{
    public class Bitacora : Entidad
    {
        public Bitacora(int id, DateTime fecha, Enum_TiposBitacora accion, Usuario usuario, string descripcion)
        {
            Id = id;
            Fecha = fecha;
            Accion = accion;
            Usuario = usuario;
            Descripcion = descripcion;
        }

        public DateTime Fecha { get; set; }
        public Enum_TiposBitacora Accion { get; set; }
        public Usuario Usuario { get; set; }
        public string Descripcion { get; set; }
    }
}