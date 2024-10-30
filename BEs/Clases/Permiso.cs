using System;
using System.Collections.Generic;

namespace BEs.Clases
{
    public class Permiso : Componente
    {
        public Permiso(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override void AgregarHijo(Componente c)
        {
            throw new NotImplementedException();
        }

        public override void EliminarHijo(Componente c)
        {
            throw new NotImplementedException();
        }

        public override IList<Componente> Listar()
        {
            throw new NotImplementedException();
        }
    }
}