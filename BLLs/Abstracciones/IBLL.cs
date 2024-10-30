using System.Collections.Generic;

namespace BLLs.Abstracciones
{
    public interface IBLL<T>
    {
        void Insertar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
        T ObtenerPorId(int id);
        List<T> ObtenerTodos();
    }
}
