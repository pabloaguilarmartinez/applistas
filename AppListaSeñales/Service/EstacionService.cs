using AppListaSeñales.Entity;
using AppListaSeñales.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppListaSeñales.Service
{
    public class EstacionService
    {
        private readonly EstacionRepository repository;

        #region Constructor
        public EstacionService()
        {
            this.repository = new EstacionRepository();
        }
        #endregion

        #region FindEstacionesByNombreExplotacion
        public DataTable findByNombreExplotacion(string nombreExplotacion, String sitAquacis)
        {
            return repository.findByNombreExplotacion(nombreExplotacion, sitAquacis.Substring(0,4));
        }
        #endregion

        public String findNumeroEstacionByNombre(String nombreEstacion)
        {
            Int32 numeroEstacion = repository.findNumeroEstacionByNombre(nombreEstacion);
            String numeroEstacionString = "";

            if (numeroEstacion < 10)
            {
                numeroEstacionString = "000" + numeroEstacion.ToString();
            }
            else if (numeroEstacion >= 10 && numeroEstacion < 100)
            {
                numeroEstacionString = "00" + numeroEstacion.ToString();
            }
            else if (numeroEstacion >= 100 && numeroEstacion < 1000)
            {
                numeroEstacionString = "0" + numeroEstacion.ToString();
            }
            else if (numeroEstacion >= 1000 && numeroEstacion < 10000)
            {
                numeroEstacionString = numeroEstacion.ToString();
            }
            return numeroEstacionString;
        }
        public int findNumeroEsclavoByNombre(String nombreEstacion)
        {
            return repository.findNumeroEsclavoByNombre(nombreEstacion);     
        }
        public Boolean createEstacion(String nombre, int numero, int idExplotacion, decimal minRaw, decimal maxRaw, String comunicaciones, int numeroEsclavo)
        {
            if (repository.create(nombre, numero, idExplotacion, minRaw, maxRaw, comunicaciones, numeroEsclavo) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Estacion findDatosPlcByNombre(String nombre)
        {
            return repository.findDatosPlcByNombre(nombre);
        }

        public int findIdByNombreEstacionAndNombreExplotacion(String nombreEstacion, String nombreExplotacion)
        {
            return repository.findIdByNombreEstacionAndNombreExplotacion(nombreEstacion, nombreExplotacion);
        }

        public int findIdByNumeroDeEstacionCebeIasExplotacionAndExplotacionIas(string cebeIas, string explotacionIas, int numeroEstacion)
        {
            return repository.findIdByNumeroDeEstacionCebeIasExplotacionAndExplotacionIas(cebeIas, explotacionIas, numeroEstacion);
        }

        public Boolean updateEstacion(String nombre, int numero, decimal minRaw, decimal maxRaw, String comunicaciones, int numeroEsclavo)
        {
            if (repository.update(nombre, numero, minRaw, maxRaw, comunicaciones, numeroEsclavo) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean deleteEstacion(String nombreEstacion, String nombreExplotacion)
        {
            if (repository.deleteByNombreEstacion(nombreEstacion, nombreExplotacion) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Estacion findEstacionByNombreEstacionAndNombreExplotacion(string nombreEstacion, string nombreExplotacion, string sitAquacis)
        {
            return repository.findEstacionByNombreEstacionAndNombreExplotacion(nombreEstacion, nombreExplotacion, sitAquacis.Substring(0, 4));
        }
    }
}
