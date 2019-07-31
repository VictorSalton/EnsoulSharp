using EnsoulSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zed_is_Back_Bitches
{
    class Update
    {
        public static void Check()
        {
            try
            {
                using (var wb = new System.Net.WebClient())
                {
                    var raw = wb.DownloadString("https://raw.githubusercontent.com/011110001/EnsoulSharp/master/Zed%20is%20Back%20Bitches/Version.txt");

                    System.Version Version = Assembly.GetExecutingAssembly().GetName().Version;

                    if (raw != Version.ToString())
                    {
                        Chat.Print("<font color=\"#ff0000\">Zed is Back Bitches is outdated! Please update to {0}!</font>", raw);
                    }
                    else
                        Chat.Print("<font color=\"#ff0000\">Zed is Back Bitches is updated! Version : {0}!</font>", Version.ToString());
                }

            }
            catch
            {
                Chat.Print("<font color=\"#ff0000\">Failed to verify script version!</font>");
            }
        }
    }
}
