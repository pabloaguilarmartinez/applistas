using AppListaSeñales.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppListaSeñales.Service
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioService()
        {
            this.usuarioRepository = new UsuarioRepository();
        }

        public String findPasswordByUser(String user)
        {
            return usuarioRepository.findPasswordByUser(user);
        }
    }
}
