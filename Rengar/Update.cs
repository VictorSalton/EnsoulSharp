using EnsoulSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rengar
{
    class Update
    {
        public static void Check()
        {
            try
            {
                using (var wb = new WebClient())
                {
                    var raw = wb.DownloadString("https://raw.githubusercontent.com/011110001/EnsoulSharp/master/Rengar/Version.txt");

                    System.Version Version = Assembly.GetExecutingAssembly().GetName().Version;

                    if(raw != Version.ToString())
                    {
                        Chat.Print("<font color=\"#ff0000\">Rengar is outdated! Please update to {0}!</font>", raw);
                    }
                }

            }
            catch
            {
                Chat.Print("<font color=\"#ff0000\">Failed to verify script version!</font>");
            }
        }
    }
}
