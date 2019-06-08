using Easy_Sup.Properties;
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
            logo = new Render.Sprite(LoadImg("lgo"), new Vector2(Drawing.Width / 2 - 250, Drawing.Height / 2 - 250));
            logo.Add(0);
            logo.OnDraw();

            DelayAction.Add(7000, () => logo.Remove());

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
            else if (ObjectManager.Player.CharacterName == "Alistar")
            {
                Alistar.OnLoad();
            }
        }

        public static Bitmap LoadImg(string imgName)
        {
            var bitmap = Resources.ResourceManager.GetObject(imgName) as Bitmap;
            if (bitmap == null)
            {
                Console.WriteLine(imgName + ".png not found.");
            }
            return bitmap;
        }
    }
}
