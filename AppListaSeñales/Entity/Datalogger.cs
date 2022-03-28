using System;
using System.Collections.Generic;
using System.Text;

namespace AppListaSeñales.Entity
{
    class Datalogger
    {
        #region Atributos
        private int id;
        private string nombre;
        private int numeroPunto;
        private int idExplotacion;
        private int numeroAgrupacion;
        private int numeroDatalogger;
        private string direccionIp;
        private int puerto;
        private string tipo;
        private string horasComunicacion;
        private string zonaSectorizacion;
        #endregion

        #region Getters y Setters
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int NumeroPunto { get => numeroPunto; set => numeroPunto = value; }
        public int IdExplotacion { get => idExplotacion; set => idExplotacion = value; }
        public int NumeroAgrupacion { get => numeroAgrupacion; set => numeroAgrupacion = value; }
        public int NumeroDatalogger { get => numeroDatalogger; set => numeroDatalogger = value; }
        public string DireccionIp { get => direccionIp; set => direccionIp = value; }
        public int Puerto { get => puerto; set => puerto = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string HorasComunicacion { get => horasComunicacion; set => horasComunicacion = value; }
        public string ZonaSectorizacion { get => zonaSectorizacion; set => zonaSectorizacion = value; }
        #endregion
    }
}
