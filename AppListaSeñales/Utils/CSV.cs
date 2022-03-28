using AppListaSeñales.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppListaSeñales.Utils
{
    class CSV
    {
        public static Tuple<bool, Dictionary<string, Señal>>  importarCSV(Stream fileStream, int idEstacion)
        {
            bool revisarNumerosLogicoFisico = false;
            string line;
            Dictionary<string, Señal> listaSeñales = new Dictionary<string, Señal>();
            using (StreamReader reader = new StreamReader(fileStream))
            {

                while ((line = reader.ReadLine()) != null)
                {
                    if (line != null && !line.Equals("") && line.Substring(0, 1).Equals("$") && (!line.Split(";")[5].Substring(0, 1).Equals("N")
                        || line.Split(";")[5].Substring(0, 1).Equals("N_PULS")) && !line.Split(";")[5].Equals("V_QMAX") && !line.Split(";")[5].Equals("V_QMIN")
                        && !line.Split(";")[5].Equals("V_QMED"))
                    {
                        //Construimos la señal
                        Señal señal = new Señal();
                        //Descripción
                        señal.Descripcion = line.Split(";")[6];
                        //Tagname señal
                        señal.Codigo = line.Split(";")[4] + "." + line.Split(";")[5];
                        //Si se historiza la señal
                        if (line.Split(";")[13].Equals("Si"))
                        {
                            señal.Historico = "Yes";
                        }
                        else
                        {
                            señal.Historico = line.Split(";")[13];
                        }
                        //Si tiene alarma, esto es para las digitales
                        señal.Alarma = line.Split(";")[22];
                        //Dirección de PLC
                        señal.DireccionPlc = line.Split(";")[14];
                        //Id de la estación a la que pertenece
                        señal.IdEstacion = idEstacion;
                        //Unidad
                        señal.Unidad = line.Split(";")[12];
                        //OnMsg
                        señal.OnMsg = line.Split(";")[21];
                        //OffMsg
                        señal.OffMsg = line.Split(";")[20];
                        //Tag InTouch
                        señal.Tag = line.Split(";")[15];
                        //Número lógico o físico
                        if (!String.IsNullOrEmpty(señal.Tag))
                        {
                            if ((señal.Tag.Substring(0, 2).Equals("ED") || señal.Tag.Substring(0, 2).Equals("EA")) && (señal.Tag.Length == 9 || señal.Tag.Length == 10) 
                                && int.TryParse(señal.Tag.Substring(2, 4), out int i))
                            {
                                señal.NumeroFisico = Convert.ToInt32(señal.Tag.Substring(2, 4));
                            }
                            else if ((señal.Tag.Substring(0, 2).Equals("IN") || señal.Tag.Substring(0, 2).Equals("CT") 
                                || señal.Tag.Substring(0, 2).Equals("CS") || señal.Tag.Substring(0, 2).Equals("PC") 
                                || señal.Tag.Substring(0, 2).Equals("TM") || señal.Tag.Substring(0, 2).Equals("CA"))
                                && (señal.Tag.Length == 9 || señal.Tag.Length == 10) && int.TryParse(señal.Tag.Substring(2, 4), out int j))
                            {
                                señal.NumeroLogico = Convert.ToInt32(señal.Tag.Substring(2, 4));
                            }
                            else
                            {
                                revisarNumerosLogicoFisico = true;
                            }
                        }
                        //Inversión señal digital
                        señal.Invertida = line.Split(";")[24];
                        //EngUnits y Raw
                        if (!String.IsNullOrEmpty(line.Split(";")[8]))
                        {
                            señal.MinRaw = Convert.ToDecimal(line.Split(";")[8].Replace(".", ","));
                        }
                        if (!String.IsNullOrEmpty(line.Split(";")[9]))
                        {
                            if (Decimal.Compare(Convert.ToDecimal(line.Split(";")[9].Replace(".", ",")), Convert.ToDecimal(999999999)) > 0)
                            {
                                señal.MaxRaw = 999999999;
                            }
                            else
                            {
                                señal.MaxRaw = Convert.ToDecimal(line.Split(";")[9].Replace(".", ","));
                            }
                            
                        }
                        if (!String.IsNullOrEmpty(line.Split(";")[10]))
                        {
                            señal.MinEngUnits = Convert.ToDecimal(line.Split(";")[10].Replace(".", ","));
                        }
                        if (!String.IsNullOrEmpty(line.Split(";")[11]))
                        {
                            if (Decimal.Compare(Convert.ToDecimal(line.Split(";")[11].Replace(".", ",")), Convert.ToDecimal(999999999)) > 0)
                            {
                                señal.MaxEngUnits = 999999999;
                            }
                            else
                            {
                                señal.MaxEngUnits = Convert.ToDecimal(line.Split(";")[11].Replace(".", ","));
                            }                   
                        }
                        // Comprobamos si la señal está a VAR_0
                        if (line.Split(";")[11].Equals("Sistema_SUEZ.#_False"))
                        {
                            señal.VarCero = true;
                        }
                        //Añadimos señal a la lista
                        listaSeñales.Add(señal.Codigo, señal);
                    }
                }
            }
            return Tuple.Create(revisarNumerosLogicoFisico, listaSeñales);
        }
    }
}
