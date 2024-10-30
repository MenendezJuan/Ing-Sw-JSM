using System.Collections.Generic;

namespace BEs.Clases
{
    public class GrupoPermisos : Componente
    {
        public List<Componente> Permisos;

        public GrupoPermisos(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Permisos = new List<Componente>();
        }

        public override void AgregarHijo(Componente c)
        {
            Permisos.Add(c);
        }

        public override void EliminarHijo(Componente c)
        {
            Permisos.Remove(c);
        }

        public override IList<Componente> Listar()
        {
            return Permisos.ToArray();
        }
    }
}