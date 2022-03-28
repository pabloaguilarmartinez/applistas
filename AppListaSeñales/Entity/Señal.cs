using System;

namespace AppListaSeñales.Entity
{
    public class Señal
    {
        private Int32 id;
        private String descripcion;
        private String tag;
        private Decimal minEngUnits;
        private Decimal maxEngUnits;
        private Decimal minRaw;
        private Decimal maxRaw;
        private String codigo;
        private String onMsg;
        private String offMsg;
        private String unidad;
        private String alarma;
        private String historico;
        private Int32 idEstacion;
        private Int32 numeroLogico;
        private Int32 numeroFisico;
        private String invertida;
        private String direccionPlc;
        private Boolean direccionPlcAutoGen;
        private Boolean varCero;
        private Boolean criterioArchivo;
        private int idDatalogger;

        #region Constructor
        public Señal(string descripcion, string tag, decimal minEngUnits,
            decimal maxEngUnits, decimal minRaw, decimal maxRaw, string codigo, string onMsg, string offMsg, string unidad,
            string alarma, string historico, int idEstacion, int numeroLogico, int numeroFisico, string invertida, string direccionPlc)
        {
            this.descripcion = descripcion;
            this.tag = tag;
            this.minEngUnits = minEngUnits;
            this.maxEngUnits = maxEngUnits;
            this.minRaw = minRaw;
            this.maxRaw = maxRaw;
            this.codigo = codigo;
            this.onMsg = onMsg;
            this.offMsg = offMsg;
            this.unidad = unidad;
            this.alarma = alarma;
            this.historico = historico;
            this.idEstacion = idEstacion;
            this.numeroLogico = numeroLogico;
            this.numeroFisico = numeroFisico;
            this.invertida = invertida;
            this.direccionPlc = direccionPlc;
        }
        public Señal()
        {
        }

        #endregion

        #region Getters y setters
        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Tag { get => tag; set => tag = value; }
        public decimal MinEngUnits { get => minEngUnits; set => minEngUnits = value; }
        public decimal MaxEngUnits { get => maxEngUnits; set => maxEngUnits = value; }
        public decimal MinRaw { get => minRaw; set => minRaw = value; }
        public decimal MaxRaw { get => maxRaw; set => maxRaw = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Unidad { get => unidad; set => unidad = value; }
        public string Alarma { get => alarma; set => alarma = value; }
        public string Historico { get => historico; set => historico = value; }
        public int IdEstacion { get => idEstacion; set => idEstacion = value; }
        public int NumeroLogico { get => numeroLogico; set => numeroLogico = value; }
        public int NumeroFisico { get => numeroFisico; set => numeroFisico = value; }
        public string Invertida { get => invertida; set => invertida = value; }
        public string DireccionPlc { get => direccionPlc; set => direccionPlc = value; }
        public string OffMsg { get => offMsg; set => offMsg = value; }
        public string OnMsg { get => onMsg; set => onMsg = value; }
        public bool DireccionPlcAutoGen { get => direccionPlcAutoGen; set => direccionPlcAutoGen = value; }
        public bool VarCero { get => varCero; set => varCero = value; }
        public bool CriterioArchivo { get => criterioArchivo; set => criterioArchivo = value; }
        public int IdDatalogger { get => idDatalogger; set => idDatalogger = value; }
        #endregion
    }
}
