using System.Collections.Generic;

namespace BEs.Interfaces
{
    public interface IObservado
    {
        IList<IObservador> ObservadoresRegistrados { get; set; }

        void RegistrarObservador(IObservador observador);

        void DesregistrarObservador(IObservador observador);

        void NotificarObservadores();
    }
}