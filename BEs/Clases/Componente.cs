using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BEs.Clases
{
    public abstract class Componente : Entidad
    {
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public abstract void AgregarHijo(Componente c);

        public abstract void EliminarHijo(Componente c);

        public abstract IList<Componente> Listar();

        public override string ToString()
        {
            return Nombre;
        }
    }
}