using System.Collections.Generic;

namespace BEs.Interfaces
{
    public interface IIdioma : IEntidad
    {
        string Nombre { get; set; }
        IList<ITraduccion> Traducciones { get; set; }

        void AgregarTraduccion(ITraduccion traduccion);

        string BuscarTraduccion(string texto);
    }
}