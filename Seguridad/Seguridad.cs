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
            Type t = entity.GetType();
            string dvh = string.Empty;
            var props = t.GetProperties();

            foreach (var item in props)
            {
                var atributos = item.GetCustomAttributes();
                var verificable = atributos.FirstOrDefault(i => i.GetType().Equals(typeof(PropiedadVerificable)));

                int len = 0;
                if (item.Name == "DV") { continue; }
                if (verificable != null)
                {
                    dvh += item.GetValue(entity).ToString();
                    foreach (char c in dvh)
                    {
                        int asciiValue = (int)c;
                        len += asciiValue;
                    }
                    dvh += len.ToString();
                }
            }

            return Hash(dvh);
        }
    }
}