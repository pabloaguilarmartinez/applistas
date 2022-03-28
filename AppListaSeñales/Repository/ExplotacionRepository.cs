using AppListaSeñales.Entity;
using AppListaSeñales.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AppListaSeñales;
using System.Text;
using System.Data;

namespace AppListaSeñales.Repository
{
    public class ExplotacionRepository
    {
        public ExplotacionRepository()
        {
        }

        #region FindAll
        public List<Explotacion> findAll()
        {
            List<Explotacion> explotaciones = new List<Explotacion>();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT * FROM AppListaSeñales.Explotacion";
                SqlCommand command = new SqlCommand(cadenaSql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Explotacion explotacion = new Explotacion();
                    explotacion.Nombre = reader["nombre"].ToString();
                    explotacion.CebeAquacis = reader["cebeAquacis"].ToString();
                    explotacion.SitAquacis = reader["sitAquacis"].ToString();
                    explotacion.CebeIas = reader["cebeIas"].ToString();
                    explotacion.ExplotacionIas = reader["explotacionIas"].ToString();
                    explotacion.ServicioIas = reader["servicioIas"].ToString();
                    explotaciones.Add(explotacion);
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
            return explotaciones;
        }
        #endregion

        public DataTable findNombreExplotacionesCreadas()
        {    
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT DISTINCT nombre FROM AppListaSeñales.EXPLOTACION WHERE cebeIas IS NOT NULL ORDER BY nombre";
                SqlCommand command = new SqlCommand(cadenaSql, connection);
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

        public DataTable findNombreExplotacionesSinCrear()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT DISTINCT nombre FROM AppListaSeñales.EXPLOTACION WHERE cebeIas IS NULL ORDER BY nombre";
                SqlCommand command = new SqlCommand(cadenaSql, connection);
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

        public Explotacion findCodigosIasByNombre(String nombreExplotacion, String sitAquacis)
        {
            Explotacion explotacion = new Explotacion();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT cebeIas, explotacionIas, servicioIas FROM AppListaSeñales.EXPLOTACION WHERE nombre = '" 
                    + nombreExplotacion + "' AND sitAquacis = '" + sitAquacis + "'";
                SqlCommand command = new SqlCommand(cadenaSql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    explotacion.CebeIas = reader["cebeIas"].ToString();
                    explotacion.ServicioIas = reader["servicioIas"].ToString();
                    explotacion.ExplotacionIas = reader["explotacionIas"].ToString();
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
            return explotacion;
        }

        public List<Explotacion> findSitAquacisByNombre(String nombreExplotacion)
        {
            List<Explotacion> explotaciones = new List<Explotacion>();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT sitAquacis, servicioIas, observaciones FROM AppListaSeñales.EXPLOTACION WHERE nombre = '" + nombreExplotacion + "'";
                SqlCommand command = new SqlCommand(cadenaSql, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Explotacion explotacion = new Explotacion();
                    explotacion.SitAquacis = reader["sitAquacis"].ToString();
                    explotacion.ServicioIas = reader["servicioIas"].ToString();
                    explotacion.Observaciones = reader["observaciones"].ToString();
                    explotaciones.Add(explotacion);
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
            return explotaciones;
        }

        public String findCebeAquacisByNombre(String nombreExplotacion)
        {
            String cebeAquacias = "";
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                String cadenaSql = "SELECT DISTINCT cebeAquacis FROM AppListaSeñales.EXPLOTACION WHERE nombre = '" + nombreExplotacion + "'";
                SqlCommand command = new SqlCommand(cadenaSql, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    cebeAquacias = reader["cebeAquacis"].ToString();
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
            return cebeAquacias;
        }

        public int updateCebeIasExplotacion(String nombreExplotacion, String cebeIas)
        {
            int rows = 0;
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("UPDATE AppListaSeñales.EXPLOTACION SET cebeIas = '");
                cadenaSql.Append(cebeIas + "' WHERE nombre = '");
                cadenaSql.Append(nombreExplotacion + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                rows = command.ExecuteNonQuery();
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
            return rows;
        }

        public int findNumeroServiciosExplotacion(String nombre)
        {
            int rows = 0;
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT COUNT(*) as numeroServicios FROM AppListaSeñales.EXPLOTACION ");
                cadenaSql.Append("WHERE nombre = '" + nombre + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    rows = Convert.ToInt32(reader["numeroServicios"]);
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
            return rows;
        }

        public int findIdByExplotacion(String nombre, String sitAquacis)
        {
            int id = 0;
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT id FROM AppListaSeñales.EXPLOTACION ");
                cadenaSql.Append("WHERE nombre = '" + nombre + "' AND sitAquacis = '");
                cadenaSql.Append(sitAquacis + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
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
            return id;
        }
    }
}
