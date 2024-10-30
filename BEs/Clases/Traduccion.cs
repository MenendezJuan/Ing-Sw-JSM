using BEs.Interfaces;

namespace BEs
{
    public class Traduccion : Entidad, ITraduccion
    {
        public string Palabra { get; set; }
        public string TraduccionTexto { get; set; }
        public int IdiomaId { get; set; }
        public int PalabraId { get; set; }
    }
}