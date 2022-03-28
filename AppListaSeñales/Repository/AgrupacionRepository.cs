using AppListaSeñales.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AppListaSeñales.Repository
{
    public class AgrupacionRepository
    {
        #region Constructor
        public AgrupacionRepository()
        {
        }
        #endregion

        #region FindNameAll
        public DataTable findDescripcionAll()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT descripcion FROM AppListaSeñales.AGRUPACION  ORDER BY descripcion";
                SqlCommand command = new SqlCommand(cadenaSql, connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                // Insertamos al principio fila en blanco para el Combo Box
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0); 
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

            return dt;
        }
        #endregion

        public String findCodigoByDescripcion(String descripcion)
        {
            String codigo = "";

            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT codigo FROM AppListaSeñales.AGRUPACION WHERE descripcion = '" + descripcion + "'";
                SqlCommand command = new SqlCommand(cadenaSql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    codigo = reader["codigo"].ToString();
                } 
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
            return codigo;
        }
    }
}
