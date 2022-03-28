using AppListaSeñales.Entity;
using AppListaSeñales.Repository;
using AppListaSeñales.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace AppListaSeñales.Service
{
    public class SeñalService
    {
        private readonly SeñalRepository señalRepository;

        #region Constructor
        public SeñalService()
        {
            this.señalRepository = new SeñalRepository();
        }
        #endregion

        public Boolean createListaSeñales(Dictionary<String, Señal> listaSeñales)
        {
            int señalesAñadidas = señalRepository.createSeñal(listaSeñales);

            if (señalesAñadidas == listaSeñales.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable findSeñalesAnalogicasByNombreEstacion(String nombreEstacion)
        {
            return señalRepository.findSeñalesAnalogicasByNombreEstacion(nombreEstacion);
        }

        public DataTable findConsignasByNombreEstacion(String nombreEstacion)
        {
            return señalRepository.findConsignasByNombreEstacion(nombreEstacion);
        }

        public DataTable findContadoresByNombreEstacion(String nombreEstacion)
        {
            return señalRepository.findContadoresByNombreEstacion(nombreEstacion);
        }

        public DataTable findDigitalesByNombreEstacion(String nombreEstacion)
        {
            return señalRepository.findDigitalesByNombreEstacion(nombreEstacion);
        }

        public DataTable findTelemandosByNombreEstacion(String nombreEstacion)
        {
            return señalRepository.findTelemandosByNombreEstacion(nombreEstacion);
        }

        public DataTable findSeñalesCreadasByNombreEstacion(String nombreEstacion)
        {
            return señalRepository.findSeñalesCreadasByNombreEstacion(nombreEstacion);
        }

        public DataTable findSeñalesCreadasByNombreDatalogger(String nombreDatalogger)
        {
            return señalRepository.findSeñalesCreadasByNombreDatalogger(nombreDatalogger.Split("(")[0]);
        }

        public DataTable findSeñalesEstacionParaExportarExcel(String nombreEstacion)
        {
            return señalRepository.findSeñalesByNombreEstacion(nombreEstacion);
        }

        public bool deleteInstancia(String instancia)
        {
            if (señalRepository.deleteSeñales(instancia) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateAtributoInstancia(Señal señal)
        {
            if (señalRepository.updateSeñal(señal) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateAtributoInstanciaPreview(Señal señal)
        {
            if (señalRepository.updateSeñalPreview(señal) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable findInstanciasByNombreEstacion(String nombreEstacion)
        {
            return señalRepository.findInstanciasByNombreEstacion(nombreEstacion);
        }

        public DataTable findSeñalesAnalogicasByNombreDatalogger(String nombreDatalogger)
        {
            return señalRepository.findSeñalesAnalogicasByNombreDatalogger(nombreDatalogger);
        }

        public DataTable findConsignasByNombreDatalogger(String nombreDatalogger)
        {
            return señalRepository.findConsignasByNombreDatalogger(nombreDatalogger);
        }

        public DataTable findContadoresByNombreDatalogger(String nombreDatalogger)
        {
            return señalRepository.findContadoresByNombreDatalogger(nombreDatalogger);
        }

        public DataTable findDigitalesByNombreDatalogger(String nombreDatalogger)
        {
            return señalRepository.findDigitalesByNombreDatalogger(nombreDatalogger);
        }

        public DataTable findTelemandosByNombreDatalogger(String nombreDatalogger)
        {
            return señalRepository.findTelemandosByNombreDatalogger(nombreDatalogger);
        }
    }
}
