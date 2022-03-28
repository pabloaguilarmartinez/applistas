using AppListaSeñales.Entity;
using AppListaSeñales.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AppListaSeñales.Repository
{
    public class SeñalRepository
    {
        #region Constructor
        public SeñalRepository()
        {
        }
        #endregion

        public int createSeñal(Dictionary<String, Señal> listaSeñales)
        {
            int rows = 0;
            // Conexión con BBDD
            SqlConnection connection = Conexiones.openConnection();
            //Creamos una transacción por si hay fallo
            SqlTransaction tran = connection.BeginTransaction("CrearSeñalTransaccion");
            try
            {
                foreach (KeyValuePair<String, Señal> señal in listaSeñales)
                {
                    // Consulta
                    StringBuilder cadenaSql = new StringBuilder();
                    
                    if (señal.Value.Codigo.Substring(5, 1).Equals("8"))
                    {
                        //Datalogger
                        // Insertamos señal digital
                        if (señal.Value.Codigo.Substring(24, 1).Equals("E") || señal.Value.Codigo.Substring(24, 1).Equals("N"))
                        {
                            cadenaSql.Append("INSERT INTO AppListaSeñales.SEÑAL ");
                            cadenaSql.Append("(descripcion, tag, codigo, invertida, numeroLogico, numeroFisico, ");
                            cadenaSql.Append("direccionPlc, offMsg, onMsg, historico, ");
                            cadenaSql.Append("alarma, idDatalogger, direccionPlcAutoGen, varCero, criterioArchivo) VALUES ");
                            cadenaSql.Append("('" + señal.Value.Descripcion + "', ");
                            if (!String.IsNullOrEmpty(señal.Value.Tag))
                            {
                                cadenaSql.Append("'" + señal.Value.Tag + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            cadenaSql.Append("'" + señal.Value.Codigo + "', '" + señal.Value.Invertida + "', ");
                            if (señal.Value.NumeroLogico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroLogico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL , ");
                            }
                            if (señal.Value.NumeroFisico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroFisico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL , ");
                            }
                            if (!String.IsNullOrEmpty(señal.Value.DireccionPlc))
                            {
                                cadenaSql.Append("'" + señal.Value.DireccionPlc + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (!String.IsNullOrEmpty(señal.Value.OffMsg))
                            {
                                cadenaSql.Append("'" + señal.Value.OffMsg + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (!String.IsNullOrEmpty(señal.Value.OnMsg))
                            {
                                cadenaSql.Append("'" + señal.Value.OnMsg + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            cadenaSql.Append("'" + señal.Value.Historico + "', '" + señal.Value.Alarma + "', " + señal.Value.IdDatalogger + ", '" + señal.Value.DireccionPlcAutoGen + "', '");
                            cadenaSql.Append(señal.Value.VarCero + "', '" + señal.Value.CriterioArchivo + "')");
                        }
                        else if (señal.Value.Codigo.Substring(24, 1).Equals("T")) // Telemando
                        {
                            cadenaSql.Append("INSERT INTO AppListaSeñales.SEÑAL ");
                            cadenaSql.Append("(descripcion, tag, codigo, numeroLogico, numeroFisico, ");
                            cadenaSql.Append("direccionPlc, offMsg, onMsg, historico, ");
                            cadenaSql.Append(" idDatalogger, direccionPlcAutoGen, varCero) VALUES ");
                            cadenaSql.Append("('" + señal.Value.Descripcion + "', ");
                            if (!String.IsNullOrEmpty(señal.Value.Tag))
                            {
                                cadenaSql.Append("'" + señal.Value.Tag + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            cadenaSql.Append("'" + señal.Value.Codigo + "', ");
                            if (señal.Value.NumeroLogico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroLogico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL , ");
                            }
                            if (señal.Value.NumeroFisico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroFisico + ", '");
                            }
                            else
                            {
                                cadenaSql.Append("NULL , ");
                            }
                            if (!String.IsNullOrEmpty(señal.Value.DireccionPlc))
                            {
                                cadenaSql.Append("'" + señal.Value.DireccionPlc + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (!String.IsNullOrEmpty(señal.Value.OffMsg))
                            {
                                cadenaSql.Append("'" + señal.Value.OffMsg + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (!String.IsNullOrEmpty(señal.Value.OnMsg))
                            {
                                cadenaSql.Append("'" + señal.Value.OnMsg + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            cadenaSql.Append("'" + señal.Value.Historico + "', " + señal.Value.IdDatalogger + ", '" + señal.Value.DireccionPlcAutoGen + "', '");
                            cadenaSql.Append(señal.Value.VarCero + "')");
                        }
                        else if (señal.Value.Codigo.Substring(24, 1).Equals("A")) // Contadores
                        {
                            cadenaSql.Append("INSERT INTO AppListaSeñales.SEÑAL ");
                            cadenaSql.Append("(descripcion, codigo, tag, numeroLogico, numeroFisico, direccionPlc, ");
                            cadenaSql.Append("minEngUnits, maxEngUnits, minRaw, maxRaw, unidad, historico, ");
                            cadenaSql.Append("idDatalogger, direccionPlcAutoGen, varCero, criterioArchivo) VALUES ");
                            cadenaSql.Append("('" + señal.Value.Descripcion + "', '" + señal.Value.Codigo + "', ");
                            if (señal.Value.Tag != null)
                            {
                                cadenaSql.Append("'" + señal.Value.Tag + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (señal.Value.NumeroLogico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroLogico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (señal.Value.NumeroFisico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroFisico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (señal.Value.DireccionPlc != null)
                            {
                                cadenaSql.Append("'" + señal.Value.DireccionPlc + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            cadenaSql.Append(señal.Value.MinEngUnits.ToString().Replace(",", ".") + ", " + señal.Value.MaxEngUnits.ToString().Replace(",", ".") + ", ");
                            cadenaSql.Append(señal.Value.MinRaw.ToString().Replace(",", ".") + ", " + señal.Value.MaxRaw.ToString().Replace(",", ".") + ", '" + señal.Value.Unidad + "', '");
                            cadenaSql.Append(señal.Value.Historico + "', " + señal.Value.IdDatalogger + ", '" + señal.Value.DireccionPlcAutoGen + "', '");
                            cadenaSql.Append(señal.Value.VarCero + "', '" + señal.Value.CriterioArchivo + "')");
                        }
                        // Otra señal
                        else
                        {
                            cadenaSql.Append("INSERT INTO AppListaSeñales.SEÑAL ");
                            cadenaSql.Append("(descripcion, tag, codigo, numeroLogico, numeroFisico, ");
                            cadenaSql.Append("direccionPlc, minEngUnits, maxEngUnits, minRaw, maxRaw, unidad, historico, ");
                            cadenaSql.Append("idDatalogger, direccionPlcAutoGen, varCero, criterioArchivo) VALUES ");
                            cadenaSql.Append("('" + señal.Value.Descripcion + "', ");
                            if (!String.IsNullOrEmpty(señal.Value.Tag))
                            {
                                cadenaSql.Append("'" + señal.Value.Tag + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            cadenaSql.Append("'" + señal.Value.Codigo + "', ");
                            if (señal.Value.NumeroLogico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroLogico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (señal.Value.NumeroFisico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroFisico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (!String.IsNullOrEmpty(señal.Value.DireccionPlc))
                            {
                                cadenaSql.Append("'" + señal.Value.DireccionPlc + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            cadenaSql.Append(señal.Value.MinEngUnits.ToString().Replace(",", ".") + ", " + señal.Value.MaxEngUnits.ToString().Replace(",", ".") + ", ");
                            cadenaSql.Append(señal.Value.MinRaw.ToString().Replace(",", ".") + ", " + señal.Value.MaxRaw.ToString().Replace(",", ".") + ", '" + señal.Value.Unidad + "', '");
                            cadenaSql.Append(señal.Value.Historico + "', " + señal.Value.IdDatalogger + ", '" + señal.Value.DireccionPlcAutoGen + "', '");
                            cadenaSql.Append(señal.Value.VarCero + "', '" + señal.Value.CriterioArchivo + "')");
                        }
                    }
                    else
                    {
                        //Estaciones
                        // Insertamos señal digital
                        if (señal.Value.Codigo.Substring(24, 1).Equals("E") || señal.Value.Codigo.Substring(24, 1).Equals("N"))
                        {
                            cadenaSql.Append("INSERT INTO AppListaSeñales.SEÑAL ");
                            cadenaSql.Append("(descripcion, tag, codigo, invertida, numeroLogico, numeroFisico, ");
                            cadenaSql.Append("direccionPlc, offMsg, onMsg, historico, ");
                            cadenaSql.Append("alarma, idEstacion, direccionPlcAutoGen, varCero, criterioArchivo) VALUES ");
                            cadenaSql.Append("('" + señal.Value.Descripcion + "', '" + señal.Value.Tag + "', '" + señal.Value.Codigo + "', '");
                            cadenaSql.Append(señal.Value.Invertida + "', ");
                            if (señal.Value.NumeroLogico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroLogico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL , ");
                            }
                            if (señal.Value.NumeroFisico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroFisico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL , ");
                            }
                            if (!String.IsNullOrEmpty(señal.Value.DireccionPlc))
                            {
                                cadenaSql.Append("'" + señal.Value.DireccionPlc + "', '");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, '");
                            }
                            cadenaSql.Append(señal.Value.OffMsg + "', '" + señal.Value.OnMsg + "', '");
                            cadenaSql.Append(señal.Value.Historico + "', '" + señal.Value.Alarma + "', " + señal.Value.IdEstacion + ", '" + señal.Value.DireccionPlcAutoGen + "', '");
                            cadenaSql.Append(señal.Value.VarCero + "', '" + señal.Value.CriterioArchivo + "')");
                        }
                        else if (señal.Value.Codigo.Substring(24, 1).Equals("T")) // Telemando
                        {
                            cadenaSql.Append("INSERT INTO AppListaSeñales.SEÑAL ");
                            cadenaSql.Append("(descripcion, tag, codigo, numeroLogico, numeroFisico, ");
                            cadenaSql.Append("direccionPlc, offMsg, onMsg, historico, ");
                            cadenaSql.Append(" idEstacion, direccionPlcAutoGen, varCero) VALUES ");
                            cadenaSql.Append("('" + señal.Value.Descripcion + "', '" + señal.Value.Tag + "', '" + señal.Value.Codigo + "', ");
                            if (señal.Value.NumeroLogico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroLogico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL , ");
                            }
                            if (señal.Value.NumeroFisico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroFisico + ", '");
                            }
                            else
                            {
                                cadenaSql.Append("NULL , ");
                            }
                            if (!String.IsNullOrEmpty(señal.Value.DireccionPlc))
                            {
                                cadenaSql.Append("'" + señal.Value.DireccionPlc + "', '");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, '");
                            }
                            cadenaSql.Append(señal.Value.OffMsg + "', '" + señal.Value.OnMsg + "', '");
                            cadenaSql.Append(señal.Value.Historico + "', " + señal.Value.IdEstacion + ", '" + señal.Value.DireccionPlcAutoGen + "', '");
                            cadenaSql.Append(señal.Value.VarCero + "')");
                        }
                        else if (señal.Value.Codigo.Substring(24, 1).Equals("A")) // Contadores
                        {
                            cadenaSql.Append("INSERT INTO AppListaSeñales.SEÑAL ");
                            cadenaSql.Append("(descripcion, codigo, tag, numeroLogico, numeroFisico, direccionPlc, ");
                            cadenaSql.Append("minEngUnits, maxEngUnits, minRaw, maxRaw, unidad, historico, ");
                            cadenaSql.Append("idEstacion, direccionPlcAutoGen, varCero, criterioArchivo) VALUES ");
                            cadenaSql.Append("('" + señal.Value.Descripcion + "', '" + señal.Value.Codigo + "', ");
                            if (señal.Value.Tag != null)
                            {
                                cadenaSql.Append("'" + señal.Value.Tag + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (señal.Value.NumeroLogico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroLogico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (señal.Value.NumeroFisico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroFisico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (señal.Value.DireccionPlc != null)
                            {
                                cadenaSql.Append("'" + señal.Value.DireccionPlc + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            cadenaSql.Append(señal.Value.MinEngUnits.ToString().Replace(",", ".") + ", " + señal.Value.MaxEngUnits.ToString().Replace(",", ".") + ", ");
                            cadenaSql.Append(señal.Value.MinRaw.ToString().Replace(",", ".") + ", " + señal.Value.MaxRaw.ToString().Replace(",", ".") + ", '" + señal.Value.Unidad + "', '");
                            cadenaSql.Append(señal.Value.Historico + "', " + señal.Value.IdEstacion + ", '" + señal.Value.DireccionPlcAutoGen + "', '");
                            cadenaSql.Append(señal.Value.VarCero + "', '" + señal.Value.CriterioArchivo + "')");
                        }
                        // Otra señal
                        else
                        {
                            cadenaSql.Append("INSERT INTO AppListaSeñales.SEÑAL ");
                            cadenaSql.Append("(descripcion, tag, codigo, numeroLogico, numeroFisico, ");
                            cadenaSql.Append("direccionPlc, minEngUnits, maxEngUnits, minRaw, maxRaw, unidad, historico, ");
                            cadenaSql.Append("idEstacion, direccionPlcAutoGen, varCero, criterioArchivo) VALUES ");
                            cadenaSql.Append("('" + señal.Value.Descripcion + "', '" + señal.Value.Tag + "', '" + señal.Value.Codigo + "', ");
                            if (señal.Value.NumeroLogico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroLogico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (señal.Value.NumeroFisico != 0)
                            {
                                cadenaSql.Append(señal.Value.NumeroFisico + ", ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            if (!String.IsNullOrEmpty(señal.Value.DireccionPlc))
                            {
                                cadenaSql.Append("'" + señal.Value.DireccionPlc + "', ");
                            }
                            else
                            {
                                cadenaSql.Append("NULL, ");
                            }
                            cadenaSql.Append(señal.Value.MinEngUnits.ToString().Replace(",", ".") + ", " + señal.Value.MaxEngUnits.ToString().Replace(",", ".") + ", ");
                            cadenaSql.Append(señal.Value.MinRaw.ToString().Replace(",", ".") + ", " + señal.Value.MaxRaw.ToString().Replace(",", ".") + ", '" + señal.Value.Unidad + "', '");
                            cadenaSql.Append(señal.Value.Historico + "', " + señal.Value.IdEstacion + ", '" + señal.Value.DireccionPlcAutoGen + "', '");
                            cadenaSql.Append(señal.Value.VarCero + "', '" + señal.Value.CriterioArchivo + "')");
                        }
                    }
                    SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                    command.Transaction = tran;
                    rows = rows + command.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (SqlException e)
            {
                tran.Rollback();
                Log.Logger(e.ToString());  
            }
            finally
            { 
                // Cerramos conexión
                Conexiones.closeConnection(connection);
            }
         return rows;
        }

        public int deleteSeñales(String instancia)
        {
            int rows = 0;
            // Conexión con BBDD
            SqlConnection connection = Conexiones.openConnection();
            //Creamos una transacción por si hay fallo
            SqlTransaction tran = connection.BeginTransaction("CrearSeñalTransaccion");
            try
            {
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("DELETE FROM AppListaSeñales.SEÑAL ");
                cadenaSql.Append("WHERE codigo LIKE '" + instancia + "%'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                command.Transaction = tran;
                rows = command.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException e)
            {
                tran.Rollback();
                Log.Logger(e.ToString());
            }
            finally
            {
                // Cerramos conexión
                Conexiones.closeConnection(connection);
            }
            return rows;
        }

        public int updateSeñal(Señal señal)
        {

            int rows = 0;
            // Conexión con BBDD
            SqlConnection connection = Conexiones.openConnection();
            //Creamos una transacción por si hay fallo
            SqlTransaction tran = connection.BeginTransaction("CrearSeñalTransaccion");
            try
            {
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("UPDATE AppListaSeñales.SEÑAL SET ");
                cadenaSql.Append("direccionPlc = '" + señal.DireccionPlc + "', ");
                cadenaSql.Append("tag = '" + señal.Tag + "', ");
                if (señal.NumeroFisico != 0)
                {
                    cadenaSql.Append("numeroFisico = " + señal.NumeroFisico + ", ");
                    cadenaSql.Append("numeroLogico = NULL, ");
                }
                else if (señal.NumeroLogico != 0)
                {
                    cadenaSql.Append("numeroLogico = " + señal.NumeroLogico + ", ");
                    cadenaSql.Append("numeroFisico = NULL, ");
                }
                cadenaSql.Append("direccionPlcAutoGen = '" + señal.DireccionPlcAutoGen + "', ");
                cadenaSql.Append("criterioArchivo = '" + señal.CriterioArchivo + "' ");
                cadenaSql.Append("WHERE codigo = '" + señal.Codigo + "'");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                command.Transaction = tran;
                rows = command.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException e)
            {
                tran.Rollback();
                Log.Logger(e.ToString());
            }
            finally
            {
                // Cerramos conexión
                Conexiones.closeConnection(connection);
            }
            return rows;
        }

        public int updateSeñalPreview(Señal señal)
        {

            int rows = 0;
            // Conexión con BBDD
            SqlConnection connection = Conexiones.openConnection();
            //Creamos una transacción por si hay fallo
            SqlTransaction tran = connection.BeginTransaction("CrearSeñalTransaccion");
            try
            {
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("UPDATE AppListaSeñales.SEÑAL SET ");
                cadenaSql.Append("direccionPlc = '" + señal.DireccionPlc + "', ");
                cadenaSql.Append("tag = '" + señal.Tag + "', ");
                if (señal.NumeroFisico != 0)
                {
                    cadenaSql.Append("numeroFisico = " + señal.NumeroFisico + ", ");
                    cadenaSql.Append("numeroLogico = NULL, ");
                }
                else if (señal.NumeroLogico != 0)
                {
                    cadenaSql.Append("numeroLogico = " + señal.NumeroLogico + ", ");
                    cadenaSql.Append("numeroFisico = NULL, ");
                }
                cadenaSql.Append("direccionPlcAutoGen = '" + señal.DireccionPlcAutoGen + "', ");
                if (señal.Unidad != null && !señal.Unidad.Equals(""))
                {
                    cadenaSql.Append("unidad = '" + señal.Unidad + "', ");
                }
                if (señal.OffMsg != null && !señal.OffMsg.Equals(""))
                {
                    cadenaSql.Append("offMsg = '" + señal.OffMsg + "', ");
                }
                if (señal.OnMsg != null && !señal.OnMsg.Equals(""))
                {
                    cadenaSql.Append("onMsg = '" + señal.OnMsg + "', ");
                }
                if (señal.Codigo.Substring(24, 1).Equals("E"))
                {
                    cadenaSql.Append("alarma = '" + señal.Alarma + "', ");
                    cadenaSql.Append("invertida = '" + señal.Invertida + "', ");
                }
                else if (señal.Codigo.Substring(24, 1).Equals("T"))
                {
                    cadenaSql.Append("alarma = '" + señal.Alarma + "', ");
                }
                else 
                {
                    cadenaSql.Append("minRaw = " + señal.MinRaw.ToString().Replace(",", ".") + ", ");
                    cadenaSql.Append("maxRaw = " + señal.MaxRaw.ToString().Replace(",", ".") + ", ");
                    cadenaSql.Append("minEngUnits = " + señal.MinEngUnits.ToString().Replace(",", ".") + ", ");
                    cadenaSql.Append("maxEngUnits = " + señal.MaxEngUnits.ToString().Replace(",", ".") + ", ");
                }
                cadenaSql.Append("historico = '" + señal.Historico + "', ");
                cadenaSql.Append("descripcion = '" + señal.Descripcion + "', ");
                cadenaSql.Append("criterioArchivo = '" + señal.CriterioArchivo + "' ");
                cadenaSql.Append("WHERE codigo = '" + señal.Codigo + "'");
                
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                command.Transaction = tran;
                rows = command.ExecuteNonQuery();
                tran.Commit();
            }
            catch (SqlException e)
            {
                tran.Rollback();
                Log.Logger(e.ToString());
            }
            finally
            {
                // Cerramos conexión
                Conexiones.closeConnection(connection);
            }
            return rows;
        }

        public DataTable findSeñalesAnalogicasByNombreEstacion(String nombreEstacion)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.codigo, S.tag, S.numeroLogico, S.numeroFisico, S.minEngUnits, S.maxEngUnits, S.minRaw, S.maxRaw, ");
                cadenaSql.Append("S.unidad, S.historico, S.alarma, S.invertida, S.direccionPlc, S.direccionPlcAutoGen, ");
                cadenaSql.Append("S.offMsg, S.onMsg, S.criterioArchivo FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.ESTACION E ");
                cadenaSql.Append("on S.idEstacion = E.id ");
                cadenaSql.Append("WHERE E.nombre = '" + nombreEstacion + "' ");
                cadenaSql.Append("AND (S.codigo LIKE '%.V[_]%' OR S.codigo LIKE '%.C[_]%' OR S.codigo LIKE '%.M[_]%') ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
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

        public DataTable findConsignasByNombreEstacion(String nombreEstacion)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.codigo, S.tag, S.numeroLogico, S.numeroFisico, S.minEngUnits, S.maxEngUnits, S.minRaw, S.maxRaw, ");
                cadenaSql.Append("S.unidad, S.historico, S.alarma, S.invertida, S.direccionPlc, S.direccionPlcAutoGen, ");
                cadenaSql.Append("S.offMsg, S.onMsg, S.criterioArchivo FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.ESTACION E ");
                cadenaSql.Append("on S.idEstacion = E.id ");
                cadenaSql.Append("WHERE E.nombre = '" + nombreEstacion + "' ");
                cadenaSql.Append("AND S.codigo LIKE '%.P[_]%' ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
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

        public DataTable findTelemandosByNombreEstacion(String nombreEstacion)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.codigo, S.tag, S.numeroLogico, S.numeroFisico, S.minEngUnits, S.maxEngUnits, S.minRaw, S.maxRaw, ");
                cadenaSql.Append("S.unidad, S.historico, S.alarma, S.invertida, S.direccionPlc, S.direccionPlcAutoGen, ");
                cadenaSql.Append("S.offMsg, S.onMsg, S.criterioArchivo FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.ESTACION E ");
                cadenaSql.Append("on S.idEstacion = E.id ");
                cadenaSql.Append("WHERE E.nombre = '" + nombreEstacion + "' ");
                cadenaSql.Append("AND S.codigo LIKE '%.T[_]%' ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
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

        public DataTable findDigitalesByNombreEstacion(String nombreEstacion)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.codigo, S.tag, S.numeroLogico, S.numeroFisico, S.minEngUnits, S.maxEngUnits, S.minRaw, S.maxRaw, ");
                cadenaSql.Append("S.unidad, S.historico, S.alarma, S.invertida, S.direccionPlc, S.direccionPlcAutoGen, ");
                cadenaSql.Append("S.offMsg, S.onMsg, S.criterioArchivo FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.ESTACION E ");
                cadenaSql.Append("on S.idEstacion = E.id ");
                cadenaSql.Append("WHERE E.nombre = '" + nombreEstacion + "' ");
                cadenaSql.Append("AND (S.codigo LIKE '%.E[_]%' OR S.codigo LIKE '%.N[_]%') ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
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

        public DataTable findContadoresByNombreEstacion(String nombreEstacion)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.codigo, S.tag, S.numeroLogico, S.numeroFisico, S.minEngUnits, S.maxEngUnits, S.minRaw, S.maxRaw, ");
                cadenaSql.Append("S.unidad, S.historico, S.alarma, S.invertida, S.direccionPlc, S.direccionPlcAutoGen, ");
                cadenaSql.Append("S.offMsg, S.onMsg, S.criterioArchivo FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.ESTACION E ");
                cadenaSql.Append("on S.idEstacion = E.id ");
                cadenaSql.Append("WHERE E.nombre = '" + nombreEstacion + "' ");
                cadenaSql.Append("AND S.codigo LIKE '%.A[_]%' ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
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

        public DataTable findSeñalesCreadasByNombreEstacion(String nombreEstacion)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.numeroLogico, S.numeroFisico, S.codigo,");
                cadenaSql.Append(" S.direccionPlc, S.criterioArchivo ");
                cadenaSql.Append("FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.ESTACION E ");
                cadenaSql.Append("on S.idEstacion = E.id ");
                cadenaSql.Append("WHERE E.nombre = '" + nombreEstacion + "' ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
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

        public DataTable findSeñalesByNombreEstacion(String nombreEstacion)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.tag, S.codigo, S.invertida, S.numeroLogico, S.numeroFisico, ");
                cadenaSql.Append("S.direccionPlc, S.varCero, S.offMsg, S.onMsg, S.minEngUnits, S.maxEngUnits, S.minRaw, ");
                cadenaSql.Append("S.maxRaw, S.unidad, S.historico, S.alarma, S.idEstacion, SUBSTRING(S.codigo, 13, 4) AS agrupador, ");
                cadenaSql.Append("SUBSTRING(S.codigo, 18, 6) AS instancia, SUBSTRING(S.codigo, 25, 6) AS atributo ");
                cadenaSql.Append("FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.ESTACION E ");
                cadenaSql.Append("ON S.idEstacion = E.id ");
                cadenaSql.Append("WHERE E.nombre = '" + nombreEstacion + "' AND S.codigo NOT LIKE '%.N[_]PULS' ");
                cadenaSql.Append("ORDER BY agrupador, instancia, atributo");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
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

        public DataTable findInstanciasByNombreEstacion(String nombreEstacion)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT DISTINCT ");
                cadenaSql.Append("SUBSTRING(S.codigo, 0, 24) AS instancia ");
                cadenaSql.Append("FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.ESTACION E ");
                cadenaSql.Append("ON S.idEstacion = E.id ");
                cadenaSql.Append("WHERE E.nombre = '" + nombreEstacion + "' ");
                cadenaSql.Append("ORDER BY instancia");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
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

        public DataTable findSeñalesCreadasByNombreDatalogger(String nombreDatalogger)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.numeroLogico, S.numeroFisico, S.codigo,");
                cadenaSql.Append(" S.direccionPlc, S.criterioArchivo ");
                cadenaSql.Append("FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("on S.idDatalogger = D.id ");
                cadenaSql.Append("WHERE D.nombre = '" + nombreDatalogger + "' ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
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

        public DataTable findSeñalesByNombreDtalogger(String nombreDatalogger)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.tag, S.codigo, S.invertida, S.numeroLogico, S.numeroFisico, ");
                cadenaSql.Append("S.direccionPlc, S.varCero, S.offMsg, S.onMsg, S.minEngUnits, S.maxEngUnits, S.minRaw, ");
                cadenaSql.Append("S.maxRaw, S.unidad, S.historico, S.alarma, S.idEstacion, SUBSTRING(S.codigo, 13, 4) AS agrupador, ");
                cadenaSql.Append("SUBSTRING(S.codigo, 18, 6) AS instancia, SUBSTRING(S.codigo, 25, 6) AS atributo ");
                cadenaSql.Append("FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("ON S.idDatalogger = D.id ");
                cadenaSql.Append("WHERE D.nombre = '" + nombreDatalogger + "' AND S.codigo NOT LIKE '%.N[_]PULS' ");
                cadenaSql.Append("ORDER BY agrupador, instancia, atributo");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
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

        public DataTable findSeñalesAnalogicasByNombreDatalogger(String nombreDatalogger)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.codigo, S.tag, S.numeroLogico, S.numeroFisico, S.minEngUnits, S.maxEngUnits, S.minRaw, S.maxRaw, ");
                cadenaSql.Append("S.unidad, S.historico, S.alarma, S.invertida, S.direccionPlc, S.direccionPlcAutoGen, ");
                cadenaSql.Append("S.offMsg, S.onMsg, S.criterioArchivo FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("on S.idDatalogger = D.id ");
                cadenaSql.Append("WHERE D.nombre = '" + nombreDatalogger + "' ");
                cadenaSql.Append("AND (S.codigo LIKE '%.V[_]%' OR S.codigo LIKE '%.C[_]%' OR S.codigo LIKE '%.M[_]%') ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
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

        public DataTable findConsignasByNombreDatalogger(String nombreDatalogger)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.codigo, S.tag, S.numeroLogico, S.numeroFisico, S.minEngUnits, S.maxEngUnits, S.minRaw, S.maxRaw, ");
                cadenaSql.Append("S.unidad, S.historico, S.alarma, S.invertida, S.direccionPlc, S.direccionPlcAutoGen, ");
                cadenaSql.Append("S.offMsg, S.onMsg, S.criterioArchivo FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("on S.idDatalogger = D.id ");
                cadenaSql.Append("WHERE D.nombre = '" + nombreDatalogger + "' ");
                cadenaSql.Append("AND S.codigo LIKE '%.P[_]%' ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
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

        public DataTable findTelemandosByNombreDatalogger(String nombreDatalogger)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.codigo, S.tag, S.numeroLogico, S.numeroFisico, S.minEngUnits, S.maxEngUnits, S.minRaw, S.maxRaw, ");
                cadenaSql.Append("S.unidad, S.historico, S.alarma, S.invertida, S.direccionPlc, S.direccionPlcAutoGen, ");
                cadenaSql.Append("S.offMsg, S.onMsg, S.criterioArchivo FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("on S.idDatalogger = D.id ");
                cadenaSql.Append("WHERE D.nombre = '" + nombreDatalogger + "' ");
                cadenaSql.Append("AND S.codigo LIKE '%.T[_]%' ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
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

        public DataTable findDigitalesByNombreDatalogger(String nombreDatalogger)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.codigo, S.tag, S.numeroLogico, S.numeroFisico, S.minEngUnits, S.maxEngUnits, S.minRaw, S.maxRaw, ");
                cadenaSql.Append("S.unidad, S.historico, S.alarma, S.invertida, S.direccionPlc, S.direccionPlcAutoGen, ");
                cadenaSql.Append("S.offMsg, S.onMsg, S.criterioArchivo FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("on S.idDatalogger = D.id ");
                cadenaSql.Append("WHERE D.nombre = '" + nombreDatalogger + "' ");
                cadenaSql.Append("AND (S.codigo LIKE '%.E[_]%' OR S.codigo LIKE '%.N[_]%') ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
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

        public DataTable findContadoresByNombreDatalogger(String nombreDatalogger)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = null;
            try
            {
                // Conexión con BBDD
                connection = Conexiones.openConnection();
                // Consulta
                StringBuilder cadenaSql = new StringBuilder();
                cadenaSql.Append("SELECT S.descripcion, S.codigo, S.tag, S.numeroLogico, S.numeroFisico, S.minEngUnits, S.maxEngUnits, S.minRaw, S.maxRaw, ");
                cadenaSql.Append("S.unidad, S.historico, S.alarma, S.invertida, S.direccionPlc, S.direccionPlcAutoGen, ");
                cadenaSql.Append("S.offMsg, S.onMsg, S.criterioArchivo FROM AppListaSeñales.SEÑAL S ");
                cadenaSql.Append("INNER JOIN AppListaSeñales.DATALOGGER D ");
                cadenaSql.Append("on S.idDatalogger = D.id ");
                cadenaSql.Append("WHERE D.nombre = '" + nombreDatalogger + "' ");
                cadenaSql.Append("AND S.codigo LIKE '%.A[_]%' ");
                cadenaSql.Append("ORDER BY S.numeroLogico, S.numeroFisico");
                SqlCommand command = new SqlCommand(cadenaSql.ToString(), connection);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
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
    }
}
