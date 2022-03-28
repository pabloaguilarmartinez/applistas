using AppListaSeñales.Entity;
using AppListaSeñales.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AppListaSeñales.Controller
{
    class DataloggerController
    {
        private readonly ExplotacionService explotacionService;
        private readonly DataloggerService dataloggerService;

        public DataloggerController()
        {
            this.dataloggerService = new DataloggerService();
            this.explotacionService = new ExplotacionService();
        }

        public void findNombreExplotaciones(ComboBox comboBoxExplotaciones)
        {
            DataTable nombreExplotaciones = explotacionService.findNombreExplotacionesCreadas();
            comboBoxExplotaciones.DisplayMember = "nombre";
            comboBoxExplotaciones.DataSource = nombreExplotaciones;
        }

        public void createDatalogger(ComboBox comboBoxExplotaciones, ComboBox comboBoxSitAquacis, TextBox textBoxDatalogger,
            TextBox textBoxNumeroAgrupacion, TextBox textBoxNumeroDatalogger, TextBox textBoxNumeroPunto, ComboBox comboBoxTipo, TextBox textBoxPuerto, TextBox textBoxIP, TextBox textBoxHoras, TextBox textBoxZona)
        {
            if (comboBoxExplotaciones.Text.Equals("") || comboBoxSitAquacis.Text.Equals("") || textBoxDatalogger.Text.Equals("") || textBoxNumeroAgrupacion.Text.Equals("") || textBoxNumeroDatalogger.Text.Equals("")
                || comboBoxTipo.Text.Equals(""))
            {
                MessageBox.Show("Debe rellenar los campos de explotación, nombre y número de datalogger, número de agrupación y tipo.");
            }
            else
            {
                int idExplotacion = explotacionService.findIdByExplotacion(comboBoxExplotaciones.Text, comboBoxSitAquacis.Text);
                if (dataloggerService.createDatalogger(textBoxDatalogger.Text, textBoxNumeroDatalogger.Text, idExplotacion, textBoxNumeroAgrupacion.Text, comboBoxTipo.Text, textBoxPuerto.Text, textBoxHoras.Text, textBoxZona.Text, textBoxIP.Text, textBoxNumeroPunto.Text))
                {
                    MessageBox.Show("Datalogger creado.");
                }
                else
                {
                    MessageBox.Show("Error al crear el datalogger.");
                }
            }
        }

        public void updateDatalogger(ComboBox comboBoxExplotaciones, ComboBox comboBoxSitAquacis, ComboBox textBoxDatalogger,
            TextBox textBoxNumeroAgrupacion, TextBox textBoxNumeroDatalogger, TextBox textBoxNumeroPunto, ComboBox comboBoxTipo, TextBox textBoxPuerto, TextBox textBoxIP, TextBox textBoxHoras, TextBox textBoxZona)
        {
            if (comboBoxExplotaciones.Text.Equals("") || comboBoxSitAquacis.Text.Equals("") || textBoxDatalogger.Text.Equals("") || textBoxNumeroAgrupacion.Text.Equals("") || textBoxNumeroDatalogger.Text.Equals("")
                || comboBoxTipo.Text.Equals(""))
            {
                MessageBox.Show("Debe rellenar los campos de explotación, nombre y número de datalogger, número de agrupación y tipo.");
            }
            else
            {
                int idExplotacion = explotacionService.findIdByExplotacion(comboBoxExplotaciones.Text, comboBoxSitAquacis.Text);
                if (dataloggerService.updateDatalogger(textBoxDatalogger.Text, textBoxNumeroDatalogger.Text, idExplotacion, textBoxNumeroAgrupacion.Text, comboBoxTipo.Text, textBoxPuerto.Text, 
                    textBoxHoras.Text, textBoxZona.Text, textBoxIP.Text, textBoxNumeroPunto.Text))
                {
                    MessageBox.Show("Datalogger actualizado.");
                }
                else
                {
                    MessageBox.Show("Error al actualizar el datalogger.");
                }
            }
        }

        public void deleteDatalogger(ComboBox comboBoxDatalogger, ComboBox comboBoxExplotaciones, ComboBox comboBoxSitAquacis)
        {
            if (comboBoxDatalogger.Text.Equals("") || comboBoxExplotaciones.Text.Equals("") || comboBoxSitAquacis.Text.Equals(""))
            {
                MessageBox.Show("Seleccione datalogger.");
            }
            else
            {
                if (dataloggerService.deleteDatalogger(comboBoxDatalogger.Text, comboBoxExplotaciones.Text, comboBoxSitAquacis.Text))
                {
                    MessageBox.Show("Datalogger borrado.");
                }
                else
                {
                    MessageBox.Show("Error al borrar el datalogger.");
                }
            }
        }

        public Datalogger findDataloggerByNombreDataloggerAndNombreExplotacion(ComboBox comboBoxDatalogger, ComboBox comboBoxExplotaciones, ComboBox comboBoxSitAquacis)
        {
            return dataloggerService.findDataloggerByNombreDataloggerAndNombreExplotacion(comboBoxDatalogger.Text, comboBoxExplotaciones.Text, comboBoxSitAquacis.Text);
        }

        public void findNombreDataloggersByNombreExplotacion(ComboBox comboBoxDataloggers, ComboBox comboBoxExplotaciones, ComboBox comboBoxSitAquacis)
        {
            DataTable nombreDataloggers = dataloggerService.findByNombreExplotacion(comboBoxExplotaciones.Text, comboBoxSitAquacis.Text);
            comboBoxDataloggers.DisplayMember = "nombre";
            comboBoxDataloggers.DataSource = nombreDataloggers;
        }
    }
}
