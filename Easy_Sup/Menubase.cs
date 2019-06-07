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


        public class lux_q
        {
            public static readonly MenuBool Q = new MenuBool("q", "Use Q - Light Binding on Combo/Harass");
            public static readonly MenuBool autoQ = new MenuBool("autoQ", "Auto Q on CC'd/Slow targets");
            public static readonly MenuBool gap = new MenuBool("gap", "Q on Gapcloser");
        }
        public class lux_w
        {
            public static readonly MenuBool W = new MenuBool("w", "Use W - Super Magical Barrier");
            public static readonly MenuBool autoW = new MenuBool("autoW", "Auto [W] on Turrets/Targetted Spells");
            public static readonly MenuSlider Wper = new MenuSlider("Wper", "^ W Heal Percent", 65, 0, 100);
        }
        public class lux_e
        {
            public static readonly MenuBool E = new MenuBool("e", "Use E - Lucent Singularity on Combo/Harass");
        }
        public class lux_r
        {
            public static readonly MenuBool R = new MenuBool("r", "Use R - Finales Funkeln");
            public static readonly MenuBool Rkill = new MenuBool("rkill", "Only use R if enemy is Killable");
            public static readonly MenuBool Raoe = new MenuBool("raoe", "Use R [AOE]", false);
            public static readonly MenuSlider Rcount = new MenuSlider("rcount", "^ Min Enemies Hit Count", 3, 1, 5);
            public static readonly MenuBool autoR = new MenuBool("autor", "If Q hits target auto R", false);
        }
        public class lux_ks
        {
            public static readonly MenuBool ksQ = new MenuBool("ksQ", "Use Q");
            public static readonly MenuBool ksE = new MenuBool("ksE", "Use E");
            public static readonly MenuBool ksR = new MenuBool("ksR", "Use R");
        }
        public class lux_clear
        {
            public static readonly MenuBool clearQ = new MenuBool("clearQ", "Use Q");
            public static readonly MenuSlider Qcount = new MenuSlider("qcount", "^ [Q] Minion Count", 2, 1, 2);
            public static readonly MenuBool clearE = new MenuBool("clearE", "Use E");
            public static readonly MenuSlider Ecount = new MenuSlider("Ecount", "^ [E] Minion Count", 3, 1, 6);
            public static readonly MenuSlider mana = new MenuSlider("mana", "^ Only clear if mana >= X%", 60, 0, 100);
        }

        public class lux_steal
        {
            public static readonly MenuBool steal = new MenuBool("steal", "Use R to Steal");
            public static readonly MenuBool blue = new MenuBool("blue", "Blue");
            public static readonly MenuBool red = new MenuBool("red", "Red");
            public static readonly MenuBool dragon = new MenuBool("dragon", "Dragon");
            public static readonly MenuBool baron = new MenuBool("baron", "Baron");

        }

    }
}
