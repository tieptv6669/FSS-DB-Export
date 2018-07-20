using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FssDbExp
{
    public class Logger
    {
        public static string pathLogFile = "AppLog" + "\\";

        public static void Logging(string msgLog, string timeLog)
        {
            string fileName = DateTime.Now.ToString("dd/MM/yyyy").Replace("/", "_") + ".txt";
            string path = pathLogFile + fileName;

            if (!Directory.Exists(pathLogFile))
            {
                Directory.CreateDirectory(pathLogFile);
            }
        
            File.AppendAllText(path, msgLog + " " + timeLog + Environment.NewLine);
        }
    }
}
