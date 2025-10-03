namespace BEs
{
    /// <summary>
    /// Clase para representar inconsistencias de integridad
    /// </summary>
    public class InconsistenciaIntegridad
    {
        public string TipoEntidad { get; set; }
        public int EntidadId { get; set; }
        public string Descripcion { get; set; }
        public string DVEsperado { get; set; }
        public string DVActual { get; set; }
        public string TipoError { get; set; } // "DV Horizontal" o "DV Vertical"
        public string ColumnaVertical { get; set; } // Solo para errores verticales

        public override string ToString()
        {
            if (TipoError == "DV Vertical")
            {
                return $"[{TipoError}] {TipoEntidad} - Columna: {ColumnaVertical}\n" +
                       $"Esperado: {DVEsperado}\n" +
                       $"Actual: {DVActual}";
            }
            else
            {
                return $"[{TipoError}] {TipoEntidad} (ID: {EntidadId})\n" +
                       $"{Descripcion}\n" +
                       $"Esperado: {DVEsperado}\n" +
                       $"Actual: {DVActual}";
            }
        }
    }
}


