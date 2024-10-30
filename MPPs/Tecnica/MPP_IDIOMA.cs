using BEs;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs
{
    public class MPP_IDIOMA
    {
        private Conexion oCnx;

        public MPP_IDIOMA()
        {
            oCnx = Conexion.Instance;
        }

        #region ABML

        public bool Agregar(Idioma idioma)
        {
            Hashtable Parametros = new Hashtable
            {
                { "@Nombre", idioma.Nombre }
            };
            return oCnx.Guardar("Guardar_Idioma", Parametros);
        }

        public bool Modificar(Idioma idioma)
        {
            Hashtable Parametros = new Hashtable
            {
                { "@Id", idioma.Id },
                { "@Nombre", idioma.Nombre }
            };
            return oCnx.Guardar("Guardar_Idioma", Parametros);
        }

        public bool Borrar(Idioma idioma)
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id", idioma.Id);
            return oCnx.Guardar("Borrar_Idioma", Parametros);
        }

        public List<Idioma> Listar()
        {
            try
            {
                DataTable dt = oCnx.Leer("Listar_Todos_Idiomas", null);
                List<Idioma> idiomas = new List<Idioma>();

                foreach (DataRow row in dt.Rows)
                {
                    Idioma idioma = new Idioma
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Nombre = Convert.ToString(row["Nombre"])
                    };
                    idiomas.Add(idioma);
                }

                return idiomas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los idiomas: " + ex.Message, ex);
            }
        }

        #endregion ABML
    }
}