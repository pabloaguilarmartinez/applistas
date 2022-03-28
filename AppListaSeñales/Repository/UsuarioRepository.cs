using AppListaSeñales.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AppListaSeñales.Repository
{
    public class UsuarioRepository
    {
        #region Constructor
        public UsuarioRepository()
        {
        }
        #endregion

        #region FindPasswordByUser
        public String findPasswordByUser(String user)
        {
            String password = null;
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT contrasena FROM AppListaSeñales.USUARIO WHERE usuario = " + "'" + user + "'";
                SqlCommand command = new SqlCommand(cadenaSql, connection);
                SqlDataReader reader = command.ExecuteReader();

                
                if (reader.Read())
                {
                    password = reader["contrasena"].ToString();
                }

                Conexiones.closeConnection(connection);
            }
            catch (SqlException e)
            {
                Log.Logger(e.ToString());
            }
            finally
            {
                // Cerramos conexión
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    Conexiones.closeConnection(connection);
                }
            }
            return password;
        }
        #endregion
    }
}
