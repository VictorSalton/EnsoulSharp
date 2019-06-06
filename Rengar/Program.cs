using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.Utility;
using Rengar.Properties;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rengar
{
    class Program
    {
        private static Render.Sprite Intro;

        private static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }

        private static void OnGameLoad()
        {
            if (ObjectManager.Player.CharacterName != "Rengar")
            {
                return;
            }
            Chat.PrintChat("Simple Rengar Script Load");
            Chat.PrintChat("011110001");
            Rengar_.OnLoad();

            Intro = new Render.Sprite(LoadImg("logo"), new Vector2(Drawing.Width / 2 - 500, Drawing.Height / 2 - 350));
            Intro.Add(0);
            Intro.OnDraw();

            DelayAction.Add(7000, () => Intro.Remove());

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
