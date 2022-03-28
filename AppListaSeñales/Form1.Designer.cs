
using AppListaSeñales.Utils;
using System;
using System.Windows.Forms;

namespace AppListaSeñales
{
    partial class AppListaSeñales
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppListaSeñales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tituloLogin = new System.Windows.Forms.Label();
            this.usuarioLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usuarioTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.errorLoginLabel1 = new System.Windows.Forms.Label();
            this.errorLogin2 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.panelMenuPrincipal = new System.Windows.Forms.Panel();
            this.buttonEditarBorrarDatalogger = new System.Windows.Forms.Button();
            this.buttonCrearDatalogger = new System.Windows.Forms.Button();
            this.buttonImportarCSV = new System.Windows.Forms.Button();
            this.buttonAñadirAtributo = new System.Windows.Forms.Button();
            this.buttonEditarBorrarEstacion = new System.Windows.Forms.Button();
            this.visualizarListaSeñales = new System.Windows.Forms.Button();
            this.crearListaButton = new System.Windows.Forms.Button();
            this.crearEstacionButton = new System.Windows.Forms.Button();
            this.crearExplotacionButton = new System.Windows.Forms.Button();
            this.inicioLinkLabel = new System.Windows.Forms.LinkLabel();
            this.logoutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.explotacionListaLabel = new System.Windows.Forms.Label();
            this.estacionListaLabel = new System.Windows.Forms.Label();
            this.agrupacionListaLabel = new System.Windows.Forms.Label();
            this.plantillaListaLabel = new System.Windows.Forms.Label();
            this.panelInteraccion = new System.Windows.Forms.Panel();
            this.buttonEditarDatalogger = new System.Windows.Forms.Button();
            this.buttonBorrarDatalogger = new System.Windows.Forms.Button();
            this.comboBoxNombreDatalogger = new System.Windows.Forms.ComboBox();
            this.textBoxNombreDatalogger = new System.Windows.Forms.TextBox();
            this.buttonCrearDataloggerInsert = new System.Windows.Forms.Button();
            this.comboBoxTipoDl = new System.Windows.Forms.ComboBox();
            this.labelTipoDl = new System.Windows.Forms.Label();
            this.textBoxZonaSectorizacion = new System.Windows.Forms.TextBox();
            this.labelZonaSectorizacion = new System.Windows.Forms.Label();
            this.textBoxHorasComunicacion = new System.Windows.Forms.TextBox();
            this.labelHorasComunicacion = new System.Windows.Forms.Label();
            this.textBoxPuerto = new System.Windows.Forms.TextBox();
            this.labelPuerto = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.textBoxNumeroPunto = new System.Windows.Forms.TextBox();
            this.labelNumeroPunto = new System.Windows.Forms.Label();
            this.textBoxNumeroDatalogger = new System.Windows.Forms.TextBox();
            this.labelNumeroDatalogger = new System.Windows.Forms.Label();
            this.textBoxNumeroAgrupacion = new System.Windows.Forms.TextBox();
            this.labelNumeroAgrupacionDl = new System.Windows.Forms.Label();
            this.labelNombreDatalogger = new System.Windows.Forms.Label();
            this.textBoxNumeroEsclavo = new System.Windows.Forms.TextBox();
            this.labelNumeroEsclavo = new System.Windows.Forms.Label();
            this.comboBoxAtributo = new System.Windows.Forms.ComboBox();
            this.labelAtributo = new System.Windows.Forms.Label();
            this.labelInstancia = new System.Windows.Forms.Label();
            this.buttonCrearAtributo = new System.Windows.Forms.Button();
            this.labelDCDC = new System.Windows.Forms.Label();
            this.pictureBoxPdf = new System.Windows.Forms.PictureBox();
            this.buttonEditarEstacion = new System.Windows.Forms.Button();
            this.buttonBorrarEstacion = new System.Windows.Forms.Button();
            this.pictureBoxExcel = new System.Windows.Forms.PictureBox();
            this.comboBoxComunicaciones = new System.Windows.Forms.ComboBox();
            this.labelComunicacion = new System.Windows.Forms.Label();
            this.textBoxMinRaw = new System.Windows.Forms.TextBox();
            this.labelMinRaw = new System.Windows.Forms.Label();
            this.textBoxMaxRaw = new System.Windows.Forms.TextBox();
            this.labelMaxRaw = new System.Windows.Forms.Label();
            this.textBoxCebeAquacis = new System.Windows.Forms.TextBox();
            this.labelCebeAquacis = new System.Windows.Forms.Label();
            this.textBoxNumeroEstacion = new System.Windows.Forms.TextBox();
            this.labelNumeroEstacion = new System.Windows.Forms.Label();
            this.textBoxCebeIas = new System.Windows.Forms.TextBox();
            this.labelCebeIas = new System.Windows.Forms.Label();
            this.buttonCrearExplotacion = new System.Windows.Forms.Button();
            this.buttonCrearEstacion = new System.Windows.Forms.Button();
            this.textBoxCrearEstacion = new System.Windows.Forms.TextBox();
            this.comboBoxSitAquacis = new System.Windows.Forms.ComboBox();
            this.labelSitAquacis = new System.Windows.Forms.Label();
            this.linkLabelConsignas = new System.Windows.Forms.LinkLabel();
            this.linkLabelTelemandos = new System.Windows.Forms.LinkLabel();
            this.linkLabelContadores = new System.Windows.Forms.LinkLabel();
            this.linkLabelDigitales = new System.Windows.Forms.LinkLabel();
            this.linkLabelAnalogicas = new System.Windows.Forms.LinkLabel();
            this.comboBoxNumeroAgrupacion = new System.Windows.Forms.ComboBox();
            this.labelNumeroAgrupacion = new System.Windows.Forms.Label();
            this.comboBoxPlantillas = new System.Windows.Forms.ComboBox();
            this.comboBoxAgrupaciones = new System.Windows.Forms.ComboBox();
            this.comboBoxEstaciones = new System.Windows.Forms.ComboBox();
            this.comboBoxExplotaciones = new System.Windows.Forms.ComboBox();
            this.gridAtributo = new System.Windows.Forms.DataGridView();
            this.gridPlantillas = new System.Windows.Forms.DataGridView();
            this.buttonAñadirSeñal = new System.Windows.Forms.Button();
            this.buttonGuardarLista = new System.Windows.Forms.Button();
            this.gridSeñales = new System.Windows.Forms.DataGridView();
            this.cmMenuPreviewListas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BorrarPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLimpiarLista = new System.Windows.Forms.Button();
            this.labelCrearExplotacion = new System.Windows.Forms.Label();
            this.labelCrearEstacion = new System.Windows.Forms.Label();
            this.labelCrearListas = new System.Windows.Forms.Label();
            this.labelVisualizarListas = new System.Windows.Forms.Label();
            this.gridSeñalesCreadas = new System.Windows.Forms.DataGridView();
            this.cmMenuGridSeñalesCreadas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Borrar = new System.Windows.Forms.ToolStripMenuItem();
            this.labelGridSeñalesCreadas = new System.Windows.Forms.Label();
            this.buttonExportarExcel = new System.Windows.Forms.Button();
            this.labelExportarExcel = new System.Windows.Forms.Label();
            this.buttonAtras = new System.Windows.Forms.Button();
            this.labelEditarEstacion = new System.Windows.Forms.Label();
            this.gridCrearSeñales = new System.Windows.Forms.DataGridView();
            this.cmMenuGridCrearSeñales = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BorrarGridCrearSeñales = new System.Windows.Forms.ToolStripMenuItem();
            this.labelFiltroPlc = new System.Windows.Forms.Label();
            this.labelFiltroNLogico = new System.Windows.Forms.Label();
            this.labelFiltroCodigo = new System.Windows.Forms.Label();
            this.labelFiltroNFisico = new System.Windows.Forms.Label();
            this.textBoxFiltroCodigo = new System.Windows.Forms.TextBox();
            this.textBoxFiltroNFisico = new System.Windows.Forms.TextBox();
            this.textBoxFiltroNLogico = new System.Windows.Forms.TextBox();
            this.textBoxFiltroPlc = new System.Windows.Forms.TextBox();
            this.labelFiltroPreviewPlc = new System.Windows.Forms.Label();
            this.textBoxFiltroPreviewDireccionPlc = new System.Windows.Forms.TextBox();
            this.labelFiltroPreviewNLogico = new System.Windows.Forms.Label();
            this.textBoxFiltroPreviewNLogico = new System.Windows.Forms.TextBox();
            this.labelFiltroPreviewNFisico = new System.Windows.Forms.Label();
            this.textBoxFiltroPreviewNFisico = new System.Windows.Forms.TextBox();
            this.textBoxFiltroPreviewDescripcion = new System.Windows.Forms.TextBox();
            this.labelFiltroPreviewDescripcion = new System.Windows.Forms.Label();
            this.labelFiltroPreviewCodigo = new System.Windows.Forms.Label();
            this.textBoxFiltroPreviewCodigo = new System.Windows.Forms.TextBox();
            this.labelAñadirAtributo = new System.Windows.Forms.Label();
            this.gridExcel = new System.Windows.Forms.DataGridView();
            this.labelCrearDatalogger = new System.Windows.Forms.Label();
            this.labelEditarBorrarDatalogger = new System.Windows.Forms.Label();
            this.panelLogin.SuspendLayout();
            this.panelMenuPrincipal.SuspendLayout();
            this.panelInteraccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtributo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlantillas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeñales)).BeginInit();
            this.cmMenuPreviewListas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeñalesCreadas)).BeginInit();
            this.cmMenuGridSeñalesCreadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCrearSeñales)).BeginInit();
            this.cmMenuGridCrearSeñales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // tituloLogin
            // 
            this.tituloLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tituloLogin.AutoSize = true;
            this.tituloLogin.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tituloLogin.Location = new System.Drawing.Point(9, 29);
            this.tituloLogin.Name = "tituloLogin";
            this.tituloLogin.Size = new System.Drawing.Size(357, 40);
            this.tituloLogin.TabIndex = 0;
            this.tituloLogin.Text = "Aplicación Lista de Señales";
            this.tituloLogin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // usuarioLabel
            // 
            this.usuarioLabel.AutoSize = true;
            this.usuarioLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usuarioLabel.Location = new System.Drawing.Point(34, 142);
            this.usuarioLabel.Name = "usuarioLabel";
            this.usuarioLabel.Size = new System.Drawing.Size(64, 21);
            this.usuarioLabel.TabIndex = 1;
            this.usuarioLabel.Text = "Usuario";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordLabel.Location = new System.Drawing.Point(9, 207);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(89, 21);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Contraseña";
            // 
            // usuarioTextBox
            // 
            this.usuarioTextBox.Location = new System.Drawing.Point(142, 142);
            this.usuarioTextBox.Name = "usuarioTextBox";
            this.usuarioTextBox.Size = new System.Drawing.Size(224, 23);
            this.usuarioTextBox.TabIndex = 3;
            this.usuarioTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usuarioTextBox_KeyDown);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(142, 205);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(224, 23);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usuarioTextBox_KeyDown);
            // 
            // errorLoginLabel1
            // 
            this.errorLoginLabel1.AutoSize = true;
            this.errorLoginLabel1.ForeColor = System.Drawing.Color.Red;
            this.errorLoginLabel1.Location = new System.Drawing.Point(142, 105);
            this.errorLoginLabel1.Name = "errorLoginLabel1";
            this.errorLoginLabel1.Size = new System.Drawing.Size(216, 15);
            this.errorLoginLabel1.TabIndex = 5;
            this.errorLoginLabel1.Text = "Usuario y/o contraseña son incorrectos.";
            this.errorLoginLabel1.Visible = false;
            // 
            // errorLogin2
            // 
            this.errorLogin2.AutoSize = true;
            this.errorLogin2.ForeColor = System.Drawing.Color.Red;
            this.errorLogin2.Location = new System.Drawing.Point(142, 105);
            this.errorLogin2.Name = "errorLogin2";
            this.errorLogin2.Size = new System.Drawing.Size(144, 15);
            this.errorLogin2.TabIndex = 6;
            this.errorLogin2.Text = "Rellene todos los campos.";
            this.errorLogin2.Visible = false;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(142, 262);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(76, 23);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "Enviar";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // panelLogin
            // 
            this.panelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLogin.Controls.Add(this.loginButton);
            this.panelLogin.Controls.Add(this.tituloLogin);
            this.panelLogin.Controls.Add(this.usuarioLabel);
            this.panelLogin.Controls.Add(this.errorLogin2);
            this.panelLogin.Controls.Add(this.passwordLabel);
            this.panelLogin.Controls.Add(this.errorLoginLabel1);
            this.panelLogin.Controls.Add(this.usuarioTextBox);
            this.panelLogin.Controls.Add(this.passwordTextBox);
            this.panelLogin.Location = new System.Drawing.Point(790, 197);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(404, 318);
            this.panelLogin.TabIndex = 8;
            // 
            // panelMenuPrincipal
            // 
            this.panelMenuPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenuPrincipal.Controls.Add(this.buttonEditarBorrarDatalogger);
            this.panelMenuPrincipal.Controls.Add(this.buttonCrearDatalogger);
            this.panelMenuPrincipal.Controls.Add(this.buttonImportarCSV);
            this.panelMenuPrincipal.Controls.Add(this.buttonAñadirAtributo);
            this.panelMenuPrincipal.Controls.Add(this.buttonEditarBorrarEstacion);
            this.panelMenuPrincipal.Controls.Add(this.visualizarListaSeñales);
            this.panelMenuPrincipal.Controls.Add(this.crearListaButton);
            this.panelMenuPrincipal.Controls.Add(this.crearEstacionButton);
            this.panelMenuPrincipal.Controls.Add(this.crearExplotacionButton);
            this.panelMenuPrincipal.Location = new System.Drawing.Point(803, 227);
            this.panelMenuPrincipal.Name = "panelMenuPrincipal";
            this.panelMenuPrincipal.Size = new System.Drawing.Size(363, 284);
            this.panelMenuPrincipal.TabIndex = 9;
            this.panelMenuPrincipal.Visible = false;
            // 
            // buttonEditarBorrarDatalogger
            // 
            this.buttonEditarBorrarDatalogger.Location = new System.Drawing.Point(192, 97);
            this.buttonEditarBorrarDatalogger.Name = "buttonEditarBorrarDatalogger";
            this.buttonEditarBorrarDatalogger.Size = new System.Drawing.Size(164, 23);
            this.buttonEditarBorrarDatalogger.TabIndex = 8;
            this.buttonEditarBorrarDatalogger.Text = "Editar/Borrar Datalogger";
            this.buttonEditarBorrarDatalogger.UseVisualStyleBackColor = true;
            this.buttonEditarBorrarDatalogger.Click += new System.EventHandler(this.buttonEditarBorrarDatalogger_Click);
            // 
            // buttonCrearDatalogger
            // 
            this.buttonCrearDatalogger.Location = new System.Drawing.Point(192, 59);
            this.buttonCrearDatalogger.Name = "buttonCrearDatalogger";
            this.buttonCrearDatalogger.Size = new System.Drawing.Size(164, 23);
            this.buttonCrearDatalogger.TabIndex = 7;
            this.buttonCrearDatalogger.Text = "Crear Datalogger";
            this.buttonCrearDatalogger.UseVisualStyleBackColor = true;
            this.buttonCrearDatalogger.Click += new System.EventHandler(this.buttonCrearDatalogger_Click);
            // 
            // buttonImportarCSV
            // 
            this.buttonImportarCSV.Location = new System.Drawing.Point(100, 249);
            this.buttonImportarCSV.Name = "buttonImportarCSV";
            this.buttonImportarCSV.Size = new System.Drawing.Size(164, 23);
            this.buttonImportarCSV.TabIndex = 6;
            this.buttonImportarCSV.Text = "Importar Lista de Señales";
            this.buttonImportarCSV.UseVisualStyleBackColor = true;
            this.buttonImportarCSV.Click += new System.EventHandler(this.buttonImportarCSV_Click);
            // 
            // buttonAñadirAtributo
            // 
            this.buttonAñadirAtributo.Location = new System.Drawing.Point(100, 173);
            this.buttonAñadirAtributo.Name = "buttonAñadirAtributo";
            this.buttonAñadirAtributo.Size = new System.Drawing.Size(164, 23);
            this.buttonAñadirAtributo.TabIndex = 5;
            this.buttonAñadirAtributo.Text = "Añadir Atributo";
            this.buttonAñadirAtributo.UseVisualStyleBackColor = true;
            this.buttonAñadirAtributo.Click += new System.EventHandler(this.buttonAñadirAtributo_Click);
            // 
            // buttonEditarBorrarEstacion
            // 
            this.buttonEditarBorrarEstacion.Location = new System.Drawing.Point(6, 97);
            this.buttonEditarBorrarEstacion.Name = "buttonEditarBorrarEstacion";
            this.buttonEditarBorrarEstacion.Size = new System.Drawing.Size(164, 23);
            this.buttonEditarBorrarEstacion.TabIndex = 4;
            this.buttonEditarBorrarEstacion.Text = "Editar/Borrar Estación";
            this.buttonEditarBorrarEstacion.UseVisualStyleBackColor = true;
            this.buttonEditarBorrarEstacion.Click += new System.EventHandler(this.buttonEditarBorrarEstacion_Click);
            // 
            // visualizarListaSeñales
            // 
            this.visualizarListaSeñales.Location = new System.Drawing.Point(100, 211);
            this.visualizarListaSeñales.Name = "visualizarListaSeñales";
            this.visualizarListaSeñales.Size = new System.Drawing.Size(164, 23);
            this.visualizarListaSeñales.TabIndex = 3;
            this.visualizarListaSeñales.Text = "Visualizar Lista de Señales";
            this.visualizarListaSeñales.UseVisualStyleBackColor = true;
            this.visualizarListaSeñales.Click += new System.EventHandler(this.visualizarListaSeñales_Click);
            // 
            // crearListaButton
            // 
            this.crearListaButton.Location = new System.Drawing.Point(100, 135);
            this.crearListaButton.Name = "crearListaButton";
            this.crearListaButton.Size = new System.Drawing.Size(164, 23);
            this.crearListaButton.TabIndex = 2;
            this.crearListaButton.Text = "Crear Lista de Señales";
            this.crearListaButton.UseVisualStyleBackColor = true;
            this.crearListaButton.Click += new System.EventHandler(this.crearListaButton_Click);
            // 
            // crearEstacionButton
            // 
            this.crearEstacionButton.Location = new System.Drawing.Point(6, 59);
            this.crearEstacionButton.Name = "crearEstacionButton";
            this.crearEstacionButton.Size = new System.Drawing.Size(164, 23);
            this.crearEstacionButton.TabIndex = 1;
            this.crearEstacionButton.Text = "Crear Estación";
            this.crearEstacionButton.UseVisualStyleBackColor = true;
            this.crearEstacionButton.Click += new System.EventHandler(this.crearEstacionButton_Click);
            // 
            // crearExplotacionButton
            // 
            this.crearExplotacionButton.Location = new System.Drawing.Point(100, 21);
            this.crearExplotacionButton.Name = "crearExplotacionButton";
            this.crearExplotacionButton.Size = new System.Drawing.Size(164, 23);
            this.crearExplotacionButton.TabIndex = 0;
            this.crearExplotacionButton.Text = "Crear Explotación";
            this.crearExplotacionButton.UseVisualStyleBackColor = true;
            this.crearExplotacionButton.Click += new System.EventHandler(this.crearExplotacionButton_Click);
            // 
            // inicioLinkLabel
            // 
            this.inicioLinkLabel.AutoSize = true;
            this.inicioLinkLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inicioLinkLabel.Location = new System.Drawing.Point(12, 2);
            this.inicioLinkLabel.Name = "inicioLinkLabel";
            this.inicioLinkLabel.Size = new System.Drawing.Size(64, 30);
            this.inicioLinkLabel.TabIndex = 10;
            this.inicioLinkLabel.TabStop = true;
            this.inicioLinkLabel.Text = "Inicio";
            this.inicioLinkLabel.Visible = false;
            this.inicioLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.inicioLlinkLabel_LinkClicked);
            // 
            // logoutLinkLabel
            // 
            this.logoutLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutLinkLabel.AutoSize = true;
            this.logoutLinkLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logoutLinkLabel.Location = new System.Drawing.Point(1620, 2);
            this.logoutLinkLabel.Name = "logoutLinkLabel";
            this.logoutLinkLabel.Size = new System.Drawing.Size(140, 30);
            this.logoutLinkLabel.TabIndex = 12;
            this.logoutLinkLabel.TabStop = true;
            this.logoutLinkLabel.Text = "Cerrar sesión";
            this.logoutLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.logoutLinkLabel.Visible = false;
            this.logoutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logoutLinkLabel_LinkClicked);
            // 
            // explotacionListaLabel
            // 
            this.explotacionListaLabel.AutoSize = true;
            this.explotacionListaLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.explotacionListaLabel.Location = new System.Drawing.Point(28, 23);
            this.explotacionListaLabel.Name = "explotacionListaLabel";
            this.explotacionListaLabel.Size = new System.Drawing.Size(95, 21);
            this.explotacionListaLabel.TabIndex = 0;
            this.explotacionListaLabel.Text = "Explotación";
            // 
            // estacionListaLabel
            // 
            this.estacionListaLabel.AutoSize = true;
            this.estacionListaLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.estacionListaLabel.Location = new System.Drawing.Point(868, 23);
            this.estacionListaLabel.Name = "estacionListaLabel";
            this.estacionListaLabel.Size = new System.Drawing.Size(70, 21);
            this.estacionListaLabel.TabIndex = 1;
            this.estacionListaLabel.Text = "Estación";
            this.estacionListaLabel.Visible = false;
            // 
            // agrupacionListaLabel
            // 
            this.agrupacionListaLabel.AutoSize = true;
            this.agrupacionListaLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.agrupacionListaLabel.Location = new System.Drawing.Point(1266, 23);
            this.agrupacionListaLabel.Name = "agrupacionListaLabel";
            this.agrupacionListaLabel.Size = new System.Drawing.Size(95, 21);
            this.agrupacionListaLabel.TabIndex = 2;
            this.agrupacionListaLabel.Text = "Agrupación";
            this.agrupacionListaLabel.Visible = false;
            // 
            // plantillaListaLabel
            // 
            this.plantillaListaLabel.AutoSize = true;
            this.plantillaListaLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.plantillaListaLabel.Location = new System.Drawing.Point(50, 91);
            this.plantillaListaLabel.Name = "plantillaListaLabel";
            this.plantillaListaLabel.Size = new System.Drawing.Size(73, 21);
            this.plantillaListaLabel.TabIndex = 3;
            this.plantillaListaLabel.Text = "Plantillas";
            this.plantillaListaLabel.Visible = false;
            // 
            // panelInteraccion
            // 
            this.panelInteraccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInteraccion.Controls.Add(this.buttonEditarDatalogger);
            this.panelInteraccion.Controls.Add(this.buttonBorrarDatalogger);
            this.panelInteraccion.Controls.Add(this.comboBoxNombreDatalogger);
            this.panelInteraccion.Controls.Add(this.textBoxNombreDatalogger);
            this.panelInteraccion.Controls.Add(this.buttonCrearDataloggerInsert);
            this.panelInteraccion.Controls.Add(this.comboBoxTipoDl);
            this.panelInteraccion.Controls.Add(this.labelTipoDl);
            this.panelInteraccion.Controls.Add(this.textBoxZonaSectorizacion);
            this.panelInteraccion.Controls.Add(this.labelZonaSectorizacion);
            this.panelInteraccion.Controls.Add(this.textBoxHorasComunicacion);
            this.panelInteraccion.Controls.Add(this.labelHorasComunicacion);
            this.panelInteraccion.Controls.Add(this.textBoxPuerto);
            this.panelInteraccion.Controls.Add(this.labelPuerto);
            this.panelInteraccion.Controls.Add(this.textBoxIP);
            this.panelInteraccion.Controls.Add(this.labelIP);
            this.panelInteraccion.Controls.Add(this.textBoxNumeroPunto);
            this.panelInteraccion.Controls.Add(this.labelNumeroPunto);
            this.panelInteraccion.Controls.Add(this.textBoxNumeroDatalogger);
            this.panelInteraccion.Controls.Add(this.labelNumeroDatalogger);
            this.panelInteraccion.Controls.Add(this.textBoxNumeroAgrupacion);
            this.panelInteraccion.Controls.Add(this.labelNumeroAgrupacionDl);
            this.panelInteraccion.Controls.Add(this.labelNombreDatalogger);
            this.panelInteraccion.Controls.Add(this.textBoxNumeroEsclavo);
            this.panelInteraccion.Controls.Add(this.labelNumeroEsclavo);
            this.panelInteraccion.Controls.Add(this.comboBoxAtributo);
            this.panelInteraccion.Controls.Add(this.labelAtributo);
            this.panelInteraccion.Controls.Add(this.labelInstancia);
            this.panelInteraccion.Controls.Add(this.buttonCrearAtributo);
            this.panelInteraccion.Controls.Add(this.labelDCDC);
            this.panelInteraccion.Controls.Add(this.pictureBoxPdf);
            this.panelInteraccion.Controls.Add(this.buttonEditarEstacion);
            this.panelInteraccion.Controls.Add(this.buttonBorrarEstacion);
            this.panelInteraccion.Controls.Add(this.pictureBoxExcel);
            this.panelInteraccion.Controls.Add(this.comboBoxComunicaciones);
            this.panelInteraccion.Controls.Add(this.labelComunicacion);
            this.panelInteraccion.Controls.Add(this.textBoxMinRaw);
            this.panelInteraccion.Controls.Add(this.labelMinRaw);
            this.panelInteraccion.Controls.Add(this.textBoxMaxRaw);
            this.panelInteraccion.Controls.Add(this.labelMaxRaw);
            this.panelInteraccion.Controls.Add(this.textBoxCebeAquacis);
            this.panelInteraccion.Controls.Add(this.labelCebeAquacis);
            this.panelInteraccion.Controls.Add(this.textBoxNumeroEstacion);
            this.panelInteraccion.Controls.Add(this.labelNumeroEstacion);
            this.panelInteraccion.Controls.Add(this.textBoxCebeIas);
            this.panelInteraccion.Controls.Add(this.labelCebeIas);
            this.panelInteraccion.Controls.Add(this.buttonCrearExplotacion);
            this.panelInteraccion.Controls.Add(this.buttonCrearEstacion);
            this.panelInteraccion.Controls.Add(this.textBoxCrearEstacion);
            this.panelInteraccion.Controls.Add(this.comboBoxSitAquacis);
            this.panelInteraccion.Controls.Add(this.labelSitAquacis);
            this.panelInteraccion.Controls.Add(this.linkLabelConsignas);
            this.panelInteraccion.Controls.Add(this.linkLabelTelemandos);
            this.panelInteraccion.Controls.Add(this.linkLabelContadores);
            this.panelInteraccion.Controls.Add(this.linkLabelDigitales);
            this.panelInteraccion.Controls.Add(this.linkLabelAnalogicas);
            this.panelInteraccion.Controls.Add(this.comboBoxNumeroAgrupacion);
            this.panelInteraccion.Controls.Add(this.labelNumeroAgrupacion);
            this.panelInteraccion.Controls.Add(this.comboBoxPlantillas);
            this.panelInteraccion.Controls.Add(this.comboBoxAgrupaciones);
            this.panelInteraccion.Controls.Add(this.comboBoxEstaciones);
            this.panelInteraccion.Controls.Add(this.comboBoxExplotaciones);
            this.panelInteraccion.Controls.Add(this.plantillaListaLabel);
            this.panelInteraccion.Controls.Add(this.agrupacionListaLabel);
            this.panelInteraccion.Controls.Add(this.estacionListaLabel);
            this.panelInteraccion.Controls.Add(this.explotacionListaLabel);
            this.panelInteraccion.Location = new System.Drawing.Point(12, 35);
            this.panelInteraccion.Name = "panelInteraccion";
            this.panelInteraccion.Size = new System.Drawing.Size(1748, 115);
            this.panelInteraccion.TabIndex = 11;
            this.panelInteraccion.Visible = false;
            // 
            // buttonEditarDatalogger
            // 
            this.buttonEditarDatalogger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditarDatalogger.Location = new System.Drawing.Point(1629, 60);
            this.buttonEditarDatalogger.Name = "buttonEditarDatalogger";
            this.buttonEditarDatalogger.Size = new System.Drawing.Size(111, 23);
            this.buttonEditarDatalogger.TabIndex = 72;
            this.buttonEditarDatalogger.Text = "Editar Datalogger";
            this.buttonEditarDatalogger.UseVisualStyleBackColor = true;
            this.buttonEditarDatalogger.Visible = false;
            this.buttonEditarDatalogger.Click += new System.EventHandler(this.buttonEditarDatalogger_Click);
            // 
            // buttonBorrarDatalogger
            // 
            this.buttonBorrarDatalogger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBorrarDatalogger.Location = new System.Drawing.Point(1629, 19);
            this.buttonBorrarDatalogger.Name = "buttonBorrarDatalogger";
            this.buttonBorrarDatalogger.Size = new System.Drawing.Size(111, 23);
            this.buttonBorrarDatalogger.TabIndex = 71;
            this.buttonBorrarDatalogger.Text = "Borrar Datalogger";
            this.buttonBorrarDatalogger.UseVisualStyleBackColor = true;
            this.buttonBorrarDatalogger.Visible = false;
            this.buttonBorrarDatalogger.Click += new System.EventHandler(this.buttonBorrarDatalogger_Click);
            // 
            // comboBoxNombreDatalogger
            // 
            this.comboBoxNombreDatalogger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNombreDatalogger.FormattingEnabled = true;
            this.comboBoxNombreDatalogger.Location = new System.Drawing.Point(966, 21);
            this.comboBoxNombreDatalogger.Name = "comboBoxNombreDatalogger";
            this.comboBoxNombreDatalogger.Size = new System.Drawing.Size(264, 23);
            this.comboBoxNombreDatalogger.TabIndex = 70;
            this.comboBoxNombreDatalogger.Visible = false;
            this.comboBoxNombreDatalogger.SelectedIndexChanged += new System.EventHandler(this.comboBoxNombreDatalogger_SelectedIndexChanged);
            // 
            // textBoxNombreDatalogger
            // 
            this.textBoxNombreDatalogger.Location = new System.Drawing.Point(966, 21);
            this.textBoxNombreDatalogger.Name = "textBoxNombreDatalogger";
            this.textBoxNombreDatalogger.Size = new System.Drawing.Size(264, 23);
            this.textBoxNombreDatalogger.TabIndex = 69;
            this.textBoxNombreDatalogger.Visible = false;
            // 
            // buttonCrearDataloggerInsert
            // 
            this.buttonCrearDataloggerInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCrearDataloggerInsert.Location = new System.Drawing.Point(1629, 61);
            this.buttonCrearDataloggerInsert.Name = "buttonCrearDataloggerInsert";
            this.buttonCrearDataloggerInsert.Size = new System.Drawing.Size(111, 23);
            this.buttonCrearDataloggerInsert.TabIndex = 68;
            this.buttonCrearDataloggerInsert.Text = "Crear Datalogger";
            this.buttonCrearDataloggerInsert.UseVisualStyleBackColor = true;
            this.buttonCrearDataloggerInsert.Visible = false;
            this.buttonCrearDataloggerInsert.Click += new System.EventHandler(this.buttonCrearDataloggerInsert_Click);
            // 
            // comboBoxTipoDl
            // 
            this.comboBoxTipoDl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoDl.FormattingEnabled = true;
            this.comboBoxTipoDl.Items.AddRange(new object[] {
            "",
            "Microcom",
            "Mejoras",
            "Sofrel",
            "Imeter"});
            this.comboBoxTipoDl.Location = new System.Drawing.Point(1196, 60);
            this.comboBoxTipoDl.Name = "comboBoxTipoDl";
            this.comboBoxTipoDl.Size = new System.Drawing.Size(159, 23);
            this.comboBoxTipoDl.TabIndex = 67;
            this.comboBoxTipoDl.Visible = false;
            this.comboBoxTipoDl.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoDl_SelectedIndexChanged);
            // 
            // labelTipoDl
            // 
            this.labelTipoDl.AutoSize = true;
            this.labelTipoDl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTipoDl.Location = new System.Drawing.Point(1147, 62);
            this.labelTipoDl.Name = "labelTipoDl";
            this.labelTipoDl.Size = new System.Drawing.Size(43, 21);
            this.labelTipoDl.TabIndex = 66;
            this.labelTipoDl.Text = "Tipo";
            this.labelTipoDl.Visible = false;
            // 
            // textBoxZonaSectorizacion
            // 
            this.textBoxZonaSectorizacion.Location = new System.Drawing.Point(902, 60);
            this.textBoxZonaSectorizacion.Name = "textBoxZonaSectorizacion";
            this.textBoxZonaSectorizacion.Size = new System.Drawing.Size(216, 23);
            this.textBoxZonaSectorizacion.TabIndex = 65;
            this.textBoxZonaSectorizacion.Visible = false;
            // 
            // labelZonaSectorizacion
            // 
            this.labelZonaSectorizacion.AutoSize = true;
            this.labelZonaSectorizacion.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelZonaSectorizacion.Location = new System.Drawing.Point(748, 62);
            this.labelZonaSectorizacion.Name = "labelZonaSectorizacion";
            this.labelZonaSectorizacion.Size = new System.Drawing.Size(148, 21);
            this.labelZonaSectorizacion.TabIndex = 64;
            this.labelZonaSectorizacion.Text = "Zona Sectorización";
            this.labelZonaSectorizacion.Visible = false;
            // 
            // textBoxHorasComunicacion
            // 
            this.textBoxHorasComunicacion.Location = new System.Drawing.Point(586, 60);
            this.textBoxHorasComunicacion.Name = "textBoxHorasComunicacion";
            this.textBoxHorasComunicacion.Size = new System.Drawing.Size(136, 23);
            this.textBoxHorasComunicacion.TabIndex = 63;
            this.textBoxHorasComunicacion.Visible = false;
            // 
            // labelHorasComunicacion
            // 
            this.labelHorasComunicacion.AutoSize = true;
            this.labelHorasComunicacion.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHorasComunicacion.Location = new System.Drawing.Point(422, 62);
            this.labelHorasComunicacion.Name = "labelHorasComunicacion";
            this.labelHorasComunicacion.Size = new System.Drawing.Size(160, 21);
            this.labelHorasComunicacion.TabIndex = 62;
            this.labelHorasComunicacion.Text = "Horas Comunicación";
            this.labelHorasComunicacion.Visible = false;
            // 
            // textBoxPuerto
            // 
            this.textBoxPuerto.Location = new System.Drawing.Point(1432, 61);
            this.textBoxPuerto.Name = "textBoxPuerto";
            this.textBoxPuerto.Size = new System.Drawing.Size(73, 23);
            this.textBoxPuerto.TabIndex = 61;
            this.textBoxPuerto.Visible = false;
            // 
            // labelPuerto
            // 
            this.labelPuerto.AutoSize = true;
            this.labelPuerto.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPuerto.Location = new System.Drawing.Point(1367, 62);
            this.labelPuerto.Name = "labelPuerto";
            this.labelPuerto.Size = new System.Drawing.Size(59, 21);
            this.labelPuerto.TabIndex = 60;
            this.labelPuerto.Text = "Puerto";
            this.labelPuerto.Visible = false;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(223, 61);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(193, 23);
            this.textBoxIP.TabIndex = 59;
            this.textBoxIP.Visible = false;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelIP.Location = new System.Drawing.Point(193, 62);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(24, 21);
            this.labelIP.TabIndex = 58;
            this.labelIP.Text = "IP";
            this.labelIP.Visible = false;
            // 
            // textBoxNumeroPunto
            // 
            this.textBoxNumeroPunto.Location = new System.Drawing.Point(110, 61);
            this.textBoxNumeroPunto.Name = "textBoxNumeroPunto";
            this.textBoxNumeroPunto.Size = new System.Drawing.Size(58, 23);
            this.textBoxNumeroPunto.TabIndex = 57;
            this.textBoxNumeroPunto.Visible = false;
            // 
            // labelNumeroPunto
            // 
            this.labelNumeroPunto.AutoSize = true;
            this.labelNumeroPunto.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumeroPunto.Location = new System.Drawing.Point(28, 62);
            this.labelNumeroPunto.Name = "labelNumeroPunto";
            this.labelNumeroPunto.Size = new System.Drawing.Size(76, 21);
            this.labelNumeroPunto.TabIndex = 56;
            this.labelNumeroPunto.Text = "Nº Punto";
            this.labelNumeroPunto.Visible = false;
            // 
            // textBoxNumeroDatalogger
            // 
            this.textBoxNumeroDatalogger.Location = new System.Drawing.Point(1547, 21);
            this.textBoxNumeroDatalogger.Name = "textBoxNumeroDatalogger";
            this.textBoxNumeroDatalogger.Size = new System.Drawing.Size(50, 23);
            this.textBoxNumeroDatalogger.TabIndex = 55;
            this.textBoxNumeroDatalogger.Visible = false;
            // 
            // labelNumeroDatalogger
            // 
            this.labelNumeroDatalogger.AutoSize = true;
            this.labelNumeroDatalogger.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumeroDatalogger.Location = new System.Drawing.Point(1423, 23);
            this.labelNumeroDatalogger.Name = "labelNumeroDatalogger";
            this.labelNumeroDatalogger.Size = new System.Drawing.Size(115, 21);
            this.labelNumeroDatalogger.TabIndex = 54;
            this.labelNumeroDatalogger.Text = "Nº Datalogger";
            this.labelNumeroDatalogger.Visible = false;
            // 
            // textBoxNumeroAgrupacion
            // 
            this.textBoxNumeroAgrupacion.Location = new System.Drawing.Point(1359, 21);
            this.textBoxNumeroAgrupacion.Name = "textBoxNumeroAgrupacion";
            this.textBoxNumeroAgrupacion.Size = new System.Drawing.Size(50, 23);
            this.textBoxNumeroAgrupacion.TabIndex = 53;
            this.textBoxNumeroAgrupacion.Visible = false;
            // 
            // labelNumeroAgrupacionDl
            // 
            this.labelNumeroAgrupacionDl.AutoSize = true;
            this.labelNumeroAgrupacionDl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumeroAgrupacionDl.Location = new System.Drawing.Point(1235, 23);
            this.labelNumeroAgrupacionDl.Name = "labelNumeroAgrupacionDl";
            this.labelNumeroAgrupacionDl.Size = new System.Drawing.Size(118, 21);
            this.labelNumeroAgrupacionDl.TabIndex = 52;
            this.labelNumeroAgrupacionDl.Text = "Nº Agrupación";
            this.labelNumeroAgrupacionDl.Visible = false;
            // 
            // labelNombreDatalogger
            // 
            this.labelNombreDatalogger.AutoSize = true;
            this.labelNombreDatalogger.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNombreDatalogger.Location = new System.Drawing.Point(868, 22);
            this.labelNombreDatalogger.Name = "labelNombreDatalogger";
            this.labelNombreDatalogger.Size = new System.Drawing.Size(92, 21);
            this.labelNombreDatalogger.TabIndex = 51;
            this.labelNombreDatalogger.Text = "Datalogger";
            this.labelNombreDatalogger.Visible = false;
            // 
            // textBoxNumeroEsclavo
            // 
            this.textBoxNumeroEsclavo.Location = new System.Drawing.Point(1459, 61);
            this.textBoxNumeroEsclavo.Name = "textBoxNumeroEsclavo";
            this.textBoxNumeroEsclavo.Size = new System.Drawing.Size(50, 23);
            this.textBoxNumeroEsclavo.TabIndex = 50;
            this.textBoxNumeroEsclavo.Visible = false;
            // 
            // labelNumeroEsclavo
            // 
            this.labelNumeroEsclavo.AutoSize = true;
            this.labelNumeroEsclavo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumeroEsclavo.Location = new System.Drawing.Point(1367, 62);
            this.labelNumeroEsclavo.Name = "labelNumeroEsclavo";
            this.labelNumeroEsclavo.Size = new System.Drawing.Size(86, 21);
            this.labelNumeroEsclavo.TabIndex = 49;
            this.labelNumeroEsclavo.Text = "Nº Esclavo";
            this.labelNumeroEsclavo.Visible = false;
            // 
            // comboBoxAtributo
            // 
            this.comboBoxAtributo.FormattingEnabled = true;
            this.comboBoxAtributo.Items.AddRange(new object[] {
            "",
            "E_AVE2",
            "E_EABI",
            "E_MARV",
            "E_MARI"});
            this.comboBoxAtributo.Location = new System.Drawing.Point(129, 89);
            this.comboBoxAtributo.Name = "comboBoxAtributo";
            this.comboBoxAtributo.Size = new System.Drawing.Size(94, 23);
            this.comboBoxAtributo.TabIndex = 48;
            this.comboBoxAtributo.Visible = false;
            this.comboBoxAtributo.SelectedIndexChanged += new System.EventHandler(this.comboBoxAtributo_SelectedIndexChanged);
            // 
            // labelAtributo
            // 
            this.labelAtributo.AutoSize = true;
            this.labelAtributo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAtributo.Location = new System.Drawing.Point(50, 91);
            this.labelAtributo.Name = "labelAtributo";
            this.labelAtributo.Size = new System.Drawing.Size(72, 21);
            this.labelAtributo.TabIndex = 47;
            this.labelAtributo.Text = "Atributo";
            this.labelAtributo.Visible = false;
            // 
            // labelInstancia
            // 
            this.labelInstancia.AutoSize = true;
            this.labelInstancia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInstancia.Location = new System.Drawing.Point(1287, 23);
            this.labelInstancia.Name = "labelInstancia";
            this.labelInstancia.Size = new System.Drawing.Size(74, 21);
            this.labelInstancia.TabIndex = 43;
            this.labelInstancia.Text = "Instancia";
            this.labelInstancia.Visible = false;
            // 
            // buttonCrearAtributo
            // 
            this.buttonCrearAtributo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCrearAtributo.Location = new System.Drawing.Point(1635, 91);
            this.buttonCrearAtributo.Name = "buttonCrearAtributo";
            this.buttonCrearAtributo.Size = new System.Drawing.Size(111, 23);
            this.buttonCrearAtributo.TabIndex = 45;
            this.buttonCrearAtributo.Text = "Crear Atributo";
            this.buttonCrearAtributo.UseVisualStyleBackColor = true;
            this.buttonCrearAtributo.Visible = false;
            this.buttonCrearAtributo.Click += new System.EventHandler(this.buttonCrearAtributo_Click);
            // 
            // labelDCDC
            // 
            this.labelDCDC.AutoSize = true;
            this.labelDCDC.Location = new System.Drawing.Point(900, 78);
            this.labelDCDC.Name = "labelDCDC";
            this.labelDCDC.Size = new System.Drawing.Size(39, 15);
            this.labelDCDC.TabIndex = 42;
            this.labelDCDC.Text = "DCDC";
            this.labelDCDC.Visible = false;
            // 
            // pictureBoxPdf
            // 
            this.pictureBoxPdf.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPdf.Image")));
            this.pictureBoxPdf.Location = new System.Drawing.Point(253, 96);
            this.pictureBoxPdf.Name = "pictureBoxPdf";
            this.pictureBoxPdf.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxPdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPdf.TabIndex = 41;
            this.pictureBoxPdf.TabStop = false;
            this.pictureBoxPdf.Visible = false;
            this.pictureBoxPdf.DoubleClick += new System.EventHandler(this.pictureBoxPdf_DoubleClick);
            // 
            // buttonEditarEstacion
            // 
            this.buttonEditarEstacion.Location = new System.Drawing.Point(1629, 61);
            this.buttonEditarEstacion.Name = "buttonEditarEstacion";
            this.buttonEditarEstacion.Size = new System.Drawing.Size(111, 23);
            this.buttonEditarEstacion.TabIndex = 40;
            this.buttonEditarEstacion.Text = "Editar Estación";
            this.buttonEditarEstacion.UseVisualStyleBackColor = true;
            this.buttonEditarEstacion.Visible = false;
            this.buttonEditarEstacion.Click += new System.EventHandler(this.buttonEditarEstacion_Click);
            // 
            // buttonBorrarEstacion
            // 
            this.buttonBorrarEstacion.Location = new System.Drawing.Point(1629, 18);
            this.buttonBorrarEstacion.Name = "buttonBorrarEstacion";
            this.buttonBorrarEstacion.Size = new System.Drawing.Size(111, 23);
            this.buttonBorrarEstacion.TabIndex = 39;
            this.buttonBorrarEstacion.Text = "Borrar Estación";
            this.buttonBorrarEstacion.UseVisualStyleBackColor = true;
            this.buttonBorrarEstacion.Visible = false;
            this.buttonBorrarEstacion.Click += new System.EventHandler(this.buttonBorrarEstacion_Click);
            // 
            // pictureBoxExcel
            // 
            this.pictureBoxExcel.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExcel.Image")));
            this.pictureBoxExcel.Location = new System.Drawing.Point(911, 96);
            this.pictureBoxExcel.Name = "pictureBoxExcel";
            this.pictureBoxExcel.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxExcel.TabIndex = 38;
            this.pictureBoxExcel.TabStop = false;
            this.pictureBoxExcel.Visible = false;
            this.pictureBoxExcel.DoubleClick += new System.EventHandler(this.pictureBoxExcel_DoubleClick);
            // 
            // comboBoxComunicaciones
            // 
            this.comboBoxComunicaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComunicaciones.FormattingEnabled = true;
            this.comboBoxComunicaciones.Items.AddRange(new object[] {
            "",
            "Modbus",
            "S7",
            "Lacbus"});
            this.comboBoxComunicaciones.Location = new System.Drawing.Point(1096, 60);
            this.comboBoxComunicaciones.Name = "comboBoxComunicaciones";
            this.comboBoxComunicaciones.Size = new System.Drawing.Size(251, 23);
            this.comboBoxComunicaciones.TabIndex = 31;
            this.comboBoxComunicaciones.Visible = false;
            // 
            // labelComunicacion
            // 
            this.labelComunicacion.AutoSize = true;
            this.labelComunicacion.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelComunicacion.Location = new System.Drawing.Point(854, 62);
            this.labelComunicacion.Name = "labelComunicacion";
            this.labelComunicacion.Size = new System.Drawing.Size(236, 21);
            this.labelComunicacion.TabIndex = 30;
            this.labelComunicacion.Text = "Protocolo Comunicación DCDC";
            this.labelComunicacion.Visible = false;
            // 
            // textBoxMinRaw
            // 
            this.textBoxMinRaw.Location = new System.Drawing.Point(129, 60);
            this.textBoxMinRaw.Name = "textBoxMinRaw";
            this.textBoxMinRaw.Size = new System.Drawing.Size(150, 23);
            this.textBoxMinRaw.TabIndex = 29;
            this.textBoxMinRaw.Visible = false;
            // 
            // labelMinRaw
            // 
            this.labelMinRaw.AutoSize = true;
            this.labelMinRaw.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMinRaw.Location = new System.Drawing.Point(28, 62);
            this.labelMinRaw.Name = "labelMinRaw";
            this.labelMinRaw.Size = new System.Drawing.Size(68, 21);
            this.labelMinRaw.TabIndex = 28;
            this.labelMinRaw.Text = "MinRaw";
            this.labelMinRaw.Visible = false;
            // 
            // textBoxMaxRaw
            // 
            this.textBoxMaxRaw.Location = new System.Drawing.Point(540, 60);
            this.textBoxMaxRaw.Name = "textBoxMaxRaw";
            this.textBoxMaxRaw.Size = new System.Drawing.Size(150, 23);
            this.textBoxMaxRaw.TabIndex = 27;
            this.textBoxMaxRaw.Visible = false;
            // 
            // labelMaxRaw
            // 
            this.labelMaxRaw.AutoSize = true;
            this.labelMaxRaw.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMaxRaw.Location = new System.Drawing.Point(448, 62);
            this.labelMaxRaw.Name = "labelMaxRaw";
            this.labelMaxRaw.Size = new System.Drawing.Size(71, 21);
            this.labelMaxRaw.TabIndex = 26;
            this.labelMaxRaw.Text = "MaxRaw";
            this.labelMaxRaw.Visible = false;
            // 
            // textBoxCebeAquacis
            // 
            this.textBoxCebeAquacis.Enabled = false;
            this.textBoxCebeAquacis.Location = new System.Drawing.Point(532, 20);
            this.textBoxCebeAquacis.Name = "textBoxCebeAquacis";
            this.textBoxCebeAquacis.ReadOnly = true;
            this.textBoxCebeAquacis.Size = new System.Drawing.Size(46, 23);
            this.textBoxCebeAquacis.TabIndex = 25;
            this.textBoxCebeAquacis.Visible = false;
            // 
            // labelCebeAquacis
            // 
            this.labelCebeAquacis.AutoSize = true;
            this.labelCebeAquacis.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCebeAquacis.Location = new System.Drawing.Point(419, 20);
            this.labelCebeAquacis.Name = "labelCebeAquacis";
            this.labelCebeAquacis.Size = new System.Drawing.Size(107, 21);
            this.labelCebeAquacis.TabIndex = 24;
            this.labelCebeAquacis.Text = "CEBE Aquacis";
            this.labelCebeAquacis.Visible = false;
            // 
            // textBoxNumeroEstacion
            // 
            this.textBoxNumeroEstacion.Location = new System.Drawing.Point(1345, 21);
            this.textBoxNumeroEstacion.Name = "textBoxNumeroEstacion";
            this.textBoxNumeroEstacion.Size = new System.Drawing.Size(50, 23);
            this.textBoxNumeroEstacion.TabIndex = 23;
            this.textBoxNumeroEstacion.Visible = false;
            // 
            // labelNumeroEstacion
            // 
            this.labelNumeroEstacion.AutoSize = true;
            this.labelNumeroEstacion.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumeroEstacion.Location = new System.Drawing.Point(1252, 23);
            this.labelNumeroEstacion.Name = "labelNumeroEstacion";
            this.labelNumeroEstacion.Size = new System.Drawing.Size(93, 21);
            this.labelNumeroEstacion.TabIndex = 22;
            this.labelNumeroEstacion.Text = "Nº Estación";
            this.labelNumeroEstacion.Visible = false;
            // 
            // textBoxCebeIas
            // 
            this.textBoxCebeIas.Location = new System.Drawing.Point(758, 21);
            this.textBoxCebeIas.Name = "textBoxCebeIas";
            this.textBoxCebeIas.Size = new System.Drawing.Size(264, 23);
            this.textBoxCebeIas.TabIndex = 21;
            this.textBoxCebeIas.Visible = false;
            // 
            // labelCebeIas
            // 
            this.labelCebeIas.AutoSize = true;
            this.labelCebeIas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCebeIas.Location = new System.Drawing.Point(624, 22);
            this.labelCebeIas.Name = "labelCebeIas";
            this.labelCebeIas.Size = new System.Drawing.Size(128, 21);
            this.labelCebeIas.TabIndex = 20;
            this.labelCebeIas.Text = "Acrónimo DCDC";
            this.labelCebeIas.Visible = false;
            // 
            // buttonCrearExplotacion
            // 
            this.buttonCrearExplotacion.Location = new System.Drawing.Point(28, 60);
            this.buttonCrearExplotacion.Name = "buttonCrearExplotacion";
            this.buttonCrearExplotacion.Size = new System.Drawing.Size(108, 23);
            this.buttonCrearExplotacion.TabIndex = 18;
            this.buttonCrearExplotacion.Text = "Crear Explotación";
            this.buttonCrearExplotacion.UseVisualStyleBackColor = true;
            this.buttonCrearExplotacion.Visible = false;
            this.buttonCrearExplotacion.Click += new System.EventHandler(this.buttonCrearExplotacion_Click);
            // 
            // buttonCrearEstacion
            // 
            this.buttonCrearEstacion.Location = new System.Drawing.Point(1629, 61);
            this.buttonCrearEstacion.Name = "buttonCrearEstacion";
            this.buttonCrearEstacion.Size = new System.Drawing.Size(111, 23);
            this.buttonCrearEstacion.TabIndex = 19;
            this.buttonCrearEstacion.Text = "Crear Estación";
            this.buttonCrearEstacion.UseVisualStyleBackColor = true;
            this.buttonCrearEstacion.Visible = false;
            this.buttonCrearEstacion.Click += new System.EventHandler(this.buttonCrearEstacion_Click);
            // 
            // textBoxCrearEstacion
            // 
            this.textBoxCrearEstacion.Location = new System.Drawing.Point(945, 20);
            this.textBoxCrearEstacion.Name = "textBoxCrearEstacion";
            this.textBoxCrearEstacion.Size = new System.Drawing.Size(264, 23);
            this.textBoxCrearEstacion.TabIndex = 18;
            this.textBoxCrearEstacion.Visible = false;
            // 
            // comboBoxSitAquacis
            // 
            this.comboBoxSitAquacis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSitAquacis.FormattingEnabled = true;
            this.comboBoxSitAquacis.Location = new System.Drawing.Point(540, 21);
            this.comboBoxSitAquacis.Name = "comboBoxSitAquacis";
            this.comboBoxSitAquacis.Size = new System.Drawing.Size(265, 23);
            this.comboBoxSitAquacis.TabIndex = 17;
            this.comboBoxSitAquacis.Visible = false;
            this.comboBoxSitAquacis.SelectedIndexChanged += new System.EventHandler(this.comboBoxSitAquacis_SelectedIndexChanged);
            // 
            // labelSitAquacis
            // 
            this.labelSitAquacis.AutoSize = true;
            this.labelSitAquacis.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSitAquacis.Location = new System.Drawing.Point(440, 23);
            this.labelSitAquacis.Name = "labelSitAquacis";
            this.labelSitAquacis.Size = new System.Drawing.Size(94, 21);
            this.labelSitAquacis.TabIndex = 16;
            this.labelSitAquacis.Text = "SIT Aquacis";
            this.labelSitAquacis.Visible = false;
            // 
            // linkLabelConsignas
            // 
            this.linkLabelConsignas.AutoSize = true;
            this.linkLabelConsignas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelConsignas.Location = new System.Drawing.Point(778, 91);
            this.linkLabelConsignas.Name = "linkLabelConsignas";
            this.linkLabelConsignas.Size = new System.Drawing.Size(82, 21);
            this.linkLabelConsignas.TabIndex = 15;
            this.linkLabelConsignas.TabStop = true;
            this.linkLabelConsignas.Text = "Consignas";
            this.linkLabelConsignas.Visible = false;
            this.linkLabelConsignas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelConsignas_LinkClicked);
            // 
            // linkLabelTelemandos
            // 
            this.linkLabelTelemandos.AutoSize = true;
            this.linkLabelTelemandos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelTelemandos.Location = new System.Drawing.Point(654, 91);
            this.linkLabelTelemandos.Name = "linkLabelTelemandos";
            this.linkLabelTelemandos.Size = new System.Drawing.Size(92, 21);
            this.linkLabelTelemandos.TabIndex = 14;
            this.linkLabelTelemandos.TabStop = true;
            this.linkLabelTelemandos.Text = "Telemandos";
            this.linkLabelTelemandos.Visible = false;
            this.linkLabelTelemandos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelTelemandos_LinkClicked);
            // 
            // linkLabelContadores
            // 
            this.linkLabelContadores.AutoSize = true;
            this.linkLabelContadores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelContadores.Location = new System.Drawing.Point(527, 91);
            this.linkLabelContadores.Name = "linkLabelContadores";
            this.linkLabelContadores.Size = new System.Drawing.Size(90, 21);
            this.linkLabelContadores.TabIndex = 13;
            this.linkLabelContadores.TabStop = true;
            this.linkLabelContadores.Text = "Contadores";
            this.linkLabelContadores.Visible = false;
            this.linkLabelContadores.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelContadores_LinkClicked);
            // 
            // linkLabelDigitales
            // 
            this.linkLabelDigitales.AutoSize = true;
            this.linkLabelDigitales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelDigitales.Location = new System.Drawing.Point(419, 91);
            this.linkLabelDigitales.Name = "linkLabelDigitales";
            this.linkLabelDigitales.Size = new System.Drawing.Size(70, 21);
            this.linkLabelDigitales.TabIndex = 12;
            this.linkLabelDigitales.TabStop = true;
            this.linkLabelDigitales.Text = "Digitales";
            this.linkLabelDigitales.Visible = false;
            this.linkLabelDigitales.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDigitales_LinkClicked);
            // 
            // linkLabelAnalogicas
            // 
            this.linkLabelAnalogicas.AutoSize = true;
            this.linkLabelAnalogicas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabelAnalogicas.Location = new System.Drawing.Point(295, 91);
            this.linkLabelAnalogicas.Name = "linkLabelAnalogicas";
            this.linkLabelAnalogicas.Size = new System.Drawing.Size(85, 21);
            this.linkLabelAnalogicas.TabIndex = 11;
            this.linkLabelAnalogicas.TabStop = true;
            this.linkLabelAnalogicas.Text = "Analógicas";
            this.linkLabelAnalogicas.Visible = false;
            this.linkLabelAnalogicas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAnalogicas_LinkClicked);
            // 
            // comboBoxNumeroAgrupacion
            // 
            this.comboBoxNumeroAgrupacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNumeroAgrupacion.FormattingEnabled = true;
            this.comboBoxNumeroAgrupacion.Items.AddRange(new object[] {
            "",
            "01",
            "02",
            "03",
            "04",
            "05"});
            this.comboBoxNumeroAgrupacion.Location = new System.Drawing.Point(1670, 21);
            this.comboBoxNumeroAgrupacion.Name = "comboBoxNumeroAgrupacion";
            this.comboBoxNumeroAgrupacion.Size = new System.Drawing.Size(70, 23);
            this.comboBoxNumeroAgrupacion.TabIndex = 10;
            this.comboBoxNumeroAgrupacion.Visible = false;
            // 
            // labelNumeroAgrupacion
            // 
            this.labelNumeroAgrupacion.AutoSize = true;
            this.labelNumeroAgrupacion.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNumeroAgrupacion.Location = new System.Drawing.Point(1635, 23);
            this.labelNumeroAgrupacion.Name = "labelNumeroAgrupacion";
            this.labelNumeroAgrupacion.Size = new System.Drawing.Size(29, 21);
            this.labelNumeroAgrupacion.TabIndex = 9;
            this.labelNumeroAgrupacion.Text = "Nº";
            this.labelNumeroAgrupacion.Visible = false;
            // 
            // comboBoxPlantillas
            // 
            this.comboBoxPlantillas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlantillas.FormattingEnabled = true;
            this.comboBoxPlantillas.Location = new System.Drawing.Point(129, 89);
            this.comboBoxPlantillas.Name = "comboBoxPlantillas";
            this.comboBoxPlantillas.Size = new System.Drawing.Size(251, 23);
            this.comboBoxPlantillas.TabIndex = 7;
            this.comboBoxPlantillas.Visible = false;
            this.comboBoxPlantillas.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlantillas_SelectedIndexChanged);
            // 
            // comboBoxAgrupaciones
            // 
            this.comboBoxAgrupaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAgrupaciones.FormattingEnabled = true;
            this.comboBoxAgrupaciones.Location = new System.Drawing.Point(1367, 21);
            this.comboBoxAgrupaciones.Name = "comboBoxAgrupaciones";
            this.comboBoxAgrupaciones.Size = new System.Drawing.Size(265, 23);
            this.comboBoxAgrupaciones.TabIndex = 6;
            this.comboBoxAgrupaciones.Visible = false;
            this.comboBoxAgrupaciones.SelectedIndexChanged += new System.EventHandler(this.comboBoxAgrupaciones_SelectedIndexChanged);
            // 
            // comboBoxEstaciones
            // 
            this.comboBoxEstaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstaciones.FormattingEnabled = true;
            this.comboBoxEstaciones.Location = new System.Drawing.Point(944, 21);
            this.comboBoxEstaciones.Name = "comboBoxEstaciones";
            this.comboBoxEstaciones.Size = new System.Drawing.Size(265, 23);
            this.comboBoxEstaciones.TabIndex = 5;
            this.comboBoxEstaciones.Visible = false;
            this.comboBoxEstaciones.SelectedIndexChanged += new System.EventHandler(this.comboBoxEstaciones_SelectedIndexChanged);
            // 
            // comboBoxExplotaciones
            // 
            this.comboBoxExplotaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExplotaciones.FormattingEnabled = true;
            this.comboBoxExplotaciones.Location = new System.Drawing.Point(129, 21);
            this.comboBoxExplotaciones.Name = "comboBoxExplotaciones";
            this.comboBoxExplotaciones.Size = new System.Drawing.Size(251, 23);
            this.comboBoxExplotaciones.TabIndex = 4;
            this.comboBoxExplotaciones.SelectedIndexChanged += new System.EventHandler(this.comboBoxExplotaciones_SelectedIndexChanged);
            // 
            // gridAtributo
            // 
            this.gridAtributo.AllowUserToAddRows = false;
            this.gridAtributo.AllowUserToDeleteRows = false;
            this.gridAtributo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAtributo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridAtributo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridAtributo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAtributo.Location = new System.Drawing.Point(62, 180);
            this.gridAtributo.Name = "gridAtributo";
            this.gridAtributo.RowHeadersVisible = false;
            this.gridAtributo.RowTemplate.Height = 25;
            this.gridAtributo.Size = new System.Drawing.Size(1371, 55);
            this.gridAtributo.TabIndex = 46;
            this.gridAtributo.Visible = false;
            this.gridAtributo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridAtributo_CellFormatting);
            // 
            // gridPlantillas
            // 
            this.gridPlantillas.AllowUserToAddRows = false;
            this.gridPlantillas.AllowUserToDeleteRows = false;
            this.gridPlantillas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPlantillas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridPlantillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlantillas.Location = new System.Drawing.Point(12, 508);
            this.gridPlantillas.Name = "gridPlantillas";
            this.gridPlantillas.RowHeadersVisible = false;
            this.gridPlantillas.RowTemplate.Height = 25;
            this.gridPlantillas.Size = new System.Drawing.Size(1300, 346);
            this.gridPlantillas.TabIndex = 13;
            this.gridPlantillas.Visible = false;
            this.gridPlantillas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridPlantillas_CellFormatting);
            this.gridPlantillas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridPlantillas_CellPainting);
            this.gridPlantillas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridPlantillas_CellValidating);
            this.gridPlantillas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPlantillas_CellValueChanged);
            // 
            // buttonAñadirSeñal
            // 
            this.buttonAñadirSeñal.Location = new System.Drawing.Point(12, 151);
            this.buttonAñadirSeñal.Name = "buttonAñadirSeñal";
            this.buttonAñadirSeñal.Size = new System.Drawing.Size(105, 23);
            this.buttonAñadirSeñal.TabIndex = 14;
            this.buttonAñadirSeñal.Text = "Añadir Señales";
            this.buttonAñadirSeñal.UseVisualStyleBackColor = true;
            this.buttonAñadirSeñal.Visible = false;
            this.buttonAñadirSeñal.Click += new System.EventHandler(this.buttonAñadirSeñal_Click);
            // 
            // buttonGuardarLista
            // 
            this.buttonGuardarLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGuardarLista.Location = new System.Drawing.Point(1655, 151);
            this.buttonGuardarLista.Name = "buttonGuardarLista";
            this.buttonGuardarLista.Size = new System.Drawing.Size(105, 23);
            this.buttonGuardarLista.TabIndex = 15;
            this.buttonGuardarLista.Text = "Crear Lista";
            this.buttonGuardarLista.UseVisualStyleBackColor = true;
            this.buttonGuardarLista.Visible = false;
            this.buttonGuardarLista.Click += new System.EventHandler(this.buttonGuardarLista_Click);
            // 
            // gridSeñales
            // 
            this.gridSeñales.AllowUserToAddRows = false;
            this.gridSeñales.AllowUserToDeleteRows = false;
            this.gridSeñales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSeñales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSeñales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSeñales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSeñales.ContextMenuStrip = this.cmMenuPreviewListas;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSeñales.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSeñales.Location = new System.Drawing.Point(12, 589);
            this.gridSeñales.Name = "gridSeñales";
            this.gridSeñales.RowTemplate.Height = 25;
            this.gridSeñales.Size = new System.Drawing.Size(1758, 265);
            this.gridSeñales.TabIndex = 17;
            this.gridSeñales.Visible = false;
            this.gridSeñales.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSeñales_CellEndEdit);
            this.gridSeñales.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridSeñales_CellFormatting);
            // 
            // cmMenuPreviewListas
            // 
            this.cmMenuPreviewListas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BorrarPreview});
            this.cmMenuPreviewListas.Name = "cmMenuPreviewListas";
            this.cmMenuPreviewListas.Size = new System.Drawing.Size(107, 26);
            this.cmMenuPreviewListas.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmMenuPreviewListas_ItemClicked);
            // 
            // BorrarPreview
            // 
            this.BorrarPreview.Name = "BorrarPreview";
            this.BorrarPreview.Size = new System.Drawing.Size(106, 22);
            this.BorrarPreview.Tag = "borrar";
            this.BorrarPreview.Text = "Borrar";
            // 
            // buttonLimpiarLista
            // 
            this.buttonLimpiarLista.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLimpiarLista.Location = new System.Drawing.Point(1318, 151);
            this.buttonLimpiarLista.Name = "buttonLimpiarLista";
            this.buttonLimpiarLista.Size = new System.Drawing.Size(95, 23);
            this.buttonLimpiarLista.TabIndex = 18;
            this.buttonLimpiarLista.Text = "Limpiar Lista";
            this.buttonLimpiarLista.UseVisualStyleBackColor = true;
            this.buttonLimpiarLista.Visible = false;
            this.buttonLimpiarLista.Click += new System.EventHandler(this.buttonLimpiarLista_Click);
            // 
            // labelCrearExplotacion
            // 
            this.labelCrearExplotacion.AutoSize = true;
            this.labelCrearExplotacion.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCrearExplotacion.Location = new System.Drawing.Point(77, 2);
            this.labelCrearExplotacion.Name = "labelCrearExplotacion";
            this.labelCrearExplotacion.Size = new System.Drawing.Size(187, 30);
            this.labelCrearExplotacion.TabIndex = 32;
            this.labelCrearExplotacion.Text = "Crear Explotación";
            this.labelCrearExplotacion.Visible = false;
            // 
            // labelCrearEstacion
            // 
            this.labelCrearEstacion.AutoSize = true;
            this.labelCrearEstacion.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCrearEstacion.Location = new System.Drawing.Point(82, 2);
            this.labelCrearEstacion.Name = "labelCrearEstacion";
            this.labelCrearEstacion.Size = new System.Drawing.Size(153, 30);
            this.labelCrearEstacion.TabIndex = 33;
            this.labelCrearEstacion.Text = "Crear Estación";
            this.labelCrearEstacion.Visible = false;
            // 
            // labelCrearListas
            // 
            this.labelCrearListas.AutoSize = true;
            this.labelCrearListas.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCrearListas.Location = new System.Drawing.Point(82, 2);
            this.labelCrearListas.Name = "labelCrearListas";
            this.labelCrearListas.Size = new System.Drawing.Size(229, 30);
            this.labelCrearListas.TabIndex = 34;
            this.labelCrearListas.Text = "Crear Lista de Señales";
            this.labelCrearListas.Visible = false;
            // 
            // labelVisualizarListas
            // 
            this.labelVisualizarListas.AutoSize = true;
            this.labelVisualizarListas.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelVisualizarListas.Location = new System.Drawing.Point(82, 2);
            this.labelVisualizarListas.Name = "labelVisualizarListas";
            this.labelVisualizarListas.Size = new System.Drawing.Size(279, 30);
            this.labelVisualizarListas.TabIndex = 35;
            this.labelVisualizarListas.Text = "Visualizar Listas de Señales";
            this.labelVisualizarListas.Visible = false;
            // 
            // gridSeñalesCreadas
            // 
            this.gridSeñalesCreadas.AllowUserToAddRows = false;
            this.gridSeñalesCreadas.AllowUserToDeleteRows = false;
            this.gridSeñalesCreadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSeñalesCreadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSeñalesCreadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSeñalesCreadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSeñalesCreadas.ContextMenuStrip = this.cmMenuGridSeñalesCreadas;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSeñalesCreadas.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridSeñalesCreadas.Location = new System.Drawing.Point(1318, 552);
            this.gridSeñalesCreadas.Name = "gridSeñalesCreadas";
            this.gridSeñalesCreadas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.gridSeñalesCreadas.RowTemplate.Height = 25;
            this.gridSeñalesCreadas.Size = new System.Drawing.Size(452, 302);
            this.gridSeñalesCreadas.TabIndex = 36;
            this.gridSeñalesCreadas.Visible = false;
            this.gridSeñalesCreadas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSeñalesCreadas_CellEndEdit);
            // 
            // cmMenuGridSeñalesCreadas
            // 
            this.cmMenuGridSeñalesCreadas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Borrar});
            this.cmMenuGridSeñalesCreadas.Name = "cmMenuGridSeñalesCreadas";
            this.cmMenuGridSeñalesCreadas.Size = new System.Drawing.Size(107, 26);
            this.cmMenuGridSeñalesCreadas.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmMenuGridSeñalesCreadas_ItemClicked);
            // 
            // Borrar
            // 
            this.Borrar.Name = "Borrar";
            this.Borrar.Size = new System.Drawing.Size(106, 22);
            this.Borrar.Tag = "borrar";
            this.Borrar.Text = "Borrar";
            // 
            // labelGridSeñalesCreadas
            // 
            this.labelGridSeñalesCreadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGridSeñalesCreadas.AutoSize = true;
            this.labelGridSeñalesCreadas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGridSeñalesCreadas.Location = new System.Drawing.Point(1318, 529);
            this.labelGridSeñalesCreadas.Name = "labelGridSeñalesCreadas";
            this.labelGridSeñalesCreadas.Size = new System.Drawing.Size(95, 15);
            this.labelGridSeñalesCreadas.TabIndex = 37;
            this.labelGridSeñalesCreadas.Text = "Señales Creadas";
            this.labelGridSeñalesCreadas.Visible = false;
            // 
            // buttonExportarExcel
            // 
            this.buttonExportarExcel.Location = new System.Drawing.Point(378, 6);
            this.buttonExportarExcel.Name = "buttonExportarExcel";
            this.buttonExportarExcel.Size = new System.Drawing.Size(108, 23);
            this.buttonExportarExcel.TabIndex = 39;
            this.buttonExportarExcel.Text = "Exportar Excel";
            this.buttonExportarExcel.UseVisualStyleBackColor = true;
            this.buttonExportarExcel.Visible = false;
            this.buttonExportarExcel.Click += new System.EventHandler(this.buttonExportarExcel_Click);
            // 
            // labelExportarExcel
            // 
            this.labelExportarExcel.AutoSize = true;
            this.labelExportarExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelExportarExcel.Location = new System.Drawing.Point(82, 2);
            this.labelExportarExcel.Name = "labelExportarExcel";
            this.labelExportarExcel.Size = new System.Drawing.Size(269, 30);
            this.labelExportarExcel.TabIndex = 40;
            this.labelExportarExcel.Text = "Exportar Listas de Señales";
            this.labelExportarExcel.Visible = false;
            // 
            // buttonAtras
            // 
            this.buttonAtras.Location = new System.Drawing.Point(507, 6);
            this.buttonAtras.Name = "buttonAtras";
            this.buttonAtras.Size = new System.Drawing.Size(152, 23);
            this.buttonAtras.TabIndex = 41;
            this.buttonAtras.Text = "Volver a Visualizar Listas";
            this.buttonAtras.UseVisualStyleBackColor = true;
            this.buttonAtras.Visible = false;
            this.buttonAtras.Click += new System.EventHandler(this.buttonAtras_Click);
            // 
            // labelEditarEstacion
            // 
            this.labelEditarEstacion.AutoSize = true;
            this.labelEditarEstacion.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEditarEstacion.Location = new System.Drawing.Point(84, 2);
            this.labelEditarEstacion.Name = "labelEditarEstacion";
            this.labelEditarEstacion.Size = new System.Drawing.Size(227, 30);
            this.labelEditarEstacion.TabIndex = 42;
            this.labelEditarEstacion.Text = "Editar/Borrar Estación";
            this.labelEditarEstacion.Visible = false;
            // 
            // gridCrearSeñales
            // 
            this.gridCrearSeñales.AllowUserToAddRows = false;
            this.gridCrearSeñales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCrearSeñales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCrearSeñales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridCrearSeñales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCrearSeñales.ContextMenuStrip = this.cmMenuGridCrearSeñales;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCrearSeñales.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridCrearSeñales.Location = new System.Drawing.Point(1318, 180);
            this.gridCrearSeñales.Name = "gridCrearSeñales";
            this.gridCrearSeñales.RowTemplate.Height = 25;
            this.gridCrearSeñales.Size = new System.Drawing.Size(452, 331);
            this.gridCrearSeñales.TabIndex = 43;
            this.gridCrearSeñales.Visible = false;
            this.gridCrearSeñales.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCrearSeñales_CellEndEdit);
            // 
            // cmMenuGridCrearSeñales
            // 
            this.cmMenuGridCrearSeñales.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BorrarGridCrearSeñales});
            this.cmMenuGridCrearSeñales.Name = "cmMenuGridCrearSeñales";
            this.cmMenuGridCrearSeñales.Size = new System.Drawing.Size(107, 26);
            this.cmMenuGridCrearSeñales.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmMenuGridCrearSeñales_ItemClicked);
            // 
            // BorrarGridCrearSeñales
            // 
            this.BorrarGridCrearSeñales.Name = "BorrarGridCrearSeñales";
            this.BorrarGridCrearSeñales.Size = new System.Drawing.Size(106, 22);
            this.BorrarGridCrearSeñales.Tag = "borrar";
            this.BorrarGridCrearSeñales.Text = "Borrar";
            // 
            // labelFiltroPlc
            // 
            this.labelFiltroPlc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFiltroPlc.AutoSize = true;
            this.labelFiltroPlc.Location = new System.Drawing.Point(1432, 514);
            this.labelFiltroPlc.Name = "labelFiltroPlc";
            this.labelFiltroPlc.Size = new System.Drawing.Size(58, 15);
            this.labelFiltroPlc.TabIndex = 44;
            this.labelFiltroPlc.Text = "Direc.PLC";
            this.labelFiltroPlc.Visible = false;
            // 
            // labelFiltroNLogico
            // 
            this.labelFiltroNLogico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFiltroNLogico.AutoSize = true;
            this.labelFiltroNLogico.Location = new System.Drawing.Point(1511, 514);
            this.labelFiltroNLogico.Name = "labelFiltroNLogico";
            this.labelFiltroNLogico.Size = new System.Drawing.Size(44, 15);
            this.labelFiltroNLogico.TabIndex = 45;
            this.labelFiltroNLogico.Text = "NºLóg.";
            this.labelFiltroNLogico.Visible = false;
            // 
            // labelFiltroCodigo
            // 
            this.labelFiltroCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFiltroCodigo.AutoSize = true;
            this.labelFiltroCodigo.Location = new System.Drawing.Point(1655, 514);
            this.labelFiltroCodigo.Name = "labelFiltroCodigo";
            this.labelFiltroCodigo.Size = new System.Drawing.Size(46, 15);
            this.labelFiltroCodigo.TabIndex = 46;
            this.labelFiltroCodigo.Text = "Código";
            this.labelFiltroCodigo.Visible = false;
            // 
            // labelFiltroNFisico
            // 
            this.labelFiltroNFisico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFiltroNFisico.AutoSize = true;
            this.labelFiltroNFisico.Location = new System.Drawing.Point(1581, 514);
            this.labelFiltroNFisico.Name = "labelFiltroNFisico";
            this.labelFiltroNFisico.Size = new System.Drawing.Size(38, 15);
            this.labelFiltroNFisico.TabIndex = 47;
            this.labelFiltroNFisico.Text = "NºFís.";
            this.labelFiltroNFisico.Visible = false;
            // 
            // textBoxFiltroCodigo
            // 
            this.textBoxFiltroCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFiltroCodigo.Location = new System.Drawing.Point(1655, 529);
            this.textBoxFiltroCodigo.Name = "textBoxFiltroCodigo";
            this.textBoxFiltroCodigo.Size = new System.Drawing.Size(115, 23);
            this.textBoxFiltroCodigo.TabIndex = 41;
            this.textBoxFiltroCodigo.Visible = false;
            this.textBoxFiltroCodigo.TextChanged += new System.EventHandler(this.textBoxFiltroCodigo_TextChanged);
            // 
            // textBoxFiltroNFisico
            // 
            this.textBoxFiltroNFisico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFiltroNFisico.Location = new System.Drawing.Point(1581, 529);
            this.textBoxFiltroNFisico.Name = "textBoxFiltroNFisico";
            this.textBoxFiltroNFisico.Size = new System.Drawing.Size(43, 23);
            this.textBoxFiltroNFisico.TabIndex = 48;
            this.textBoxFiltroNFisico.Visible = false;
            this.textBoxFiltroNFisico.TextChanged += new System.EventHandler(this.textBoxFiltroNFisico_TextChanged);
            // 
            // textBoxFiltroNLogico
            // 
            this.textBoxFiltroNLogico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFiltroNLogico.Location = new System.Drawing.Point(1511, 529);
            this.textBoxFiltroNLogico.Name = "textBoxFiltroNLogico";
            this.textBoxFiltroNLogico.Size = new System.Drawing.Size(43, 23);
            this.textBoxFiltroNLogico.TabIndex = 49;
            this.textBoxFiltroNLogico.Visible = false;
            this.textBoxFiltroNLogico.TextChanged += new System.EventHandler(this.textBoxFiltroNLogico_TextChanged);
            // 
            // textBoxFiltroPlc
            // 
            this.textBoxFiltroPlc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFiltroPlc.Location = new System.Drawing.Point(1432, 529);
            this.textBoxFiltroPlc.Name = "textBoxFiltroPlc";
            this.textBoxFiltroPlc.Size = new System.Drawing.Size(58, 23);
            this.textBoxFiltroPlc.TabIndex = 50;
            this.textBoxFiltroPlc.Visible = false;
            this.textBoxFiltroPlc.TextChanged += new System.EventHandler(this.textBoxFiltroPlc_TextChanged);
            // 
            // labelFiltroPreviewPlc
            // 
            this.labelFiltroPreviewPlc.AutoSize = true;
            this.labelFiltroPreviewPlc.Location = new System.Drawing.Point(18, 177);
            this.labelFiltroPreviewPlc.Name = "labelFiltroPreviewPlc";
            this.labelFiltroPreviewPlc.Size = new System.Drawing.Size(58, 15);
            this.labelFiltroPreviewPlc.TabIndex = 51;
            this.labelFiltroPreviewPlc.Text = "Direc.PLC";
            this.labelFiltroPreviewPlc.Visible = false;
            // 
            // textBoxFiltroPreviewDireccionPlc
            // 
            this.textBoxFiltroPreviewDireccionPlc.Location = new System.Drawing.Point(82, 173);
            this.textBoxFiltroPreviewDireccionPlc.Name = "textBoxFiltroPreviewDireccionPlc";
            this.textBoxFiltroPreviewDireccionPlc.Size = new System.Drawing.Size(58, 23);
            this.textBoxFiltroPreviewDireccionPlc.TabIndex = 52;
            this.textBoxFiltroPreviewDireccionPlc.Visible = false;
            this.textBoxFiltroPreviewDireccionPlc.TextChanged += new System.EventHandler(this.textBoxFiltroPreviewDireccionPlc_TextChanged);
            // 
            // labelFiltroPreviewNLogico
            // 
            this.labelFiltroPreviewNLogico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFiltroPreviewNLogico.AutoSize = true;
            this.labelFiltroPreviewNLogico.Location = new System.Drawing.Point(163, 176);
            this.labelFiltroPreviewNLogico.Name = "labelFiltroPreviewNLogico";
            this.labelFiltroPreviewNLogico.Size = new System.Drawing.Size(44, 15);
            this.labelFiltroPreviewNLogico.TabIndex = 53;
            this.labelFiltroPreviewNLogico.Text = "NºLóg.";
            this.labelFiltroPreviewNLogico.Visible = false;
            // 
            // textBoxFiltroPreviewNLogico
            // 
            this.textBoxFiltroPreviewNLogico.Location = new System.Drawing.Point(213, 173);
            this.textBoxFiltroPreviewNLogico.Name = "textBoxFiltroPreviewNLogico";
            this.textBoxFiltroPreviewNLogico.Size = new System.Drawing.Size(43, 23);
            this.textBoxFiltroPreviewNLogico.TabIndex = 54;
            this.textBoxFiltroPreviewNLogico.Visible = false;
            this.textBoxFiltroPreviewNLogico.TextChanged += new System.EventHandler(this.textBoxFiltroPreviewNLogico_TextChanged);
            // 
            // labelFiltroPreviewNFisico
            // 
            this.labelFiltroPreviewNFisico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFiltroPreviewNFisico.AutoSize = true;
            this.labelFiltroPreviewNFisico.Location = new System.Drawing.Point(280, 177);
            this.labelFiltroPreviewNFisico.Name = "labelFiltroPreviewNFisico";
            this.labelFiltroPreviewNFisico.Size = new System.Drawing.Size(38, 15);
            this.labelFiltroPreviewNFisico.TabIndex = 55;
            this.labelFiltroPreviewNFisico.Text = "NºFís.";
            this.labelFiltroPreviewNFisico.Visible = false;
            // 
            // textBoxFiltroPreviewNFisico
            // 
            this.textBoxFiltroPreviewNFisico.Location = new System.Drawing.Point(324, 173);
            this.textBoxFiltroPreviewNFisico.Name = "textBoxFiltroPreviewNFisico";
            this.textBoxFiltroPreviewNFisico.Size = new System.Drawing.Size(43, 23);
            this.textBoxFiltroPreviewNFisico.TabIndex = 56;
            this.textBoxFiltroPreviewNFisico.Visible = false;
            this.textBoxFiltroPreviewNFisico.TextChanged += new System.EventHandler(this.textBoxFiltroPreviewNFisico_TextChanged);
            // 
            // textBoxFiltroPreviewDescripcion
            // 
            this.textBoxFiltroPreviewDescripcion.Location = new System.Drawing.Point(476, 173);
            this.textBoxFiltroPreviewDescripcion.Name = "textBoxFiltroPreviewDescripcion";
            this.textBoxFiltroPreviewDescripcion.Size = new System.Drawing.Size(124, 23);
            this.textBoxFiltroPreviewDescripcion.TabIndex = 58;
            this.textBoxFiltroPreviewDescripcion.Visible = false;
            this.textBoxFiltroPreviewDescripcion.TextChanged += new System.EventHandler(this.textBoxFiltroPreviewDescripcion_TextChanged);
            // 
            // labelFiltroPreviewDescripcion
            // 
            this.labelFiltroPreviewDescripcion.AutoSize = true;
            this.labelFiltroPreviewDescripcion.Location = new System.Drawing.Point(401, 177);
            this.labelFiltroPreviewDescripcion.Name = "labelFiltroPreviewDescripcion";
            this.labelFiltroPreviewDescripcion.Size = new System.Drawing.Size(69, 15);
            this.labelFiltroPreviewDescripcion.TabIndex = 57;
            this.labelFiltroPreviewDescripcion.Text = "Descripción";
            this.labelFiltroPreviewDescripcion.Visible = false;
            // 
            // labelFiltroPreviewCodigo
            // 
            this.labelFiltroPreviewCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFiltroPreviewCodigo.AutoSize = true;
            this.labelFiltroPreviewCodigo.Location = new System.Drawing.Point(636, 176);
            this.labelFiltroPreviewCodigo.Name = "labelFiltroPreviewCodigo";
            this.labelFiltroPreviewCodigo.Size = new System.Drawing.Size(46, 15);
            this.labelFiltroPreviewCodigo.TabIndex = 59;
            this.labelFiltroPreviewCodigo.Text = "Código";
            this.labelFiltroPreviewCodigo.Visible = false;
            // 
            // textBoxFiltroPreviewCodigo
            // 
            this.textBoxFiltroPreviewCodigo.Location = new System.Drawing.Point(688, 173);
            this.textBoxFiltroPreviewCodigo.Name = "textBoxFiltroPreviewCodigo";
            this.textBoxFiltroPreviewCodigo.Size = new System.Drawing.Size(115, 23);
            this.textBoxFiltroPreviewCodigo.TabIndex = 60;
            this.textBoxFiltroPreviewCodigo.Visible = false;
            this.textBoxFiltroPreviewCodigo.TextChanged += new System.EventHandler(this.textBoxFiltroPreviewCodigo_TextChanged);
            // 
            // labelAñadirAtributo
            // 
            this.labelAñadirAtributo.AutoSize = true;
            this.labelAñadirAtributo.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAñadirAtributo.Location = new System.Drawing.Point(84, 2);
            this.labelAñadirAtributo.Name = "labelAñadirAtributo";
            this.labelAñadirAtributo.Size = new System.Drawing.Size(169, 30);
            this.labelAñadirAtributo.TabIndex = 61;
            this.labelAñadirAtributo.Text = "Añadir Atributo";
            this.labelAñadirAtributo.Visible = false;
            // 
            // gridExcel
            // 
            this.gridExcel.AllowUserToAddRows = false;
            this.gridExcel.AllowUserToDeleteRows = false;
            this.gridExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridExcel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridExcel.Location = new System.Drawing.Point(13, 649);
            this.gridExcel.Name = "gridExcel";
            this.gridExcel.RowTemplate.Height = 25;
            this.gridExcel.Size = new System.Drawing.Size(1747, 205);
            this.gridExcel.TabIndex = 62;
            this.gridExcel.Visible = false;
            // 
            // labelCrearDatalogger
            // 
            this.labelCrearDatalogger.AutoSize = true;
            this.labelCrearDatalogger.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCrearDatalogger.Location = new System.Drawing.Point(87, 2);
            this.labelCrearDatalogger.Name = "labelCrearDatalogger";
            this.labelCrearDatalogger.Size = new System.Drawing.Size(183, 30);
            this.labelCrearDatalogger.TabIndex = 63;
            this.labelCrearDatalogger.Text = "Crear Datalogger";
            this.labelCrearDatalogger.Visible = false;
            // 
            // labelEditarBorrarDatalogger
            // 
            this.labelEditarBorrarDatalogger.AutoSize = true;
            this.labelEditarBorrarDatalogger.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEditarBorrarDatalogger.Location = new System.Drawing.Point(87, 2);
            this.labelEditarBorrarDatalogger.Name = "labelEditarBorrarDatalogger";
            this.labelEditarBorrarDatalogger.Size = new System.Drawing.Size(257, 30);
            this.labelEditarBorrarDatalogger.TabIndex = 64;
            this.labelEditarBorrarDatalogger.Text = "Editar/Borrar Datalogger";
            this.labelEditarBorrarDatalogger.Visible = false;
            // 
            // AppListaSeñales
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1772, 858);
            this.Controls.Add(this.labelEditarBorrarDatalogger);
            this.Controls.Add(this.labelCrearDatalogger);
            this.Controls.Add(this.gridExcel);
            this.Controls.Add(this.labelAñadirAtributo);
            this.Controls.Add(this.textBoxFiltroPreviewCodigo);
            this.Controls.Add(this.labelFiltroPreviewCodigo);
            this.Controls.Add(this.gridAtributo);
            this.Controls.Add(this.textBoxFiltroPreviewDescripcion);
            this.Controls.Add(this.labelFiltroPreviewDescripcion);
            this.Controls.Add(this.textBoxFiltroPreviewNFisico);
            this.Controls.Add(this.labelFiltroPreviewNFisico);
            this.Controls.Add(this.textBoxFiltroPreviewNLogico);
            this.Controls.Add(this.labelFiltroPreviewNLogico);
            this.Controls.Add(this.textBoxFiltroPreviewDireccionPlc);
            this.Controls.Add(this.labelFiltroPreviewPlc);
            this.Controls.Add(this.textBoxFiltroPlc);
            this.Controls.Add(this.textBoxFiltroNLogico);
            this.Controls.Add(this.textBoxFiltroNFisico);
            this.Controls.Add(this.textBoxFiltroCodigo);
            this.Controls.Add(this.labelFiltroNFisico);
            this.Controls.Add(this.labelFiltroCodigo);
            this.Controls.Add(this.labelFiltroNLogico);
            this.Controls.Add(this.labelFiltroPlc);
            this.Controls.Add(this.gridCrearSeñales);
            this.Controls.Add(this.labelEditarEstacion);
            this.Controls.Add(this.buttonAtras);
            this.Controls.Add(this.labelExportarExcel);
            this.Controls.Add(this.buttonExportarExcel);
            this.Controls.Add(this.labelGridSeñalesCreadas);
            this.Controls.Add(this.gridSeñalesCreadas);
            this.Controls.Add(this.labelVisualizarListas);
            this.Controls.Add(this.labelCrearListas);
            this.Controls.Add(this.labelCrearEstacion);
            this.Controls.Add(this.labelCrearExplotacion);
            this.Controls.Add(this.buttonLimpiarLista);
            this.Controls.Add(this.gridSeñales);
            this.Controls.Add(this.buttonGuardarLista);
            this.Controls.Add(this.buttonAñadirSeñal);
            this.Controls.Add(this.gridPlantillas);
            this.Controls.Add(this.logoutLinkLabel);
            this.Controls.Add(this.panelInteraccion);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.inicioLinkLabel);
            this.Controls.Add(this.panelMenuPrincipal);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "AppListaSeñales";
            this.Text = "AppListaSeñales";
            this.Load += new System.EventHandler(this.AppListaSeñales_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelMenuPrincipal.ResumeLayout(false);
            this.panelInteraccion.ResumeLayout(false);
            this.panelInteraccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtributo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlantillas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSeñales)).EndInit();
            this.cmMenuPreviewListas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSeñalesCreadas)).EndInit();
            this.cmMenuGridSeñalesCreadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCrearSeñales)).EndInit();
            this.cmMenuGridCrearSeñales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label tituloLogin;
        private System.Windows.Forms.Label usuarioLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usuarioTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label errorLoginLabel1;
        private System.Windows.Forms.Label errorLogin2;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelMenuPrincipal;
        private System.Windows.Forms.Button visualizarListaSeñales;
        private System.Windows.Forms.Button crearListaButton;
        private System.Windows.Forms.Button crearEstacionButton;
        private System.Windows.Forms.Button crearExplotacionButton;
        private System.Windows.Forms.LinkLabel inicioLinkLabel;
        private System.Windows.Forms.LinkLabel logoutLinkLabel;
        private System.Windows.Forms.Label explotacionListaLabel;
        private System.Windows.Forms.Label estacionListaLabel;
        private System.Windows.Forms.Label agrupacionListaLabel;
        private System.Windows.Forms.Label plantillaListaLabel;
        private System.Windows.Forms.Panel panelInteraccion;
        private System.Windows.Forms.ComboBox comboBoxPlantillas;
        private System.Windows.Forms.ComboBox comboBoxAgrupaciones;
        private System.Windows.Forms.ComboBox comboBoxEstaciones;
        private System.Windows.Forms.ComboBox comboBoxExplotaciones;
        private System.Windows.Forms.DataGridView gridPlantillas;
        private ComboBox comboBoxNumeroAgrupacion;
        private Label labelNumeroAgrupacion;
        private Button buttonAñadirSeñal;
        private Button buttonGuardarLista;
        private LinkLabel linkLabelConsignas;
        private LinkLabel linkLabelTelemandos;
        private LinkLabel linkLabelContadores;
        private LinkLabel linkLabelDigitales;
        private LinkLabel linkLabelAnalogicas;
        private DataGridView gridSeñales;
        private ComboBox comboBoxSitAquacis;
        private Label labelSitAquacis;
        private Button buttonCrearExplotacion;
        private Button buttonCrearEstacion;
        private TextBox textBoxCrearEstacion;
        private TextBox textBoxNumeroEstacion;
        private Label labelNumeroEstacion;
        private TextBox textBoxCebeIas;
        private Label labelCebeIas;
        private TextBox textBoxCebeAquacis;
        private Label labelCebeAquacis;
        private ComboBox comboBoxComunicaciones;
        private Label labelComunicacion;
        private TextBox textBoxMinRaw;
        private Label labelMinRaw;
        private TextBox textBoxMaxRaw;
        private Label labelMaxRaw;
        private Button buttonLimpiarLista;
        private Label labelCrearExplotacion;
        private Label labelCrearEstacion;
        private Label labelCrearListas;
        private Label labelVisualizarListas;
        private DataGridView gridSeñalesCreadas;
        private Label labelGridSeñalesCreadas;
        private PictureBox pictureBoxExcel;
        private Button buttonExportarExcel;
        private Label labelExportarExcel;
        private Button buttonAtras;
        private Button buttonBorrarEstacion;
        private Button buttonEditarEstacion;
        private Button buttonEditarBorrarEstacion;
        private Label labelEditarEstacion;
        private ContextMenuStrip cmMenuGridSeñalesCreadas;
        private ToolStripMenuItem Borrar;
        private DataGridView gridCrearSeñales;
        private ContextMenuStrip cmMenuGridCrearSeñales;
        private ToolStripMenuItem BorrarGridCrearSeñales;
        private ContextMenuStrip cmMenuPreviewListas;
        private ToolStripMenuItem BorrarPreview;
        private Label labelFiltroPlc;
        private Label labelFiltroNLogico;
        private Label labelFiltroCodigo;
        private Label labelFiltroNFisico;
        private TextBox textBoxFiltroCodigo;
        private TextBox textBoxFiltroNFisico;
        private TextBox textBoxFiltroNLogico;
        private TextBox textBoxFiltroPlc;
        private Label labelFiltroPreviewPlc;
        private TextBox textBoxFiltroPreviewDireccionPlc;
        private Label labelFiltroPreviewNLogico;
        private TextBox textBoxFiltroPreviewNLogico;
        private Label labelFiltroPreviewNFisico;
        private TextBox textBoxFiltroPreviewNFisico;
        private TextBox textBoxFiltroPreviewDescripcion;
        private Label labelFiltroPreviewDescripcion;
        private Label labelFiltroPreviewCodigo;
        private TextBox textBoxFiltroPreviewCodigo;
        private PictureBox pictureBoxPdf;
        private Label labelDCDC;
        private Button buttonAñadirAtributo;
        private Label labelAñadirAtributo;
        private Label labelInstancia;
        private Button buttonCrearAtributo;
        private DataGridView gridAtributo;
        private ComboBox comboBoxAtributo;
        private Label labelAtributo;
        private DataGridView gridExcel;
        private TextBox textBoxNumeroEsclavo;
        private Label labelNumeroEsclavo;
        private Button buttonImportarCSV;
        private Label labelCrearDatalogger;
        private Button buttonCrearDatalogger;
        private TextBox textBoxNumeroDatalogger;
        private Label labelNumeroDatalogger;
        private TextBox textBoxNumeroAgrupacion;
        private Label labelNumeroAgrupacionDl;
        private Label labelNombreDatalogger;
        private Button buttonCrearDataloggerInsert;
        private ComboBox comboBoxTipoDl;
        private Label labelTipoDl;
        private TextBox textBoxZonaSectorizacion;
        private Label labelZonaSectorizacion;
        private TextBox textBoxHorasComunicacion;
        private Label labelHorasComunicacion;
        private TextBox textBoxPuerto;
        private Label labelPuerto;
        private TextBox textBoxIP;
        private Label labelIP;
        private TextBox textBoxNumeroPunto;
        private Label labelNumeroPunto;
        private TextBox textBoxNombreDatalogger;
        private Button buttonEditarBorrarDatalogger;
        private ComboBox comboBoxNombreDatalogger;
        private Button buttonBorrarDatalogger;
        private Button buttonEditarDatalogger;
        private Label labelEditarBorrarDatalogger;
    }
}

