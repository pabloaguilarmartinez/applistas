using AppListaSeñales.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AppListaSeñales.Repository
{

    public class PlantillaRepository
    {
        #region Constructor
        public PlantillaRepository()
        {
        }
        #endregion

        public DataTable findTipoPlantillaAll()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT DISTINCT sTipoPlantilla FROM AppListaSeñales.PLANTILLA ORDER BY sTipoPlantilla";
                SqlCommand command = new SqlCommand(cadenaSql, connection);
                //SqlDataReader reader = command.ExecuteReader();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                // Insertamos al principio fila en blanco para el Combo Box
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                // Cerramos conexión
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
            return dt;
        }

        public DataTable findByTipoPlantilla(String tipoPlantilla)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT P1.sNombrePlantilla, P1.sNombreAtributo, P1.sDescripcion, ");
                cadenaSql.Append("P1.nMaxCuentas, P1.nMinCuentas, P1.nMaxRango, P1.nMinRango, P1.sUnidad, P1.sHistorico, P1.sAlarma, ");
                cadenaSql.Append("(SELECT COUNT(*) FROM AppListaSeñales.PLANTILLA P2 WHERE P1.sNombrePlantilla = P2.sNombrePlantilla) AS orden ");
                cadenaSql.Append(" FROM AppListaSeñales.PLANTILLA P1 WHERE sTipoPlantilla = '" + tipoPlantilla + "' ");
                cadenaSql.Append("AND (sNombreAtributo LIKE 'A[_]%' OR sNombreAtributo LIKE 'V[_]%' OR sNombreAtributo LIKE 'M[_]%'");
                cadenaSql.Append("OR sNombreAtributo LIKE 'C[_]%' OR sNombreAtributo LIKE 'P[_]%' OR sNombreAtributo LIKE 'E[_]%'");
                cadenaSql.Append("OR sNombreAtributo LIKE 'T[_]%') ");
                cadenaSql.Append("ORDER BY orden, P1.sNombrePlantilla");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);

                // Cerramos conexión
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
            return dt;
        }

        public DataTable findNombrePlantillaByTipoPlantilla(String tipoPlantilla)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT DISTINCT sNombrePlantilla FROM AppListaSeñales.PLANTILLA WHERE sTipoPlantilla = '" + tipoPlantilla + "'";
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

        public List<String> findAtributosByNombrePlantilla(String nombrePlantilla)
        {
            List<String> atributos = new List<String>();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT sNombreAtributo FROM AppListaSeñales.PLANTILLA ");
                cadenaSql.Append("WHERE sNombrePlantilla LIKE '");
                cadenaSql.Append(nombrePlantilla + "' ");
                cadenaSql.Append("AND (sNombreAtributo LIKE 'A[_]%' OR sNombreAtributo LIKE 'V[_]%' OR sNombreAtributo LIKE 'M[_]%'");
                cadenaSql.Append("OR sNombreAtributo LIKE 'C[_]%' OR sNombreAtributo LIKE 'P[_]%' OR sNombreAtributo LIKE 'E[_]%'");
                cadenaSql.Append("OR sNombreAtributo LIKE 'T[_]%')");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    String atributo = reader["sNombreAtributo"].ToString();
                    atributos.Add(atributo);
                }
                // Cerramos conexión
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
            return atributos;
        }
    }
}
