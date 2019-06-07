using EnsoulSharp.SDK.MenuUI.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyke
{
    class PykeMenu
    {
        public class Combat
        {
            public static readonly MenuBool Q = new MenuBool("q", "Use [Q]");
            public static readonly MenuSlider Qhit = new MenuSlider("qhit", "^ Q Hitchance = 1-Low ~ 4-Very High", 3, 1, 4);
            public static readonly MenuBool E = new MenuBool("e", "Use [E]");
            public static readonly MenuBool Etower = new MenuBool("Etower", "^ Don't use if enemy is under turret");
            public static readonly MenuBool R = new MenuBool("r", "Use [R]");
            public static readonly MenuBool Rkill = new MenuBool("rkill", "^Only if Enemy is Killable");
        }
        public class Clear
        {
            public static readonly MenuBool Ec = new MenuBool("ec", "Use [E]");
            public static readonly MenuSlider ehit = new MenuSlider("ehit", "^ Min. Minions Hit to use E", 3, 1, 6);
        }
        public class Harass
        {
            public static readonly MenuBool Q = new MenuBool("qh", "Use [Q]");
            public static readonly MenuBool E = new MenuBool("eh", "Use [E]");
        }
        public class KS
        {
            public static readonly MenuBool R = new MenuBool("rks", "Use [R]");
        }
        public class misc
        {
            public static readonly MenuBool Qin = new MenuBool("qin", "Use [Q] to interrupt");
            public static readonly MenuBool Qgap = new MenuBool("qgap", "Use [Q] on gapcloser");
        }
    }
}
