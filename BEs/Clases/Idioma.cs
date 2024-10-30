using BEs.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BEs
{
    public class Idioma : Entidad, IIdioma
    {
        public string Nombre { get; set; }
        public IList<ITraduccion> Traducciones { get; set; } = new List<ITraduccion>();

        public void AgregarTraduccion(ITraduccion traduccion)
        {
            Traducciones.Add(traduccion);
        }

        public string BuscarTraduccion(string texto)
        {
            var traduccion = Traducciones.FirstOrDefault(t => t.Palabra == texto);
            return traduccion != null ? traduccion.TraduccionTexto : "";
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}