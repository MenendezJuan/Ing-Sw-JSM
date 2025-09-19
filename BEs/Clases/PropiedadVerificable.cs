using System;

namespace BEs.Clases
{
    /// <summary>
    /// Atributo para marcar propiedades que deben incluirse en el cálculo del dígito verificador
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PropiedadVerificable : Attribute
    {
        /// <summary>
        /// Orden de la propiedad en el cálculo del hash (opcional)
        /// </summary>
        public int Orden { get; set; } = 0;

        /// <summary>
        /// Indica si la propiedad es crítica para la integridad
        /// </summary>
        public bool Critica { get; set; } = true;

        /// <summary>
        /// Nombre personalizado para la propiedad en el hash (opcional)
        /// </summary>
        public string Nombre { get; set; }

        public PropiedadVerificable()
        {
        }

        public PropiedadVerificable(int orden)
        {
            Orden = orden;
        }

        public PropiedadVerificable(int orden, bool critica)
        {
            Orden = orden;
            Critica = critica;
        }
    }
}