using System;
using System.Collections.Generic;
using System.Text;

namespace AppListaSeñales.Entity
{
    public class Plantilla
    {
        private String nombrePlantilla;
        private String nombreAtributo;
        private String descripcion;
        private String tipo;
        private Decimal maxCuentas;
        private Decimal minCuentas;
        private Decimal maxRango;
        private Decimal minRango;
        private String unidad;
        private String historico;
        private String alarma;
        private String observaciones;
        private String tipoPlantilla;
        private String shortDesc;

        #region Getters y setters
        public string NombrePlantilla { get => nombrePlantilla; set => nombrePlantilla = value; }
        public string NombreAtributo { get => nombreAtributo; set => nombreAtributo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public decimal MaxCuentas { get => maxCuentas; set => maxCuentas = value; }
        public decimal MinCuentas { get => minCuentas; set => minCuentas = value; }
        public decimal MaxRango { get => maxRango; set => maxRango = value; }
        public decimal MinRango { get => minRango; set => minRango = value; }
        public string Unidad { get => unidad; set => unidad = value; }
        public string Historico { get => historico; set => historico = value; }
        public string Alarma { get => alarma; set => alarma = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string TipoPlantilla { get => tipoPlantilla; set => tipoPlantilla = value; }
        public string ShortDesc { get => shortDesc; set => shortDesc = value; }
        #endregion
    }
}
