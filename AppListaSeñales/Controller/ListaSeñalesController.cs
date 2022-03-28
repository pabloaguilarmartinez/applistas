using AppListaSeñales.Entity;
using AppListaSeñales.Service;
using AppListaSeñales.Utils;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppListaSeñales.Controller
{
    public class ListaSeñalesController
    {
        #region Servicios
        private readonly AgrupacionService agrupacionService;
        private readonly ExplotacionService explotacionService;
        private readonly EstacionService estacionService;
        private readonly PlantillaService plantillaService;
        private readonly SeñalService señalService;
        private readonly DataloggerService dataloggerService;
        #endregion

        #region Constructor
        public ListaSeñalesController()
        {
            this.agrupacionService = new AgrupacionService();
            this.explotacionService = new ExplotacionService();
            this.estacionService = new EstacionService();
            this.plantillaService = new PlantillaService();
            this.señalService = new SeñalService();
            this.dataloggerService = new DataloggerService();
        }
        #endregion

        public void findNombreExplotaciones(ComboBox comboBoxExplotaciones)
        {
            DataTable nombreExplotaciones = explotacionService.findNombreExplotacionesCreadas();
            comboBoxExplotaciones.DisplayMember = "nombre";
            comboBoxExplotaciones.DataSource = nombreExplotaciones;
        }

        public void findDescripcionAgrupaciones(ComboBox comboBoxAgrupaciones)
        {
            DataTable descripcionAgrupaciones = agrupacionService.findDescripcionAll();
            comboBoxAgrupaciones.DisplayMember = "descripcion";
            comboBoxAgrupaciones.DataSource = descripcionAgrupaciones;
        }

        public void findNombreEstacionesByNombreExplotacion(ComboBox comboBoxEstaciones, ComboBox nombreExplotacion, ComboBox comboBoxSitAquacis)
        {
            DataTable nombreEstaciones = estacionService.findByNombreExplotacion(nombreExplotacion.Text, comboBoxSitAquacis.Text);
            comboBoxEstaciones.DisplayMember = "nombre";
            comboBoxEstaciones.DataSource = nombreEstaciones;
            comboBoxEstaciones.SelectedItem = -1;
        }

        public void findNombreEstacionesAndNombreDataloggersByNombreExplotacion(ComboBox comboBoxEstaciones, ComboBox nombreExplotacion, ComboBox comboBoxSitAquacis)
        {
            DataTable nombreEstaciones = estacionService.findByNombreExplotacion(nombreExplotacion.Text, comboBoxSitAquacis.Text);
            DataTable nombreDataloggers = dataloggerService.findForListasByNombreExplotacion(nombreExplotacion.Text, comboBoxSitAquacis.Text);
            nombreEstaciones.Merge(nombreDataloggers);
            comboBoxEstaciones.DisplayMember = "nombre";
            comboBoxEstaciones.DataSource = nombreEstaciones;
            comboBoxEstaciones.SelectedItem = -1;
        }

        public void findTipoPlantillaAll(ComboBox comboBoxPlantillas)
        {
            DataTable tiposPlantilla = plantillaService.findTipoPlantillaAll();
            comboBoxPlantillas.DisplayMember = "sTipoPlantilla";
            comboBoxPlantillas.DataSource = tiposPlantilla;      
        }

        public void findPlantillasByTipoPlantilla(ComboBox comboBoxPlantillas, ComboBox comboBoxEstaciones, DataGridView gridPlantillas)
        {
            if (AppListaSeñales.esDatalogger)
            {
                DataTable plantillas = plantillaService.findByTipoPlantilla(comboBoxPlantillas.Text);
                gridPlantillas.DataSource = plantillas;
                gridPlantillas.Visible = true;
                String nombrePlantillaAnterior = "";
                // Formateamos el grid
                for (int i = 0; i < gridPlantillas.Rows.Count; i++)
                {
                    // Borramos las celdas de nombre plantilla que estén repetidas y sólo dejamos habilitada
                    //la celda de al lado de la única existente para añadir señales
                    String nombrePlantillaActual = gridPlantillas.Rows[i].Cells["Nombre Plantilla"].Value.ToString();
                    if (nombrePlantillaActual.Equals(nombrePlantillaAnterior))
                    {
                        gridPlantillas.Rows[i].Cells["Nombre Plantilla"].Value = "";
                        gridPlantillas.Rows[i].Cells["Elementos"].ReadOnly = true;
                        gridPlantillas.Rows[i].Cells["Elementos"].Value = "";
                        gridPlantillas.Rows[i].Cells["Característica Elemento"].Value = "";
                        gridPlantillas.Rows[i].Cells["Característica Elemento"].ReadOnly = true;
                    }
                    else
                    {
                        gridPlantillas.Rows[i].Cells["Característica Elemento"].Value = "XXXXX";
                        gridPlantillas.Rows[i].Cells["Elementos"].Value = "0";
                        nombrePlantillaAnterior = nombrePlantillaActual;
                    }
                    // Formateamos descripciones (Se hace en la inserción de la señal)
                    // gridPlantillas.Rows[i].Cells["Descripción"].Value = gridPlantillas.Rows[i].Cells["Descripción"].Value + " XXXXX - " + comboBoxEstaciones.Text;
                    // Formateamos MinRaw y MaxRaw con los valores introducidos en la creación de la estación
                    if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("V")
                        || gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("C")
                        || gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("P"))
                    {

                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("A"))
                    {
                        gridPlantillas.Rows[i].Cells["MinRaw"].Value = 0;
                        gridPlantillas.Rows[i].Cells["MaxRaw"].Value = 999999999;
                        gridPlantillas.Rows[i].Cells["MinEU"].Value = 0;
                        gridPlantillas.Rows[i].Cells["MaxEU"].Value = 999999999;
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("M"))
                    {
                        gridPlantillas.Rows[i].Cells["MinRaw"].Value = 0;
                        gridPlantillas.Rows[i].Cells["MaxRaw"].Value = 65535;
                        gridPlantillas.Rows[i].Cells["MinEU"].Value = 0;
                        gridPlantillas.Rows[i].Cells["MaxEU"].Value = 65535;
                    }
                    // Formateamos alarma e histórico
                    if (gridPlantillas.Rows[i].Cells["Histórico"].Value.ToString().Equals("Si") || gridPlantillas.Rows[i].Cells["Histórico"].Value.ToString().Equals("SI"))
                    {
                        gridPlantillas.Rows[i].Cells["Histórico"].Value = "Yes";
                    }
                    else
                    {
                        gridPlantillas.Rows[i].Cells["Histórico"].Value = "No";
                    }
                    if (gridPlantillas.Rows[i].Cells["Alarma"].Value.ToString().Equals("Si") || gridPlantillas.Rows[i].Cells["Alarma"].Value.ToString().Equals("SI"))
                    {
                        gridPlantillas.Rows[i].Cells["Alarma"].Value = "On";
                    }
                    else
                    {
                        gridPlantillas.Rows[i].Cells["Alarma"].Value = "None";
                    }
                    // Añadimos Protocolo Comunicación al grid, aunque no se muestra
                    //gridPlantillas.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
                    // Creamos identificador
                    gridPlantillas.Rows[i].Cells["Identificador"].Value = nombrePlantillaActual + gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString();
                    // Formateamos Invertida de digitales
                    /*if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("E"))
                    {
                        //gridPlantillas.Rows[i].Cells["Invertida"] = new DataGridViewCheckBoxCell();
                        //gridPlantillas.Rows[i].Cells["Invertida"].Value = "Direct";
                    }*/
                    // Formateamos On y Off Msg
                    if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("T"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Desactivada";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Activada";
                        gridPlantillas.Rows[i].Cells["Número Físico"].ReadOnly = true;
                        gridPlantillas.Rows[i].Cells["MinRaw"].ReadOnly = true;
                        gridPlantillas.Rows[i].Cells["MaxRaw"].ReadOnly = true;
                        gridPlantillas.Rows[i].Cells["MinEU"].ReadOnly = true;
                        gridPlantillas.Rows[i].Cells["MaxEU"].ReadOnly = true;
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_MARC"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Paro";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Marcha";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_ASIG"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Desasignado";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Asignado";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_AUMA"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Manual";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Automático";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_HADE"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Deshabilitado";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Habilitado";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_LOCL") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_REMO") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_AUTO") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_MANU") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_ABIE") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_ANDO") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_CERR") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_CNDO") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_PARA") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TMFU") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TMF2") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TMF3"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "No";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Si";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TRM1"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "No";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "En Tramo 1";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TRM2"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "No";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "En Tramo 2";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TRM3"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "No";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "En Tramo 3";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TRM4"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "No";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "En Tramo 4";
                    }
                    else
                    {
                        if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("E"))
                        {
                            gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Normal";
                            gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Alarma";
                        }
                    }
                    // Comprobamos si el atributo es derivado
                    /*if (atributosDerivados.ContainsKey(gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString()))
                    {
                        gridPlantillas.Rows[i].Cells["Atributo Derivado"].Value = "True";
                    }
                    else
                    {
                        gridPlantillas.Rows[i].Cells["Atributo Derivado"].Value = "False";
                        atributosDerivados.Add(gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString(), true);
                    }*/
                }
            }
            else
            {
                //Dictionary<String, Boolean> atributosDerivados = new Dictionary<string, bool>();
                DataTable plantillas = plantillaService.findByTipoPlantilla(comboBoxPlantillas.Text);
                Estacion estacion = estacionService.findDatosPlcByNombre(comboBoxEstaciones.Text);
                Decimal minRaw = estacion.MinRaw;
                Decimal maxRaw = estacion.MaxRaw;
                String protocoloComunicacion = estacion.ProtocoloComunicacion;
                if (protocoloComunicacion.Equals("Lacbus"))
                {
                    gridPlantillas.Columns["Criterio Archivo"].Visible = true;
                }
                else
                {
                    gridPlantillas.Columns["Criterio Archivo"].Visible = false;
                }
                gridPlantillas.DataSource = plantillas;
                gridPlantillas.Visible = true;
                String nombrePlantillaAnterior = "";
                // Formateamos el grid
                for (int i = 0; i < gridPlantillas.Rows.Count; i++)
                {
                    // Borramos las celdas de nombre plantilla que estén repetidas y sólo dejamos habilitada
                    //la celda de al lado de la única existente para añadir señales
                    String nombrePlantillaActual = gridPlantillas.Rows[i].Cells["Nombre Plantilla"].Value.ToString();
                    if (nombrePlantillaActual.Equals(nombrePlantillaAnterior))
                    {
                        gridPlantillas.Rows[i].Cells["Nombre Plantilla"].Value = "";
                        gridPlantillas.Rows[i].Cells["Elementos"].ReadOnly = true;
                        gridPlantillas.Rows[i].Cells["Elementos"].Value = "";
                        gridPlantillas.Rows[i].Cells["Característica Elemento"].Value = "";
                        gridPlantillas.Rows[i].Cells["Característica Elemento"].ReadOnly = true;
                    }
                    else
                    {
                        gridPlantillas.Rows[i].Cells["Característica Elemento"].Value = "XXXXX";
                        gridPlantillas.Rows[i].Cells["Elementos"].Value = "0";
                        nombrePlantillaAnterior = nombrePlantillaActual;
                    }
                    // Formateamos descripciones (Se hace en la inserción de la señal)
                    // gridPlantillas.Rows[i].Cells["Descripción"].Value = gridPlantillas.Rows[i].Cells["Descripción"].Value + " XXXXX - " + comboBoxEstaciones.Text;
                    // Formateamos MinRaw y MaxRaw con los valores introducidos en la creación de la estación
                    if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("V")
                        || gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("C")
                        || gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("P"))
                    {
                        gridPlantillas.Rows[i].Cells["MinRaw"].Value = minRaw;
                        gridPlantillas.Rows[i].Cells["MaxRaw"].Value = maxRaw;
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("A"))
                    {
                        gridPlantillas.Rows[i].Cells["MinRaw"].Value = 0;
                        gridPlantillas.Rows[i].Cells["MaxRaw"].Value = 999999999;
                        gridPlantillas.Rows[i].Cells["MinEU"].Value = 0;
                        gridPlantillas.Rows[i].Cells["MaxEU"].Value = 999999999;
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("M"))
                    {
                        gridPlantillas.Rows[i].Cells["MinRaw"].Value = 0;
                        gridPlantillas.Rows[i].Cells["MaxRaw"].Value = 65535;
                        gridPlantillas.Rows[i].Cells["MinEU"].Value = 0;
                        gridPlantillas.Rows[i].Cells["MaxEU"].Value = 65535;
                    }
                    // Formateamos alarma e histórico
                    if (gridPlantillas.Rows[i].Cells["Histórico"].Value.ToString().Equals("Si") || gridPlantillas.Rows[i].Cells["Histórico"].Value.ToString().Equals("SI"))
                    {
                        gridPlantillas.Rows[i].Cells["Histórico"].Value = "Yes";
                    }
                    else
                    {
                        gridPlantillas.Rows[i].Cells["Histórico"].Value = "No";
                    }
                    if (gridPlantillas.Rows[i].Cells["Alarma"].Value.ToString().Equals("Si") || gridPlantillas.Rows[i].Cells["Alarma"].Value.ToString().Equals("SI"))
                    {
                        gridPlantillas.Rows[i].Cells["Alarma"].Value = "On";
                    }
                    else
                    {
                        gridPlantillas.Rows[i].Cells["Alarma"].Value = "None";
                    }
                    // Añadimos Protocolo Comunicación al grid, aunque no se muestra
                    gridPlantillas.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
                    // Creamos identificador
                    gridPlantillas.Rows[i].Cells["Identificador"].Value = nombrePlantillaActual + gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString();
                    // Formateamos Invertida de digitales
                    /*if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("E"))
                    {
                        //gridPlantillas.Rows[i].Cells["Invertida"] = new DataGridViewCheckBoxCell();
                        //gridPlantillas.Rows[i].Cells["Invertida"].Value = "Direct";
                    }*/
                    // Formateamos On y Off Msg
                    if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("T"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Desactivada";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Activada";
                        gridPlantillas.Rows[i].Cells["Número Físico"].ReadOnly = true;
                        gridPlantillas.Rows[i].Cells["MinRaw"].ReadOnly = true;
                        gridPlantillas.Rows[i].Cells["MaxRaw"].ReadOnly = true;
                        gridPlantillas.Rows[i].Cells["MinEU"].ReadOnly = true;
                        gridPlantillas.Rows[i].Cells["MaxEU"].ReadOnly = true;
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_MARC"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Paro";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Marcha";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_ASIG"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Desasignado";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Asignado";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_AUMA"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Manual";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Automático";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_HADE"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Deshabilitado";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Habilitado";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_LOCL") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_REMO") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_AUTO") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_MANU") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_ABIE") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_ANDO") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_CERR") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_CNDO") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_PARA") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TMFU") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TMF2") ||
                        gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TMF3"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "No";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Si";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TRM1"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "No";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "En Tramo 1";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TRM2"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "No";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "En Tramo 2";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TRM3"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "No";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "En Tramo 3";
                    }
                    else if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Equals("E_TRM4"))
                    {
                        gridPlantillas.Rows[i].Cells["OffMsg"].Value = "No";
                        gridPlantillas.Rows[i].Cells["OnMsg"].Value = "En Tramo 4";
                    }
                    else
                    {
                        if (gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("E"))
                        {
                            gridPlantillas.Rows[i].Cells["OffMsg"].Value = "Normal";
                            gridPlantillas.Rows[i].Cells["OnMsg"].Value = "Alarma";
                        }
                    }
                    // Comprobamos si el atributo es derivado
                    /*if (atributosDerivados.ContainsKey(gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString()))
                    {
                        gridPlantillas.Rows[i].Cells["Atributo Derivado"].Value = "True";
                    }
                    else
                    {
                        gridPlantillas.Rows[i].Cells["Atributo Derivado"].Value = "False";
                        atributosDerivados.Add(gridPlantillas.Rows[i].Cells["Atributo"].Value.ToString(), true);
                    }*/
                }
            }       
        }

        public DataTable findNombrePlantillasByTipoPlantilla(ComboBox tipoPlantilla)
        {
            return plantillaService.findNombrePlantillaByTipoPlantilla(tipoPlantilla.Text);
        }

        public void createListaSeñales(Dictionary<String, Señal> listaSeñales, DataGridView gridCrearSeñales)
        {
            if (señalService.createListaSeñales(listaSeñales))
            {
                MessageBox.Show("Lista de señales creada.");
                gridCrearSeñales.Rows.Clear();
                listaSeñales.Clear();
            }
            else
            {
                MessageBox.Show("Error al crear lista de señales.");
            }
        }

        public void findSeñalesCreadasByNombreDatalogger(ComboBox nombreDatalogger, DataGridView gridSeñalesCreadas)
        {
            DataTable señales = señalService.findSeñalesCreadasByNombreDatalogger(nombreDatalogger.Text);
            AppListaSeñales.señalesCreadas = señales.AsEnumerable().ToDictionary<DataRow, String, Señal>(row => row.Field<String>("codigo"), row => new Señal());
            gridSeñalesCreadas.DataSource = señales;
        }

        public void findSeñalesCreadasByNombreEstacion(ComboBox nombreEstacion, DataGridView gridSeñalesCreadas)
        {
            Estacion estacion = estacionService.findDatosPlcByNombre(nombreEstacion.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñalesCreadas.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñalesCreadas.Columns["Criterio Archivo"].Visible = false;
            }
            DataTable señales = señalService.findSeñalesCreadasByNombreEstacion(nombreEstacion.Text);
            AppListaSeñales.señalesCreadas = señales.AsEnumerable().ToDictionary<DataRow, String, Señal>(row => row.Field<String>("codigo"), row => new Señal());
            gridSeñalesCreadas.DataSource = señales;
            for (int i = 0; i < gridSeñalesCreadas.Rows.Count; i++)
            {
                gridSeñalesCreadas.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }
        }

        public void findSeñalesEstacionExportarExcel(ComboBox nombreEstacion, DataGridView gridExcel)
        {
            DataTable señales = señalService.findSeñalesEstacionParaExportarExcel(nombreEstacion.Text);
            gridExcel.DataSource = señales;
            gridExcel.Visible = true;
            gridExcel.Visible = false;
            // Formateamos el grid
            for (int i = 0; i < gridExcel.Rows.Count; i++)
            {
                // Generamos ID
                gridExcel.Rows[i].Cells["ID"].Value = i + 1;
                // Descartables
                if (gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("N"))
                {
                    gridExcel.Rows[i].Cells["Descartable"].Value = "Yes";
                }
                else
                {
                    gridExcel.Rows[i].Cells["Descartable"].Value = "No";
                }
                // Generamos Grupo
                gridExcel.Rows[i].Cells["Grupo"].Value = "Estación " + gridExcel.Rows[i].Cells["Estacion"].Value;
                // Valor inicial
                if (gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0,1).Equals("V") || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("A")
                    || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("M") || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("P")
                    || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("C"))
                {
                    gridExcel.Rows[i].Cells["ValorInicial"].Value = gridExcel.Rows[i].Cells["MinValue"].Value;
                }
                else
                {
                    gridExcel.Rows[i].Cells["ValorInicial"].Value = "Off";
                }
                // ReadOnly
                if (gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("T") || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("A")
                    || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("P"))
                {
                    gridExcel.Rows[i].Cells["ReadOnly"].Value = "No";
                }
                else
                {
                    gridExcel.Rows[i].Cells["ReadOnly"].Value = "Yes";
                }
                // VAR_0
                if (!String.IsNullOrEmpty(gridExcel.Rows[i].Cells["varCero"].Value.ToString()) && gridExcel.Rows[i].Cells["varCero"].Value.ToString().Equals("True"))
                {
                    gridExcel.Rows[i].Cells["VAR_0"].Value = "VAR_0";
                }
                // Evento y AlarmState
                if (gridExcel.Rows[i].Cells["AlarmState"].Value.ToString().Equals("On"))
                {
                    gridExcel.Rows[i].Cells["Evento"].Value = "No";
                }
                else if(gridExcel.Rows[i].Cells["AlarmState"].Value.ToString().Equals("None"))
                {
                    gridExcel.Rows[i].Cells["Evento"].Value = "Yes";
                }
                // Alarm
                if (gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("E") || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Substring(0, 1).Equals("T"))
                {
                    gridExcel.Rows[i].Cells["AlarmPri"].Value = 400;
                }
                else
                {
                    gridExcel.Rows[i].Cells["LoLoAlarmPri"].Value = 400;
                    gridExcel.Rows[i].Cells["HiHiAlarmPri"].Value = 400;
                    gridExcel.Rows[i].Cells["LoAlarmPri"].Value = 600;
                    gridExcel.Rows[i].Cells["HiAlarmPri"].Value = 600;
                    if (gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_CAUD"))
                    {
                        gridExcel.Rows[i].Cells["LoLoAlarmState"].Value = "Off";
                        gridExcel.Rows[i].Cells["HiHiAlarmState"].Value = "On";
                        gridExcel.Rows[i].Cells["LoAlarmState"].Value = "Off";
                        gridExcel.Rows[i].Cells["HiAlarmState"].Value = "On";
                        gridExcel.Rows[i].Cells["LoLoAlarmValue"].Value = gridExcel.Rows[i].Cells["MinValue"].Value;
                        gridExcel.Rows[i].Cells["HiHiAlarmValue"].Value = gridExcel.Rows[i].Cells["MaxValue"].Value;
                        gridExcel.Rows[i].Cells["LoAlarmValue"].Value = gridExcel.Rows[i].Cells["MinValue"].Value;
                        gridExcel.Rows[i].Cells["HiAlarmValue"].Value = (Decimal)gridExcel.Rows[i].Cells["MaxValue"].Value - 1;

                    }
                    else if (gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_CLOR"))
                    {
                        gridExcel.Rows[i].Cells["LoLoAlarmState"].Value = "On";
                        gridExcel.Rows[i].Cells["HiHiAlarmState"].Value = "On";
                        gridExcel.Rows[i].Cells["LoAlarmState"].Value = "On";
                        gridExcel.Rows[i].Cells["HiAlarmState"].Value = "On";
                        gridExcel.Rows[i].Cells["LoLoAlarmValue"].Value = 0;
                        gridExcel.Rows[i].Cells["HiHiAlarmValue"].Value = 2;
                        gridExcel.Rows[i].Cells["LoAlarmValue"].Value = 0.1;
                        gridExcel.Rows[i].Cells["HiAlarmValue"].Value = 1.9;
                    }
                    else if (gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_NIVE") || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_NIV2") ||
                        gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_PRES") || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_INTE") ||
                        gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_VAPH") || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_COND") ||
                        gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_TURB") || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_POTA") || 
                        gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_POTR") || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_FPOT") ||
                        gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_TEMP") || gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_INTH") ||
                        gridExcel.Rows[i].Cells["Atributo"].Value.ToString().Equals("V_FPOT"))
                    {
                        gridExcel.Rows[i].Cells["LoLoAlarmState"].Value = "On";
                        gridExcel.Rows[i].Cells["HiHiAlarmState"].Value = "On";
                        gridExcel.Rows[i].Cells["LoAlarmState"].Value = "On";
                        gridExcel.Rows[i].Cells["HiAlarmState"].Value = "On";
                        gridExcel.Rows[i].Cells["LoLoAlarmValue"].Value = (Decimal)gridExcel.Rows[i].Cells["MinValue"].Value;
                        gridExcel.Rows[i].Cells["HiHiAlarmValue"].Value = (Decimal)gridExcel.Rows[i].Cells["MaxValue"].Value;
                        gridExcel.Rows[i].Cells["LoAlarmValue"].Value = (Decimal)gridExcel.Rows[i].Cells["MinValue"].Value + 1;
                        gridExcel.Rows[i].Cells["HiAlarmValue"].Value = (Decimal)gridExcel.Rows[i].Cells["MaxValue"].Value - 1;
                    }
                    else
                    {
                        gridExcel.Rows[i].Cells["LoLoAlarmState"].Value = "Off";
                        gridExcel.Rows[i].Cells["HiHiAlarmState"].Value = "Off";
                        gridExcel.Rows[i].Cells["LoAlarmState"].Value = "Off";
                        gridExcel.Rows[i].Cells["HiAlarmState"].Value = "Off";
                        gridExcel.Rows[i].Cells["LoLoAlarmValue"].Value = gridExcel.Rows[i].Cells["MinValue"].Value;
                        gridExcel.Rows[i].Cells["HiHiAlarmValue"].Value = gridExcel.Rows[i].Cells["MinValue"].Value;
                        gridExcel.Rows[i].Cells["LoAlarmValue"].Value = gridExcel.Rows[i].Cells["MinValue"].Value;
                        gridExcel.Rows[i].Cells["HiAlarmValue"].Value = gridExcel.Rows[i].Cells["MinValue"].Value;
                    }
                }
            }
        }

        public void findSeñalesAnalogicasByNombreEstacion(ComboBox nombreEstacion, DataGridView gridSeñales)
        {

            gridSeñales.DataSource = null;
            Estacion estacion = estacionService.findDatosPlcByNombre(nombreEstacion.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = false;
            }
            DataTable señales = señalService.findSeñalesAnalogicasByNombreEstacion(nombreEstacion.Text);
            gridSeñales.DataSource = señales;
            for (int i = 0; i < gridSeñales.Rows.Count; i++)
            {
                gridSeñales.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }
        }

        public void findConsignasByNombreEstacion(ComboBox nombreEstacion, DataGridView gridSeñales)
        {
            gridSeñales.DataSource = null;
            Estacion estacion = estacionService.findDatosPlcByNombre(nombreEstacion.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = false;
            }
            DataTable señales = señalService.findConsignasByNombreEstacion(nombreEstacion.Text);
            gridSeñales.DataSource = señales;
            for (int i = 0; i < gridSeñales.Rows.Count; i++)
            {
                gridSeñales.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }
        }

        public void findContadoresByNombreEstacion(ComboBox nombreEstacion, DataGridView gridSeñales)
        {
            gridSeñales.DataSource = null;
            Estacion estacion = estacionService.findDatosPlcByNombre(nombreEstacion.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = false;
            }
            DataTable señales = señalService.findContadoresByNombreEstacion(nombreEstacion.Text);
            gridSeñales.DataSource = señales;
            for (int i = 0; i < gridSeñales.Rows.Count; i++)
            {
                gridSeñales.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }
        }

        public void findDigitalesByNombreEstacion(ComboBox nombreEstacion, DataGridView gridSeñales)
        {
            Estacion estacion = estacionService.findDatosPlcByNombre(nombreEstacion.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = false;
            }
            DataTable señales = señalService.findDigitalesByNombreEstacion(nombreEstacion.Text);
            gridSeñales.DataSource = señales;
            for (int i = 0; i < gridSeñales.Rows.Count; i++)
            {
                gridSeñales.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }
        }

        public void findTelemandosByNombreEstacion(ComboBox nombreEstacion, DataGridView gridSeñales)
        {
            gridSeñales.DataSource = null;
            Estacion estacion = estacionService.findDatosPlcByNombre(nombreEstacion.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = false;
            }
            DataTable señales = señalService.findTelemandosByNombreEstacion(nombreEstacion.Text);
            gridSeñales.DataSource = señales;
            for (int i = 0; i < gridSeñales.Rows.Count; i++)
            {
                gridSeñales.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }       
        }

        public void findSeñalesAnalogicasByNombreDatalogger(ComboBox nombreDatalogger, DataGridView gridSeñales)
        {

            gridSeñales.DataSource = null;
            /*Estacion estacion = estacionService.findDatosPlcByNombre(nombreDatalogger.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = false;
            }*/
            DataTable señales = señalService.findSeñalesAnalogicasByNombreDatalogger(nombreDatalogger.Text);
            gridSeñales.DataSource = señales;
            /*for (int i = 0; i < gridSeñales.Rows.Count; i++)
            {
                gridSeñales.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }*/
        }

        public void findConsignasByNombreDatalogger(ComboBox nombreDatalogger, DataGridView gridSeñales)
        {
            gridSeñales.DataSource = null;
            /*Estacion estacion = estacionService.findDatosPlcByNombre(nombreDatalogger.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = false;
            }*/
            DataTable señales = señalService.findConsignasByNombreDatalogger(nombreDatalogger.Text);
            gridSeñales.DataSource = señales;
            /*for (int i = 0; i < gridSeñales.Rows.Count; i++)
            {
                gridSeñales.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }*/
        }

        public void findContadoresByNombreDatalogger(ComboBox nombreDatalogger, DataGridView gridSeñales)
        {
            gridSeñales.DataSource = null;
            /*Estacion estacion = estacionService.findDatosPlcByNombre(nombreEstacion.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = false;
            }*/
            DataTable señales = señalService.findContadoresByNombreDatalogger(nombreDatalogger.Text);
            gridSeñales.DataSource = señales;
            /*for (int i = 0; i < gridSeñales.Rows.Count; i++)
            {
                gridSeñales.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }*/
        }

        public void findDigitalesByNombreDatalogger(ComboBox nombreDatalogger, DataGridView gridSeñales)
        {
            /*Estacion estacion = estacionService.findDatosPlcByNombre(nombreDatalogger.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = false;
            }*/
            DataTable señales = señalService.findDigitalesByNombreDatalogger(nombreDatalogger.Text);
            gridSeñales.DataSource = señales;
            /*for (int i = 0; i < gridSeñales.Rows.Count; i++)
            {
                gridSeñales.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }*/
        }

        public void findTelemandosByNombreDatalogger(ComboBox nombreDatalogger, DataGridView gridSeñales)
        {
            gridSeñales.DataSource = null;
            /*Estacion estacion = estacionService.findDatosPlcByNombre(nombreEstacion.Text);
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                gridSeñales.Columns["Criterio Archivo"].Visible = false;
            }*/
            DataTable señales = señalService.findTelemandosByNombreDatalogger(nombreDatalogger.Text);
            gridSeñales.DataSource = señales;
            /*for (int i = 0; i < gridSeñales.Rows.Count; i++)
            {
                gridSeñales.Rows[i].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;
            }*/
        }
        public void añadirSeñal(ComboBox comboBoxExplotaciones, ComboBox comboBoxSitAquacis, ComboBox comboBoxEstaciones, ComboBox comboBoxAgrupaciones,
            ComboBox comboBoxNumeroAgrupacion, DataGridView gridPlantillas, DataGridView listBoxSeñales)
        {
            if (AppListaSeñales.esDatalogger)
            {
                // Variables necesarias para construir el código IAS de la señal
                Explotacion explotacion = explotacionService.findCodigosIasByNombre(comboBoxExplotaciones.Text, comboBoxSitAquacis.Text);
                String cebeIas = explotacion.CebeIas;
                String servicioIas = explotacion.ServicioIas;
                String explotacionIas = explotacion.ExplotacionIas;
                String codigoAgrupacion = "DL";
                Tuple<int, string, string> datalogger = dataloggerService.findIdNumeroDataloggerAndNumeroAgrupacionByNombreDataloggerAndNombreExplotacion(comboBoxEstaciones.Text, comboBoxExplotaciones.Text, comboBoxSitAquacis.Text);
                int idDatalogger = datalogger.Item1;
                string numeroDatalogger = datalogger.Item2;
                string numeroAgrupacion = datalogger.Item3;
                for (int i = 0; i < gridPlantillas.Rows.Count; i++)
                {
                    if (gridPlantillas.Rows[i].Cells["Elementos"].Value != null && !gridPlantillas.Rows[i].Cells["Elementos"].Value.Equals(""))
                    {
                        if (Convert.ToInt16(gridPlantillas.Rows[i].Cells["Elementos"].Value) > 0)
                        {
                            String nombrePlantilla = gridPlantillas.Rows[i].Cells["Nombre Plantilla"].Value.ToString();
                            String caracteristicaElemento = String.Empty;
                            if (gridPlantillas.Rows[i].Cells["Característica Elemento"].Value != null)
                            {
                                caracteristicaElemento = gridPlantillas.Rows[i].Cells["Característica Elemento"].Value.ToString();
                            }
                            List<String> atributosPlantilla = plantillaService.findAtributosByNombrePlantilla(nombrePlantilla);
                            for (int j = 1; j <= Convert.ToInt16(gridPlantillas.Rows[i].Cells["Elementos"].Value); j++)
                            {
                                StringBuilder codigoInstancia = new StringBuilder();
                                codigoInstancia.Append(cebeIas + explotacionIas + "8" + numeroDatalogger + servicioIas);
                                codigoInstancia.Append("_" + codigoAgrupacion + numeroAgrupacion + "_");
                                codigoInstancia.Append(nombrePlantilla.Substring(1, 4));
                                int iNumeroInstancia = 1;
                                String sNumeroInstancia = "0" + iNumeroInstancia.ToString();
                                // Recorremos el grid para ver si hay alguna instancia igual creada
                                bool existe = true;
                                while (existe)
                                {
                                    if (AppListaSeñales.listaSeñales.ContainsKey(codigoInstancia.ToString() + sNumeroInstancia.ToString() + "." + atributosPlantilla[0])
                                        || AppListaSeñales.señalesCreadas.ContainsKey(codigoInstancia.ToString() + sNumeroInstancia.ToString() + "." + atributosPlantilla[0]))
                                    {
                                        iNumeroInstancia = iNumeroInstancia + 1;
                                    }
                                    else
                                    {
                                        existe = false;
                                    }
                                    sNumeroInstancia = "0" + iNumeroInstancia.ToString();
                                    if (iNumeroInstancia >= 10)
                                    {
                                        sNumeroInstancia = iNumeroInstancia.ToString();
                                    }
                                }
                                codigoInstancia.Append(sNumeroInstancia);
                                // Guardamos instancia en el diccionario
                                int numeroAtributo = 0;
                                // Pulsos Dosificadora Vemos si ha preguntado para no preguntar una vez por cada atributo (No usamos para datalogger(?))
                                //bool preguntado = false;
                                foreach (String atributo in atributosPlantilla)
                                {

                                    /*for (int row = 0; row < listBoxSeñales.Rows.Count; row++)
                                    {
                                        if (AppListaSeñales.listaSeñales.ContainsKey(codigoInstancia.ToString() + sNumeroInstancia.ToString() + "." + atributo))
                                        {
                                            iNumeroInstancia = iNumeroInstancia + 1;
                                        }
                                        sNumeroInstancia = "0" + iNumeroInstancia.ToString();
                                        if (iNumeroInstancia >= 10)
                                        {
                                            sNumeroInstancia = iNumeroInstancia.ToString();
                                        }
                                    }*/

                                    // Guardamos señal en la lista que está en memoria
                                    Señal señal = new Señal();
                                    // Descripción de la señal
                                    if (String.IsNullOrEmpty(caracteristicaElemento))
                                    {
                                        señal.Descripcion = gridPlantillas.Rows[i + numeroAtributo].Cells["Descripción"].Value.ToString() + " - " +
                                           comboBoxEstaciones.Text.Split("(")[0];
                                    }
                                    else
                                    {
                                        señal.Descripcion = gridPlantillas.Rows[i + numeroAtributo].Cells["Descripción"].Value.ToString() + " "
                                        + caracteristicaElemento + " - " + comboBoxEstaciones.Text.Split("(")[0];
                                    }
                                    // Guardamos si se historiza o no
                                    señal.Historico = gridPlantillas.Rows[i + numeroAtributo].Cells["Histórico"].Value.ToString();
                                    /*************REVISAR*************************/
                                    /*if (gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString().Equals("Lacbus"))
                                    {
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["Criterio Archivo"].ToolTipText.Equals("True"))
                                        {
                                            señal.CriterioArchivo = true;
                                        }
                                        else
                                        {
                                            señal.CriterioArchivo = false;
                                        }
                                    }*/
                                    // Si tiene unidad la guardamos
                                    if (gridPlantillas.Rows[i + numeroAtributo].Cells["Unidad"].Value != null)
                                    {
                                        señal.Unidad = gridPlantillas.Rows[i + numeroAtributo].Cells["Unidad"].Value.ToString();
                                    }
                                    if (gridPlantillas.Rows[i + numeroAtributo].Cells["VAR_0"].ToolTipText.Equals("True"))
                                    {
                                        señal.VarCero = true;
                                    }
                                    else
                                    {
                                        señal.VarCero = false;
                                        // Si tiene dirección de PLC se guarda, si no se autogenera
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["Dirección PLC"].Value != null)
                                        {
                                            señal.DireccionPlc = gridPlantillas.Rows[i + numeroAtributo].Cells["Dirección PLC"].Value.ToString();
                                            señal.DireccionPlcAutoGen = false;
                                        }
                                        else
                                        {
                                            if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value != null)
                                            {
                                                señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value), atributo,
                                                    gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString(), gridPlantillas.Rows[i + numeroAtributo].Cells["Criterio Archivo"].ToolTipText);
                                                señal.DireccionPlcAutoGen = true;
                                            }
                                            else if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value != null)
                                            {
                                                señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value), atributo,
                                                    gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString(), gridPlantillas.Rows[i + numeroAtributo].Cells["Criterio Archivo"].ToolTipText);
                                                señal.DireccionPlcAutoGen = true;
                                            }
                                        }
                                        // Creamos Tag en función del Número Lógico o Físico
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value != null)
                                        {
                                            señal.NumeroFisico = Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value);
                                            señal.Tag = generarTagNumeroFisico(Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value), Convert.ToInt32(numeroDatalogger), atributo);
                                        }
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value != null)
                                        {
                                            señal.NumeroLogico = Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value);
                                            señal.Tag = generarTagNumeroLogico(Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value), Convert.ToInt32(numeroDatalogger), atributo);
                                        }
                                    }
                                    // Guardamos Off y On Msg si los tiene
                                    if (gridPlantillas.Rows[i + numeroAtributo].Cells["OffMsg"].Value != null)
                                    {
                                        señal.OffMsg = gridPlantillas.Rows[i + numeroAtributo].Cells["OffMsg"].Value.ToString();
                                    }
                                    if (gridPlantillas.Rows[i + numeroAtributo].Cells["OnMsg"].Value != null)
                                    {
                                        señal.OnMsg = gridPlantillas.Rows[i + numeroAtributo].Cells["OnMsg"].Value.ToString();
                                    }
                                    // Id de la estación que relaciona la señal con la estación
                                    señal.IdDatalogger = idDatalogger;
                                    // Dependiendo del atributo guardamos alarma o rangos
                                    if (atributo.Substring(0, 1).Equals("E"))
                                    {
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["Invertida"].ToolTipText.Equals("True"))
                                        {
                                            señal.Invertida = "Reverse";
                                        }
                                        else
                                        {
                                            señal.Invertida = "Direct";
                                        }

                                        señal.Alarma = gridPlantillas.Rows[i + numeroAtributo].Cells["Alarma"].Value.ToString();
                                    }
                                    else if (atributo.Substring(0, 1).Equals("T"))
                                    {
                                        señal.Alarma = gridPlantillas.Rows[i + numeroAtributo].Cells["Alarma"].Value.ToString();
                                    }
                                    else if (atributo.Substring(0, 1).Equals("V") || atributo.Substring(0, 1).Equals("A") || atributo.Substring(0, 1).Equals("C") || atributo.Substring(0, 1).Equals("P") || atributo.Substring(0, 1).Equals("M"))
                                    {
                                        señal.MaxEngUnits = Convert.ToDecimal(gridPlantillas.Rows[i + numeroAtributo].Cells["MaxEU"].Value);
                                        señal.MinEngUnits = Convert.ToDecimal(gridPlantillas.Rows[i + numeroAtributo].Cells["MinEU"].Value);
                                        señal.MaxRaw = Convert.ToDecimal(gridPlantillas.Rows[i + numeroAtributo].Cells["MaxRaw"].Value);
                                        señal.MinRaw = Convert.ToDecimal(gridPlantillas.Rows[i + numeroAtributo].Cells["MinRaw"].Value);
                                    }
                                    // Código de la señal
                                    señal.Codigo = codigoInstancia.ToString() + "." + atributo;

                                    // Mostramos instancia en la previsualización

                                    // Mostramos atributos de la instancia en la previsualización
                                    if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value != null)
                                    {
                                        listBoxSeñales.Rows.Add(señal.DireccionPlc, "", señal.NumeroFisico, señal.CriterioArchivo, señal.Codigo, gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString());
                                    }
                                    else if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value != null)
                                    {
                                        listBoxSeñales.Rows.Add(señal.DireccionPlc, señal.NumeroLogico, "", señal.CriterioArchivo, señal.Codigo, gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString());
                                    }
                                    else if (gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value != null)
                                    {
                                        listBoxSeñales.Rows.Add(señal.DireccionPlc, "", "", señal.CriterioArchivo, señal.Codigo, gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString());
                                    }
                                    else
                                    {
                                        listBoxSeñales.Rows.Add(señal.DireccionPlc, "", "", señal.CriterioArchivo, señal.Codigo, "");
                                    }
                                    // Añadimos a la lista
                                    AppListaSeñales.listaSeñales.Add(señal.Codigo, señal);
                                    // Si el contador tiene pulsos
                                    /*if (atributo.Equals("V_CAUD"))
                                    {
                                        DialogResult hayPulso = MessageBox.Show("¿El contador que va a añadir tiene pulsos?", "Pulsos Contador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (hayPulso == DialogResult.Yes)
                                        {
                                            Señal pulso = new Señal();
                                            pulso.OffMsg = "-----";
                                            pulso.OnMsg = "+++++";
                                            pulso.Alarma = "None";
                                            pulso.Invertida = "Direct";
                                            pulso.Historico = "No";
                                            pulso.Codigo = codigoInstancia.ToString() + ".N_PULS";
                                            pulso.DireccionPlcAutoGen = true;
                                            pulso.VarCero = false;
                                            if (String.IsNullOrEmpty(caracteristicaElemento))
                                            {
                                                pulso.Descripcion = "Pulsos Caudal - " + comboBoxEstaciones.Text;

                                            }
                                            else
                                            {
                                                pulso.Descripcion = "Pulsos Caudal " + caracteristicaElemento + " - " + comboBoxEstaciones.Text;
                                            }
                                            pulso.IdEstacion = señal.IdEstacion;
                                            String value = "0";
                                            if (InputBox.InputText("Entrada Pulsos Caudal", "Indique el número físico que corresponde a los pulsos: ", ref value) == DialogResult.OK)
                                            {
                                                pulso.NumeroFisico = Convert.ToInt32(value);
                                                pulso.Tag = generarTagNumeroFisico(pulso.NumeroFisico, Convert.ToInt32(numeroEstacion), "N_PULS");
                                                pulso.DireccionPlc = generarDireccionPlc(pulso.NumeroFisico, "N_PULS",
                                                    gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString(), "False");
                                            }
                                            // Mostramos atributos de la instancia en la previsualización
                                            listBoxSeñales.Rows.Add(pulso.DireccionPlc, "", pulso.NumeroFisico, pulso.CriterioArchivo, pulso.Codigo, gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString());
                                            // Añadimos a la lista
                                            AppListaSeñales.listaSeñales.Add(pulso.Codigo, pulso);
                                        }
                                    }
                                    else if (codigoInstancia.ToString().Substring(17, 2).Equals("DS"))
                                    {
                                        if (!preguntado)
                                        {
                                            DialogResult hayPulso = MessageBox.Show("¿La bomba dosificadora que va a añadir tiene pulsos?", "Pulsos Bomba Dosificadora", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (hayPulso == DialogResult.Yes)
                                            {
                                                Señal pulso = new Señal();
                                                pulso.OffMsg = "-----";
                                                pulso.OnMsg = "+++++";
                                                pulso.Alarma = "None";
                                                pulso.Invertida = "Direct";
                                                pulso.Historico = "No";
                                                pulso.Codigo = codigoInstancia.ToString() + ".N_PULS";
                                                pulso.DireccionPlcAutoGen = true;
                                                pulso.VarCero = false;
                                                if (String.IsNullOrEmpty(caracteristicaElemento))
                                                {
                                                    pulso.Descripcion = "Pulsos Bomba Dosificadora - " + comboBoxEstaciones.Text;

                                                }
                                                else
                                                {
                                                    pulso.Descripcion = "Pulsos Bomba Dosificadora " + caracteristicaElemento + " - " + comboBoxEstaciones.Text;
                                                }
                                                pulso.IdEstacion = señal.IdEstacion;
                                                String value = "0";
                                                if (InputBox.InputText("Entrada Pulsos Bomba Dosificadora", "Indique el número físico que corresponde a los pulsos: ", ref value) == DialogResult.OK)
                                                {
                                                    pulso.NumeroFisico = Convert.ToInt32(value);
                                                    pulso.Tag = generarTagNumeroFisico(pulso.NumeroFisico, Convert.ToInt32(numeroEstacion), "N_PULS");
                                                    pulso.DireccionPlc = generarDireccionPlc(pulso.NumeroFisico, "N_PULS",
                                                        gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString(), "False");
                                                }
                                                // Mostramos atributos de la instancia en la previsualización
                                                listBoxSeñales.Rows.Add(pulso.DireccionPlc, "", pulso.NumeroFisico, pulso.CriterioArchivo, pulso.Codigo, gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString());
                                                // Añadimos a la lista
                                                AppListaSeñales.listaSeñales.Add(pulso.Codigo, pulso);
                                            }
                                            preguntado = true;
                                        }
                                    }*/
                                    numeroAtributo++;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (!comboBoxAgrupaciones.Text.Equals("") && !comboBoxNumeroAgrupacion.Text.Equals(""))
                {
                    // Variables necesarias para construir el código IAS de la señal
                    Explotacion explotacion = explotacionService.findCodigosIasByNombre(comboBoxExplotaciones.Text, comboBoxSitAquacis.Text);
                    String cebeIas = explotacion.CebeIas;
                    String servicioIas = explotacion.ServicioIas;
                    String explotacionIas = explotacion.ExplotacionIas;
                    String numeroAgrupacion = comboBoxNumeroAgrupacion.Text;
                    String codigoAgrupacion = agrupacionService.findCodigoByDescripcion(comboBoxAgrupaciones.Text);
                    String numeroEstacion = estacionService.findNumeroEstacionByNombre(comboBoxEstaciones.Text);
                    int idEstacion = estacionService.findIdByNombreEstacionAndNombreExplotacion(comboBoxEstaciones.Text, comboBoxExplotaciones.Text);
                    // Protocolo Lacbus
                    if (gridPlantillas.Rows[0].Cells["Protocolo Comunicación"].Value.ToString().Equals("Lacbus"))
                    {
                        listBoxSeñales.Columns["Criterio Archivo"].Visible = true;
                    }
                    else
                    {
                        listBoxSeñales.Columns["Criterio Archivo"].Visible = false;
                    }
                    for (int i = 0; i < gridPlantillas.Rows.Count; i++)
                    {
                        if (gridPlantillas.Rows[i].Cells["Elementos"].Value != null && !gridPlantillas.Rows[i].Cells["Elementos"].Value.Equals(""))
                        {
                            if (Convert.ToInt16(gridPlantillas.Rows[i].Cells["Elementos"].Value) > 0)
                            {
                                String nombrePlantilla = gridPlantillas.Rows[i].Cells["Nombre Plantilla"].Value.ToString();
                                String caracteristicaElemento = String.Empty;
                                if (gridPlantillas.Rows[i].Cells["Característica Elemento"].Value != null)
                                {
                                    caracteristicaElemento = gridPlantillas.Rows[i].Cells["Característica Elemento"].Value.ToString();
                                }
                                List<String> atributosPlantilla = plantillaService.findAtributosByNombrePlantilla(nombrePlantilla);
                                for (int j = 1; j <= Convert.ToInt16(gridPlantillas.Rows[i].Cells["Elementos"].Value); j++)
                                {
                                    StringBuilder codigoInstancia = new StringBuilder();
                                    codigoInstancia.Append(cebeIas + explotacionIas + numeroEstacion + servicioIas);
                                    codigoInstancia.Append("_" + codigoAgrupacion + numeroAgrupacion + "_");
                                    codigoInstancia.Append(nombrePlantilla.Substring(1, 4));
                                    int iNumeroInstancia = 1;
                                    String sNumeroInstancia = "0" + iNumeroInstancia.ToString();
                                    // Recorremos el grid para ver si hay alguna instancia igual creada
                                    bool existe = true;
                                    while (existe)
                                    {
                                        if (AppListaSeñales.listaSeñales.ContainsKey(codigoInstancia.ToString() + sNumeroInstancia.ToString() + "." + atributosPlantilla[0])
                                            || AppListaSeñales.señalesCreadas.ContainsKey(codigoInstancia.ToString() + sNumeroInstancia.ToString() + "." + atributosPlantilla[0]))
                                        {
                                            iNumeroInstancia = iNumeroInstancia + 1;
                                        }
                                        else
                                        {
                                            existe = false;
                                        }
                                        sNumeroInstancia = "0" + iNumeroInstancia.ToString();
                                        if (iNumeroInstancia >= 10)
                                        {
                                            sNumeroInstancia = iNumeroInstancia.ToString();
                                        }
                                    }
                                    codigoInstancia.Append(sNumeroInstancia);
                                    // Guardamos instancia en el diccionario
                                    int numeroAtributo = 0;
                                    // Pulsos Dosificadora Vemos si ha preguntado para no preguntar una vez por cada atributo
                                    bool preguntado = false;
                                    foreach (String atributo in atributosPlantilla)
                                    {

                                        /*for (int row = 0; row < listBoxSeñales.Rows.Count; row++)
                                        {
                                            if (AppListaSeñales.listaSeñales.ContainsKey(codigoInstancia.ToString() + sNumeroInstancia.ToString() + "." + atributo))
                                            {
                                                iNumeroInstancia = iNumeroInstancia + 1;
                                            }
                                            sNumeroInstancia = "0" + iNumeroInstancia.ToString();
                                            if (iNumeroInstancia >= 10)
                                            {
                                                sNumeroInstancia = iNumeroInstancia.ToString();
                                            }
                                        }*/

                                        // Guardamos señal en la lista que está en memoria
                                        Señal señal = new Señal();
                                        // Descripción de la señal
                                        if (String.IsNullOrEmpty(caracteristicaElemento))
                                        {
                                            señal.Descripcion = gridPlantillas.Rows[i + numeroAtributo].Cells["Descripción"].Value.ToString() + " - " +
                                               comboBoxEstaciones.Text;
                                        }
                                        else
                                        {
                                            señal.Descripcion = gridPlantillas.Rows[i + numeroAtributo].Cells["Descripción"].Value.ToString() + " "
                                            + caracteristicaElemento + " - " + comboBoxEstaciones.Text;
                                        }
                                        // Guardamos si se historiza o no
                                        señal.Historico = gridPlantillas.Rows[i + numeroAtributo].Cells["Histórico"].Value.ToString();
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString().Equals("Lacbus"))
                                        {
                                            if (gridPlantillas.Rows[i + numeroAtributo].Cells["Criterio Archivo"].ToolTipText.Equals("True"))
                                            {
                                                señal.CriterioArchivo = true;
                                            }
                                            else
                                            {
                                                señal.CriterioArchivo = false;
                                            }
                                        }
                                        // Si tiene unidad la guardamos
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["Unidad"].Value != null)
                                        {
                                            señal.Unidad = gridPlantillas.Rows[i + numeroAtributo].Cells["Unidad"].Value.ToString();
                                        }
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["VAR_0"].ToolTipText.Equals("True"))
                                        {
                                            señal.VarCero = true;
                                        }
                                        else
                                        {
                                            señal.VarCero = false;
                                            // Si tiene dirección de PLC se guarda, si no se autogenera
                                            if (gridPlantillas.Rows[i + numeroAtributo].Cells["Dirección PLC"].Value != null)
                                            {
                                                señal.DireccionPlc = gridPlantillas.Rows[i + numeroAtributo].Cells["Dirección PLC"].Value.ToString();
                                                señal.DireccionPlcAutoGen = false;
                                            }
                                            else
                                            {
                                                if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value != null)
                                                {
                                                    señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value), atributo,
                                                        gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString(), gridPlantillas.Rows[i + numeroAtributo].Cells["Criterio Archivo"].ToolTipText);
                                                    señal.DireccionPlcAutoGen = true;
                                                }
                                                else if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value != null)
                                                {
                                                    señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value), atributo,
                                                        gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString(), gridPlantillas.Rows[i + numeroAtributo].Cells["Criterio Archivo"].ToolTipText);
                                                    señal.DireccionPlcAutoGen = true;
                                                }
                                            }
                                            // Creamos Tag en función del Número Lógico o Físico
                                            if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value != null)
                                            {
                                                señal.NumeroFisico = Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value);
                                                señal.Tag = generarTagNumeroFisico(Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value), Convert.ToInt32(numeroEstacion), atributo);
                                            }
                                            if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value != null)
                                            {
                                                señal.NumeroLogico = Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value);
                                                señal.Tag = generarTagNumeroLogico(Convert.ToInt32(gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value), Convert.ToInt32(numeroEstacion), atributo);
                                            }
                                        }
                                        // Guardamos Off y On Msg si los tiene
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["OffMsg"].Value != null)
                                        {
                                            señal.OffMsg = gridPlantillas.Rows[i + numeroAtributo].Cells["OffMsg"].Value.ToString();
                                        }
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["OnMsg"].Value != null)
                                        {
                                            señal.OnMsg = gridPlantillas.Rows[i + numeroAtributo].Cells["OnMsg"].Value.ToString();
                                        }
                                        // Id de la estación que relaciona la señal con la estación
                                        señal.IdEstacion = idEstacion;
                                        // Dependiendo del atributo guardamos alarma o rangos
                                        if (atributo.Substring(0, 1).Equals("E"))
                                        {
                                            if (gridPlantillas.Rows[i + numeroAtributo].Cells["Invertida"].ToolTipText.Equals("True"))
                                            {
                                                señal.Invertida = "Reverse";
                                            }
                                            else
                                            {
                                                señal.Invertida = "Direct";
                                            }

                                            señal.Alarma = gridPlantillas.Rows[i + numeroAtributo].Cells["Alarma"].Value.ToString();
                                        }
                                        else if (atributo.Substring(0, 1).Equals("T"))
                                        {
                                            señal.Alarma = gridPlantillas.Rows[i + numeroAtributo].Cells["Alarma"].Value.ToString();
                                        }
                                        else if (atributo.Substring(0, 1).Equals("V") || atributo.Substring(0, 1).Equals("A") || atributo.Substring(0, 1).Equals("C") || atributo.Substring(0, 1).Equals("P") || atributo.Substring(0, 1).Equals("M"))
                                        {
                                            señal.MaxEngUnits = Convert.ToDecimal(gridPlantillas.Rows[i + numeroAtributo].Cells["MaxEU"].Value);
                                            señal.MinEngUnits = Convert.ToDecimal(gridPlantillas.Rows[i + numeroAtributo].Cells["MinEU"].Value);
                                            señal.MaxRaw = Convert.ToDecimal(gridPlantillas.Rows[i + numeroAtributo].Cells["MaxRaw"].Value);
                                            señal.MinRaw = Convert.ToDecimal(gridPlantillas.Rows[i + numeroAtributo].Cells["MinRaw"].Value);
                                        }
                                        // Código de la señal
                                        señal.Codigo = codigoInstancia.ToString() + "." + atributo;

                                        // Mostramos instancia en la previsualización

                                        // Mostramos atributos de la instancia en la previsualización
                                        if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Físico"].Value != null)
                                        {
                                            listBoxSeñales.Rows.Add(señal.DireccionPlc, "", señal.NumeroFisico, señal.CriterioArchivo, señal.Codigo, gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString());
                                        }
                                        else if (gridPlantillas.Rows[i + numeroAtributo].Cells["Número Lógico"].Value != null)
                                        {
                                            listBoxSeñales.Rows.Add(señal.DireccionPlc, señal.NumeroLogico, "", señal.CriterioArchivo, señal.Codigo, gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString());
                                        }
                                        else
                                        {
                                            listBoxSeñales.Rows.Add(señal.DireccionPlc, "", "", señal.CriterioArchivo, señal.Codigo, gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString());
                                        }
                                        // Añadimos a la lista
                                        AppListaSeñales.listaSeñales.Add(señal.Codigo, señal);
                                        // Si el contador tiene pulsos
                                        if (atributo.Equals("V_CAUD"))
                                        {
                                            DialogResult hayPulso = MessageBox.Show("¿El contador que va a añadir tiene pulsos?", "Pulsos Contador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (hayPulso == DialogResult.Yes)
                                            {
                                                Señal pulso = new Señal();
                                                pulso.OffMsg = "-----";
                                                pulso.OnMsg = "+++++";
                                                pulso.Alarma = "None";
                                                pulso.Invertida = "Direct";
                                                pulso.Historico = "No";
                                                pulso.Codigo = codigoInstancia.ToString() + ".N_PULS";
                                                pulso.DireccionPlcAutoGen = true;
                                                pulso.VarCero = false;
                                                if (String.IsNullOrEmpty(caracteristicaElemento))
                                                {
                                                    pulso.Descripcion = "Pulsos Caudal - " + comboBoxEstaciones.Text;

                                                }
                                                else
                                                {
                                                    pulso.Descripcion = "Pulsos Caudal " + caracteristicaElemento + " - " + comboBoxEstaciones.Text;
                                                }
                                                pulso.IdEstacion = señal.IdEstacion;
                                                String value = "0";
                                                if (InputBox.InputText("Entrada Pulsos Caudal", "Indique el número físico que corresponde a los pulsos: ", ref value) == DialogResult.OK)
                                                {
                                                    pulso.NumeroFisico = Convert.ToInt32(value);
                                                    pulso.Tag = generarTagNumeroFisico(pulso.NumeroFisico, Convert.ToInt32(numeroEstacion), "N_PULS");
                                                    pulso.DireccionPlc = generarDireccionPlc(pulso.NumeroFisico, "N_PULS",
                                                        gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString(), "False");
                                                }
                                                // Mostramos atributos de la instancia en la previsualización
                                                listBoxSeñales.Rows.Add(pulso.DireccionPlc, "", pulso.NumeroFisico, pulso.CriterioArchivo, pulso.Codigo, gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString());
                                                // Añadimos a la lista
                                                AppListaSeñales.listaSeñales.Add(pulso.Codigo, pulso);
                                            }
                                        }
                                        else if (codigoInstancia.ToString().Substring(17, 2).Equals("DS"))
                                        {
                                            if (!preguntado)
                                            {
                                                DialogResult hayPulso = MessageBox.Show("¿La bomba dosificadora que va a añadir tiene pulsos?", "Pulsos Bomba Dosificadora", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                if (hayPulso == DialogResult.Yes)
                                                {
                                                    Señal pulso = new Señal();
                                                    pulso.OffMsg = "-----";
                                                    pulso.OnMsg = "+++++";
                                                    pulso.Alarma = "None";
                                                    pulso.Invertida = "Direct";
                                                    pulso.Historico = "No";
                                                    pulso.Codigo = codigoInstancia.ToString() + ".N_PULS";
                                                    pulso.DireccionPlcAutoGen = true;
                                                    pulso.VarCero = false;
                                                    if (String.IsNullOrEmpty(caracteristicaElemento))
                                                    {
                                                        pulso.Descripcion = "Pulsos Bomba Dosificadora - " + comboBoxEstaciones.Text;

                                                    }
                                                    else
                                                    {
                                                        pulso.Descripcion = "Pulsos Bomba Dosificadora " + caracteristicaElemento + " - " + comboBoxEstaciones.Text;
                                                    }
                                                    pulso.IdEstacion = señal.IdEstacion;
                                                    String value = "0";
                                                    if (InputBox.InputText("Entrada Pulsos Bomba Dosificadora", "Indique el número físico que corresponde a los pulsos: ", ref value) == DialogResult.OK)
                                                    {
                                                        pulso.NumeroFisico = Convert.ToInt32(value);
                                                        pulso.Tag = generarTagNumeroFisico(pulso.NumeroFisico, Convert.ToInt32(numeroEstacion), "N_PULS");
                                                        pulso.DireccionPlc = generarDireccionPlc(pulso.NumeroFisico, "N_PULS",
                                                            gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString(), "False");
                                                    }
                                                    // Mostramos atributos de la instancia en la previsualización
                                                    listBoxSeñales.Rows.Add(pulso.DireccionPlc, "", pulso.NumeroFisico, pulso.CriterioArchivo, pulso.Codigo, gridPlantillas.Rows[i + numeroAtributo].Cells["Protocolo Comunicación"].Value.ToString());
                                                    // Añadimos a la lista
                                                    AppListaSeñales.listaSeñales.Add(pulso.Codigo, pulso);
                                                }
                                                preguntado = true;
                                            }
                                        }
                                        numeroAtributo++;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Rellenar los campos de AGRUPACIÓN.");
                }
            }      
        }

        public void findSitAquacisExplotacion(ComboBox nombreEstacion, ComboBox comboBoxSitAquacis)
        {
            DataTable sitAquacis = explotacionService.findSitAquacisByNombre(nombreEstacion.Text);
            comboBoxSitAquacis.DisplayMember = "sitAquacis";
            comboBoxSitAquacis.DataSource = sitAquacis;
            comboBoxSitAquacis.SelectedItem = -1;
        }

        private String generarTagNumeroFisico (int numeroFisico, int numeroEstacion, String atributo)
        {
            String tag = String.Empty;
            String sNumeroEstacion = numeroEstacion.ToString();
            if (numeroEstacion < 10)
            {
                sNumeroEstacion = "0" + sNumeroEstacion;
            }

            if (atributo.Substring(0,1).Equals("V") || atributo.Substring(0, 1).Equals("C") || atributo.Substring(0, 1).Equals("M"))
            {
                if (numeroFisico < 10)
                {
                    tag = "EA000" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroFisico < 100 && numeroFisico >= 10)
                {
                    tag = "EA00" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroFisico < 1000 && numeroFisico >= 100) 
                {
                    tag = "EA0" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
                else
                {
                    tag = "EA" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }

            }
            else if (atributo.Substring(0, 1).Equals("E") || atributo.Substring(0, 1).Equals("N"))
            {
                if (numeroFisico < 10)
                {
                    tag = "ED000" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroFisico < 100 && numeroFisico >= 10)
                {
                    tag = "ED00" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroFisico < 1000 && numeroFisico >= 100)
                {
                    tag = "ED0" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
                else
                {
                    tag = "ED" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
            }
            else if (atributo.Substring(0, 1).Equals("A"))
            {
                if (numeroFisico < 10)
                {
                    tag = "CT000" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroFisico < 100 && numeroFisico >= 10)
                {
                    tag = "CT00" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroFisico < 1000 && numeroFisico >= 100)
                {
                    tag = "CT0" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
                else
                {
                    tag = "CT" + numeroFisico.ToString() + "-" + sNumeroEstacion;
                }
            }

            return tag;
        }

        private String generarTagNumeroLogico(int numeroLogico, int numeroEstacion, String atributo)
        {
            String tag = String.Empty;
            String sNumeroEstacion = numeroEstacion.ToString();
            if (numeroEstacion < 10)
            {
                sNumeroEstacion = "0" + sNumeroEstacion;
            }

            if (atributo.Substring(0, 1).Equals("V") || atributo.Substring(0, 1).Equals("C") || atributo.Substring(0, 1).Equals("M"))
            {
                if (numeroLogico < 10)
                {
                    tag = "CS000" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroLogico < 100 && numeroLogico >= 10)
                {
                    tag = "CS00" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroLogico < 1000 && numeroLogico >= 100)
                {
                    tag = "CS0" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else
                {
                    tag = "CS" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }

            }
            else if (atributo.Substring(0, 1).Equals("E"))
            {
                if (numeroLogico < 10)
                {
                    tag = "IN000" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroLogico < 100 && numeroLogico >= 10)
                {
                    tag = "IN00" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroLogico < 1000 && numeroLogico >= 100)
                {
                    tag = "IN0" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else
                {
                    tag = "IN" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
            }
            else if (atributo.Substring(0, 1).Equals("P"))
            {
                if (numeroLogico < 10)
                {
                    tag = "PC000" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroLogico < 100 && numeroLogico >= 10)
                {
                    tag = "PC00" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroLogico < 1000 && numeroLogico >= 100)
                {
                    tag = "PC0" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else
                {
                    tag = "PC" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
            }
            else if (atributo.Substring(0, 1).Equals("T"))
            {
                if (numeroLogico < 10)
                {
                    tag = "TM000" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroLogico < 100 && numeroLogico >= 10)
                {
                    tag = "TM00" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroLogico < 1000 && numeroLogico >= 100)
                {
                    tag = "TM0" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else
                {
                    tag = "TM" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
            }
            else if (atributo.Substring(0, 1).Equals("A"))
            {
                if (numeroLogico < 10)
                {
                    tag = "CT000" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroLogico < 100 && numeroLogico >= 10)
                {
                    tag = "CT00" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else if (numeroLogico < 1000 && numeroLogico >= 100)
                {
                    tag = "CT0" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
                else
                {
                    tag = "CT" + numeroLogico.ToString() + "-" + sNumeroEstacion;
                }
            }

            return tag;
        }

        private String generarDireccionPlc(int numero, String atributo, String protocolo, String criterioArchivo)
        {
            String direccionPlc = String.Empty;

            if (atributo.Substring(0, 1).Equals("V") || atributo.Substring(0, 1).Equals("C") || atributo.Substring(0, 1).Equals("M") || atributo.Substring(0, 1).Equals("P")
                || atributo.Substring(0, 1).Equals("A"))
            {
                if (protocolo.Equals("Modbus"))
                {
                    numero = numero + 10;
                    direccionPlc = "%MW" + numero.ToString();
                }
                else if (protocolo.Equals("Lacbus"))
                {
                    if (atributo.Substring(0, 1).Equals("P"))
                    {
                        direccionPlc = "NO/Value(" + numero + ")";
                    }
                    else
                    {
                        if (criterioArchivo.Equals("True"))
                        {
                            direccionPlc = "NI/HValue(" + numero + ")";
                        }
                        else
                        {
                            direccionPlc = "NI/Value(" + numero + ")";
                        }
                    }
                }
                else if (protocolo.Equals("S7"))
                {
                    if (atributo.Substring(0, 1).Equals("P"))
                    {
                        numero = numero * 2 - 2;
                        direccionPlc = "DB4,W" + numero.ToString();
                    }
                    else if (atributo.Substring(0, 1).Equals("A"))
                    {
                        numero = numero * 4 - 4;
                        direccionPlc = "DB5,DWORD" + numero.ToString();
                    }
                    else
                    {
                        numero = numero * 4 - 4;
                        direccionPlc = "DB3,W" + numero.ToString();
                    }           
                }
            }
            else if (atributo.Substring(0, 1).Equals("E") || atributo.Substring(0, 1).Equals("N"))
            {
                if (protocolo.Equals("Modbus"))
                {
                    int palabra = numero / 16;
                    int bit = (numero % 16) - 1;

                    if (bit < 10 && bit >= 0)
                    {
                        direccionPlc = "%MW" + palabra.ToString() + ".0" + bit.ToString();
                    }
                    else if (bit >= 10)
                    {
                        direccionPlc = "%MW" + palabra.ToString() + "." + bit.ToString();
                    }
                    else if (bit < 0)
                    {
                        palabra = palabra - 1;
                        direccionPlc = "%MW" + palabra.ToString() + ".15";
                    }
                }
                else if (protocolo.Equals("Lacbus"))
                {
                    if (criterioArchivo.Equals("True"))
                    {
                        direccionPlc = "LI/HValue(" + numero + ")";
                    }
                    else
                    {
                        direccionPlc = "LI/Value(" + numero + ")";
                    }
                }
                else if (protocolo.Equals("S7"))
                {
                    int palabra = numero / 8;
                    int bit = (numero % 8) - 1;

                    if (bit >= 0)
                    {
                        direccionPlc = "DB2,X" + palabra.ToString() + "." + bit.ToString();
                    }
                    else
                    {
                        palabra = palabra - 1;
                        direccionPlc = "DB2,X" + palabra.ToString() + ".7";
                    }
                }
            }
            else if (atributo.Substring(0, 1).Equals("T"))
            {
                if (protocolo.Equals("Modbus"))
                {
                    // Se podría usar el mismo codigo que para digitales, pero sumando 9 a la palabra
                    if (numero < 17)
                    {
                        if (numero < 11)
                        {
                            numero = numero - 1;
                            direccionPlc = "%MW9.0" + numero.ToString();
                        }
                        else
                        {
                            numero = numero - 1;
                            direccionPlc = "%MW9." + numero.ToString();
                        }
                    }
                    else if (numero >= 17 && numero < 33)
                    {
                        if (numero < 27)
                        {
                            numero = numero - 17;
                            direccionPlc = "%MW10.0" + numero.ToString();
                        }
                        else
                        {
                            numero = numero - 17;
                            direccionPlc = "%MW10." + numero.ToString();
                        }
                    }
                }
                else if (protocolo.Equals("Lacbus"))
                {
                    direccionPlc = "LO/Value(" + numero + ")";
                }
                else if (protocolo.Equals("S7"))
                {
                    int palabra = numero / 8;
                    int bit = (numero % 8) - 1;

                    if (bit >= 0)
                    {
                        direccionPlc = "DB6,X" + palabra.ToString() + "." + bit.ToString();
                    }
                    else
                    {
                        palabra = palabra - 1;
                        direccionPlc = "DB6,X" + palabra.ToString() + ".7";
                    }
                }
            }
            return direccionPlc;
        }

        public Boolean comprobacionRangosGridPlantillas(DataGridView gridPlantillas)
        {
            for (int i = 0; i < gridPlantillas.Rows.Count; i++)
            {
                if (gridPlantillas.Rows[i].Cells["Elementos"].Value != null && !gridPlantillas.Rows[i].Cells["Elementos"].Value.ToString().Equals("")
                    && !gridPlantillas.Rows[i].Cells["Elementos"].Value.ToString().Equals("0"))
                {
                    if (Convert.ToInt16(gridPlantillas.Rows[i].Cells["Elementos"].Value) > 0)
                    {
                        String nombrePlantilla = gridPlantillas.Rows[i].Cells["Nombre Plantilla"].Value.ToString();
                        List<String> atributosPlantilla = plantillaService.findAtributosByNombrePlantilla(nombrePlantilla);
                        int numeroAtributo = 0;
                        foreach (String atributo in atributosPlantilla)
                        {
                            if (atributo.Substring(0, 1).Equals("V") || atributo.Substring(0, 1).Equals("A") || atributo.Substring(0, 1).Equals("C") || atributo.Substring(0, 1).Equals("P") || atributo.Substring(0, 1).Equals("M"))
                            {
                                if(gridPlantillas.Rows[i + numeroAtributo].Cells["MaxEU"].Value == null || gridPlantillas.Rows[i + numeroAtributo].Cells["MinEU"].Value == null
                                    || gridPlantillas.Rows[i + numeroAtributo].Cells["MaxRaw"].Value == null || gridPlantillas.Rows[i + numeroAtributo].Cells["MinRaw"].Value == null
                                    || gridPlantillas.Rows[i + numeroAtributo].Cells["MaxEU"].Value.ToString().Equals("") || gridPlantillas.Rows[i + numeroAtributo].Cells["MinEU"].Value.ToString().Equals("")
                                    || gridPlantillas.Rows[i + numeroAtributo].Cells["MaxRaw"].Value.ToString().Equals("") || gridPlantillas.Rows[i + numeroAtributo].Cells["MinRaw"].Value.ToString().Equals(""))
                                {
                                    return true;
                                }
                            }
                            numeroAtributo++;
                        }
                    }
                }
            }
            return false;
        }

        public void deleteInstanciaCreada(String instancia)
        {
            if (señalService.deleteInstancia(instancia))
            {
                MessageBox.Show("Instancia borrada.");
            }
            else
            {
                MessageBox.Show("Error al borrar.");
            }
        }

        public void updateAtributoInstanciaCreada(DataGridView gridPlantillas, int fila)
        {
            String atributo = gridPlantillas.Rows[fila].Cells["Código Señal"].Value.ToString().Substring(24, 6);
            String numeroEstacion = gridPlantillas.Rows[fila].Cells["Código Señal"].Value.ToString().Substring(5, 4);
            Señal señal = new Señal();

            señal.Codigo = gridPlantillas.Rows[fila].Cells["Código Señal"].Value.ToString();
            if (gridPlantillas.Rows[fila].Cells["Criterio Archivo"].ToolTipText.Equals("True"))
            {
                señal.CriterioArchivo = true;
            }
            else
            {
                señal.CriterioArchivo = false;
            }
            if (gridPlantillas.Rows[fila].Cells["Dirección PLC"].Value != null && !gridPlantillas.Rows[fila].Cells["Dirección PLC"].Value.ToString().Equals(""))
            {
                señal.DireccionPlc = gridPlantillas.Rows[fila].Cells["Dirección PLC"].Value.ToString();
                señal.DireccionPlcAutoGen = false;
            }
            else
            {
                if (gridPlantillas.Rows[fila].Cells["Número Físico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Físico"].Value.ToString().Equals(""))
                {
                    señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Físico"].Value), atributo, 
                        gridPlantillas.Rows[fila].Cells["Protocolo Comunicación"].Value.ToString(), gridPlantillas.Rows[fila].Cells["Criterio Archivo"].ToolTipText);
                    señal.DireccionPlcAutoGen = true;
                }
                else if (gridPlantillas.Rows[fila].Cells["Número Lógico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Lógico"].Value.ToString().Equals(""))
                {
                    señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Lógico"].Value), atributo,
                        gridPlantillas.Rows[fila].Cells["Protocolo Comunicación"].Value.ToString(), gridPlantillas.Rows[fila].Cells["Criterio Archivo"].ToolTipText);
                    señal.DireccionPlcAutoGen = true;
                }
            }
            if (gridPlantillas.Rows[fila].Cells["Número Físico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Físico"].Value.ToString().Equals(""))
            {
                señal.NumeroFisico = Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Físico"].Value);
                señal.Tag = generarTagNumeroFisico(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Físico"].Value), Convert.ToInt32(numeroEstacion), atributo);
            }
            if (gridPlantillas.Rows[fila].Cells["Número Lógico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Lógico"].Value.ToString().Equals(""))
            {
                señal.NumeroLogico = Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Lógico"].Value);
                señal.Tag = generarTagNumeroLogico(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Lógico"].Value), Convert.ToInt32(numeroEstacion), atributo);
            }
            
            if (señalService.updateAtributoInstancia(señal))
            {
                /*StringBuilder message = new StringBuilder();
                message.Append("Se han editado los siguientes campos del atributo ");
                message.Append(señal.Codigo + ": \n");
                message.Append("Direccion PLC: " + señal.DireccionPlc + " \n");
                message.Append("Tag: " + señal.Tag + " \n");
                if (gridPlantillas.Rows[fila].Cells["Número Físico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Físico"].Value.ToString().Equals(""))
                {
                    message.Append("Número Físico: " + señal.NumeroFisico + " \n");
                }
                if (gridPlantillas.Rows[fila].Cells["Número Lógico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Lógico"].Value.ToString().Equals(""))
                {
                    message.Append("Número Lógico: " + señal.NumeroLogico + " \n");
                }
                
                MessageBox.Show(message.ToString());*/
            }
            else
            {
                MessageBox.Show("Error al actualizar.");
            }
        }

        public void updateAtributoInstanciaACrear(DataGridView gridPlantillas, int fila)
        {
            String atributo = gridPlantillas.Rows[fila].Cells["Código Señal"].Value.ToString().Substring(24, 6);
            String numeroEstacion = gridPlantillas.Rows[fila].Cells["Código Señal"].Value.ToString().Substring(5, 4);
            Señal señal = AppListaSeñales.listaSeñales[gridPlantillas.Rows[fila].Cells["Código Señal"].Value.ToString()];
            if (gridPlantillas.Rows[fila].Cells["Criterio Archivo"].ToolTipText.Equals("True"))
            {
                señal.CriterioArchivo = true;
            }
            else
            {
                señal.CriterioArchivo = false;
            }
            if (gridPlantillas.Rows[fila].Cells["Dirección PLC"].Value != null && !gridPlantillas.Rows[fila].Cells["Dirección PLC"].Value.ToString().Equals(""))
            {
                señal.DireccionPlc = gridPlantillas.Rows[fila].Cells["Dirección PLC"].Value.ToString();
                señal.DireccionPlcAutoGen = false;
            }
            else
            {
                if (gridPlantillas.Rows[fila].Cells["Número Físico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Físico"].Value.ToString().Equals(""))
                {
                    señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Físico"].Value), atributo,
                        gridPlantillas.Rows[fila].Cells["Protocolo Comunicación"].Value.ToString(), gridPlantillas.Rows[fila].Cells["Criterio Archivo"].ToolTipText);
                    señal.DireccionPlcAutoGen = true;
                }
                else if (gridPlantillas.Rows[fila].Cells["Número Lógico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Lógico"].Value.ToString().Equals(""))
                {
                    señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Lógico"].Value), atributo, 
                        gridPlantillas.Rows[fila].Cells["Protocolo Comunicación"].Value.ToString(), gridPlantillas.Rows[fila].Cells["Criterio Archivo"].ToolTipText);
                    señal.DireccionPlcAutoGen = true;
                }
            }
            if (gridPlantillas.Rows[fila].Cells["Número Físico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Físico"].Value.ToString().Equals(""))
            {
                señal.NumeroFisico = Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Físico"].Value);
                señal.Tag = generarTagNumeroFisico(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Físico"].Value), Convert.ToInt32(numeroEstacion), atributo);
            }
            else
            {
                señal.NumeroFisico = 0;
            }
            if (gridPlantillas.Rows[fila].Cells["Número Lógico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Lógico"].Value.ToString().Equals(""))
            {
                señal.NumeroLogico = Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Lógico"].Value);
                señal.Tag = generarTagNumeroLogico(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Lógico"].Value), Convert.ToInt32(numeroEstacion), atributo);
            }
            else
            {
                señal.NumeroLogico = 0;
            }

            /*StringBuilder message = new StringBuilder();
            message.Append("Se han editado los siguientes campos del atributo ");
            message.Append(señal.Codigo + ": \n");
            message.Append("Direccion PLC: " + señal.DireccionPlc + " \n");*/
            gridPlantillas.Rows[fila].Cells["Dirección PLC"].Value = señal.DireccionPlc;
            /*message.Append("Tag: " + señal.Tag + " \n");
            if (gridPlantillas.Rows[fila].Cells["Número Físico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Físico"].Value.ToString().Equals(""))
            {
                message.Append("Número Físico: " + señal.NumeroFisico + " \n");
            }
            if (gridPlantillas.Rows[fila].Cells["Número Lógico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Lógico"].Value.ToString().Equals(""))
            {
                message.Append("Número Lógico: " + señal.NumeroLogico + " \n");
            }*/
            AppListaSeñales.listaSeñales[gridPlantillas.Rows[fila].Cells["Código Señal"].Value.ToString()] = señal;
            //MessageBox.Show(message.ToString());           
        }

        public void updateAtributoInstanciaPreview(DataGridView gridPlantillas, int fila)
        {
            // Preparamos señal a actualizar
            String atributo = gridPlantillas.Rows[fila].Cells["Código Señal"].Value.ToString().Substring(24, 6);
            String numeroEstacion = gridPlantillas.Rows[fila].Cells["Código Señal"].Value.ToString().Substring(5, 4);
            Señal señal = new Señal();
            if (gridPlantillas.Rows[fila].Cells["Criterio Archivo"].ToolTipText.Equals("True"))
            {
                señal.CriterioArchivo = true;
            }
            else
            {
                señal.CriterioArchivo = false;
            }
            señal.Codigo = gridPlantillas.Rows[fila].Cells["Código Señal"].Value.ToString();
            señal.Descripcion = gridPlantillas.Rows[fila].Cells["Descripción"].Value.ToString();
            señal.Historico = gridPlantillas.Rows[fila].Cells["Histórico"].Value.ToString();
            if (gridPlantillas.Rows[fila].Cells["Unidad"].Value != null && !gridPlantillas.Rows[fila].Cells["Unidad"].Value.ToString().Equals(""))
            {
                señal.Unidad = gridPlantillas.Rows[fila].Cells["Unidad"].Value.ToString();
            }
            if (gridPlantillas.Rows[fila].Cells["Dirección PLC"].Value != null && !gridPlantillas.Rows[fila].Cells["Dirección PLC"].Value.ToString().Equals(""))
            {
                señal.DireccionPlc = gridPlantillas.Rows[fila].Cells["Dirección PLC"].Value.ToString();
                señal.DireccionPlcAutoGen = false;
            }
            else
            {
                if (gridPlantillas.Rows[fila].Cells["Número Físico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Físico"].Value.ToString().Equals(""))
                {
                    señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Físico"].Value), atributo, 
                        gridPlantillas.Rows[fila].Cells["Protocolo Comunicación"].Value.ToString(), gridPlantillas.Rows[fila].Cells["Criterio Archivo"].ToolTipText);
                    señal.DireccionPlcAutoGen = true;
                }
                else if (gridPlantillas.Rows[fila].Cells["Número Lógico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Lógico"].Value.ToString().Equals(""))
                {
                    señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Lógico"].Value), atributo, 
                        gridPlantillas.Rows[fila].Cells["Protocolo Comunicación"].Value.ToString(), gridPlantillas.Rows[fila].Cells["Criterio Archivo"].ToolTipText);
                    señal.DireccionPlcAutoGen = true;
                }
            }
            if (gridPlantillas.Rows[fila].Cells["Tag"].Value != null && !gridPlantillas.Rows[fila].Cells["Tag"].Value.ToString().Equals(""))
            {
                señal.Tag = gridPlantillas.Rows[fila].Cells["Tag"].Value.ToString();
            }
            else
            {
                if (gridPlantillas.Rows[fila].Cells["Número Físico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Físico"].Value.ToString().Equals(""))
                {
                    señal.NumeroFisico = Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Físico"].Value);
                    señal.Tag = generarTagNumeroFisico(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Físico"].Value), Convert.ToInt32(numeroEstacion), atributo);
                }
                if (gridPlantillas.Rows[fila].Cells["Número Lógico"].Value != null && !gridPlantillas.Rows[fila].Cells["Número Lógico"].Value.ToString().Equals(""))
                {
                    señal.NumeroLogico = Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Lógico"].Value);
                    señal.Tag = generarTagNumeroLogico(Convert.ToInt32(gridPlantillas.Rows[fila].Cells["Número Lógico"].Value), Convert.ToInt32(numeroEstacion), atributo);
                }
            }
            if (gridPlantillas.Rows[fila].Cells["OffMsg"].Value != null && !gridPlantillas.Rows[fila].Cells["OffMsg"].Value.ToString().Equals(""))
            {
                señal.OffMsg = gridPlantillas.Rows[fila].Cells["OffMsg"].Value.ToString();
            }
            if (gridPlantillas.Rows[fila].Cells["OnMsg"].Value != null && !gridPlantillas.Rows[fila].Cells["OnMsg"].Value.ToString().Equals(""))
            {
                señal.OnMsg = gridPlantillas.Rows[fila].Cells["OnMsg"].Value.ToString();
            }
            if (atributo.Substring(0, 1).Equals("E"))
            {
                señal.Alarma = gridPlantillas.Rows[fila].Cells["Alarma"].Value.ToString();
                señal.Invertida = gridPlantillas.Rows[fila].Cells["Invertida"].Value.ToString();
            }
            else if (atributo.Substring(0, 1).Equals("T"))
            {
                señal.Alarma = gridPlantillas.Rows[fila].Cells["Alarma"].Value.ToString();
            }
            else if (atributo.Substring(0, 1).Equals("V") || atributo.Substring(0, 1).Equals("A") || atributo.Substring(0, 1).Equals("C") || atributo.Substring(0, 1).Equals("P") || atributo.Substring(0, 1).Equals("M"))
            {
                señal.MaxEngUnits = Convert.ToDecimal(gridPlantillas.Rows[fila].Cells["MaxEU"].Value);
                señal.MinEngUnits = Convert.ToDecimal(gridPlantillas.Rows[fila].Cells["MinEU"].Value);
                señal.MaxRaw = Convert.ToDecimal(gridPlantillas.Rows[fila].Cells["MaxRaw"].Value);
                señal.MinRaw = Convert.ToDecimal(gridPlantillas.Rows[fila].Cells["MinRaw"].Value);
            }
            // Realizamos update
            if (señalService.updateAtributoInstanciaPreview(señal))
            {
                //MessageBox.Show("Atributo actualizado. Recargue la consulta.");
            }
            else
            {
                MessageBox.Show("Error al actualizar.");
            }
        }

        public void extraerPDF(ComboBox comboBoxExplotaciones, ComboBox comboBoxEstaciones)
        {
            PDF.extraerPDF(comboBoxExplotaciones.Text, comboBoxEstaciones.Text, Convert.ToInt32(estacionService.findNumeroEstacionByNombre(comboBoxEstaciones.Text)), 
                señalService.findSeñalesAnalogicasByNombreEstacion(comboBoxEstaciones.Text), señalService.findDigitalesByNombreEstacion(comboBoxEstaciones.Text),
                señalService.findContadoresByNombreEstacion(comboBoxEstaciones.Text), señalService.findConsignasByNombreEstacion(comboBoxEstaciones.Text),
                señalService.findTelemandosByNombreEstacion(comboBoxEstaciones.Text), estacionService.findNumeroEsclavoByNombre(comboBoxEstaciones.Text));
        }

        public void findInstanciasByNombreEstacion(ComboBox comboBoxEstaciones, ComboBox comboBoxAgrupaciones)
        {
            DataTable instancias = señalService.findInstanciasByNombreEstacion(comboBoxEstaciones.Text);
            comboBoxAgrupaciones.DisplayMember = "instancia";
            comboBoxAgrupaciones.DataSource = instancias;
        }

        public void rellenarPrimeraFilaGridAtributo(DataGridView grid, ComboBox comboBoxEstaciones, ComboBox comboBoxAtributo)
        {
            
            Estacion estacion = estacionService.findDatosPlcByNombre(comboBoxEstaciones.Text);
            Decimal minRaw = estacion.MinRaw;
            Decimal maxRaw = estacion.MaxRaw;
            String protocoloComunicacion = estacion.ProtocoloComunicacion;
            if (protocoloComunicacion.Equals("Lacbus"))
            {
                grid.Columns["Criterio Archivo"].Visible = true;
            }
            else
            {
                grid.Columns["Criterio Archivo"].Visible = false;
            }
            if (grid.Rows.Count < 1)
            {
                grid.Rows.Insert(0);
            }
            if (comboBoxAtributo.Text.Equals(""))
            {
                grid.Rows[0].Cells["Histórico"].Value = "No";
                grid.Rows[0].Cells["Alarma"].Value = "None";
                grid.Rows[0].Cells["OffMsg"].Value = "Normal";
                grid.Rows[0].Cells["OnMsg"].Value = "Alarma";
                grid.Rows[0].Cells["MinRaw"].Style.BackColor = Color.White;
                grid.Rows[0].Cells["MaxRaw"].Style.BackColor = Color.White;
                grid.Rows[0].Cells["MinEU"].Style.BackColor = Color.White;
                grid.Rows[0].Cells["MaxEU"].Style.BackColor = Color.White;
                grid.Rows[0].Cells["Unidad"].Style.BackColor = Color.White;

            }
            else if (comboBoxAtributo.Text.Equals("E_AVE2"))
            {
                grid.Rows[0].Cells["Histórico"].Value = "No";
                grid.Rows[0].Cells["Alarma"].Value = "Yes";
                grid.Rows[0].Cells["OffMsg"].Value = "Normal";
                grid.Rows[0].Cells["OnMsg"].Value = "Alarma";
                grid.Rows[0].Cells["MinRaw"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["MaxRaw"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["MinEU"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["MaxEU"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["Unidad"].Style.BackColor = Color.Gray;
            }
            else if (comboBoxAtributo.Text.Equals("E_MARV") || comboBoxAtributo.Text.Equals("E_MARI"))
            {
                grid.Rows[0].Cells["Histórico"].Value = "Yes";
                grid.Rows[0].Cells["Alarma"].Value = "None";
                grid.Rows[0].Cells["OffMsg"].Value = "Paro";
                grid.Rows[0].Cells["OnMsg"].Value = "Marcha";
                grid.Rows[0].Cells["MinRaw"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["MaxRaw"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["MinEU"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["MaxEU"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["Unidad"].Style.BackColor = Color.Gray;
            }
            else if (comboBoxAtributo.Text.Equals("E_EABI"))
            {
                grid.Rows[0].Cells["Histórico"].Value = "No";
                grid.Rows[0].Cells["Alarma"].Value = "None";
                grid.Rows[0].Cells["OffMsg"].Value = "No";
                grid.Rows[0].Cells["OnMsg"].Value = "Si";
                grid.Rows[0].Cells["MinRaw"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["MaxRaw"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["MinEU"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["MaxEU"].Style.BackColor = Color.Gray;
                grid.Rows[0].Cells["Unidad"].Style.BackColor = Color.Gray;

            }
            else
            {
                grid.Rows[0].Cells["Histórico"].Value = "No";
                grid.Rows[0].Cells["Alarma"].Value = "None";
                grid.Rows[0].Cells["OffMsg"].Value = "Normal";
                grid.Rows[0].Cells["OnMsg"].Value = "Alarma";
                grid.Rows[0].Cells["MinRaw"].Style.BackColor = Color.White;
                grid.Rows[0].Cells["MaxRaw"].Style.BackColor = Color.White;
                grid.Rows[0].Cells["MinEU"].Style.BackColor = Color.White;
                grid.Rows[0].Cells["MaxEU"].Style.BackColor = Color.White;
                grid.Rows[0].Cells["Unidad"].Style.BackColor = Color.White;
            }
            grid.Rows[0].Cells["MinRaw"].Value = minRaw;
            grid.Rows[0].Cells["MaxRaw"].Value = maxRaw;
            grid.Rows[0].Cells["Protocolo Comunicación"].Value = protocoloComunicacion;  
            grid.Rows[0].Cells["Descripción"].Value = "XXXXX - " + comboBoxEstaciones.Text;   
        }

        public void añadirAtributo(ComboBox comboBoxInstancia, DataGridView grid, ComboBox comboBoxEstaciones, ComboBox comboBoxExplotaciones, ComboBox comboBoxAtributo)
        {
            if (!comboBoxInstancia.Text.Equals(""))
            {
                Dictionary<String, Señal> atributos = new Dictionary<String, Señal>();
                Señal señal = new Señal();
                if (!comboBoxAtributo.Text.Equals(""))
                {
                    if (!AppListaSeñales.señalesCreadas.ContainsKey(comboBoxInstancia.Text + "." + comboBoxAtributo.Text))
                    {
                        String numeroEstacion = estacionService.findNumeroEstacionByNombre(comboBoxEstaciones.Text);
                        int idEstacion = estacionService.findIdByNombreEstacionAndNombreExplotacion(comboBoxEstaciones.Text, comboBoxExplotaciones.Text);
                        señal.Codigo = comboBoxInstancia.Text + "." + comboBoxAtributo.Text;
                        señal.Descripcion = grid.Rows[0].Cells["Descripción"].Value.ToString();
                        señal.Historico = grid.Rows[0].Cells["Histórico"].Value.ToString();
                        // Si tiene unidad la guardamos
                        if (grid.Rows[0].Cells["Unidad"].Value != null)
                        {
                            señal.Unidad = grid.Rows[0].Cells["Unidad"].Value.ToString();
                        }
                        // Históricos si no hay comunicación en caso de protocolo Lacbus
                        if (grid.Rows[0].Cells["Protocolo Comunicación"].Value.ToString().Equals("Lacbus"))
                        {
                            if (grid.Rows[0].Cells["Criterio Archivo"].ToolTipText.Equals("True"))
                            {
                                señal.CriterioArchivo = true;
                            }
                            else
                            {
                                señal.CriterioArchivo = false;
                            }
                        }
                        // No va a VAR_0
                        señal.VarCero = false;
                        // Si tiene dirección de PLC se guarda, si no se autogenera
                        if (grid.Rows[0].Cells["Dirección PLC"].Value != null)
                        {
                            señal.DireccionPlc = grid.Rows[0].Cells["Dirección PLC"].Value.ToString();
                            señal.DireccionPlcAutoGen = false;
                        }
                        else
                        {
                            if (grid.Rows[0].Cells["Número Físico"].Value != null)
                            {
                                señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(grid.Rows[0].Cells["Número Físico"].Value), comboBoxAtributo.Text,
                                    grid.Rows[0].Cells["Protocolo Comunicación"].Value.ToString(), grid.Rows[0].Cells["Criterio Archivo"].ToolTipText);
                                señal.DireccionPlcAutoGen = true;
                            }
                            else if (grid.Rows[0].Cells["Número Lógico"].Value != null)
                            {
                                señal.DireccionPlc = generarDireccionPlc(Convert.ToInt32(grid.Rows[0].Cells["Número Lógico"].Value), comboBoxAtributo.Text,
                                    grid.Rows[0].Cells["Protocolo Comunicación"].Value.ToString(), grid.Rows[0].Cells["Criterio Archivo"].ToolTipText);
                                señal.DireccionPlcAutoGen = true;
                            }
                        }
                        // Creamos Tag en función del Número Lógico o Físico
                        if (grid.Rows[0].Cells["Número Físico"].Value != null)
                        {
                            señal.NumeroFisico = Convert.ToInt32(grid.Rows[0].Cells["Número Físico"].Value);
                            señal.Tag = generarTagNumeroFisico(Convert.ToInt32(grid.Rows[0].Cells["Número Físico"].Value), Convert.ToInt32(numeroEstacion), comboBoxAtributo.Text);
                        }
                        if (grid.Rows[0].Cells["Número Lógico"].Value != null)
                        {
                            señal.NumeroLogico = Convert.ToInt32(grid.Rows[0].Cells["Número Lógico"].Value);
                            señal.Tag = generarTagNumeroLogico(Convert.ToInt32(grid.Rows[0].Cells["Número Lógico"].Value), Convert.ToInt32(numeroEstacion), comboBoxAtributo.Text);
                        }

                        // Id de la estación que relaciona la señal con la estación
                        señal.IdEstacion = idEstacion;
                        // Dependiendo del atributo guardamos alarma o rangos
                        if (comboBoxAtributo.Text.Substring(0, 1).Equals("E"))
                        {
                            // Guardamos Off y On Msg si los tiene
                            if (grid.Rows[0].Cells["OffMsg"].Value != null)
                            {
                                señal.OffMsg = grid.Rows[0].Cells["OffMsg"].Value.ToString();
                            }
                            if (grid.Rows[0].Cells["OnMsg"].Value != null)
                            {
                                señal.OnMsg = grid.Rows[0].Cells["OnMsg"].Value.ToString();
                            }
                            // Invertida
                            if (grid.Rows[0].Cells["Invertida"].ToolTipText.Equals("True"))
                            {
                                señal.Invertida = "Reverse";
                            }
                            else
                            {
                                señal.Invertida = "Direct";
                            }
                            // Alarma
                            señal.Alarma = grid.Rows[0].Cells["Alarma"].Value.ToString();
                        }
                        else if (comboBoxAtributo.Text.Substring(0, 1).Equals("T"))
                        {
                            // Guardamos Off y On Msg si los tiene
                            if (grid.Rows[0].Cells["OffMsg"].Value != null)
                            {
                                señal.OffMsg = grid.Rows[0].Cells["OffMsg"].Value.ToString();
                            }
                            if (grid.Rows[0].Cells["OnMsg"].Value != null)
                            {
                                señal.OnMsg = grid.Rows[0].Cells["OnMsg"].Value.ToString();
                            }
                            // Alarma
                            señal.Alarma = grid.Rows[0].Cells["Alarma"].Value.ToString();
                        }
                        else if (comboBoxAtributo.Text.Substring(0, 1).Equals("V") || comboBoxAtributo.Text.Substring(0, 1).Equals("A")
                            || comboBoxAtributo.Text.Substring(0, 1).Equals("C") || comboBoxAtributo.Text.Substring(0, 1).Equals("P")
                            || comboBoxAtributo.Text.Substring(0, 1).Equals("M"))
                        {
                            señal.MaxEngUnits = Convert.ToDecimal(grid.Rows[0].Cells["MaxEU"].Value);
                            señal.MinEngUnits = Convert.ToDecimal(grid.Rows[0].Cells["MinEU"].Value);
                            señal.MaxRaw = Convert.ToDecimal(grid.Rows[0].Cells["MaxRaw"].Value);
                            señal.MinRaw = Convert.ToDecimal(grid.Rows[0].Cells["MinRaw"].Value);
                        }
                        atributos.Add(señal.Codigo, señal);

                        if (señalService.createListaSeñales(atributos))
                        {
                            MessageBox.Show("Atributo añadido.");
                        }
                        else
                        {
                            MessageBox.Show("Error al añadir atributo.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La instancia " + comboBoxInstancia.Text + " ya tiene el atributo " + comboBoxAtributo.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Indique el nombre del atributo.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione la instancia en la que va a añadir el atributo.");
            }
        }

        public void importarListaDeSeñales()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Path del archivo
                        string filePath = openFileDialog.FileName;
                        string areaContenedora = filePath.Split(Path.DirectorySeparatorChar).Last();
                        //Consultamos a qué estación corresponde
                        int idEstacion = estacionService.findIdByNumeroDeEstacionCebeIasExplotacionAndExplotacionIas(areaContenedora.Substring(0, 3), areaContenedora.Substring(3, 2), Convert.ToInt32(areaContenedora.Substring(5, 4)));
                        if (idEstacion > 0)
                        {
                            bool errorInsercion = false;
                            //Lee contenido del fichero
                            var contenido = CSV.importarCSV(openFileDialog.OpenFile(), idEstacion);
                            //Insertamos en BBDD
                            if (señalService.createListaSeñales(contenido.Item2))
                            {
                                MessageBox.Show("Lista de señales importada.");
                            }
                            else
                            {
                                MessageBox.Show("Error al insertar la lista de señales en la base de datos.");
                                errorInsercion = true;
                            }
                            //Si la variable de InTouch de las señales no es la habitual mandamos mensaje de revisión
                            if (contenido.Item1 && !errorInsercion)
                            {
                                MessageBox.Show("Revise los números físico y lógico de las señales.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La estación no existe.");
                        }     
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al importar: " + ex.Message);
                    }

                }
            }
        }

    }
}
