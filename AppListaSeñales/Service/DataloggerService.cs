using AppListaSeñales.Entity;
using AppListaSeñales.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppListaSeñales.Service
{
    class DataloggerService
    {
        private readonly DataloggerRepository repository;

        #region Constructor
        public DataloggerService()
        {
            this.repository = new DataloggerRepository();
        }
        #endregion

        public Boolean createDatalogger(string nombre, string numeroDatalogger, int idExplotacion, string numeroAgrupacion, string tipo, string puerto, string horasComunicacion, string zonaSectorizacion, string direccionIp, string numeroPunto)
        {
            if (String.IsNullOrEmpty(puerto))
            {
                puerto = "0";
            }
            if (String.IsNullOrEmpty(numeroPunto))
            {
                numeroPunto = "0";
            }
 
            if (repository.create(nombre, Convert.ToInt32(numeroDatalogger), idExplotacion, 
                Convert.ToInt32(numeroAgrupacion), tipo, Convert.ToInt32(puerto), horasComunicacion, zonaSectorizacion, direccionIp, 
                Convert.ToInt32(numeroPunto)) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean updateDatalogger(string nombre, string numeroDatalogger, int idExplotacion, string numeroAgrupacion, string tipo, string puerto, string horasComunicacion, string zonaSectorizacion, string direccionIp, string numeroPunto)
        {
            if (String.IsNullOrEmpty(puerto))
            {
                puerto = "0";
            }
            if (String.IsNullOrEmpty(numeroPunto))
            {
                numeroPunto = "0";
            }
            if (repository.update(nombre, Convert.ToInt32(numeroDatalogger), idExplotacion,
                Convert.ToInt32(numeroAgrupacion), tipo, Convert.ToInt32(puerto), horasComunicacion, zonaSectorizacion, direccionIp,
                Convert.ToInt32(numeroPunto)) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean deleteDatalogger(String nombreEstacion, String nombreExplotacion, string sitAquacis)
        {
            if (repository.deleteByNombreDatalogger(nombreEstacion, nombreExplotacion, sitAquacis.Substring(0, 4)) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable findByNombreExplotacion(string nombreExplotacion, String sitAquacis)
        {
            return repository.findNombreDataloggerByNombreExplotacion(nombreExplotacion, sitAquacis.Substring(0, 4));
        }

        public Datalogger findDataloggerByNombreDataloggerAndNombreExplotacion(string nombreDatalogger, string nombreExplotacion, string sitAquacis)
        {
            return repository.findDataloggerByNombreDataloggerAndNombreExplotacion(nombreDatalogger, nombreExplotacion, sitAquacis.Substring(0, 4));
        }

        public Tuple<int, string, string> findIdNumeroDataloggerAndNumeroAgrupacionByNombreDataloggerAndNombreExplotacion(string nombreDatalogger, string nombreExplotacion, string sitAquacis)
        {
            Datalogger datalogger = repository.findIdNumeroDataloggerAndNumeroAgrupacionByNombreDataloggerAndNombreExplotacion(nombreDatalogger.Split("(")[0], nombreExplotacion, sitAquacis.Substring(0, 4));

            Int32 numeroDatalogger = datalogger.NumeroDatalogger;
            String numeroDataloggerString = "";
            Int32 numeroAgrupacion = datalogger.NumeroAgrupacion;
            String numeroAgrupacionString = "";

            if (numeroDatalogger < 10)
            {
                numeroDataloggerString = "00" + numeroDatalogger.ToString();
            }
            else if (numeroDatalogger >= 10 && numeroDatalogger < 100)
            {
                numeroDataloggerString = "0" + numeroDatalogger.ToString();
            }
            else if (numeroDatalogger >= 100 && numeroDatalogger < 1000)
            {
                numeroDataloggerString =  numeroDatalogger.ToString();
            }

            if (numeroAgrupacion < 10)
            {
                numeroAgrupacionString = "0" + numeroAgrupacion.ToString();
            }
            else
            {
                numeroAgrupacionString = numeroAgrupacion.ToString();
            }

            return Tuple.Create(datalogger.Id, numeroDataloggerString, numeroAgrupacionString);
        }

        public DataTable findForListasByNombreExplotacion(string nombreExplotacion, string sitAquacis)
        {
            DataTable dataloggers = repository.findNombreDataloggerByNombreExplotacion(nombreExplotacion, sitAquacis.Substring(0, 4));
            dataloggers.Rows[0].Delete();
            foreach (DataRow row in dataloggers.Rows)
            {
                row[0] = row[0] + "(Datalogger)";
            }
            return dataloggers;
        }
    }
}
