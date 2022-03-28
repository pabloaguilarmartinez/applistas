using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AppListaSeñales.Utils
{
    class Excel
    {
        public static void extraerExcel(DataGridView grid)
        {
            String codigoEstacion = grid.Rows[0].Cells["Automatico"].Value.ToString().Substring(0, 11);
            String nombreEstacion = grid.Rows[0].Cells["Descripcion"].Value.ToString().Split("-")[1];
            String fecha = DateTime.Now.ToString("ddMMyyyy");
            // Crear Aplicación Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // Crear libro con la aplicación Excel      
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // Crear nueva hoja      
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;      
            // see the excel sheet behind the program      
            app.Visible = false;      
            // get the reference of first sheet. By default its name is Sheet1.     
            // store its reference to worksheet      
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Hoja1"];      
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;      
            // changing the name of active sheet      
            worksheet.Name = "Hoja1"; 
            // storing header part in Excel      
            for (int i = 1; i < grid.Columns.Count + 1; i++) 
            {          
                worksheet.Cells[1, i] = grid.Columns[i - 1].HeaderText;      
            }      
            // storing Each row and column value to excel sheet      
            for (int i = 0; i < grid.Rows.Count; i++) 
            {
                for (int j = 0; j < grid.Columns.Count; j++) 
                {   
                    if (grid.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = grid.Rows[i].Cells[j].Value;      
                    }          
                }      
            } 
            // Selección del fichero csv a crear
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            String fic = "";
            dialog.Description = "Seleccione una carpeta";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fic = dialog.SelectedPath + "\\DCDC - LS " + codigoEstacion + " - " + nombreEstacion + " " + fecha + ".xlsx";
            }
            // Guardar Aplicación     
            workbook.SaveAs(fic, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);      
            // Cerrar Aplicación    
            app.Quit();  
        }

    }
}
