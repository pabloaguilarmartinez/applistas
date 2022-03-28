using System;

namespace AppListaSeñales.Utils
{
    public class Log
    {
        private static System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\logAppListas.txt", true);
        public static void Logger(String log)
        {
            sw.WriteLine(DateTime.Now + ": " + log);
            //Quitar si no funciona el logger
            LoggerClose();
        }

        public static void LoggerClose()
        {
            sw.Close();
        }
    }
}
