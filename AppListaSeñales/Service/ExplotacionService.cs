using AppListaSeñales.Entity;
using AppListaSeñales.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppListaSeñales.Service
{
    public class ExplotacionService
    {

        private readonly ExplotacionRepository repository;

        #region Constructor
        public ExplotacionService()
        {
            this.repository = new ExplotacionRepository();
        }
        #endregion

        public Boolean updateCebeIas(String nombreExplotacion, String cebeIas)
        {
            if (repository.findNumeroServiciosExplotacion(nombreExplotacion) == repository.updateCebeIasExplotacion(nombreExplotacion, cebeIas))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable findSitAquacisByNombre(String nombre)
        {
            List<Explotacion> explotaciones = repository.findSitAquacisByNombre(nombre);
            DataTable dt = new DataTable();
            dt.Columns.Add("sitAquacis", typeof(string));
            foreach (Explotacion explotacion in explotaciones)
            {
                String servicioIas = "";
                if (explotacion.ServicioIas.Equals("AB"))
                {
                    servicioIas = "Abastecimiento";
                }
                if (explotacion.ServicioIas.Equals("AC"))
                {
                    servicioIas = "Saneamiento";
                }
                if (explotacion.ServicioIas.Equals("ET"))
                {
                    servicioIas = "Producción";
                }
                if (explotacion.ServicioIas.Equals("ED"))
                {
                    servicioIas = "Depuración";
                }
                if (explotacion.ServicioIas.Equals("CO"))
                {
                    servicioIas = "Colectores";
                }
                if (explotacion.ServicioIas.Equals("LA"))
                {
                    servicioIas = "Línea de agua";
                }
                if (explotacion.ServicioIas.Equals("LF"))
                {
                    servicioIas = "Línea de fangos";
                }
                if (explotacion.ServicioIas.Equals("DE"))
                {
                    servicioIas = "Desodorización";
                }
                if (explotacion.ServicioIas.Equals("LG"))
                {
                    servicioIas = "Línea de gas";
                }
                if (explotacion.ServicioIas.Equals("SZ"))
                {
                    servicioIas = "Sectorización";
                }
                DataRow row = dt.NewRow();
                if (explotacion.Observaciones.Equals(""))
                {
                    row["sitAquacis"] = explotacion.SitAquacis + " - " + servicioIas;
                }
                else
                {
                    row["sitAquacis"] = explotacion.SitAquacis + " - " + servicioIas + " (" + explotacion.Observaciones + ")";
                }
                
                dt.Rows.Add(row);
            }
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public DataTable findNombreExplotacionesCreadas()
        {
            return repository.findNombreExplotacionesCreadas();
        }

        public DataTable findNombreExplotacionesSinCrear()
        {
            return repository.findNombreExplotacionesSinCrear();
        }

        public Explotacion findCodigosIasByNombre(String nombreExplotacion, String sitAquacis)
        {
            return repository.findCodigosIasByNombre(nombreExplotacion, sitAquacis.Substring(0,4));
        }

        public int findIdByExplotacion(String nombre, String sitAquacis)
        {
            return repository.findIdByExplotacion(nombre, sitAquacis.Substring(0, 4));
        }

        public String findCebeAquacisByNombre(String nombre)
        {
            return repository.findCebeAquacisByNombre(nombre);
        }
    }
}
