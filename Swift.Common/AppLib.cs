using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.Common
{
    public static class AppLib
    {
        public static string WriteLogState = "";
        public static void WriteLog(String str)
        {
            if (Common.AppLib.WriteLogState.ToLower() != "off")
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(Path.GetTempPath() + "SwiftAppDemo_log.txt", true))
                    {
                        writer.WriteLine(string.Format("{0:dd/MM/yyyy hh:mm:ss} => {1}", DateTime.Now, str));
                    }
                }
                catch (Exception) { }
            }

        }
        public static void WriteLog(Exception ex)
        {
            WriteLog(string.Format("Error=> ExMessage:{0},StackTrace:{1}", ex.Message, ex.StackTrace));
        }
    }
}
