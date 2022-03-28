using AppListaSeñales.Controller;
using AppListaSeñales.Entity;
using AppListaSeñales.Repository;
using AppListaSeñales.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppListaSeñales
{
    public partial class AppListaSeñales : Form
    {
        #region Variables Privadas
        private Boolean inicializarCellValidating = false;
        private int flag = 0; // Variable para diferenciar que hemos seleccionado en el menú principal
        #endregion
        #region Variables Públicas
        public static Dictionary<String, Señal> listaSeñales = new Dictionary<String, Señal>();
        public static Dictionary<String, Señal> señalesCreadas = new Dictionary<String, Señal>();
        public static bool esDatalogger = false;
        #endregion
        #region Controllers
        // Controllers que interactúan con el form
        private readonly ListaSeñalesController listaSeñalesController = new ListaSeñalesController();
        private readonly UsuarioController usuarioController = new UsuarioController();
        private readonly ExplotacionController explotacionController = new ExplotacionController();
        private readonly EstacionController estacionController = new EstacionController();
        private readonly DataloggerController dataloggerController = new DataloggerController();
        #endregion
        public AppListaSeñales()
        {
            InitializeComponent();
        }

        private void AppListaSeñales_Load(object sender, EventArgs e)
        {
            // Inicializamos el diseño del grid para elegir las plantillas que deseamos
            diseñoGridPlantillas();
            // Inicializamos el diseño del grid para ver señales
            diseñoGridSeñales();
            // Inicializamos el diseño del grid para ver señales creadas durante la creación
            diseñoGridSeñalesCreadas();
            // Inicializamos el diseño del grid para ver señales al exportar a excel
            diseñoGridExcel();
            // Inicializamos el diseño del grid para ver señales que se van a crear
            diseñoGridCrearSeñales();
            // Inicializamos el diseño del grid para añadir atributos
            diseñoGridAtributos();
        }
        #region Login
        private void usuarioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, new EventArgs());
            }
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usuarioTextBox.Text.Equals("") || passwordTextBox.Text.Equals(""))
            {
                if (errorLoginLabel1.Visible) errorLoginLabel1.Visible = false;
                errorLogin2.Visible = true;
            }
            else
            {
                if (passwordTextBox.Text.Equals(usuarioController.findPasswordByUser(usuarioTextBox)))
                {
                    panelLogin.Hide();
                    panelMenuPrincipal.Show();
                    logoutLinkLabel.Visible = true;
                }
                else
                {
                    if (errorLogin2.Visible) errorLogin2.Visible = false;
                    errorLoginLabel1.Visible = true;
                }
            }
        }
        #endregion

        #region Vuelta a Menú Principal
        private void inicioLlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            labelEditarBorrarDatalogger.Visible = false;
            buttonCrearDataloggerInsert.Visible = false;
            buttonEditarDatalogger.Visible = false;
            buttonBorrarDatalogger.Visible = false;
            comboBoxNombreDatalogger.Visible = false;
            textBoxNombreDatalogger.Clear();
            textBoxNumeroPunto.Clear();
            textBoxNumeroDatalogger.Clear();
            textBoxNumeroAgrupacion.Clear();
            textBoxIP.Clear();
            textBoxPuerto.Clear();
            comboBoxTipoDl.SelectedIndex = 0;
            textBoxHorasComunicacion.Clear();
            labelNumeroDatalogger.Visible = false;
            textBoxZonaSectorizacion.Clear();
            textBoxNombreDatalogger.Visible = false;
            labelNombreDatalogger.Visible = false;
            labelNumeroAgrupacionDl.Visible = false;
            textBoxNumeroAgrupacion.Visible = false;
            textBoxNumeroDatalogger.Visible = false;
            labelNumeroPunto.Visible = false;
            textBoxNumeroPunto.Visible = false;
            comboBoxTipoDl.Visible = false;
            labelTipoDl.Visible = false;
            labelHorasComunicacion.Visible = false;
            labelZonaSectorizacion.Visible = false;
            textBoxZonaSectorizacion.Visible = false;
            textBoxHorasComunicacion.Visible = false;
            textBoxIP.Visible = false;
            textBoxPuerto.Visible = false;
            labelPuerto.Visible = false;
            labelIP.Visible = false;
            buttonCrearDataloggerInsert.Visible = false;
            labelCrearDatalogger.Visible = false;
            labelNumeroEsclavo.Visible = false;
            textBoxNumeroEsclavo.Visible = false;
            comboBoxExplotaciones.SelectedIndex = -1;
            comboBoxNumeroAgrupacion.SelectedIndex = -1;
            gridAtributo.Visible = false;
            buttonCrearAtributo.Visible = false;
            labelInstancia.Visible = false;
            labelAñadirAtributo.Visible = false;
            labelDCDC.Visible = false;
            pictureBoxPdf.Visible = false;
            textBoxFiltroPreviewCodigo.Visible = false;
            textBoxFiltroPreviewNFisico.Visible = false;
            textBoxFiltroPreviewDescripcion.Visible = false;
            textBoxFiltroPreviewNLogico.Visible = false;
            textBoxFiltroPreviewDireccionPlc.Visible = false;
            labelFiltroPreviewCodigo.Visible = false;
            labelFiltroPreviewDescripcion.Visible = false;
            labelFiltroPreviewNFisico.Visible = false;
            labelFiltroPreviewNLogico.Visible = false;
            labelFiltroPreviewPlc.Visible = false;
            textBoxFiltroPreviewCodigo.Clear();
            textBoxFiltroPreviewNFisico.Clear();
            textBoxFiltroPreviewDescripcion.Clear();
            textBoxFiltroPreviewNLogico.Clear();
            textBoxFiltroPreviewDireccionPlc.Clear();
            comboBoxNumeroAgrupacion.SelectedIndex = 0;
            textBoxFiltroNFisico.Clear();
            textBoxFiltroCodigo.Clear();
            textBoxFiltroNLogico.Clear();
            textBoxFiltroPlc.Clear();
            labelFiltroCodigo.Visible = false;
            labelFiltroNFisico.Visible = false;
            labelFiltroNLogico.Visible = false;
            labelFiltroPlc.Visible = false;
            textBoxFiltroCodigo.Visible = false;
            textBoxFiltroNFisico.Visible = false;
            textBoxFiltroNLogico.Visible = false;
            textBoxFiltroPlc.Visible = false;
            buttonAtras.Visible = false;
            textBoxNumeroEstacion.Clear();
            labelEditarEstacion.Visible = false;
            buttonBorrarEstacion.Visible = false;
            buttonEditarEstacion.Visible = false;
            textBoxCebeIas.Clear();
            textBoxCrearEstacion.Clear();
            textBoxMaxRaw.Clear();
            textBoxMinRaw.Clear();
            comboBoxComunicaciones.SelectedIndex = 0;
            textBoxNumeroEsclavo.Clear();
            labelExportarExcel.Visible = false;
            gridExcel.Visible = false;
            buttonExportarExcel.Visible = false;
            panelMenuPrincipal.Visible = true;
            panelInteraccion.Visible = false;
            labelCrearEstacion.Visible = false;
            labelGridSeñalesCreadas.Visible = false;
            labelCrearListas.Visible = false;
            pictureBoxExcel.Visible = false;
            inicioLinkLabel.Visible = false;
            labelCrearExplotacion.Visible = false;
            buttonGuardarLista.Visible = false;
            gridCrearSeñales.Visible = false;
            buttonLimpiarLista.Visible = false;
            gridPlantillas.Visible = false;
            buttonAñadirSeñal.Visible = false;
            gridSeñales.Visible = false;
            gridSeñalesCreadas.Visible = false;
            comboBoxEstaciones.Visible = false;
            estacionListaLabel.Visible = false;
            agrupacionListaLabel.Visible = false;
            plantillaListaLabel.Visible = false;
            comboBoxPlantillas.Visible = false;
            comboBoxAgrupaciones.Visible = false;
            comboBoxNumeroAgrupacion.Visible = false;
            labelNumeroAgrupacion.Visible = false;
            labelSitAquacis.Visible = false;
            comboBoxSitAquacis.Visible = false;
            labelCebeIas.Visible = false;
            textBoxCebeIas.Visible = false;
            buttonCrearExplotacion.Visible = false;
            textBoxCrearEstacion.Visible = false;
            buttonCrearEstacion.Visible = false;
            labelNumeroEstacion.Visible = false;
            textBoxNumeroEstacion.Visible = false;
            textBoxCebeAquacis.Visible = false;
            labelCebeAquacis.Visible = false;
            textBoxMaxRaw.Visible = false;
            textBoxMinRaw.Visible = false;
            labelMaxRaw.Visible = false;
            labelMinRaw.Visible = false;
            labelComunicacion.Visible = false;
            comboBoxComunicaciones.Visible = false;
            linkLabelAnalogicas.Visible = false;
            linkLabelConsignas.Visible = false;
            linkLabelContadores.Visible = false;
            linkLabelDigitales.Visible = false;
            linkLabelTelemandos.Visible = false;
            labelVisualizarListas.Visible = false;
            comboBoxAtributo.Visible = false;
            labelAtributo.Visible = false;
        }
        #endregion

        #region Menú Principal
        private void crearExplotacionButton_Click(object sender, EventArgs e)
        {
            flag = 0;
            panelMenuPrincipal.Hide();
            panelInteraccion.Show();
            inicioLinkLabel.Visible = true;
            labelCebeIas.Visible = true;
            labelCrearExplotacion.Visible = true;
            textBoxCebeIas.Visible = true;
            buttonCrearExplotacion.Visible = true;
            textBoxCebeAquacis.Visible = true;
            labelCebeAquacis.Visible = true;
            explotacionController.findNombreExplotacionesSinCrear(comboBoxExplotaciones);
        }

        private void crearEstacionButton_Click(object sender, EventArgs e)
        {
            flag = 3;
            panelMenuPrincipal.Hide();
            panelInteraccion.Show();
            inicioLinkLabel.Visible = true;
            labelCrearEstacion.Visible = true;
            estacionController.findNombreExplotaciones(comboBoxExplotaciones);
        }

        private void buttonEditarBorrarEstacion_Click(object sender, EventArgs e)
        {
            flag = 4;
            panelMenuPrincipal.Hide();
            panelInteraccion.Show();
            inicioLinkLabel.Visible = true;
            labelEditarEstacion.Visible = true;
            estacionController.findNombreExplotaciones(comboBoxExplotaciones);
        }
        private void crearListaButton_Click(object sender, EventArgs e)
        {
            flag = 1;
            //Visibilidad
            labelCrearListas.Visible = true;
            inicioLinkLabel.Visible = true;
            panelMenuPrincipal.Hide();
            panelInteraccion.Show();
            
            // Rellenamos combobox de explotaciones
            listaSeñalesController.findNombreExplotaciones(comboBoxExplotaciones);
            // Rellenamos Combobox agrupaciones
            listaSeñalesController.findDescripcionAgrupaciones(comboBoxAgrupaciones);
            // Rellenamos Combobox plantillas
            listaSeñalesController.findTipoPlantillaAll(comboBoxPlantillas);
        }

        private void buttonAñadirAtributo_Click(object sender, EventArgs e)
        {
            flag = 5;
            panelMenuPrincipal.Hide();
            panelInteraccion.Show();
            inicioLinkLabel.Visible = true;
            labelAñadirAtributo.Visible = true;
            //Rellenamos combobox de explotaciones
            listaSeñalesController.findNombreExplotaciones(comboBoxExplotaciones);
        }

        private void visualizarListaSeñales_Click(object sender, EventArgs e)
        {
            flag = 2;
            inicioLinkLabel.Visible = true;
            panelMenuPrincipal.Hide();
            panelInteraccion.Show();
            labelVisualizarListas.Visible = true;
            //Rellenamos combobox de explotaciones
            listaSeñalesController.findNombreExplotaciones(comboBoxExplotaciones);
        }
        private void buttonImportarCSV_Click(object sender, EventArgs e)
        {
            flag = 6;
            listaSeñalesController.importarListaDeSeñales();
        }

        private void buttonCrearDatalogger_Click(object sender, EventArgs e)
        {
            flag = 7;
            panelMenuPrincipal.Hide();
            panelInteraccion.Show();
            inicioLinkLabel.Visible = true;
            labelCrearDatalogger.Visible = true;
            dataloggerController.findNombreExplotaciones(comboBoxExplotaciones);
        }
        private void buttonEditarBorrarDatalogger_Click(object sender, EventArgs e)
        {
            flag = 8;
            panelMenuPrincipal.Hide();
            panelInteraccion.Show();
            inicioLinkLabel.Visible = true;
            labelEditarBorrarDatalogger.Visible = true;
            dataloggerController.findNombreExplotaciones(comboBoxExplotaciones);
        }
        #endregion

        #region Crear Explotación
        private void buttonCrearExplotacion_Click(object sender, EventArgs e)
        {
            explotacionController.crearExplotacion(comboBoxExplotaciones, textBoxCebeIas);
        }
        #endregion

        #region Crear Estación
        private void buttonCrearEstacion_Click(object sender, EventArgs e)
        {
            estacionController.createEstacion(comboBoxExplotaciones, comboBoxSitAquacis, textBoxCrearEstacion, textBoxNumeroEstacion, textBoxMinRaw, textBoxMaxRaw, comboBoxComunicaciones, textBoxNumeroEsclavo);
        }
        #endregion

        #region Selección explotación y estación
        // Elegir explotación
        private void comboBoxExplotaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxExplotaciones.Text.Equals(""))
            {
                // Si no se elige una explotación no se da visibilidad a lo demás
                comboBoxEstaciones.Visible = false;
                estacionListaLabel.Visible = false;
                agrupacionListaLabel.Visible = false;
                plantillaListaLabel.Visible = false;
                comboBoxPlantillas.Visible = false;
                comboBoxAgrupaciones.Visible = false;
                comboBoxNumeroAgrupacion.Visible = false;
                labelNumeroAgrupacion.Visible = false;
                labelSitAquacis.Visible = false;
                comboBoxSitAquacis.Visible = false;
                if (flag == 0)
                {
                    explotacionController.findCebeAquacisByNombre(comboBoxExplotaciones, textBoxCebeAquacis);
                }
            }
            else
            {
                if (flag == 0)
                {
                    explotacionController.findCebeAquacisByNombre(comboBoxExplotaciones, textBoxCebeAquacis);
                }
                else
                {
                    labelSitAquacis.Visible = true;
                    comboBoxSitAquacis.Visible = true;
                    listaSeñalesController.findSitAquacisExplotacion(comboBoxExplotaciones, comboBoxSitAquacis);
                }
            }

        }
        // Elegir SIT Aquacis
        private void comboBoxSitAquacis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSitAquacis.Text.Equals(""))
            {
                // Si no se elige una explotación no se da visibilidad a lo demás
                comboBoxEstaciones.Visible = false;
                estacionListaLabel.Visible = false;
                agrupacionListaLabel.Visible = false;
                plantillaListaLabel.Visible = false;
                comboBoxPlantillas.Visible = false;
                comboBoxAgrupaciones.Visible = false;
                comboBoxNumeroAgrupacion.Visible = false;
                labelNumeroAgrupacion.Visible = false;
            }
            else
            {
                // Si hemos elegido crear lista de señales
                if (flag == 1)
                {
                    // Cuando se elige una explotación y se elige el sit aquacis
                    comboBoxEstaciones.Visible = true;
                    estacionListaLabel.Visible = true;
                    agrupacionListaLabel.Visible = true;
                    plantillaListaLabel.Visible = true;
                    comboBoxPlantillas.Visible = true;
                    comboBoxAgrupaciones.Visible = true;
                    comboBoxNumeroAgrupacion.Visible = true;
                    labelNumeroAgrupacion.Visible = true;
                    // Combobox estaciones, que tiene tanto estaciones como dataloggers de la explotación
                    listaSeñalesController.findNombreEstacionesAndNombreDataloggersByNombreExplotacion(comboBoxEstaciones, comboBoxExplotaciones, comboBoxSitAquacis);
                }
                else if (/*flag == 2 ||*/flag == 5) // Si hemos elegido añadir atributo
                {
                    // Cuando se elige una explotación se da visibilidad a lo demás
                    comboBoxEstaciones.Visible = true;
                    estacionListaLabel.Visible = true;
                    // Combobox estaciones
                    listaSeñalesController.findNombreEstacionesByNombreExplotacion(comboBoxEstaciones, comboBoxExplotaciones, comboBoxSitAquacis);
                    
                }
                else if (flag == 2) //Si hemos elegido visualizar listas de señales
                {
                    // Cuando se elige una explotación se da visibilidad a lo demás
                    comboBoxEstaciones.Visible = true;
                    estacionListaLabel.Visible = true;
                    // Combobox estaciones
                    //listaSeñalesController.findNombreEstacionesByNombreExplotacion(comboBoxEstaciones, comboBoxExplotaciones, comboBoxSitAquacis);
                    listaSeñalesController.findNombreEstacionesAndNombreDataloggersByNombreExplotacion(comboBoxEstaciones, comboBoxExplotaciones, comboBoxSitAquacis);
                }
                else if (flag == 3) // Crear estación
                {
                    textBoxCrearEstacion.Visible = true;
                    buttonCrearEstacion.Visible = true;
                    labelNumeroEstacion.Visible = true;
                    estacionListaLabel.Visible = true;
                    textBoxNumeroEstacion.Visible = true;
                    textBoxMaxRaw.Visible = true;
                    textBoxMinRaw.Visible = true;
                    labelMaxRaw.Visible = true;
                    labelMinRaw.Visible = true;
                    labelNumeroEsclavo.Visible = true;
                    textBoxNumeroEsclavo.Visible = true;
                    labelComunicacion.Visible = true;
                    comboBoxComunicaciones.Visible = true;
                }
                else if (flag == 4) // Editar/Borrar estación
                {
                    comboBoxEstaciones.Visible = true;
                    estacionListaLabel.Visible = true;
                    buttonBorrarEstacion.Visible = true;
                    labelNumeroEstacion.Visible = true;
                    buttonEditarEstacion.Visible = true;
                    labelNumeroEsclavo.Visible = true;
                    textBoxNumeroEsclavo.Visible = true;
                    textBoxNumeroEstacion.Visible = true;
                    textBoxMaxRaw.Visible = true;
                    textBoxMinRaw.Visible = true;
                    labelMaxRaw.Visible = true;
                    labelMinRaw.Visible = true;
                    labelComunicacion.Visible = true;
                    comboBoxComunicaciones.Visible = true;
                    // Combobox estaciones
                    listaSeñalesController.findNombreEstacionesByNombreExplotacion(comboBoxEstaciones, comboBoxExplotaciones, comboBoxSitAquacis);
                }
                else if (flag == 7) // Crear Datalogger
                {
                    textBoxNombreDatalogger.Visible = true;
                    labelNombreDatalogger.Visible = true;
                    labelNumeroAgrupacionDl.Visible = true;
                    labelNumeroDatalogger.Visible = true;
                    textBoxNumeroAgrupacion.Visible = true;
                    textBoxNumeroDatalogger.Visible = true;
                    labelNumeroPunto.Visible = true;
                    textBoxNumeroPunto.Visible = true;
                    comboBoxTipoDl.Visible = true;
                    labelTipoDl.Visible = true;
                    labelHorasComunicacion.Visible = true;
                    labelZonaSectorizacion.Visible = true;
                    textBoxZonaSectorizacion.Visible = true;
                    textBoxHorasComunicacion.Visible = true;
                    textBoxIP.Visible = true;
                    textBoxPuerto.Visible = true;
                    labelPuerto.Visible = true;
                    labelIP.Visible = true;
                    buttonCrearDataloggerInsert.Visible = true;
                }
                else if (flag == 8) // Editar/Borrar Datalogger
                {
                    buttonEditarDatalogger.Visible = true;
                    buttonBorrarDatalogger.Visible = true;
                    comboBoxNombreDatalogger.Visible = true;
                    labelNombreDatalogger.Visible = true;
                    labelNumeroAgrupacionDl.Visible = true;
                    labelNumeroDatalogger.Visible = true;
                    textBoxNumeroAgrupacion.Visible = true;
                    textBoxNumeroDatalogger.Visible = true;
                    labelNumeroPunto.Visible = true;
                    textBoxNumeroPunto.Visible = true;
                    comboBoxTipoDl.Visible = true;
                    labelTipoDl.Visible = true;
                    labelHorasComunicacion.Visible = true;
                    labelZonaSectorizacion.Visible = true;
                    textBoxZonaSectorizacion.Visible = true;
                    textBoxHorasComunicacion.Visible = true;
                    textBoxIP.Visible = true;
                    textBoxPuerto.Visible = true;
                    labelPuerto.Visible = true;
                    labelIP.Visible = true;
                    // Rellenar combo dataloggers
                    dataloggerController.findNombreDataloggersByNombreExplotacion(comboBoxNombreDatalogger, comboBoxExplotaciones, comboBoxSitAquacis);
                }
            }  
        }
        // Elegir estación
        private void comboBoxEstaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEstaciones.Text.Equals(""))
            {
                labelDCDC.Visible = false;
                agrupacionListaLabel.Visible = false;
                plantillaListaLabel.Visible = false;
                comboBoxPlantillas.Visible = false;
                comboBoxAgrupaciones.Visible = false;
                comboBoxNumeroAgrupacion.Visible = false;
                labelNumeroAgrupacion.Visible = false;
                linkLabelAnalogicas.Visible = false;
                pictureBoxExcel.Visible = false;
                pictureBoxPdf.Visible = false;
                linkLabelConsignas.Visible = false;
                linkLabelContadores.Visible = false;
                linkLabelDigitales.Visible = false;
                linkLabelTelemandos.Visible = false;
                labelInstancia.Visible = false;
                buttonCrearAtributo.Visible = false;
                gridAtributo.Visible = false;
                gridSeñalesCreadas.Visible = false;
                labelGridSeñalesCreadas.Visible = false;
                labelFiltroCodigo.Visible = false;
                labelFiltroNFisico.Visible = false;
                labelFiltroNLogico.Visible = false;
                labelFiltroPlc.Visible = false;
                textBoxFiltroCodigo.Visible = false;
                textBoxFiltroNFisico.Visible = false;
                textBoxFiltroNLogico.Visible = false;
                textBoxFiltroPlc.Visible = false;
                comboBoxAtributo.Visible = false;
                labelAtributo.Visible = false;
            }
            else
            {
                if (comboBoxEstaciones.Text.Contains("(Datalogger)"))
                {
                    esDatalogger = true;
                }
                else
                {
                    esDatalogger = false;
                }
                if (flag == 1)
                {
                    plantillaListaLabel.Visible = true;
                    comboBoxPlantillas.Visible = true;
                    gridSeñalesCreadas.Visible = true;
                    gridSeñalesCreadas.Visible = false;
                    if (esDatalogger)
                    {
                        agrupacionListaLabel.Visible = false;
                        comboBoxAgrupaciones.Visible = false;
                        labelNumeroAgrupacion.Visible = false;
                        comboBoxNumeroAgrupacion.Visible = false;
                        comboBoxNumeroAgrupacion.SelectedIndex = 0;
                        comboBoxAgrupaciones.SelectedIndex = 0;
                        listaSeñalesController.findSeñalesCreadasByNombreDatalogger(comboBoxEstaciones, gridSeñalesCreadas);
                    }
                    else
                    {
                        agrupacionListaLabel.Visible = true;
                        comboBoxAgrupaciones.Visible = true;
                        labelNumeroAgrupacion.Visible = true;
                        comboBoxNumeroAgrupacion.Visible = true;
                        listaSeñalesController.findSeñalesCreadasByNombreEstacion(comboBoxEstaciones, gridSeñalesCreadas);
                    }      
                }
                else if (flag == 2)
                {
                    labelDCDC.Visible = true;
                    pictureBoxPdf.Visible = true;
                    linkLabelAnalogicas.Visible = true;
                    linkLabelConsignas.Visible = true;
                    linkLabelContadores.Visible = true;
                    pictureBoxExcel.Visible = true;
                    linkLabelDigitales.Visible = true;
                    linkLabelTelemandos.Visible = true;
                }
                else if (flag == 5)
                {
                    gridSeñalesCreadas.Visible = true;
                    gridSeñalesCreadas.Visible = false;
                    listaSeñalesController.findInstanciasByNombreEstacion(comboBoxEstaciones, comboBoxAgrupaciones);
                    listaSeñalesController.findSeñalesCreadasByNombreEstacion(comboBoxEstaciones, gridSeñalesCreadas);
                    labelInstancia.Visible = true;
                    comboBoxAgrupaciones.Visible = true;
                    buttonCrearAtributo.Visible = true;
                    gridAtributo.Visible = true;
                    gridSeñalesCreadas.Visible = true;
                    labelGridSeñalesCreadas.Visible = true;
                    labelFiltroCodigo.Visible = true;
                    labelFiltroNFisico.Visible = true;
                    labelFiltroNLogico.Visible = true;
                    labelFiltroPlc.Visible = true;
                    textBoxFiltroCodigo.Visible = true;
                    textBoxFiltroNFisico.Visible = true;
                    textBoxFiltroNLogico.Visible = true;
                    textBoxFiltroPlc.Visible = true;
                    comboBoxAtributo.Visible = true;
                    labelAtributo.Visible = true;
                    listaSeñalesController.rellenarPrimeraFilaGridAtributo(gridAtributo, comboBoxEstaciones, comboBoxAtributo);
                }
                else if (flag == 4)
                {
                    Estacion estacion = estacionController.findEstacionByNombreEstacionAndNombreExplotacion(comboBoxEstaciones, comboBoxExplotaciones, comboBoxSitAquacis);
                    if (estacion != null)
                    {
                        //Rellenamos textbox número estación
                        if (estacion.Numero > 0)
                        {
                            textBoxNumeroEstacion.Text = estacion.Numero.ToString();
                        }
                        else
                        {
                            textBoxNumeroEstacion.Clear();
                        }
                        //Rellenamos textbox número esclavo
                        textBoxNumeroEsclavo.Text = estacion.NumeroEsclavo.ToString();
                        //Seleccionamos protocolo
                        if (estacion.ProtocoloComunicacion.Equals("Modbus"))
                        {
                            comboBoxComunicaciones.SelectedIndex = 1;
                        }
                        else if (estacion.ProtocoloComunicacion.Equals("S7"))
                        {
                            comboBoxComunicaciones.SelectedIndex = 2;
                        }
                        else if (estacion.ProtocoloComunicacion.Equals("Lacbus"))
                        {
                            comboBoxComunicaciones.SelectedIndex = 3;
                        }
                        else
                        {
                            comboBoxComunicaciones.SelectedIndex = 0;
                        }
                        //MinRaw y MaxRaw
                        textBoxMinRaw.Text = estacion.MinRaw.ToString();
                        textBoxMaxRaw.Text = estacion.MaxRaw.ToString();
                    }
                }                
            }         
        }
        #endregion

        #region Editar/Borrar Estación
        private void buttonBorrarEstacion_Click(object sender, EventArgs e)
        {
            DialogResult borrarEstacion = MessageBox.Show("Va a borrar la estación " + comboBoxEstaciones.Text + ", ¿está seguro?", "Borrar estación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (borrarEstacion == DialogResult.Yes)
            {
                estacionController.deleteEstacion(comboBoxEstaciones, comboBoxExplotaciones);
                listaSeñalesController.findNombreEstacionesByNombreExplotacion(comboBoxEstaciones, comboBoxExplotaciones, comboBoxSitAquacis);
            }          
        }

        private void buttonEditarEstacion_Click(object sender, EventArgs e)
        {
            estacionController.updateEstacion(comboBoxEstaciones, textBoxNumeroEstacion, textBoxMinRaw, textBoxMaxRaw, comboBoxComunicaciones, textBoxNumeroEsclavo);
        }
        #endregion

        #region Crear Lista de Señales
        // Elegir plantilla
        private void comboBoxPlantillas_SelectedIndexChanged(object sender, EventArgs e)
        {
            inicializarCellValidating = false;
            if (comboBoxPlantillas.Text.Equals(""))
            {
                gridPlantillas.Visible = false;
                gridSeñalesCreadas.Visible = false;
                buttonAñadirSeñal.Visible = false;
                gridCrearSeñales.Visible = false;
                buttonGuardarLista.Visible = false;
                buttonLimpiarLista.Visible = false;
                labelGridSeñalesCreadas.Visible = false;
                labelFiltroCodigo.Visible = false;
                labelFiltroNFisico.Visible = false;
                labelFiltroNLogico.Visible = false;
                labelFiltroPlc.Visible = false;
                textBoxFiltroCodigo.Visible = false;
                textBoxFiltroNFisico.Visible = false;
                textBoxFiltroNLogico.Visible = false;
                textBoxFiltroPlc.Visible = false;
            }
            else
            {
                listaSeñalesController.findPlantillasByTipoPlantilla(comboBoxPlantillas, comboBoxEstaciones, gridPlantillas);
                buttonAñadirSeñal.Visible = true;
                buttonLimpiarLista.Visible = true;
                gridCrearSeñales.Visible = true;
                buttonGuardarLista.Visible = true;
                inicializarCellValidating = true;
                gridSeñalesCreadas.Visible = true;
                labelGridSeñalesCreadas.Visible = true;
                labelFiltroCodigo.Visible = true;
                labelFiltroNFisico.Visible = true;
                labelFiltroNLogico.Visible = true;
                labelFiltroPlc.Visible = true;
                textBoxFiltroCodigo.Visible = true;
                textBoxFiltroNFisico.Visible = true;
                textBoxFiltroNLogico.Visible = true;
                textBoxFiltroPlc.Visible = true;
            }
        }
        
        // Elegir agrupación
        private void comboBoxAgrupaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Añadir señales a la vista previa
        private void buttonAñadirSeñal_Click(object sender, EventArgs e)
        {
            if (!listaSeñalesController.comprobacionRangosGridPlantillas(gridPlantillas))
            {
                listaSeñalesController.añadirSeñal(comboBoxExplotaciones, comboBoxSitAquacis, comboBoxEstaciones, comboBoxAgrupaciones,
                comboBoxNumeroAgrupacion, gridPlantillas, gridCrearSeñales);
            }
            else
            {
                MessageBox.Show("Revise los límites de EngUnits y Raw de la instancia a crear.");
            }
 
        }
        // Crear lista señales
        private void buttonGuardarLista_Click(object sender, EventArgs e)
        {
            listaSeñalesController.createListaSeñales(listaSeñales,  gridCrearSeñales);      
            if (esDatalogger)
            {
                listaSeñalesController.findSeñalesCreadasByNombreDatalogger(comboBoxEstaciones, gridSeñalesCreadas);
            }
            else
            {
                listaSeñalesController.findSeñalesCreadasByNombreEstacion(comboBoxEstaciones, gridSeñalesCreadas);
            }
            
        }

        // Limpiar lista de señales
        private void buttonLimpiarLista_Click(object sender, EventArgs e)
        {
            gridCrearSeñales.Rows.Clear();
            listaSeñales.Clear();
        }
        #endregion

        #region Visualizar listas de señales
        private void linkLabelAnalogicas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridSeñales.Visible = true;
            if (esDatalogger)
            {
                listaSeñalesController.findSeñalesAnalogicasByNombreDatalogger(comboBoxEstaciones, gridSeñales);
            }
            else
            {
                listaSeñalesController.findSeñalesAnalogicasByNombreEstacion(comboBoxEstaciones, gridSeñales);
            }
             
            textBoxFiltroPreviewCodigo.Visible = true;
            textBoxFiltroPreviewNFisico.Visible = true;
            textBoxFiltroPreviewDescripcion.Visible = true;
            textBoxFiltroPreviewNLogico.Visible = true;
            textBoxFiltroPreviewDireccionPlc.Visible = true;
            labelFiltroPreviewCodigo.Visible = true;
            labelFiltroPreviewDescripcion.Visible = true;
            labelFiltroPreviewNFisico.Visible = true;
            labelFiltroPreviewNLogico.Visible = true;
            labelFiltroPreviewPlc.Visible = true;
            textBoxFiltroPreviewCodigo.Clear();
            textBoxFiltroPreviewNFisico.Clear();
            textBoxFiltroPreviewDescripcion.Clear();
            textBoxFiltroPreviewNLogico.Clear();
            textBoxFiltroPreviewDireccionPlc.Clear();
        }

        private void linkLabelDigitales_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridSeñales.Visible = true;
            if (esDatalogger)
            {
                listaSeñalesController.findDigitalesByNombreDatalogger(comboBoxEstaciones, gridSeñales);
            }
            else
            {
                listaSeñalesController.findDigitalesByNombreEstacion(comboBoxEstaciones, gridSeñales);
            }
                       
            textBoxFiltroPreviewCodigo.Visible = true;
            textBoxFiltroPreviewNFisico.Visible = true;
            textBoxFiltroPreviewDescripcion.Visible = true;
            textBoxFiltroPreviewNLogico.Visible = true;
            textBoxFiltroPreviewDireccionPlc.Visible = true;
            labelFiltroPreviewCodigo.Visible = true;
            labelFiltroPreviewDescripcion.Visible = true;
            labelFiltroPreviewNFisico.Visible = true;
            labelFiltroPreviewNLogico.Visible = true;
            labelFiltroPreviewPlc.Visible = true;
            textBoxFiltroPreviewCodigo.Clear();
            textBoxFiltroPreviewNFisico.Clear();
            textBoxFiltroPreviewDescripcion.Clear();
            textBoxFiltroPreviewNLogico.Clear();
            textBoxFiltroPreviewDireccionPlc.Clear();
        }

        private void linkLabelContadores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridSeñales.Visible = true;
            if (esDatalogger)
            {
                listaSeñalesController.findContadoresByNombreDatalogger(comboBoxEstaciones, gridSeñales);
            }
            else
            {
                listaSeñalesController.findContadoresByNombreEstacion(comboBoxEstaciones, gridSeñales);
            }
             
            textBoxFiltroPreviewCodigo.Visible = true;
            textBoxFiltroPreviewNFisico.Visible = true;
            textBoxFiltroPreviewDescripcion.Visible = true;
            textBoxFiltroPreviewNLogico.Visible = true;
            textBoxFiltroPreviewDireccionPlc.Visible = true;
            labelFiltroPreviewCodigo.Visible = true;
            labelFiltroPreviewDescripcion.Visible = true;
            labelFiltroPreviewNFisico.Visible = true;
            labelFiltroPreviewNLogico.Visible = true;
            labelFiltroPreviewPlc.Visible = true;
            textBoxFiltroPreviewCodigo.Clear();
            textBoxFiltroPreviewNFisico.Clear();
            textBoxFiltroPreviewDescripcion.Clear();
            textBoxFiltroPreviewNLogico.Clear();
            textBoxFiltroPreviewDireccionPlc.Clear();
        }

        private void linkLabelTelemandos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridSeñales.Visible = true;
            if (esDatalogger)
            {
                listaSeñalesController.findTelemandosByNombreDatalogger(comboBoxEstaciones, gridSeñales);
            }
            else
            {
                listaSeñalesController.findTelemandosByNombreEstacion(comboBoxEstaciones, gridSeñales);
            }
              
            textBoxFiltroPreviewCodigo.Visible = true;
            textBoxFiltroPreviewNFisico.Visible = true;
            textBoxFiltroPreviewDescripcion.Visible = true;
            textBoxFiltroPreviewNLogico.Visible = true;
            textBoxFiltroPreviewDireccionPlc.Visible = true;
            labelFiltroPreviewCodigo.Visible = true;
            labelFiltroPreviewDescripcion.Visible = true;
            labelFiltroPreviewNFisico.Visible = true;
            labelFiltroPreviewNLogico.Visible = true;
            labelFiltroPreviewPlc.Visible = true;
            textBoxFiltroPreviewCodigo.Clear();
            textBoxFiltroPreviewNFisico.Clear();
            textBoxFiltroPreviewDescripcion.Clear();
            textBoxFiltroPreviewNLogico.Clear();
            textBoxFiltroPreviewDireccionPlc.Clear();
        }

        private void linkLabelConsignas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            gridSeñales.Visible = true;
            if (esDatalogger)
            {
                listaSeñalesController.findConsignasByNombreDatalogger(comboBoxEstaciones, gridSeñales);
            }
            else
            {
                listaSeñalesController.findConsignasByNombreEstacion(comboBoxEstaciones, gridSeñales);
            }
              
            textBoxFiltroPreviewCodigo.Visible = true;
            textBoxFiltroPreviewNFisico.Visible = true;
            textBoxFiltroPreviewDescripcion.Visible = true;
            textBoxFiltroPreviewNLogico.Visible = true;
            textBoxFiltroPreviewDireccionPlc.Visible = true;
            labelFiltroPreviewCodigo.Visible = true;
            labelFiltroPreviewDescripcion.Visible = true;
            labelFiltroPreviewNFisico.Visible = true;
            labelFiltroPreviewNLogico.Visible = true;
            labelFiltroPreviewPlc.Visible = true;
            textBoxFiltroPreviewCodigo.Clear();
            textBoxFiltroPreviewNFisico.Clear();
            textBoxFiltroPreviewDescripcion.Clear();
            textBoxFiltroPreviewNLogico.Clear();
            textBoxFiltroPreviewDireccionPlc.Clear();
        }
        #endregion

        #region Logout
        private void logoutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            labelNumeroDatalogger.Visible = false;
            labelEditarBorrarDatalogger.Visible = false;
            buttonCrearDataloggerInsert.Visible = false;
            buttonEditarDatalogger.Visible = false;
            buttonBorrarDatalogger.Visible = false;
            comboBoxNombreDatalogger.Visible = false;
            textBoxNombreDatalogger.Clear();
            textBoxNumeroPunto.Clear();
            textBoxNumeroDatalogger.Clear();
            textBoxNumeroAgrupacion.Clear();
            textBoxIP.Clear();
            textBoxPuerto.Clear();
            comboBoxTipoDl.SelectedIndex = 0;
            textBoxHorasComunicacion.Clear();
            textBoxZonaSectorizacion.Clear();
            textBoxNombreDatalogger.Visible = false;
            labelNombreDatalogger.Visible = false;
            labelNumeroAgrupacionDl.Visible = false;
            textBoxNumeroAgrupacion.Visible = false;
            textBoxNumeroDatalogger.Visible = false;
            labelNumeroPunto.Visible = false;
            textBoxNumeroPunto.Visible = false;
            comboBoxTipoDl.Visible = false;
            labelTipoDl.Visible = false;
            labelHorasComunicacion.Visible = false;
            labelZonaSectorizacion.Visible = false;
            textBoxZonaSectorizacion.Visible = false;
            textBoxHorasComunicacion.Visible = false;
            textBoxIP.Visible = false;
            textBoxPuerto.Visible = false;
            labelPuerto.Visible = false;
            labelIP.Visible = false;
            buttonCrearDataloggerInsert.Visible = false;
            labelCrearDatalogger.Visible = false;
            labelNumeroEsclavo.Visible = false;
            textBoxNumeroEsclavo.Visible = false;
            comboBoxAtributo.Visible = false;
            labelAtributo.Visible = false;
            gridAtributo.Visible = false;
            buttonCrearAtributo.Visible = false;
            labelInstancia.Visible = false;
            labelAñadirAtributo.Visible = false;
            labelDCDC.Visible = false;
            pictureBoxPdf.Visible = false;
            textBoxFiltroPreviewCodigo.Visible = false;
            textBoxFiltroPreviewNFisico.Visible = false;
            textBoxFiltroPreviewDescripcion.Visible = false;
            textBoxFiltroPreviewNLogico.Visible = false;
            textBoxFiltroPreviewDireccionPlc.Visible = false;
            labelFiltroPreviewCodigo.Visible = false;
            labelFiltroPreviewDescripcion.Visible = false;
            labelFiltroPreviewNFisico.Visible = false;
            labelFiltroPreviewNLogico.Visible = false;
            labelFiltroPreviewPlc.Visible = false;
            textBoxFiltroPreviewCodigo.Clear();
            textBoxFiltroPreviewNFisico.Clear();
            textBoxFiltroPreviewDescripcion.Clear();
            textBoxFiltroPreviewNLogico.Clear();
            textBoxFiltroPreviewDireccionPlc.Clear();
            comboBoxNumeroAgrupacion.SelectedIndex = 0;
            textBoxFiltroNFisico.Clear();
            textBoxFiltroCodigo.Clear();
            textBoxFiltroNLogico.Clear();
            textBoxFiltroPlc.Clear();
            labelFiltroCodigo.Visible = false;
            labelFiltroNFisico.Visible = false;
            labelFiltroNLogico.Visible = false;
            labelFiltroPlc.Visible = false;
            textBoxFiltroCodigo.Visible = false;
            textBoxFiltroNFisico.Visible = false;
            textBoxFiltroNLogico.Visible = false;
            textBoxFiltroPlc.Visible = false;
            labelEditarEstacion.Visible = false;
            buttonAtras.Visible = false;
            buttonBorrarEstacion.Visible = false;
            buttonEditarEstacion.Visible = false;
            labelExportarExcel.Visible = false;
            gridExcel.Visible = false;
            buttonExportarExcel.Visible = false;
            gridSeñalesCreadas.Visible = false;
            inicioLinkLabel.Visible = false;
            labelGridSeñalesCreadas.Visible = false;
            logoutLinkLabel.Visible = false;
            panelInteraccion.Visible = false;
            panelMenuPrincipal.Visible = false;
            textBoxNumeroEstacion.Clear();
            textBoxCebeIas.Clear();
            textBoxCrearEstacion.Clear();
            textBoxMaxRaw.Clear();
            textBoxMinRaw.Clear();
            usuarioTextBox.Clear();
            passwordTextBox.Clear();
            labelCrearExplotacion.Visible = false;
            panelLogin.Visible = true;
            buttonGuardarLista.Visible = false;
            buttonAñadirSeñal.Visible = false;
            gridCrearSeñales.Visible = false;
            gridPlantillas.Visible = false;
            labelCrearEstacion.Visible = false;
            gridSeñales.Visible = false;
            comboBoxEstaciones.Visible = false;
            estacionListaLabel.Visible = false;
            agrupacionListaLabel.Visible = false;
            plantillaListaLabel.Visible = false;
            comboBoxPlantillas.Visible = false;
            labelVisualizarListas.Visible = false;
            comboBoxAgrupaciones.Visible = false;
            comboBoxNumeroAgrupacion.Visible = false;
            labelNumeroAgrupacion.Visible = false;
            labelSitAquacis.Visible = false;
            pictureBoxExcel.Visible = false;
            comboBoxSitAquacis.Visible = false;
            labelCebeIas.Visible = false;
            textBoxCebeIas.Visible = false;
            buttonCrearExplotacion.Visible = false;
            textBoxCrearEstacion.Visible = false;
            buttonCrearEstacion.Visible = false;
            labelNumeroEstacion.Visible = false;
            textBoxNumeroEstacion.Visible = false;
            textBoxCebeAquacis.Visible = false;
            labelCebeAquacis.Visible = false;
            textBoxMaxRaw.Visible = false;
            textBoxMinRaw.Visible = false;
            labelMaxRaw.Visible = false;
            labelMinRaw.Visible = false;
            labelComunicacion.Visible = false;
            comboBoxComunicaciones.Visible = false;
            linkLabelAnalogicas.Visible = false;
            linkLabelConsignas.Visible = false;
            linkLabelContadores.Visible = false;
            linkLabelDigitales.Visible = false;
            buttonLimpiarLista.Visible = false;
            linkLabelTelemandos.Visible = false;
            labelCrearListas.Visible = false;
        }
        #endregion

        #region Diseños Grids
        // Diseño del grid que muestra las plantillas
        private void diseñoGridPlantillas()
        {
            try
            {
                DataGridViewColumn textBoxColumn = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                // Columna Nombre Plantilla
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "sNombrePlantilla";
                textBoxColumn.Name = "Nombre Plantilla";
                textBoxColumn.HeaderText = "Nombre Plantilla";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = true;
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Número Elementos
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Elementos";
                textBoxColumn.HeaderText = "Número Elementos";
                textBoxColumn.ReadOnly = false;
                textBoxColumn.Visible = true;
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Atributos
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "sNombreAtributo";
                textBoxColumn.Name = "Atributo";
                textBoxColumn.HeaderText = "Atributo";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = true;
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Invertida para digitales
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                //textBoxColumn.CellTemplate = new DataGridViewCheckBoxCell();
                checkBoxColumn.Name = "Invertida";
                checkBoxColumn.HeaderText = "Invertida";
                checkBoxColumn.Visible = true;
                checkBoxColumn.ReadOnly = false; // Añadir Direct o Reverse a digitales
                gridPlantillas.Columns.Add(checkBoxColumn);
                // Columna Descripción Atributo
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "sDescripcion";
                textBoxColumn.Name = "Descripción";
                textBoxColumn.HeaderText = "Descripción";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar descripción
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Característica Elemento
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Característica Elemento";
                textBoxColumn.HeaderText = "Carac. Elemento";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar descripción
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna OffMsg
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "OffMsg";
                textBoxColumn.HeaderText = "OffMsg";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Añadir off msg
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna OnMsg
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "OnMsg";
                textBoxColumn.HeaderText = "OnMsg";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Añadir on msg
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Número Lógico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Número Lógico";
                textBoxColumn.HeaderText = "Nº Lóg.";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Añadir número lógico
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Número Físico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Número Físico";
                textBoxColumn.HeaderText = "Nº Fís.";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Añadir número físico
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Dirección PLC
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Dirección PLC";
                textBoxColumn.HeaderText = "Dirección PLC";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Añadir Dirección PLC
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Criterio Archivo Lacbus
                checkBoxColumn = new DataGridViewCheckBoxColumn();
                //textBoxColumn.CellTemplate = new DataGridViewCheckBoxCell();
                checkBoxColumn.Name = "Criterio Archivo";
                checkBoxColumn.HeaderText = "Criterio Archivo";
                checkBoxColumn.Visible = false;
                checkBoxColumn.ReadOnly = false; // Check si comunica por Lacbus y se quiere Histórico cuando no comuncia
                gridPlantillas.Columns.Add(checkBoxColumn);             
                // Columna VAR_0
                checkBoxColumn = new DataGridViewCheckBoxColumn();
                //textBoxColumn.CellTemplate = new DataGridViewCheckBoxCell();
                checkBoxColumn.Name = "VAR_0";
                checkBoxColumn.HeaderText = "VAR_0";
                checkBoxColumn.Visible = true;
                checkBoxColumn.ReadOnly = false; // Check si apunta a VAR_0
                gridPlantillas.Columns.Add(checkBoxColumn);
                // Columna MinEU
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "nMinCuentas";
                textBoxColumn.Name = "MinEU";
                textBoxColumn.HeaderText = "MinEU";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar límite inferior EngUnits
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna MaxEU
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "nMaxCuentas";
                textBoxColumn.Name = "MaxEU";
                textBoxColumn.HeaderText = "MaxEU";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar límite superior EngUnits
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna MinRaw
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "nMinRango";
                textBoxColumn.Name = "MinRaw";
                textBoxColumn.HeaderText = "MinRaw";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar límite inferior Raw
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna MaxRaw
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "nMaxRango";
                textBoxColumn.Name = "MaxRaw";
                textBoxColumn.HeaderText = "MaxRaw";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar límite inferior Raw
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Unidad
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "sUnidad";
                textBoxColumn.Name = "Unidad";
                textBoxColumn.HeaderText = "Unidad";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar unidad si procede
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Histórico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "sHistorico";
                textBoxColumn.Name = "Histórico";
                textBoxColumn.HeaderText = "Histórico";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Alarma
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "sAlarma";
                textBoxColumn.Name = "Alarma";
                textBoxColumn.HeaderText = "Alarma";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Protocolo Comunicación que no se muestra
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Protocolo Comunicación";
                textBoxColumn.HeaderText = "Protocolo Comunicación";
                textBoxColumn.Visible = false;
                textBoxColumn.ReadOnly = true;
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Identificador atributo
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Identificador";
                textBoxColumn.HeaderText = "Identificador";
                textBoxColumn.Visible = false;
                textBoxColumn.ReadOnly = true;
                gridPlantillas.Columns.Add(textBoxColumn);
                // Columna Atributo Derivado
                /*textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Atributo Derivado";
                textBoxColumn.HeaderText = "Atributo Derivado";
                textBoxColumn.Visible = false;
                textBoxColumn.ReadOnly = true;
                gridPlantillas.Columns.Add(textBoxColumn);*/

                gridPlantillas.AllowUserToAddRows = false;
                gridPlantillas.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                Log.Logger(ex.ToString());
            }
        }
        // Formato de las plantillas
        private void gridPlantillas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.Value != null && e.Value.Equals(""))
            {
                e.CellStyle.BackColor = Color.Gray;
            }
            if (e.ColumnIndex == 1 && e.Value != null && e.Value.Equals(""))
            {
                e.CellStyle.BackColor = Color.Gray;
            }
            if (e.ColumnIndex == 5 && e.Value != null && e.Value.Equals(""))
            {
                e.CellStyle.BackColor = Color.Gray;
            }
            if (e.ColumnIndex == 9)
            {
                DataGridViewTextBoxCell cell = gridPlantillas[2, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell.Value.ToString().Substring(0, 1).Equals("T"))
                {
                    e.CellStyle.BackColor = Color.Gray;
                } 
            }
            if (e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10)
            {
                DataGridViewTextBoxCell cell = gridPlantillas[2, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell.Value.ToString().Equals("A_EAAY") || cell.Value.ToString().Equals("A_EAHO"))
                {
                    e.CellStyle.BackColor = Color.Gray;
                }
            }
                if (e.ColumnIndex == 13 || e.ColumnIndex == 14 || e.ColumnIndex == 15 || e.ColumnIndex == 16)
            {
                DataGridViewTextBoxCell cell = gridPlantillas[2, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell.Value.ToString().Substring(0, 1).Equals("E") || cell.Value.ToString().Substring(0, 1).Equals("T"))
                {
                    e.CellStyle.BackColor = Color.Gray;
                }
            }
            /*if (e.ColumnIndex == 2)
            {
                DataGridViewTextBoxCell cell = gridPlantillas[19, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell.Value != null && cell.Value.ToString().Equals("True"))
                {
                    e.CellStyle.BackColor = Color.Coral;
                }
            }*/

        }
        // Validación si se pone un número entero en las celdas de número de elementos, nº lógico o nº físico
        private void gridPlantillas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 8 || e.ColumnIndex == 9 ||
                e.ColumnIndex == 15 || e.ColumnIndex == 16 || e.ColumnIndex == 13 || e.ColumnIndex == 14)
            {
                //DataGridViewTextBoxCell cell = gridPlantillas[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
                if (e.FormattedValue != null && !e.FormattedValue.ToString().Equals("") && inicializarCellValidating)
                {
                    /*char[] chars = e.FormattedValue.ToString().ToCharArray();
                    foreach (char c in chars)
                    {
                        if (!c.Equals(',') && !c.Equals('.'))
                        {
                            if (char.IsDigit(c) == false)
                            {
                                MessageBox.Show("Tienes que insertar un número." + c.ToString());

                                e.Cancel = true;
                                break;
                            }
                        }                   
                    }*/
                    String num = e.FormattedValue.ToString().Replace(",", ".");
                    try
                    {
                        Decimal.Parse(num);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tienes que insertar un número.");
                        e.Cancel = true;
                        Log.Logger(ex.ToString());

                    }

                }
            }
            else if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                if (e.FormattedValue != null && !e.FormattedValue.ToString().Equals("") && inicializarCellValidating)
                {
                    String descripcion = e.FormattedValue.ToString();
                    if (descripcion.Substring(descripcion.Length - 1, 1).Equals(" "))
                    {
                        MessageBox.Show("No deje un espacio al final de la descripción.");
                        e.Cancel = true;
                    }
                    else if (descripcion.Substring(0, 1).Equals(" "))
                    {
                        MessageBox.Show("No deje un espacio al principio de la descripción.");
                        e.Cancel = true;
                    }
                }
            }
        }

        // Autorellenar P si se rellena el número lógico de una C
        private void gridPlantillas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                DataGridViewTextBoxCell cell = gridPlantillas[2, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell.Value.ToString().Substring(0, 1).Equals("C"))
                {
                    String identificadorC = gridPlantillas.Rows[e.RowIndex].Cells["Identificador"].Value.ToString();
                    String identificadorP = identificadorC.Replace("C_", "P_");
                    for (int i = 0; i < gridPlantillas.Rows.Count; i++)
                    {
                        if (gridPlantillas.Rows[i].Cells["Identificador"].Value.ToString().Equals(identificadorP))
                        {
                            gridPlantillas.Rows[i].Cells["Número Lógico"].Value = gridPlantillas.Rows[e.RowIndex].Cells["Número Lógico"].Value;
                            break;
                        }
                    }
                }
            }
        }

        // Separador entre plantillas en el grid
        private void gridPlantillas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex != this.gridPlantillas.Rows.Count - 1)
            {
                DataGridViewRow thisRow = this.gridPlantillas.Rows[e.RowIndex];
                DataGridViewRow nextRow = this.gridPlantillas.Rows[e.RowIndex + 1];

                if (thisRow.Cells[0].FormattedValue.ToString() != nextRow.Cells[0].FormattedValue.ToString() && nextRow.Cells[1].FormattedValue.ToString() != "")
                {
                    e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

                    Rectangle divider = new Rectangle(e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height - 2, e.CellBounds.Width, 2);
                    e.Graphics.FillRectangle(Brushes.Black, divider);

                    e.Handled = true;
                }
            }
        }

        // Diseño del grid que muestra las señales creadas por si se quiere recordar
        private void diseñoGridSeñalesCreadas()
        {
            try
            {
                DataGridViewColumn textBoxColumn = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                // Columna Dirección PLC
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "direccionPlc";
                textBoxColumn.Name = "Dirección PLC";
                textBoxColumn.HeaderText = "Direc. PLC";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñalesCreadas.Columns.Add(textBoxColumn);
                // Columna Número Lógico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "numeroLogico";
                textBoxColumn.Name = "Número Lógico";
                textBoxColumn.HeaderText = "Nº Lóg.";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñalesCreadas.Columns.Add(textBoxColumn);
                // Columna Número Físico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "numeroFisico";
                textBoxColumn.Name = "Número Físico";
                textBoxColumn.HeaderText = "Nº Fís.";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñalesCreadas.Columns.Add(textBoxColumn);
                // Columna Criterio Archivo Lacbus
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                //textBoxColumn.CellTemplate = new DataGridViewCheckBoxCell();
                checkBoxColumn.DataPropertyName = "criterioArchivo";
                checkBoxColumn.Name = "Criterio Archivo";
                checkBoxColumn.HeaderText = "Criterio Archivo";
                checkBoxColumn.Visible = false;
                checkBoxColumn.ReadOnly = false; // Check si comunica por Lacbus y se quiere Histórico cuando no comuncia
                gridSeñalesCreadas.Columns.Add(checkBoxColumn);
                // Columna Código Señal
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "codigo";
                textBoxColumn.Name = "Código Señal";
                textBoxColumn.HeaderText = "Código Señal";
                textBoxColumn.ReadOnly = true;
                textBoxColumn.Visible = true;
                gridSeñalesCreadas.Columns.Add(textBoxColumn);
                // Columna Protocolo Comunicación que no se muestra
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Protocolo Comunicación";
                textBoxColumn.HeaderText = "Protocolo Comunicación";
                textBoxColumn.Visible = false;
                textBoxColumn.ReadOnly = true;
                gridSeñalesCreadas.Columns.Add(textBoxColumn);

                gridSeñalesCreadas.AllowUserToAddRows = false;
                gridSeñalesCreadas.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                Log.Logger(ex.ToString());
            }
        }
        // Diseño del grid que muestra las señales que se van a crear
        private void diseñoGridCrearSeñales()
        {
            try
            {
                DataGridViewColumn textBoxColumn = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                // Columna Dirección PLC
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "direccionPlc";
                textBoxColumn.Name = "Dirección PLC";
                textBoxColumn.HeaderText = "Direc. PLC";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridCrearSeñales.Columns.Add(textBoxColumn);
                // Columna Número Lógico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "numeroLogico";
                textBoxColumn.Name = "Número Lógico";
                textBoxColumn.HeaderText = "Nº Lóg.";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridCrearSeñales.Columns.Add(textBoxColumn);
                // Columna Número Físico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "numeroFisico";
                textBoxColumn.Name = "Número Físico";
                textBoxColumn.HeaderText = "Nº Fís.";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridCrearSeñales.Columns.Add(textBoxColumn);
                // Columna Criterio Archivo Lacbus
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                //textBoxColumn.CellTemplate = new DataGridViewCheckBoxCell();
                checkBoxColumn.Name = "Criterio Archivo";
                checkBoxColumn.HeaderText = "Criterio Archivo";
                checkBoxColumn.Visible = false;
                checkBoxColumn.ReadOnly = false; // Check si comunica por Lacbus y se quiere Histórico cuando no comuncia
                gridCrearSeñales.Columns.Add(checkBoxColumn);
                // Columna Código Señal
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "codigo";
                textBoxColumn.Name = "Código Señal";
                textBoxColumn.HeaderText = "Código Señal";
                textBoxColumn.ReadOnly = true;
                textBoxColumn.Visible = true;
                gridCrearSeñales.Columns.Add(textBoxColumn);
                // Columna Protocolo Comunicación que no se muestra
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Protocolo Comunicación";
                textBoxColumn.HeaderText = "Protocolo Comunicación";
                textBoxColumn.Visible = false;
                textBoxColumn.ReadOnly = true;
                gridCrearSeñales.Columns.Add(textBoxColumn);

                gridCrearSeñales.AllowUserToAddRows = false;
                gridCrearSeñales.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                Log.Logger(ex.ToString());
            }
        }

        // Formatting para direcciones de PLC autogeneradas
        private void gridSeñales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewTextBoxCell cell = gridSeñales[17, e.RowIndex] as DataGridViewTextBoxCell;
                if (cell.Value.ToString().Equals("True"))
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
            }
        }

        // Diseño del grid que muestra las señales
        private void diseñoGridSeñales()
        {
            try
            {
                DataGridViewColumn textBoxColumn = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                // Columna Dirección PLC
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "direccionPlc";
                textBoxColumn.Name = "Dirección PLC";
                textBoxColumn.HeaderText = "Dirección PLC";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna Número Lógico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "numeroLogico";
                textBoxColumn.Name = "Número Lógico";
                textBoxColumn.HeaderText = "Nº Lóg.";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna Número Físico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "numeroFisico";
                textBoxColumn.Name = "Número Físico";
                textBoxColumn.HeaderText = "Nº Fís.";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna Criterio Archivo Lacbus
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                //textBoxColumn.CellTemplate = new DataGridViewCheckBoxCell();
                checkBoxColumn.DataPropertyName = "criterioArchivo";
                checkBoxColumn.Name = "Criterio Archivo";
                checkBoxColumn.HeaderText = "Criterio Archivo";
                checkBoxColumn.Visible = false;
                checkBoxColumn.ReadOnly = false; // Check si comunica por Lacbus y se quiere Histórico cuando no comuncia
                gridSeñales.Columns.Add(checkBoxColumn);
                // Columna Descripción de la Señal
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "descripcion";
                textBoxColumn.Name = "Descripción";
                textBoxColumn.HeaderText = "Descripción";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna Tag
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "tag";
                textBoxColumn.Name = "Tag";
                textBoxColumn.HeaderText = "Tag";
                textBoxColumn.ReadOnly = false;
                textBoxColumn.Visible = true;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna OffMsg
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "offMsg";
                textBoxColumn.Name = "OffMsg";
                textBoxColumn.HeaderText = "OffMsg";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna OnMsg
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "onMsg";
                textBoxColumn.Name = "OnMsg";
                textBoxColumn.HeaderText = "OnMsg";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna Invertida
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "invertida";
                textBoxColumn.Name = "Invertida";
                textBoxColumn.HeaderText = "Invertida";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna MinEU
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "minEngUnits";
                textBoxColumn.Name = "MinEU";
                textBoxColumn.HeaderText = "MinEU";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna MaxEU
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "maxEngUnits";
                textBoxColumn.Name = "MaxEU";
                textBoxColumn.HeaderText = "MaxEU";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna MinRaw
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "minRaw";
                textBoxColumn.Name = "MinRaw";
                textBoxColumn.HeaderText = "MinRaw";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna MaxRaw
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "maxRaw";
                textBoxColumn.Name = "MaxRaw";
                textBoxColumn.HeaderText = "MaxRaw";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna Unidad
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "unidad";
                textBoxColumn.Name = "Unidad";
                textBoxColumn.HeaderText = "Unidad";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna Histórico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "historico";
                textBoxColumn.Name = "Histórico";
                textBoxColumn.HeaderText = "Histórico";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna Alarma
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "alarma";
                textBoxColumn.Name = "Alarma";
                textBoxColumn.HeaderText = "Alarma";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna Código Señal
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "codigo";
                textBoxColumn.Name = "Código Señal";
                textBoxColumn.HeaderText = "Código Señal";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = true;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna AutoGen
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "direccionPlcAutoGen";
                textBoxColumn.Name = "Dirección PLC Autogenerada";
                textBoxColumn.HeaderText = "Dirección PLC Autogenerada";
                textBoxColumn.Visible = false;
                textBoxColumn.ReadOnly = true;
                gridSeñales.Columns.Add(textBoxColumn);
                // Columna Protocolo Comunicación que no se muestra
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Protocolo Comunicación";
                textBoxColumn.HeaderText = "Protocolo Comunicación";
                textBoxColumn.Visible = false;
                textBoxColumn.ReadOnly = true;
                gridSeñales.Columns.Add(textBoxColumn);

                gridSeñales.AllowUserToAddRows = false;
                gridSeñales.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                Log.Logger(ex.ToString());
            }
        }

        // Diseño del grid para exportar excel lista señales DCDC
        private void diseñoGridExcel()
        {
            try
            {
                DataGridViewColumn textBoxColumn = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                // Columna ID
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "ID";
                textBoxColumn.HeaderText = "ID";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Utilizada
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Utilizada";
                textBoxColumn.HeaderText = "Utilizada";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Automático
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "codigo";
                textBoxColumn.Name = "Automatico";
                textBoxColumn.HeaderText = "Automatico";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Descartable
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Descartable";
                textBoxColumn.HeaderText = "Descartable";
                textBoxColumn.Visible = true;
                textBoxColumn.DefaultCellStyle.NullValue = "No";
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Revisar
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Revisar";
                textBoxColumn.HeaderText = "Revisar";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna FueraPlantilla
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "FueraPlantilla";
                textBoxColumn.HeaderText = "FueraPlantilla";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna VAR_0
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "VAR_0";
                textBoxColumn.HeaderText = "VAR_0";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Comentarios
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Comentarios";
                textBoxColumn.HeaderText = "Comentarios";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Script
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Script";
                textBoxColumn.HeaderText = "Script";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Estacion
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "idEstacion";
                textBoxColumn.Name = "Estacion";
                textBoxColumn.HeaderText = "Estacion";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Agrupador
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "agrupador";
                textBoxColumn.Name = "Agrupador";
                textBoxColumn.HeaderText = "Agrupador";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Instancia
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "instancia";
                textBoxColumn.Name = "Instancia";
                textBoxColumn.HeaderText = "Instancia";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Atributo
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "atributo";
                textBoxColumn.Name = "Atributo";
                textBoxColumn.HeaderText = "Atributo";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Nombre
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "tag";
                textBoxColumn.Name = "Nombre";
                textBoxColumn.HeaderText = "Nombre";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Tipo
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Tipo";
                textBoxColumn.HeaderText = "Tipo";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Grupo
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Grupo";
                textBoxColumn.HeaderText = "Grupo";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Descripción
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "descripcion";
                textBoxColumn.Name = "Descripcion";
                textBoxColumn.HeaderText = "Descripcion";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna ValorInicial
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "ValorInicial";
                textBoxColumn.HeaderText = "ValorInicial";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna OffMsg
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "offMsg";
                textBoxColumn.Name = "OffMsg";
                textBoxColumn.HeaderText = "OffMsg";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna OnMsg
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "onMsg";
                textBoxColumn.Name = "OnMsg";
                textBoxColumn.HeaderText = "OnMsg";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna AccesName
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "AccessName";
                textBoxColumn.HeaderText = "AccessName";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Dirección PLC
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "direccionPlc";
                textBoxColumn.Name = "DireccionPLC";
                textBoxColumn.HeaderText = "DireccionPLC";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna ReadOnly
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "ReadOnly";
                textBoxColumn.HeaderText = "ReadOnly";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Invertida
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "invertida";
                textBoxColumn.Name = "Invertida";
                textBoxColumn.HeaderText = "Invertida";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna EngUnits
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "unidad";
                textBoxColumn.Name = "EngUnits";
                textBoxColumn.HeaderText = "EngUnits";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna MinValue
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "minEngUnits";
                textBoxColumn.Name = "MinValue";
                textBoxColumn.HeaderText = "MinValue";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna MaxValue
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "maxEngUnits";
                textBoxColumn.Name = "MaxValue";
                textBoxColumn.HeaderText = "MaxValue";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna MinRaw
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "minRaw";
                textBoxColumn.Name = "MinRaw";
                textBoxColumn.HeaderText = "MinRaw";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna MaxRaw
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "maxRaw";
                textBoxColumn.Name = "MaxRaw";
                textBoxColumn.HeaderText = "MaxRaw";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Histórico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "historico";
                textBoxColumn.Name = "Historico";
                textBoxColumn.HeaderText = "Historico";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna HistMax
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "HistMax";
                textBoxColumn.HeaderText = "HistMax";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna HistMin
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "HistMin";
                textBoxColumn.HeaderText = "HistMin";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna Evento
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Evento";
                textBoxColumn.HeaderText = "Evento";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna AlarmState
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "alarma";
                textBoxColumn.Name = "AlarmState";
                textBoxColumn.HeaderText = "AlarmState";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna AlarmPri
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "AlarmPri";
                textBoxColumn.HeaderText = "AlarmPri";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna LoLoAlarmState
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "LoLoAlarmState";
                textBoxColumn.HeaderText = "LoLoAlarmState";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna LoLoAlarmValue
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "LoLoAlarmValue";
                textBoxColumn.HeaderText = "LoLoAlarmValue";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna LoLoAlarmPri
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "LoLoAlarmPri";
                textBoxColumn.HeaderText = "LoLoAlarmPri";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna LoAlarmState
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "LoAlarmState";
                textBoxColumn.HeaderText = "LoAlarmState";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna LoAlarmValue
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "LoAlarmValue";
                textBoxColumn.HeaderText = "LoAlarmValue";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna LoAlarmPri
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "LoAlarmPri";
                textBoxColumn.HeaderText = "LoAlarmPri";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna HiAlarmState
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "HiAlarmState";
                textBoxColumn.HeaderText = "HiAlarmState";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna HiAlarmValue
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "HiAlarmValue";
                textBoxColumn.HeaderText = "HiAlarmValue";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna HiAlarmPri
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "HiAlarmPri";
                textBoxColumn.HeaderText = "HiAlarmPri";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna HiHiAlarmState
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "HiHiAlarmState";
                textBoxColumn.HeaderText = "HiHiAlarmState";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna HiHiAlarmValue
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "HiHiAlarmValue";
                textBoxColumn.HeaderText = "HiHiAlarmValue";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna HiHiAlarmPri
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "HiHiAlarmPri";
                textBoxColumn.HeaderText = "HiHiAlarmPri";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridExcel.Columns.Add(textBoxColumn);
                // Columna VAR_0 BBDD
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.DataPropertyName = "varCero";
                textBoxColumn.Name = "varCero";
                textBoxColumn.HeaderText = "varCero";
                textBoxColumn.Visible = false;
                textBoxColumn.ReadOnly = true;
                gridExcel.Columns.Add(textBoxColumn);

                gridExcel.AllowUserToAddRows = false;
                gridExcel.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                Log.Logger(ex.ToString());
            }
        }

        // Diseño del grid que muestra las plantillas
        private void diseñoGridAtributos()
        {
            try
            {
                DataGridViewColumn textBoxColumn = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                // Columna Descripción Atributo
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Descripción";
                textBoxColumn.HeaderText = "Descripción";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar descripción
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna Invertida para digitales
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                //textBoxColumn.CellTemplate = new DataGridViewCheckBoxCell();
                checkBoxColumn.Name = "Invertida";
                checkBoxColumn.HeaderText = "Invertida";
                checkBoxColumn.Visible = true;
                checkBoxColumn.ReadOnly = false; // Añadir Direct o Reverse a digitales
                gridAtributo.Columns.Add(checkBoxColumn);       
                // Columna OffMsg
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "OffMsg";
                textBoxColumn.HeaderText = "OffMsg";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Añadir off msg
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna OnMsg
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "OnMsg";
                textBoxColumn.HeaderText = "OnMsg";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Añadir on msg
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna Número Lógico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Número Lógico";
                textBoxColumn.HeaderText = "Nº Lóg.";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Añadir número lógico
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna Número Físico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Número Físico";
                textBoxColumn.HeaderText = "Nº Fís.";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Añadir número físico
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna Dirección PLC
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Dirección PLC";
                textBoxColumn.HeaderText = "Dirección PLC";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Añadir Dirección PLC
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna Criterio Archivo Lacbus
                checkBoxColumn = new DataGridViewCheckBoxColumn();
                //textBoxColumn.CellTemplate = new DataGridViewCheckBoxCell();
                checkBoxColumn.Name = "Criterio Archivo";
                checkBoxColumn.HeaderText = "Criterio Archivo";
                checkBoxColumn.Visible = false;
                checkBoxColumn.ReadOnly = false; // Check si comunica por Lacbus y se quiere Histórico cuando no comuncia
                gridAtributo.Columns.Add(checkBoxColumn);
                // Columna MinEU
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "MinEU";
                textBoxColumn.HeaderText = "MinEU";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar límite inferior EngUnits
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna MaxEU
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "MaxEU";
                textBoxColumn.HeaderText = "MaxEU";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar límite superior EngUnits
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna MinRaw
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "MinRaw";
                textBoxColumn.HeaderText = "MinRaw";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar límite inferior Raw
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna MaxRaw
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "MaxRaw";
                textBoxColumn.HeaderText = "MaxRaw";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar límite inferior Raw
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna Unidad
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Unidad";
                textBoxColumn.HeaderText = "Unidad";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false; // Editar unidad si procede
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna Histórico
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Histórico";
                textBoxColumn.HeaderText = "Histórico";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna Alarma
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Alarma";
                textBoxColumn.HeaderText = "Alarma";
                textBoxColumn.Visible = true;
                textBoxColumn.ReadOnly = false;
                gridAtributo.Columns.Add(textBoxColumn);
                // Columna Protocolo Comunicación que no se muestra
                textBoxColumn = new DataGridViewColumn();
                textBoxColumn.CellTemplate = cell;
                textBoxColumn.Name = "Protocolo Comunicación";
                textBoxColumn.HeaderText = "Protocolo Comunicación";
                textBoxColumn.Visible = false;
                textBoxColumn.ReadOnly = true;
                gridAtributo.Columns.Add(textBoxColumn);

                gridAtributo.AllowUserToAddRows = false;
                gridAtributo.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                Log.Logger(ex.ToString());
            }
        }
        #endregion

        #region Exportar Excel
        private void pictureBoxExcel_DoubleClick(object sender, EventArgs e)
        { 
            listaSeñalesController.findSeñalesEstacionExportarExcel(comboBoxEstaciones, gridExcel);
            panelInteraccion.Hide();
            labelVisualizarListas.Visible = false;
            gridExcel.Visible = true;
            labelExportarExcel.Visible = true;  
            buttonAtras.Visible = true;
            gridSeñales.Visible = false;
            buttonExportarExcel.Visible = true;
            textBoxFiltroPreviewCodigo.Visible = false;
            textBoxFiltroPreviewNFisico.Visible = false;
            textBoxFiltroPreviewDescripcion.Visible = false;
            textBoxFiltroPreviewNLogico.Visible = false;
            textBoxFiltroPreviewDireccionPlc.Visible = false;
            labelFiltroPreviewCodigo.Visible = false;
            labelFiltroPreviewDescripcion.Visible = false;
            labelFiltroPreviewNFisico.Visible = false;
            labelFiltroPreviewNLogico.Visible = false;
            labelFiltroPreviewPlc.Visible = false;
            textBoxFiltroPreviewCodigo.Clear();
            textBoxFiltroPreviewNFisico.Clear();
            textBoxFiltroPreviewDescripcion.Clear();
            textBoxFiltroPreviewNLogico.Clear();
            textBoxFiltroPreviewDireccionPlc.Clear();
        }
        private void buttonAtras_Click(object sender, EventArgs e)
        {
            panelInteraccion.Show();
            labelExportarExcel.Visible = false;
            gridExcel.Visible = false;
            buttonAtras.Visible = false;
            buttonExportarExcel.Visible = false;
            labelVisualizarListas.Visible = true;
        }
        private void buttonExportarExcel_Click(object sender, EventArgs e)
        {
            Excel.extraerExcel(gridExcel);
        }
        #endregion

        #region Update/Delete
        private void cmMenuGridSeñalesCreadas_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            /*if(e.ClickedItem != null && e.ClickedItem.Tag.Equals("editar"))
            {
                String atributo = gridSeñalesCreadas.CurrentRow.Cells["Código Señal"].Value.ToString();
                DialogResult dialogo = MessageBox.Show("¿Desea editar el atributo " + atributo + "? Debe ELIMINAR la Dirección de PLC si quiere que se autogenere.", "Editar atributo de BBDD", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogo == DialogResult.OK)
                {
                    listaSeñalesController.updateAtributoInstanciaCreada(gridSeñalesCreadas, gridSeñalesCreadas.CurrentRow.Index);
                    listaSeñalesController.findSeñalesCreadasByNombreEstacion(comboBoxEstaciones, gridSeñalesCreadas);
                }
            }
            else*/ if (e.ClickedItem != null && e.ClickedItem.Tag.Equals("borrar"))
            {
                String instancia = gridSeñalesCreadas.CurrentRow.Cells["Código Señal"].Value.ToString().Substring(0, 23);
                DialogResult dialogo = MessageBox.Show("¿Desea borrar la instancia " + instancia + "?", "Borrar instancia de BBDD", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogo == DialogResult.OK)
                {
                    listaSeñalesController.deleteInstanciaCreada(instancia);
                    if (esDatalogger)
                    {
                        listaSeñalesController.findSeñalesCreadasByNombreDatalogger(comboBoxEstaciones, gridSeñalesCreadas);
                    }
                    else
                    {
                        listaSeñalesController.findSeñalesCreadasByNombreEstacion(comboBoxEstaciones, gridSeñalesCreadas);
                    }
                    
                }
            }
        }

        private void cmMenuGridCrearSeñales_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            /*if (e.ClickedItem != null && e.ClickedItem.Tag.Equals("editar"))
            {
                String atributo = gridCrearSeñales.CurrentRow.Cells["Código Señal"].Value.ToString();
                DialogResult dialogo = MessageBox.Show("¿Desea editar el atributo " + atributo + "? Debe ELIMINAR la Dirección de PLC si quiere que se autogenere.", "Editar atributo de la lista a crear", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogo == DialogResult.OK)
                {
                    listaSeñalesController.updateAtributoInstanciaACrear(gridCrearSeñales, gridCrearSeñales.CurrentRow.Index);
                }
            }
            else*/ if (e.ClickedItem != null && e.ClickedItem.Tag.Equals("borrar"))
            {
                String atributo = gridCrearSeñales.CurrentRow.Cells["Código Señal"].Value.ToString();
                DialogResult dialogo = MessageBox.Show("¿Desea borrar el atributo " + atributo + "?", "Borrar atributo de la lista a crear", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogo == DialogResult.OK)
                {
                    listaSeñales.Remove(atributo);
                    gridCrearSeñales.Rows.RemoveAt(gridCrearSeñales.CurrentRow.Index);
                }
            }
        }

        private void cmMenuPreviewListas_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            /*if (e.ClickedItem != null && e.ClickedItem.Tag.Equals("editar"))
            {
                String atributo = gridSeñales.CurrentRow.Cells["Código Señal"].Value.ToString();
                DialogResult dialogo = MessageBox.Show("¿Desea editar el atributo " + atributo + "? Debe ELIMINAR la Dirección de PLC si quiere que se autogenere.", "Editar atributo de BBDD", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogo == DialogResult.OK)
                {
                    listaSeñalesController.updateAtributoInstanciaPreview(gridSeñales, gridSeñales.CurrentRow.Index);
                }
            }
            else*/ if (e.ClickedItem != null && e.ClickedItem.Tag.Equals("borrar"))
            {
                String instancia = gridSeñales.CurrentRow.Cells["Código Señal"].Value.ToString().Substring(0, 23);
                DialogResult dialogo = MessageBox.Show("¿Desea borrar la instancia " + instancia + "?", "Borrar instancia de BBDD", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogo == DialogResult.OK)
                {
                    listaSeñalesController.deleteInstanciaCreada(instancia);
                }
            }
        }
        private void gridSeñales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            listaSeñalesController.updateAtributoInstanciaPreview(gridSeñales, gridSeñales.CurrentRow.Index);
        }

        private void gridSeñalesCreadas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            listaSeñalesController.updateAtributoInstanciaCreada(gridSeñalesCreadas, gridSeñalesCreadas.CurrentRow.Index);
            listaSeñalesController.findSeñalesCreadasByNombreEstacion(comboBoxEstaciones, gridSeñalesCreadas);
        }

        private void gridCrearSeñales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            listaSeñalesController.updateAtributoInstanciaACrear(gridCrearSeñales, gridCrearSeñales.CurrentRow.Index);
        }
        #endregion

        #region Filtros
        // Filtro codigo señal creada
        private void textBoxFiltroCodigo_TextChanged(object sender, EventArgs e)
        {
            filtroGridSeñalesCreadas();
        }
        // Filtro dirección plc señal creada
        private void textBoxFiltroPlc_TextChanged(object sender, EventArgs e)
        {
            filtroGridSeñalesCreadas();
        }
        // Filtro número lógico
        private void textBoxFiltroNLogico_TextChanged(object sender, EventArgs e)
        {
            filtroGridSeñalesCreadas();      
        }
        // Filtro número físico
        private void textBoxFiltroNFisico_TextChanged(object sender, EventArgs e)
        {
            filtroGridSeñalesCreadas();
        }
        // Filtro del grid de señales creadas
        private void filtroGridSeñalesCreadas()
        {
            String filtro = "";
            if (!String.IsNullOrEmpty(textBoxFiltroNLogico.Text))
            {
                filtro += "numeroLogico = " + textBoxFiltroNLogico.Text + "";
            }
            if (!String.IsNullOrEmpty(textBoxFiltroCodigo.Text))
            {
                if (filtro.Equals(""))
                {
                    filtro += "codigo LIKE '%" + textBoxFiltroCodigo.Text + "%'";
                }
                else
                {
                    filtro += " AND codigo LIKE '%" + textBoxFiltroCodigo.Text + "%'";
                }
            }
            if (!String.IsNullOrEmpty(textBoxFiltroNFisico.Text))
            {
                if (filtro.Equals(""))
                {
                    filtro += "numeroFisico = " + textBoxFiltroNFisico.Text + "";
                }
                else
                {
                    filtro += " AND numeroFisico = " + textBoxFiltroNFisico.Text + "";
                }
            }
            if (!String.IsNullOrEmpty(textBoxFiltroPlc.Text))
            {
                if (filtro.Equals(""))
                {
                    filtro += "direccionPlc LIKE '%" + textBoxFiltroPlc.Text + "%'";
                }
                else
                {
                    filtro += " AND direccionPlc LIKE '%" + textBoxFiltroPlc.Text + "%'";
                }
            }
            (gridSeñalesCreadas.DataSource as DataTable).DefaultView.RowFilter = filtro;
        }

        // Filtro del grid de visualización de señales
        private void filtroGridSeñales()
        {
            String filtro = "";
            if (!String.IsNullOrEmpty(textBoxFiltroPreviewNLogico.Text))
            {
                filtro += "numeroLogico = " + textBoxFiltroPreviewNLogico.Text + "";
            }
            if (!String.IsNullOrEmpty(textBoxFiltroPreviewCodigo.Text))
            {
                if (filtro.Equals(""))
                {
                    filtro += "codigo LIKE '%" + textBoxFiltroPreviewCodigo.Text + "%'";
                }
                else
                {
                    filtro += " AND codigo LIKE '%" + textBoxFiltroPreviewCodigo.Text + "%'";
                }
            }
            if (!String.IsNullOrEmpty(textBoxFiltroPreviewNFisico.Text))
            {
                if (filtro.Equals(""))
                {
                    filtro += "numeroFisico = " + textBoxFiltroPreviewNFisico.Text + "";
                }
                else
                {
                    filtro += " AND numeroFisico = " + textBoxFiltroPreviewNFisico.Text + "";
                }
            }
            if (!String.IsNullOrEmpty(textBoxFiltroPreviewDireccionPlc.Text))
            {
                if (filtro.Equals(""))
                {
                    filtro += "direccionPlc LIKE '%" + textBoxFiltroPreviewDireccionPlc.Text + "%'";
                }
                else
                {
                    filtro += " AND direccionPlc LIKE '%" + textBoxFiltroPreviewDireccionPlc.Text + "%'";
                }
            }
            if (!String.IsNullOrEmpty(textBoxFiltroPreviewDescripcion.Text))
            {
                if (filtro.Equals(""))
                {
                    filtro += "descripcion LIKE '%" + textBoxFiltroPreviewDescripcion.Text + "%'";
                }
                else
                {
                    filtro += " AND direccionPlc LIKE '%" + textBoxFiltroPreviewDescripcion.Text + "%'";
                }
            }
            (gridSeñales.DataSource as DataTable).DefaultView.RowFilter = filtro;
        }
        private void textBoxFiltroPreviewDireccionPlc_TextChanged(object sender, EventArgs e)
        {
            filtroGridSeñales();
        }

        private void textBoxFiltroPreviewNLogico_TextChanged(object sender, EventArgs e)
        {
            filtroGridSeñales();
        }

        private void textBoxFiltroPreviewNFisico_TextChanged(object sender, EventArgs e)
        {
            filtroGridSeñales();
        }

        private void textBoxFiltroPreviewDescripcion_TextChanged(object sender, EventArgs e)
        {
            filtroGridSeñales();
        }

        private void textBoxFiltroPreviewCodigo_TextChanged(object sender, EventArgs e)
        {
            filtroGridSeñales();
        }
        #endregion

        #region Exportar PDF
        private void pictureBoxPdf_DoubleClick(object sender, EventArgs e)
        {
            listaSeñalesController.extraerPDF(comboBoxExplotaciones, comboBoxEstaciones);
        }

        #endregion

        #region Crear Atributo
        private void buttonCrearAtributo_Click(object sender, EventArgs e)
        {
            listaSeñalesController.añadirAtributo(comboBoxAgrupaciones, gridAtributo, comboBoxEstaciones, comboBoxExplotaciones, comboBoxAtributo);
            listaSeñalesController.findSeñalesCreadasByNombreEstacion(comboBoxEstaciones, gridSeñalesCreadas);
        }
        private void comboBoxAtributo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaSeñalesController.rellenarPrimeraFilaGridAtributo(gridAtributo, comboBoxEstaciones, comboBoxAtributo);
        }

        private void gridAtributo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 12 || e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11)
            {
                if (!String.IsNullOrEmpty(comboBoxAtributo.Text) && comboBoxAtributo.Text.Substring(0, 1).Equals("E"))
                {
                    e.CellStyle.BackColor = Color.Gray;
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }
            }
        }

        #endregion

        #region Crear Datalogger
        private void buttonCrearDataloggerInsert_Click(object sender, EventArgs e)
        {
            dataloggerController.createDatalogger(comboBoxExplotaciones, comboBoxSitAquacis, textBoxNombreDatalogger, textBoxNumeroAgrupacion, textBoxNumeroDatalogger, textBoxNumeroPunto, comboBoxTipoDl, textBoxPuerto, textBoxIP, textBoxHorasComunicacion, textBoxZonaSectorizacion);
        }
        private void comboBoxTipoDl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoDl.SelectedIndex == 1)
            {
                textBoxPuerto.Text = "3030";
            }
            else if (comboBoxTipoDl.SelectedIndex == 2)
            {
                textBoxPuerto.Text = "23024";
            }
            else if (comboBoxTipoDl.SelectedIndex == 3)
            {
                textBoxPuerto.Text = "502";
            }
            else
            {
                textBoxPuerto.Clear();
            }
        }
        #endregion

        #region Editar/Borrar Datalogger
        private void buttonBorrarDatalogger_Click(object sender, EventArgs e)
        {
            DialogResult borrarEstacion = MessageBox.Show("Va a borrar el datalogger " + comboBoxNombreDatalogger.Text + ", ¿está seguro?", "Borrar datalogger", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (borrarEstacion == DialogResult.Yes)
            {
                dataloggerController.deleteDatalogger(comboBoxNombreDatalogger, comboBoxExplotaciones, comboBoxSitAquacis);
                dataloggerController.findNombreDataloggersByNombreExplotacion(comboBoxNombreDatalogger, comboBoxExplotaciones, comboBoxSitAquacis);
            }
        }

        private void comboBoxNombreDatalogger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNombreDatalogger.SelectedIndex == 0)
            {

            }
            else
            {
                if (flag == 8)
                {
                    Datalogger datalogger = dataloggerController.findDataloggerByNombreDataloggerAndNombreExplotacion(comboBoxNombreDatalogger, comboBoxExplotaciones, comboBoxSitAquacis);
                    if (datalogger != null)
                    {
                        //Rellenamos textbox número datalogger
                        textBoxNumeroDatalogger.Text = datalogger.NumeroDatalogger.ToString();
                        //Rellenamos textbox número agrupación
                        textBoxNumeroAgrupacion.Text = datalogger.NumeroAgrupacion.ToString();
                        //Seleccionamos tipo
                        if (datalogger.Tipo.Equals("Microcom"))
                        {
                            comboBoxTipoDl.SelectedIndex = 1;
                        }
                        else if (datalogger.Tipo.Equals("Mejoras"))
                        {
                            comboBoxTipoDl.SelectedIndex = 2;
                        }
                        else if (datalogger.Tipo.Equals("Sofrel"))
                        {
                            comboBoxTipoDl.SelectedIndex = 3;
                        }
                        else if (datalogger.Tipo.Equals("Imeter"))
                        {
                            comboBoxTipoDl.SelectedIndex = 4;
                        }
                        else
                        {
                            comboBoxTipoDl.SelectedIndex = 0;
                        }
                        //Rellenamos puerto
                        textBoxPuerto.Text = datalogger.Puerto.ToString();
                        //Rellenamos IP
                        textBoxIP.Text = datalogger.DireccionIp;
                        //Rellenamos Horas Comunicación
                        textBoxHorasComunicacion.Text = datalogger.HorasComunicacion;
                        //Rellenamos Zona Sectorización
                        textBoxZonaSectorizacion.Text = datalogger.ZonaSectorizacion;
                        //Rellenamos Número Punto
                        if (datalogger.NumeroPunto != 0)
                        {
                            textBoxNumeroPunto.Text = datalogger.NumeroPunto.ToString();
                        }
                    }
                }        
            }
        }

        private void buttonEditarDatalogger_Click(object sender, EventArgs e)
        {
            dataloggerController.updateDatalogger(comboBoxExplotaciones, comboBoxSitAquacis, comboBoxNombreDatalogger, textBoxNumeroAgrupacion, textBoxNumeroDatalogger, textBoxNumeroPunto, comboBoxTipoDl, textBoxPuerto, textBoxIP, textBoxHorasComunicacion, textBoxZonaSectorizacion);
        }
        #endregion

    }
}
