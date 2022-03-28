using AppListaSeñales.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AppListaSeñales.Controller
{
    public class UsuarioController
    {
        private readonly UsuarioService usuarioService;

        #region Constructor
        public UsuarioController()
        {
            this.usuarioService = new UsuarioService();
        }
        #endregion

        public String findPasswordByUser(TextBox textBoxUser)
        {
            return usuarioService.findPasswordByUser(textBoxUser.Text);
        }
    }
}
