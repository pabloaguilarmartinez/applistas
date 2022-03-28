using AppListaSeñales.Entity;
using AppListaSeñales.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AppListaSeñales.Controller
{
    public class EstacionController
    {
        private readonly EstacionService estacionService;
        private readonly ExplotacionService explotacionService;

        public EstacionController()
        {
            this.estacionService = new EstacionService();
            this.explotacionService = new ExplotacionService();
        }

        public void createEstacion(ComboBox comboBoxExplotaciones, ComboBox comboBoxSitAquacis, TextBox textBoxEstacion, 
            TextBox textBoxNumero, TextBox minRaw, TextBox maxRaw, ComboBox comunicaciones, TextBox textBoxNumeroEsclavo)
        {
            if (comboBoxExplotaciones.Text.Equals("") || comboBoxSitAquacis.Text.Equals("") || textBoxEstacion.Text.Equals("") || textBoxNumero.Text.Equals("")
                || minRaw.Text.Equals("") || maxRaw.Text.Equals("") || comunicaciones.Text.Equals("") || textBoxNumeroEsclavo.Text.Equals(""))
            {
                MessageBox.Show("Rellene todos los campos.");
            }
            else
            {
                int idExplotacion = explotacionService.findIdByExplotacion(comboBoxExplotaciones.Text, comboBoxSitAquacis.Text);
                if (estacionService.createEstacion(textBoxEstacion.Text, Convert.ToInt32(textBoxNumero.Text), 
                    idExplotacion, Convert.ToDecimal(minRaw.Text), Convert.ToDecimal(maxRaw.Text), comunicaciones.Text, Convert.ToInt32(textBoxNumeroEsclavo.Text)))
                {
                    MessageBox.Show("Estación creada.");
                }
                else
                {
                    MessageBox.Show("Error al crear la estación.");
                }
            }
        }

        public void updateEstacion(ComboBox comboBoxEstaciones, TextBox textBoxNumero, TextBox minRaw, TextBox maxRaw, ComboBox comunicaciones, TextBox textBoxNumeroEsclavo)
        {
            if (comboBoxEstaciones.Text.Equals("") || textBoxNumero.Text.Equals("")
                || minRaw.Text.Equals("") || maxRaw.Text.Equals("") || comunicaciones.Text.Equals("") || textBoxNumeroEsclavo.Text.Equals(""))
            {
                MessageBox.Show("Rellene todos los campos.");
            }
            else
            {
                if (estacionService.updateEstacion(comboBoxEstaciones.Text, Convert.ToInt32(textBoxNumero.Text), 
                    Convert.ToDecimal(minRaw.Text), Convert.ToDecimal(maxRaw.Text), comunicaciones.Text, Convert.ToInt32(textBoxNumeroEsclavo.Text)))
                {
                    MessageBox.Show("Estación actualizada.");
                }
                else
                {
                    MessageBox.Show("Error al actualizar la estación");
                }
            }
        }

        public void deleteEstacion(ComboBox comboBoxEstaciones, ComboBox comboBoxExplotaciones)
        {
            if (comboBoxEstaciones.Text.Equals("") || comboBoxExplotaciones.Text.Equals(""))
            {
                MessageBox.Show("Seleccione estación.");
            }
            else
            {
                if (estacionService.deleteEstacion(comboBoxEstaciones.Text, comboBoxExplotaciones.Text))
                {
                    MessageBox.Show("Estación borrada.");
                }
                else
                {
                    MessageBox.Show("Error al borrar la estación.");
                }
            }
        }

        public void findNombreExplotaciones(ComboBox comboBoxExplotaciones)
        {
            DataTable nombreExplotaciones = explotacionService.findNombreExplotacionesCreadas();
            comboBoxExplotaciones.DisplayMember = "nombre";
            comboBoxExplotaciones.DataSource = nombreExplotaciones;
        }

        public Estacion findEstacionByNombreEstacionAndNombreExplotacion(ComboBox comboBoxEstaciones, ComboBox comboBoxExplotaciones, ComboBox comboBoxSitAquacis)
        {
            return estacionService.findEstacionByNombreEstacionAndNombreExplotacion(comboBoxEstaciones.Text, comboBoxExplotaciones.Text, comboBoxSitAquacis.Text);
        }
    }
}
