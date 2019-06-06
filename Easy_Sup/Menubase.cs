using EnsoulSharp.SDK.MenuUI.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_Sup
{
    class Menubase
    {
        //SORAKA
        public class soraka_combat
        {
            public static readonly MenuBool Q = new MenuBool("q", "Use Q");
            public static readonly MenuBool E = new MenuBool("e", "Use E");
        }

        public class soraka_heal
        {
            public static readonly MenuBool W = new MenuBool("w", "Auto use W");
            public static readonly MenuSlider allyHeal = new MenuSlider("aHeal", "Ally Health Percent",75,1,100);
            public static readonly MenuSlider myHeal = new MenuSlider("myHeal", "My Health Percent", 45, 1, 100);
        }

        public class soraka_ultimate
        {
            public static readonly MenuBool R = new MenuBool("r", "Auto use R");
            public static readonly MenuSlider rHeal = new MenuSlider("rHeal", "Health Percent", 35, 1, 100);
        }

        public class soraka_draw
        {
            public static readonly MenuBool Dq = new MenuBool("dq", "Draw Q");
            public static readonly MenuBool Dw = new MenuBool("dw", "Draw W");
            public static readonly MenuBool De = new MenuBool("de", "Draw E");
        }
        public class soraka_harass
        {
            public static readonly MenuBool Qh = new MenuBool("qh", "Use Q");
            public static readonly MenuBool Eh = new MenuBool("eh", "Use E");
        }

        public class blitz_combat
        {
            public static readonly MenuBool Qb = new MenuBool("q", "Use Q");
            public static readonly MenuBool Wb = new MenuBool("w", "Use W");
            public static readonly MenuBool Eb = new MenuBool("e", "Use E");
            public static readonly MenuBool Rb = new MenuBool("r", "Use R");
            public static readonly MenuSlider Rcount = new MenuSlider("Rcount", "^ Min enemies for use R", 2, 1, 5);
            public static readonly MenuSlider qhit = new MenuSlider("hitchanceq", "Q Hitchance 1-Low, 4-Very High", 3, 1, 4);
        }

        //Blitz
        public class blitz_ks
        {
            public static readonly MenuBool Qks = new MenuBool("Qks", "Use Q to KS");
            public static readonly MenuBool Rks = new MenuBool("Rks", "Use R to KS");
        }

        public class blitz_harass
        {
            public static readonly MenuBool Qh = new MenuBool("Qh", "Use Q to Harass");
        }

        public class blitz_misc
        {
            public static readonly MenuBool Qint = new MenuBool("Qint", "Q to Interrupt");
            public static readonly MenuBool Qdash = new MenuBool("Qdash", "Q on Dash");
            public static readonly MenuBool Rint = new MenuBool("Rint", "R to Interrupt");
            public static readonly MenuBool Qii = new MenuBool("Qii", "Q on Immobile Enemies");

        }

        public class blitz_draw
        {
            public static readonly MenuBool Dq = new MenuBool("dq", "Draw Q");
            public static readonly MenuBool Dr = new MenuBool("de", "Draw R");
        }

      
    }
}
