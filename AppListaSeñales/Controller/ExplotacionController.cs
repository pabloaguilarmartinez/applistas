using AppListaSeñales.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AppListaSeñales.Controller
{
    public class ExplotacionController
    {
        private readonly ExplotacionService explotacionService;

        #region Constructor
        public ExplotacionController()
        {
            this.explotacionService = new ExplotacionService();
        }
        #endregion

        public void findNombreExplotacionesSinCrear(ComboBox comboBoxExplotaciones)
        {
            DataTable nombreExplotaciones = explotacionService.findNombreExplotacionesSinCrear();
            comboBoxExplotaciones.DisplayMember = "nombre";
            comboBoxExplotaciones.DataSource = nombreExplotaciones;
        }

        public void crearExplotacion(ComboBox comboBoxExplotaciones, TextBox cebeIas)
        {
            if (comboBoxExplotaciones.Text.Equals("") || cebeIas.Text.Equals(""))
            {
                MessageBox.Show("Rellene todos los campos.");
            }
            else
            {
                if (cebeIas.Text.Length != 3)
                {
                    MessageBox.Show("El acrónimo de DCDC debe tener 3 carácteres.");
                }
                else
                {
                    if (explotacionService.updateCebeIas(comboBoxExplotaciones.Text, cebeIas.Text))
                    {
                        MessageBox.Show("Explotación creada.");
                    }
                    else
                    {
                        MessageBox.Show("Error al crear la explotación");
                    }
                }
            }
        }

        public void findCebeAquacisByNombre(ComboBox comboBoxExplotaciones, TextBox textBoxCebeAquacis)
        {
            textBoxCebeAquacis.Text = explotacionService.findCebeAquacisByNombre(comboBoxExplotaciones.Text);
        }
    }
}
