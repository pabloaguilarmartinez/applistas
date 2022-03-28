using System;
using System.Collections.Generic;
using System.Text;

namespace AppListaSeñales.Entity
{
    public class Agrupacion
    {
        private Int32 id;
        private String codigo;
        private String descripcion;

        #region Getters y setters
        public int Id { get => id; set => id = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        #endregion
    }
}
