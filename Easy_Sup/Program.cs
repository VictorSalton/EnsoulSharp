using Easy_Sup.scripts;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.Utility;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_Sup
{
    class Program
    {
        private static Render.Sprite logo;

        static void Main(string[] args)
        {
            GameEvent.OnGameLoad += On_LoadGame;
        }
        private static void On_LoadGame()
        {

            Chat.PrintChat("Supported Champions: Blitz , Soraka, Lux, Pyke");
            Chat.PrintChat("SPrediction Port By Mask");
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
            else if (ObjectManager.Player.CharacterName == "Lux")
            {
                Lux.Load();
                Chat.PrintChat("Partial Port of ChewyMoon Lux Load");
            }
            else if (ObjectManager.Player.CharacterName == "Pyke")
            {
                Pyke.On_Load();
                Chat.PrintChat("011110001.Pyke Load");
            }
            else if (ObjectManager.Player.CharacterName == "Thresh")
            {
                Thresh.OnLoad();
                Chat.PrintChat("011110001.Thresh Load");
            }
        }
    }
}
