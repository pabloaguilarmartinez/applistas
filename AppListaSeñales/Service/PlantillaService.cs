using AppListaSeñales.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppListaSeñales.Service
{
    public class PlantillaService
    {
        private readonly PlantillaRepository plantillaRepository;

        #region Constructor
        public PlantillaService()
        {
            this.plantillaRepository = new PlantillaRepository();
        }
        #endregion

        public DataTable findTipoPlantillaAll()
        {
            return plantillaRepository.findTipoPlantillaAll();
        }

        public DataTable findByTipoPlantilla(String tipoPlantilla)
        {
            return plantillaRepository.findByTipoPlantilla(tipoPlantilla);
        }

        public DataTable findNombrePlantillaByTipoPlantilla(String tipoPlantilla)
        {
            return plantillaRepository.findNombrePlantillaByTipoPlantilla(tipoPlantilla);
        }

        public List<String> findAtributosByNombrePlantilla(String nombrePlantilla)
        {
            return plantillaRepository.findAtributosByNombrePlantilla(nombrePlantilla);
        }
    }
}
