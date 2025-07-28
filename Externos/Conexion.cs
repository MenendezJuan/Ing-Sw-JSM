using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Servicios
{
    public class Conexion
    {
        // Variable para mantener la única instancia de Conexion
        private static Conexion _instance;

        // Objeto para bloquear el acceso simultáneo en ambientes multihilo
        private static readonly object _lock = new object();

        private SqlConnection oCnx;
        private SqlTransaction oTransaction;
        private SqlCommand oCmd;

        // Constructor privado para evitar instanciación directa
        private Conexion()
        {
            oCnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Juan"].ConnectionString);
        }

        // Propiedad para acceder a la instancia única
        public static Conexion Instance
        {
            get
            {
                // Si la instancia es nula, intentar obtener el bloqueo y crearla
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        // Doble verificación para asegurar que aún no se ha creado
                        if (_instance == null)
                        {
                            _instance = new Conexion();
                        }
                    }
                }
                return _instance;
            }
        }

        // Método para ejecutar comandos de guardado en la base de datos
        public bool Guardar(string Query, Hashtable Parametros)
        {
            oCnx.Open(); // Abrir la conexión
            oTransaction = oCnx.BeginTransaction(); // Iniciar una transacción
            oCmd = new SqlCommand(Query, oCnx, oTransaction); // Crear el comando SQL
            oCmd.CommandType = CommandType.StoredProcedure;
            foreach (string key in Parametros.Keys)
            {
                oCmd.Parameters.AddWithValue(key, Parametros[key]);
            }
            try
            {
                oCmd.ExecuteNonQuery();
                oTransaction.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                oTransaction.Rollback();// Revertir la transacción en caso de error SQL
                throw new Exception("SQL Error: " + ex.Message, ex);
            }
            finally
            {
                oCnx.Close(); // Cerrar la conexión
            }
        }

        // Método para ejecutar comandos de guardado en la base de datos y devolver un valor
        public int GuardarConRetorno(string Query, Hashtable Parametros)
        {
            oCnx.Open(); // Abrir la conexión
            oTransaction = oCnx.BeginTransaction(); // Iniciar una transacción
            oCmd = new SqlCommand(Query, oCnx, oTransaction); // Crear el comando SQL
            oCmd.CommandType = CommandType.StoredProcedure;

            // Agregar parámetros al comando
            foreach (string key in Parametros.Keys)
            {
                oCmd.Parameters.AddWithValue(key, Parametros[key]);
            }

            try
            {
                // Ejecutar el comando y devolver el valor generado
                var result = oCmd.ExecuteScalar();
                oTransaction.Commit(); // Confirmar la transacción
                return Convert.ToInt32(result); // Devolver el ID como un entero
            }
            catch (SqlException ex)
            {
                oTransaction.Rollback(); // Revertir la transacción en caso de error SQL
                throw new Exception("SQL Error: " + ex.Message, ex);
            }
            finally
            {
                oCnx.Close(); // Cerrar la conexión
            }
        }


        // Método para leer datos de la base de datos de forma asincrona
        public DataTable Leer(string Query, Hashtable Parametros)
        {
            try
            {
                oCnx.Open(); // Abrir la conexión
                oCmd = new SqlCommand(Query, oCnx); // Crear el comando SQL
                oCmd.CommandType = CommandType.StoredProcedure;

                if (Parametros != null)
                {
                    foreach (string entry in Parametros.Keys)
                    {
                        oCmd.Parameters.AddWithValue(entry, Parametros[entry]); // Añadir parámetros al comando
                    }
                }

                SqlDataAdapter Da = new SqlDataAdapter(oCmd); // Crear un adaptador de datos
                DataTable Datos = new DataTable(); // Crear tabla para almacenar los datos
                Da.Fill(Datos); // Llenar la tabla con los datos
                oCnx.Close();
                return Datos;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Error: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCnx.Close(); // Cerrar la conexión
            }
        }

        // Método para ejecutar comandos SQL directos (para backup/restore)
        public bool EjecutarComandoSQL(string sqlCommand, int timeoutMinutos = 10)
        {
            try
            {
                oCnx.Open();
                oCmd = new SqlCommand(sqlCommand, oCnx);
                oCmd.CommandType = CommandType.Text; // Comando SQL directo
                oCmd.CommandTimeout = timeoutMinutos * 60; // Convertir minutos a segundos
                
                oCmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Error: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCnx.Close();
            }
        }

        // Método para obtener información de la base de datos actual
        public string ObtenerNombreBaseDatos()
        {
            try
            {
                oCnx.Open();
                return oCnx.Database;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener nombre de base de datos: " + ex.Message, ex);
            }
            finally
            {
                oCnx.Close();
            }
        }
    }
}