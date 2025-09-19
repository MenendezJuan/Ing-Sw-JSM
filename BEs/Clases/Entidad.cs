using BEs.Clases;

namespace BEs
{
    public class Entidad : IEntidad
    {
        [PropiedadVerificable(0)]
        public int Id { get; set; }
    }
}