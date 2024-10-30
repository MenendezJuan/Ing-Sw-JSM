using BEs;
using BEs.Interfaces;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs
{
    public class MPP_TRADUCCION
    {
        private Conexion oCnx;

        public MPP_TRADUCCION()
        {
            oCnx = Conexion.Instance;
        }

        #region ABML

        public bool Agregar(Traduccion traduccion)
        {
            Hashtable parametros = new Hashtable
            {
                { "@Id_Idioma", traduccion.IdiomaId },
                { "@Palabra", traduccion.Palabra },
                { "@TraduccionTexto", traduccion.TraduccionTexto }
            };
            return oCnx.Guardar("Guardar_Traduccion", parametros);
        }

        public bool Modificar(Traduccion traduccion)
        {
            Hashtable parametros = new Hashtable
            {
                { "@Id", traduccion.Id },
                { "@Id_Idioma", traduccion.IdiomaId },
                { "@Palabra", traduccion.Palabra },
                { "@TraduccionTexto", traduccion.TraduccionTexto }
            };
            return oCnx.Guardar("Guardar_Traduccion", parametros);
        }

        public bool Borrar(Traduccion traduccion)
        {
            Hashtable parametros = new Hashtable
            {
                { "@Id_Idioma", traduccion.IdiomaId },
                { "@Palabra", traduccion.Palabra }
            };
            return oCnx.Guardar("Borrar_Traduccion", parametros);
        }

        public List<ITraduccion> ListarPorIdioma(int idiomaId)
        {
            Hashtable parametros = new Hashtable
            {
                { "@Id_Idioma", idiomaId }
            };

            DataTable dt = oCnx.Leer("ListarTraduccionesPorIdioma", parametros);
            List<ITraduccion> traducciones = new List<ITraduccion>();

            foreach (DataRow row in dt.Rows)
            {
                ITraduccion traduccion = new Traduccion
                {
                    Id = Convert.ToInt32(row["Id"]),
                    IdiomaId = Convert.ToInt32(row["Id_Idioma"]),
                    Palabra = Convert.ToString(row["Palabra"]),
                    TraduccionTexto = Convert.ToString(row["TraduccionTexto"])
                };

                traducciones.Add(traduccion);
            }

            return traducciones;
        }

        public List<string> ListarPalabrasSinTraduccion(int idiomaId)
        {
            Hashtable parametros = new Hashtable
            {
                { "@Id_Idioma", idiomaId }
            };

            DataTable dt = oCnx.Leer("ListarPalabrasSinTraduccion", parametros);
            List<string> traducciones = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                traducciones.Add(row["Texto"].ToString());
            }

            return traducciones;
        }

        public string BuscarTraduccion(string tag, int idiomaId)
        {
            try
            {
                Hashtable parametros = new Hashtable
                {
                    { "@Tag", tag },
                    { "@Id_Idioma", idiomaId }
                };

                DataTable dt = oCnx.Leer("Buscar_Traduccion", parametros);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["TraduccionTexto"].ToString();
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar la traducción: " + ex.Message, ex);
            }
        }

        #endregion ABML
    }
}