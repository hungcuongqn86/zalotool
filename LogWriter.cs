using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace transtrusttool
{
    public class LogWriter
    {
        private string m_exePath = string.Empty;
        public string filename = "logs.txt";
        public LogWriter(string logMessage)
        {
            LogWrite(logMessage);
        }
        public void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                string logPath = m_exePath + "\\logs";
                bool exists = System.IO.Directory.Exists(logPath);
                if (!exists)
                    System.IO.Directory.CreateDirectory(logPath);
                using (StreamWriter w = File.AppendText(logPath + "\\" + filename))
                {
                    Log(logMessage, w);
                }
            }
            catch
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("{0} {1}: {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), logMessage);
            }
            catch
            {
            }
        }
    }
}
