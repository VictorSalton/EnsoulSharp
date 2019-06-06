using Easy_Sup.scripts;
using EnsoulSharp;
using EnsoulSharp.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_Sup
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEvent.OnGameLoad += On_LoadGame;
        }
        private static void On_LoadGame()
        {
            Chat.PrintChat("Supported Champions: Blitz , Soraka");
            if (ObjectManager.Player.CharacterName == "Soraka")
            {
                Soraka.Load();
                Chat.PrintChat("Soraka Script Load");
            }
            else if (ObjectManager.Player.CharacterName == "Blitzcrank")
            {
                Blitz.BlitzOnLoad();
                Chat.PrintChat("Blitzcrank Script Load");
                Chat.PrintChat("This script is a Port of KurisuBlitz (Code of Kurisu)");
            }
        }
    }
}
