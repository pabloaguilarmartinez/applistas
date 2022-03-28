using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AppListaSeñales.Utils
{
    /// <summary>
    /// Procedimiento que abre una conexión
    /// </summary>
    /// <returns>Devuelve la conexión</returns>
    public class Conexiones
    {
        public static SqlConnection openConnection()
        {
            SqlConnection connection = new SqlConnection();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "SRVIASDES011";
            builder.InitialCatalog = "SCADA_SISCON";
            builder.UserID = "sa";
            builder.Password = "123qweASD";

            // Conexión
            try
            {
                connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
            }
            catch (SqlException e)
            {
                Log.Logger(e.ToString());
            }

            return connection;
        }

        /// <summary>
        /// Procedimiento que cierra la conexión que se le pasa como parámetro.
        /// </summary>
        /// <param name="cnn">Conexión</param>
        public static void closeConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (SqlException e)
            {
                Log.Logger(e.ToString());
            }
        }
    }
}
