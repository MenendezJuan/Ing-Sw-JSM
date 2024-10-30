using System.Collections.Generic;

namespace BEs
{
    public interface IGeneric<T> where T : Entidad
    {
        bool Agregar(T entidad);

        bool Borrar(T entidad);

        bool Modificar(T entidad);

        List<T> Listar();
    }
}