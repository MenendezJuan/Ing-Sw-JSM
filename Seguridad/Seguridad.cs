using BEs.Clases;
using BEs.Interfaces;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Servicios
{
    public class Seguridad
    {
        public static string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir el string de entrada en un array de bytes y calcular el hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir el array de bytes a un string de tipo hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string CalcularDigitoVerificadorHorizontal(IVerificableEntity entity)
        {
            // Reglas deterministas:
            // - Solo propiedades marcadas con PropiedadVerificable
            // - Ordenadas por atributo Orden y luego por nombre
            // - Para cada propiedad: concatenar su valor (normalizado) + suma ASCII de ese valor
            // - Excluir la propiedad DV

            Type t = entity.GetType();

            var verificables = t
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name != "DV")
                .Select(p => new
                {
                    Prop = p,
                    Attr = p.GetCustomAttributes().FirstOrDefault(a => a.GetType().Equals(typeof(PropiedadVerificable))) as PropiedadVerificable
                })
                .Where(x => x.Attr != null)
                .OrderBy(x => x.Attr.Orden)
                .ThenBy(x => x.Prop.Name)
                .ToList();

            var builder = new StringBuilder();

            foreach (var item in verificables)
            {
                object raw = item.Prop.GetValue(entity);
                string text = raw?.ToString() ?? string.Empty;

                // Normalización mínima para estabilidad
                text = text.Trim();

                int sum = 0;
                foreach (char c in text)
                {
                    sum += (int)c;
                }

                builder.Append(text);
                builder.Append(sum.ToString());
            }

            return Hash(builder.ToString());
        }
    }
}
