using BEs;
using BEs.Clases;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MPPs
{
    public class MPP_USUARIO : IGeneric<Usuario>
    {
        public MPP_USUARIO()
        {
            oCnx = Conexion.Instance; // Usando el patrón Singleton para la conexión
        }

        private Conexion oCnx;

        #region ABML

        public bool Agregar(Usuario entidad)
        {
            try
            {
                // Se guarda el usuario en la BD
                Hashtable Parametros = new Hashtable();
                Parametros.Add("@Email", entidad.Email);
                Parametros.Add("@Contraseña", entidad.Contraseña);
                Parametros.Add("@DV", entidad.DV);
                return oCnx.Guardar("Guardar_Usuario", Parametros);
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Borrar(Usuario entidad)
        {
            try
            {
                Hashtable Parametros = new Hashtable();
                Parametros.Add("@Id", entidad.Id);
                return oCnx.Guardar("Borrar_Usuario", Parametros);
            }
            catch (Exception ex) { throw ex; }
        }

        public bool Modificar(Usuario entidad)
        {
            try
            {
                Hashtable Parametros = new Hashtable();
                Parametros.Add("@Id", entidad.Id);
                Parametros.Add("@Email", entidad.Email);
                Parametros.Add("@Contraseña", entidad.Contraseña);
                Parametros.Add("@DV", entidad.DV);
                return oCnx.Guardar("Guardar_Usuario", Parametros);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Usuario> Listar()
        {
            try
            {
                DataTable dt = oCnx.Leer("Leer_Usuarios", null);
                return dt?.AsEnumerable().Select(row => new Usuario((int)row["Id"], row["Email"].ToString(), row["Contraseña"].ToString(), row["DigitoVerificador"].ToString())).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Usuario> ListarUsuariosActivos()
        {
            try
            {
                DataTable dt = oCnx.Leer("Leer_Usuarios_Activos", null);
                return dt?.AsEnumerable().Select(row => new Usuario((int)row["Id"], row["Email"].ToString(), row["Contraseña"].ToString(), row["DigitoVerificador"].ToString())).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion ABML

        #region Login/LogOut

        public Usuario BuscarUsuarioPorCredenciales(string email)
        {
            try
            {
                Hashtable Parametros = new Hashtable();
                Parametros.Add("@Email", email);
                DataTable dt = oCnx.Leer("LogIn", Parametros);
                if (dt.Rows.Count > 0)
                {
                    return dt?.AsEnumerable().Select(row => new Usuario((int)row["Id"], row["Email"].ToString(), row["Contraseña"].ToString(), row["DigitoVerificador"].ToString())).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { throw ex; }
        } //Método para buscar usuario específico por email y contraseña

        #endregion Login/LogOut

        #region DV

        public bool ActualizarDigitoVertical(string DV)
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Tabla", "Usuarios");
            Parametros.Add("@DVV", DV);
            return oCnx.Guardar("Guardar_DigitoVertical", Parametros);
        }

        public string VerificarSeguridad()
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Tabla", "Usuarios");

            DataTable Datos = oCnx.Leer("ListarControlSeguridad", Parametros);
            foreach (DataRow row in Datos.Rows)
            {
                return row["Digito"].ToString();
            }
            return "-1";
        }

        #endregion DV

        #region Historial

        public bool Restaurar(HistorialUsuario oHistorial)
        {
            try
            {
                Hashtable Parametros = new Hashtable();
                Parametros.Add("@Id", oHistorial.Id);

                return oCnx.Guardar("Recuperar", Parametros);
            }
            catch (Exception ex) { throw ex; }
        }

        public List<HistorialUsuario> ListarHistorial(Usuario oUsuario)
        {
            List<HistorialUsuario> Lista = new List<HistorialUsuario>();
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id_Usuario", oUsuario.Id);
            DataTable dataTable = oCnx.Leer("Leer_Historia", Parametros);

            foreach (DataRow row in dataTable.Rows)
            {
                HistorialUsuario oHistorial = new HistorialUsuario((DateTime)row["Fecha"], row["Email"].ToString(), (bool)row["Activo"], (int)row["Id"], row["DigitoVerificador"].ToString());
                Lista.Add(oHistorial);
            }
            return Lista;
        }

        #endregion Historial
    }
}