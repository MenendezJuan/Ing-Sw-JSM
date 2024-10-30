using System.Collections.Generic;

namespace MPPs
{
    public interface IRepositorio<T>
    {
        void Insertar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
        T ObtenerPorId(int id);
        List<T> ObtenerTodos();
    }
}
