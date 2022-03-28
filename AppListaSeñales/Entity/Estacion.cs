using System;
using System.Collections.Generic;
using System.Text;

namespace AppListaSeñales.Entity
{
    public class Estacion
    {
        // Atributos
        private Int32 id;
        private String nombre;
        private Int32 numero;
        private Int32 idExplotacion;
        private Decimal minRaw;
        private Decimal maxRaw;
        private String protocoloComunicacion;
        private int numeroEsclavo;

        #region Constructores
        // Sin parámetros
        public Estacion()
        {
        }
        #endregion

        #region Getters y Setters
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Numero { get => numero; set => numero = value; }
        public int IdExplotacion { get => idExplotacion; set => idExplotacion = value; }
        public decimal MinRaw { get => minRaw; set => minRaw = value; }
        public decimal MaxRaw { get => maxRaw; set => maxRaw = value; }
        public string ProtocoloComunicacion { get => protocoloComunicacion; set => protocoloComunicacion = value; }
        public int NumeroEsclavo { get => numeroEsclavo; set => numeroEsclavo = value; }
        #endregion
    }
}
