using AppListaSeñales.Entity;
using AppListaSeñales.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AppListaSeñales.Repository
{
    public class EstacionRepository
    {
        #region Constructor
        public EstacionRepository()
        {
        }
        #endregion

        #region FindByNombreExplotacion
        public DataTable findByNombreExplotacion(String nombreExplotacion, String sitAquacis)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT E.nombre FROM AppListaSeñales.ESTACION E ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.EXPLOTACION EX ");
                cadenaSql.Append("on E.idExplotacion = EX.id ");
                cadenaSql.Append("WHERE EX.nombre = '" + nombreExplotacion + "' AND EX.sitAquacis = '" + sitAquacis + "' ");
                cadenaSql.Append("ORDER BY E.nombre");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
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
        #endregion

        public Int32 findNumeroEstacionByNombre(String nombreEstacion)
        {
            Int32 numeroEstacion = 0;
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT numero FROM AppListaSeñales.ESTACION ");
                cadenaSql.Append("WHERE nombre = '");
                cadenaSql.Append(nombreEstacion + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    numeroEstacion = (Int32)reader["numero"];
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
            return numeroEstacion;
        }

        public Int32 findNumeroEsclavoByNombre(String nombreEstacion)
        {
            Int32 numeroEsclavo = 0;
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT numeroEsclavo FROM AppListaSeñales.ESTACION ");
                cadenaSql.Append("WHERE nombre = '");
                cadenaSql.Append(nombreEstacion + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (!Convert.IsDBNull(reader["numeroEsclavo"]))
                    {
                        numeroEsclavo = (Int32)reader["numeroEsclavo"];
                    }    
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
            return numeroEsclavo;
        }
        public int create(String nombre, int numeroEstacion, int idExplotacion, decimal minRaw, decimal maxRaw, String comunicaciones, int numeroEsclavo)
        {
            int rows = 0;
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("INSERT INTO AppListaSeñales.ESTACION (nombre, numero, idExplotacion, minRaw, maxRaw, protocoloComunicacion, numeroEsclavo) VALUES ");
                cadenaSql.Append("('" + nombre + "', " + numeroEstacion + ", " + idExplotacion);
                cadenaSql.Append(", " + minRaw + ", " + maxRaw + ", '" + comunicaciones + "', " + numeroEsclavo + ")");
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

        public int update(String nombreEstacion, int numeroEstacion, decimal minRaw, decimal maxRaw, String comunicaciones, int numeroEsclavo)
        {
            int rows = 0;

            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("UPDATE AppListaSeñales.ESTACION SET ");
                cadenaSql.Append("numero = " + numeroEstacion);
                cadenaSql.Append(", minRaw = " + minRaw);
                cadenaSql.Append(", maxRaw = " + maxRaw);
                cadenaSql.Append(", protocoloComunicacion = '" + comunicaciones + "'");
                cadenaSql.Append(", numeroEsclavo = " + numeroEsclavo);
                cadenaSql.Append(" WHERE nombre = '" + nombreEstacion + "'");
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
        public int deleteByNombreEstacion(String nombreEstacion, String nombreExplotacion)
        {
            int rows = 0;

            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("DELETE E FROM AppListaSeñales.ESTACION E ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.EXPLOTACION EX ");
                cadenaSql.Append("ON E.idExplotacion = EX.id ");
                cadenaSql.Append("WHERE EX.nombre = '" + nombreExplotacion + "' ");
                cadenaSql.Append("AND E.nombre = '" + nombreEstacion + "'");
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

        public Estacion findDatosPlcByNombre(String nombre)
        {
            Estacion estacion = new Estacion();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT minRaw, maxRaw, protocoloComunicacion FROM AppListaSeñales.ESTACION WHERE ");
                cadenaSql.Append("nombre = '" + nombre + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    estacion.MinRaw = (Decimal)reader["minRaw"];
                    estacion.MaxRaw = (Decimal)reader["maxRaw"];
                    estacion.ProtocoloComunicacion = reader["protocoloComunicacion"].ToString();
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
            return estacion;
        }

        public int findIdByNombreEstacionAndNombreExplotacion(String nombreEstacion, String nombreExplotacion)
        {
            Int32 id = 0;
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT E.id FROM AppListaSeñales.ESTACION E ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.EXPLOTACION EX ");
                cadenaSql.Append("ON E.idExplotacion = EX.id ");
                cadenaSql.Append("WHERE EX.nombre = '" + nombreExplotacion + "' AND E.nombre = '" + nombreEstacion + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    id = (Int32)reader["id"];
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
            return id;
        }

        public int findIdByNumeroDeEstacionCebeIasExplotacionAndExplotacionIas(string cebeIas, string explotacionIas, int numeroEstacion)
        {
            Int32 id = 0;
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT E.id FROM AppListaSeñales.ESTACION E ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.EXPLOTACION EX ");
                cadenaSql.Append("ON E.idExplotacion = EX.id ");
                cadenaSql.Append("WHERE EX.cebeIas = '" + cebeIas + "' AND EX.explotacionIas = '" + explotacionIas + "' ");
                cadenaSql.Append("AND E.numero = " + numeroEstacion);
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    id = (Int32)reader["id"];
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
            return id;
        }

        public Estacion findEstacionByNombreEstacionAndNombreExplotacion(string nombreEstacion, string nombreExplotacion, string sitAquacis)
        {
            Estacion estacion = new Estacion();

            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT E.numero, E.minRaw, E.maxRaw, E.protocoloComunicacion, E.numeroEsclavo FROM AppListaSeñales.ESTACION E ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.EXPLOTACION EX ");
                cadenaSql.Append("on E.idExplotacion = EX.id ");
                cadenaSql.Append("WHERE EX.nombre = '" + nombreExplotacion + "' AND EX.sitAquacis = '" + sitAquacis + "' ");
                cadenaSql.Append("AND E.nombre = '" + nombreEstacion + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    estacion.Numero = (Int32)reader["numero"];
                    estacion.MinRaw = (Decimal)reader["minRaw"];
                    estacion.MaxRaw = (Decimal)reader["maxRaw"];
                    estacion.ProtocoloComunicacion = reader["protocoloComunicacion"].ToString();
                    if (!DBNull.Value.Equals(reader["numeroEsclavo"]))
                    {
                        estacion.NumeroEsclavo = (Int32)reader["numeroEsclavo"];
                    }
                    
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
            return estacion;
        }
    }
}
