using BEs;
using BEs.Clases;
using MPPs;
using System;
using System.Collections.Generic;

namespace BLLs
{
    public class BLL_PERMISO
    {
        public BLL_PERMISO()
        {
            Mpp_Permiso = new MPP_PERMISO();
            Mpp_Bitacora = new MPP_BITACORA();
        }

        private MPP_PERMISO Mpp_Permiso;
        private MPP_BITACORA Mpp_Bitacora;

        #region ABM

        public bool Agregar(Componente Padre, Componente Hijo)
        {
            try
            {
                if (Mpp_Permiso.Agregar(Padre, Hijo))
                {
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se agrego un permiso a un grupo");
                }
                return false;
            }
            catch (Exception)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al agregar un permiso a un grupo");
                throw new Exception("Error al agregar un permiso a grupo");
            }
        } // Agregar Permiso a grupo

        public bool Borrar(Componente entidad, GrupoPermisos Padre)
        {
            try
            {
                if (Mpp_Permiso.Borrar(entidad, Padre))
                {
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se borro un permiso de un grupo");
                }
                return false;
            }
            catch (Exception)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al borrar un permiso de un grupo");
                throw new Exception("Error al borrar permiso de grupo");
            }
        }// Borrar Permiso de grupo

        public bool AgregarGrupo(Componente Grupo)
        {
            try
            {
                if (Mpp_Permiso.AgregarGrupo(Grupo))
                {
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se Agrego un grupo");
                }
                return false;
            }
            catch (Exception)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al agregar un grupo");
                throw new Exception("Error al agregar un grupo");
            }
        } // Crear grupo

        public bool BorrarGrupo(GrupoPermisos entidad)
        {
            try
            {
                if (Mpp_Permiso.BorrarGrupo(entidad))
                {
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se borro un grupo");
                }
                return false;
            }
            catch (Exception)
            {
                return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al borrar un grupo");
                throw new Exception("Error al borrar un grupo");
            }
        } // Borrar grupo

        #endregion ABM

        #region Listar

        public List<Componente> ListarGrupos()
        {
            try
            {
                List<Componente> Lista = Mpp_Permiso.ListarGrupos();
                if (Lista.Count > 0)
                {
                    Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se listan los grupos");
                    return Lista;
                }
                return null;
            }
            catch (Exception)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al listar los grupos");
                throw new Exception("Error al listar los grupos");
            }
        } // Listar Grupos

        public List<Componente> ListarPermisos()
        {
            try
            {
                List<Componente> Lista = Mpp_Permiso.ListarPermisos();
                if (Lista.Count > 0)
                {
                    Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se listan los permisos");
                    return Lista;
                }
                return null;
            }
            catch (Exception)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al listar permisos");
                throw new Exception("Error al listar permisos");
            }
        } // Listar Permisos

        public List<Componente> BuscarPermisosAsignados(Usuario oUsuario)
        {
            try
            {
                List<Componente> Lista = Mpp_Permiso.BuscarPermisosAsignados(oUsuario);
                if (Lista.Count > 0)
                {
                    Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se listan los permisos asignados de usuario");
                    return Lista;
                }
                return null;
            }
            catch (Exception)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al listan los permisos asignados a usuario");
                throw new Exception("Error al buscar permisos asignados a usuario");
            }
        } // Listar permisos asignados a usuario

        public List<Componente> ObtenerPermisosRecursivos(int idPermisoPadre)
        {
            try
            {
                List<Componente> listaPermisos = Mpp_Permiso.ListarPermisosRecursivos(idPermisoPadre);

                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se listaron permisos recursivos");

                return listaPermisos ?? new List<Componente>(); // Retornar una lista vacía si es null
            }
            catch (Exception)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al listar permisos recursivos");
                throw new Exception("Error al listar permisos recursivos");
            }
        }

        #endregion Listar

        #region Asignacion de Permisos

        public bool AsignarGrupo(GrupoPermisos oGrupo, Usuario oUsuario)
        {
            try
            {
                if (Mpp_Permiso.AsignarGrupo(oGrupo, oUsuario))
                {
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se le asigno un grupo al usuario");
                }
                return false;
            }
            catch (Exception)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al asignar grupo al usuario");
                throw new Exception("Error al asignar un grupo al usuario");
            }
        } // Asignar grupo a usuario

        public bool DesAsignar(GrupoPermisos oGrupo, Usuario oUsuario)
        {
            try
            {
                if (Mpp_Permiso.DesAsignar(oGrupo, oUsuario))
                {
                    return Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ABML, "Se le desasigno un grupo al usuario");
                }
                return false;
            }
            catch (Exception)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al desasignar grupo al usuario");
                throw new Exception("Error al desasignar grupo al usuario");
            }
        } // Desasignar grupo a usuario

        #endregion Asignacion de Permisos

        #region Validacion permisos

        private List<Componente> listaDePermisos = new List<Componente>();

        public bool ValidarBucle(Componente padre, Componente hijo)
        {
            try
            {
                if (listaDePermisos.Count <= 0)
                {
                    listaDePermisos = ListarGrupos();// Lista los grupos
                }

                if (hijo.Id == padre.Id)
                {
                    Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.VALIDACION, "Validacion Permiso en grupo");
                    return true;
                }

                foreach (Componente p in listaDePermisos)
                {
                    if (p is GrupoPermisos)
                    {
                        if (p.Id == hijo.Id)
                        {
                            if (comparar(padre, p))
                            {
                                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.VALIDACION, "Validacion Permiso en grupo");
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (p.Id == hijo.Id)
                        {
                            return true;
                        }
                    }
                }
                listaDePermisos.Clear();
                return false;
            }
            catch (Exception)
            {
                Mpp_Bitacora.Agregar(SessionManager.GetInstance().oUsuario, Enum_TiposBitacora.ERROR, "Error al validar permiso en grupo");
                throw new Exception("Error al validar permiso en grupo");
            }
        } // Valida permiso en grupo

        public bool comparar(Componente Padre, Componente comparacion)
        {
            if (comparacion is GrupoPermisos)
            {
                GrupoPermisos gp = (GrupoPermisos)comparacion;
                foreach (Componente c in gp.Permisos)
                {
                    if (Padre.Id == c.Id)
                    {
                        return true;
                    }
                    if (c is GrupoPermisos)
                    {
                        if (comparar(Padre, c)) { return true; }
                    }
                }
            }

            return false;
        } // Funcion recursiva para validar permiso en grupo

        #endregion Validacion permisos
    }
}