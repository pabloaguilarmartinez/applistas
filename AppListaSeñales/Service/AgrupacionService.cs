using AppListaSeñales.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppListaSeñales.Service
{
    public class AgrupacionService
    {
        private readonly AgrupacionRepository repository;

        #region Constructor
        public AgrupacionService()
        {
            this.repository = new AgrupacionRepository();
        }
        #endregion

        public DataTable findDescripcionAll()
        {
            return repository.findDescripcionAll();
        }

        public String findCodigoByDescripcion(String descripcion)
        {
            return repository.findCodigoByDescripcion(descripcion);
        }
    }
}
