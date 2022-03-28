using System;
using System.Collections.Generic;
using System.Text;

namespace AppListaSeñales.Entity
{
    public class Usuario
    {
        private Int32 id;
        private String user;
        private String password;

        #region Getters y setters
        public int Id { get => id; set => id = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        #endregion
    }
}
