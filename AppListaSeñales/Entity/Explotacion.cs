using System;
using System.Collections.Generic;
using System.Text;

namespace AppListaSeñales.Entity
{
    public class Explotacion
    {
        // Atributos
        private Int32 id;
        private String nombre;
        private String cebeAquacis;
        private String sitAquacis;
        private String cebeIas;
        private String explotacionIas;
        private String servicioIas;
        private String observaciones;

        #region Constructores
        // Sin parámetros
        public Explotacion()
        {
        }
        #endregion

        #region Getters y Setters
        // Getters y setters
        public string Nombre { get => nombre; set => nombre = value; }
        public string CebeAquacis { get => cebeAquacis; set => cebeAquacis = value; }
        public string SitAquacis { get => sitAquacis; set => sitAquacis = value; }
        public string CebeIas { get => cebeIas; set => cebeIas = value; }
        public string ExplotacionIas { get => explotacionIas; set => explotacionIas = value; }
        public string ServicioIas { get => servicioIas; set => servicioIas = value; }
        public int Id { get => id; set => id = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        #endregion
    }
}
