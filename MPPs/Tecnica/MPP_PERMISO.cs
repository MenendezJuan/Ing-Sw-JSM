using BEs;
using BEs.Clases;
using Servicios;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MPPs
{
    public class MPP_PERMISO
    {
        public MPP_PERMISO()
        { oCnx = Conexion.Instance; }

        private Conexion oCnx;

        #region ABM

        public bool Agregar(Componente Padre, Componente Hijo)
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id_Padre", Padre.Id);
            Parametros.Add("@Id_Hijo", Hijo.Id);
            return oCnx.Guardar("Guardar_Permiso", Parametros);
        }// Agrega permiso en grupo

        public bool Borrar(Componente permiso, GrupoPermisos padre)
        {
            Hashtable Parametros = new Hashtable();
            if (padre == null) { Parametros.Add("@Id_Padre", 0); }
            else { Parametros.Add("@Id_Padre", padre.Id); }
            Parametros.Add("@Id_Hijo", permiso.Id);
            return oCnx.Guardar("Borrar_Permiso", Parametros);
        }// Borrar Permiso de grupo

        public bool BorrarGrupo(GrupoPermisos entidad)
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id", entidad.Id);
            return oCnx.Guardar("Borrar_Grupo", Parametros);
        }// Borra un grupo

        public bool AgregarGrupo(Componente Grupo)
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Nombre", Grupo.Nombre);
            return oCnx.Guardar("Guardar_Grupo", Parametros);
        }// Crea un grupo

        public List<Componente> ListarPermisosRecursivos(int idPermisoPadre)
        {
            List<Componente> lista = new List<Componente>();
            Hashtable parametros = new Hashtable();
            parametros.Add("@IdPermisoPadre", idPermisoPadre);

            // Llama al stored procedure y obtiene los datos en un DataTable
            DataTable data = oCnx.Leer("ObtenerPermisosRecursivos", parametros);

            // Recorre los resultados y los convierte en una estructura de permisos
            foreach (DataRow row in data.Rows)
            {
                Componente oComponente;
                if ((bool)row["Es_Padre"])
                {
                    oComponente = new GrupoPermisos((int)row["Id"], row["Nombre"].ToString());
                }
                else
                {
                    oComponente = new Permiso((int)row["Id"], row["Nombre"].ToString());
                }

                lista.Add(oComponente);
            }

            return lista;
        }

        #endregion ABM

        #region Listar

        public List<Componente> ListarPermisos()
        {
            List<Componente> Lista = new List<Componente>();
            DataTable data = oCnx.Leer("Listar_Permisos", null);
            foreach (DataRow row in data.Rows)
            {
                Componente oComponente;
                if ((bool)row["Es_Padre"])
                {
                    oComponente = new GrupoPermisos((int)row["Id"], row["Nombre"].ToString());
                }//Si es necesario agregar funcion para cargar el grupo (CargarPermisos)
                else
                {
                    oComponente = new Permiso((int)row["Id"], row["Nombre"].ToString());
                }
                Lista.Add(oComponente);
            }
            return Lista;
        }// Lista los permisos (Ramas/Hojas)

        public List<Componente> ListarGrupos()
        {
            DataTable Datos = oCnx.Leer("Listar_Grupos", null);
            List<int> Ultimos = new List<int>();
            List<Componente> lista = new List<Componente>();

            foreach (DataRow row in Datos.Rows)
            {
                if (Ultimos.Contains((int)row["Id_Padre"]))
                {
                    continue;
                }
                if ((bool)row["Es_Padre_Padre"])
                {
                    GrupoPermisos grupoPermisos = new GrupoPermisos((int)row["Id_Padre"], row["Nombre_Padre"].ToString());
                    lista.Add(CargarPermisos(grupoPermisos, Datos));
                    Ultimos.Add((int)row["Id_Padre"]);
                }
            }
            return lista;
        }// Listar grupos

        public List<Componente> BuscarPermisosAsignados(Usuario oUsuario)
        {
            List<Componente> Lista = new List<Componente>();
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id_Usuario", oUsuario.Id);
            DataTable da = oCnx.Leer("Buscar_Permisos_Asignados", Parametros);
            foreach (DataRow row in da.Rows)
            {
                GrupoPermisos oGrupo = new GrupoPermisos((int)row["Id"], row["Nombre"].ToString());
                Lista.Add(CargarPermisos(oGrupo, null));
            }
            return Lista;
        }// Permisos de X usuario

        public Componente CargarPermisos(Componente oComponente, DataTable tabla)
        {
            if (tabla == null)
            {
                tabla = oCnx.Leer("Listar_Grupos", null);
            }
            foreach (DataRow row in tabla.Rows)
            {
                if ((int)row["Id_Padre"] == oComponente.Id)
                {
                    if ((bool)row["Es_Padre_Hijo"])
                    {
                        GrupoPermisos grupoPermisosHijo = new GrupoPermisos((int)row["Id_Hijo"], row["Nombre_Hijo"].ToString());
                        CargarPermisos(grupoPermisosHijo, tabla);
                        oComponente.AgregarHijo(grupoPermisosHijo);
                    }
                    else
                    {
                        Permiso oPermiso = new Permiso((int)row["Id_Hijo"], row["Nombre_Hijo"].ToString());
                        oComponente.AgregarHijo(oPermiso);
                    }
                }
            }
            return oComponente;
        }// Llena los grupos

        #endregion Listar

        #region Asignacion de Permisos

        public bool AsignarGrupo(GrupoPermisos oGrupo, Usuario oUsuario)
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id_Grupo", oGrupo.Id);
            Parametros.Add("@Id_Usuario", oUsuario.Id);
            return oCnx.Guardar("Asignar_Grupo", Parametros);
        }// Asigna un grupo a un usuario

        public bool DesAsignar(GrupoPermisos oGrupo, Usuario oUsuario)
        {
            Hashtable Parametros = new Hashtable();
            Parametros.Add("@Id_Grupo", oGrupo.Id);
            Parametros.Add("@Id_Usuario", oUsuario.Id);
            return oCnx.Guardar("DesAsignar_Grupo", Parametros);
        }// Desasigna un grupo a un usuario

        #endregion Asignacion de Permisos
    }
}