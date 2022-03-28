using AppListaSeñales.Entity;
using AppListaSeñales.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AppListaSeñales.Repository
{
    class DataloggerRepository
    {
        public int create(string nombre, int numeroDatalogger, int idExplotacion, int numeroAgrupacion, string tipo, int puerto, string horasComunicacion, string zonaSectorizacion, string direccionIp, int numeroPunto)
        {
            int rows = 0;
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("INSERT INTO AppListaSeñales.Datalogger(nombre, numeroDatalogger, numeroAgrupacion, idExplotacion, tipo");
                if (puerto != 0)
                {
                    cadenaSql.Append(", puerto");
                }
                if (!String.IsNullOrEmpty(horasComunicacion))
                {
                    cadenaSql.Append(", horasComunicacion");
                }
                if (!String.IsNullOrEmpty(zonaSectorizacion))
                {
                    cadenaSql.Append(", zonaSectorizacion");
                }
                if (!String.IsNullOrEmpty(direccionIp))
                {
                    cadenaSql.Append(", direccionIp");
                }
                if (numeroPunto != 0)
                {
                    cadenaSql.Append(", numeroPunto");
                }
                cadenaSql.Append(") VALUES ");
                cadenaSql.Append("('" + nombre + "', " + numeroDatalogger + ", " + numeroAgrupacion + ", " + idExplotacion + ", '" + tipo + "'");
                if (puerto != 0)
                {
                    cadenaSql.Append(", " + puerto);
                }
                if (!String.IsNullOrEmpty(horasComunicacion))
                {
                    cadenaSql.Append(", '" + horasComunicacion + "'");
                }
                if (!String.IsNullOrEmpty(zonaSectorizacion))
                {
                    cadenaSql.Append(", '" + zonaSectorizacion + "'");
                }
                if (!String.IsNullOrEmpty(direccionIp))
                {
                    cadenaSql.Append(", '" + direccionIp + "'");
                }
                if (numeroPunto != 0)
                {
                    cadenaSql.Append(", " + numeroPunto);
                }
                cadenaSql.Append(")");

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

        public DataTable findNombreDataloggerByNombreExplotacion(String nombreExplotacion, String sitAquacis)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT D.nombre FROM AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.EXPLOTACION EX ");
                cadenaSql.Append("on D.idExplotacion = EX.id ");
                cadenaSql.Append("WHERE EX.nombre = '" + nombreExplotacion + "' AND EX.sitAquacis = '" + sitAquacis + "' ");
                cadenaSql.Append("ORDER BY D.nombre");
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

        public int deleteByNombreDatalogger(String nombreDatalogger, String nombreExplotacion, string sitAquacis)
        {
            int rows = 0;

            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("DELETE D FROM AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.EXPLOTACION EX ");
                cadenaSql.Append("ON D.idExplotacion = EX.id ");
                cadenaSql.Append("WHERE EX.nombre = '" + nombreExplotacion + "' AND EX.sitAquacis = '" + sitAquacis + "' ");
                cadenaSql.Append("AND D.nombre = '" + nombreDatalogger + "'");
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
        public Datalogger findDataloggerByNombreDataloggerAndNombreExplotacion(string nombreDatalogger, string nombreExplotacion, string sitAquacis)
        {
            Datalogger datalogger = new Datalogger();

            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT D.numeroPunto, D.numeroAgrupacion, D.numeroDatalogger, D.direccionIp, D.tipo, D.puerto, D.horasComunicacion, D.zonaSectorizacion FROM AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.EXPLOTACION EX ");
                cadenaSql.Append("on D.idExplotacion = EX.id ");
                cadenaSql.Append("WHERE EX.nombre = '" + nombreExplotacion + "' AND EX.sitAquacis = '" + sitAquacis + "' ");
                cadenaSql.Append("AND D.nombre = '" + nombreDatalogger + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    datalogger.NumeroAgrupacion = (int)reader["numeroAgrupacion"];
                    datalogger.NumeroDatalogger = (int)reader["numeroDatalogger"];
                    datalogger.Tipo = reader["tipo"].ToString();
                    if (!DBNull.Value.Equals(reader["numeroPunto"]))
                    {
                        datalogger.NumeroPunto = (int)reader["numeroPunto"];
                    }
                    if (!DBNull.Value.Equals(reader["direccionIp"]))
                    {
                        datalogger.DireccionIp = reader["direccionIp"].ToString();
                    }
                    if (!DBNull.Value.Equals(reader["puerto"]))
                    {
                        datalogger.Puerto = (int)reader["puerto"];
                    }
                    if (!DBNull.Value.Equals(reader["horasComunicacion"]))
                    {
                        datalogger.HorasComunicacion = reader["horasComunicacion"].ToString();
                    }
                    if (!DBNull.Value.Equals(reader["zonaSectorizacion"]))
                    {
                        datalogger.ZonaSectorizacion = reader["zonaSectorizacion"].ToString();
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
            return datalogger;
        }

        public Datalogger findIdNumeroDataloggerAndNumeroAgrupacionByNombreDataloggerAndNombreExplotacion(string nombreDatalogger, string nombreExplotacion, string sitAquacis)
        {
            Datalogger datalogger = new Datalogger();

            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT D.id, D.numeroAgrupacion, D.numeroDatalogger FROM AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.EXPLOTACION EX ");
                cadenaSql.Append("on D.idExplotacion = EX.id ");
                cadenaSql.Append("WHERE EX.nombre = '" + nombreExplotacion + "' AND EX.sitAquacis = '" + sitAquacis + "' ");
                cadenaSql.Append("AND D.nombre = '" + nombreDatalogger + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    datalogger.NumeroAgrupacion = (int)reader["numeroAgrupacion"];
                    datalogger.NumeroDatalogger = (int)reader["numeroDatalogger"];
                    datalogger.Id = (int)reader["id"];                  
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
            return datalogger;
        }
        public int update(string nombre, int numeroDatalogger, int idExplotacion, int numeroAgrupacion, string tipo, int puerto, string horasComunicacion, string zonaSectorizacion, string direccionIp, int numeroPunto)
        {
            int rows = 0;

            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("UPDATE AppListaSeñales.DATALOGGER SET ");
                cadenaSql.Append("numeroDatalogger = " + numeroDatalogger);
                cadenaSql.Append(", numeroAgrupacion = " + numeroAgrupacion);
                cadenaSql.Append(", tipo = '" + tipo + "'");
                if (puerto != 0)
                {
                    cadenaSql.Append(", puerto = " + puerto);
                }
                if (!String.IsNullOrEmpty(horasComunicacion))
                {
                    cadenaSql.Append(", horasComunicacion = '" + horasComunicacion + "'");
                }
                if (!String.IsNullOrEmpty(zonaSectorizacion))
                {
                    cadenaSql.Append(", zonaSectorizacion = '" + zonaSectorizacion + "'");
                }
                if (!String.IsNullOrEmpty(direccionIp))
                {
                    cadenaSql.Append(", direccionIp = '" + direccionIp + "'");
                }
                if (numeroPunto != 0)
                {
                    cadenaSql.Append(", numeroPunto = " + numeroPunto);
                }
                cadenaSql.Append(" WHERE nombre = '" + nombre + "' ");
                cadenaSql.Append("AND idExplotacion = " + idExplotacion);
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
    }
}
