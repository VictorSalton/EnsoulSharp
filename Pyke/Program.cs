using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Prediction;
using SPrediction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyke
{
    class Program
    {

        private static Spell Q, W, E, R, Q2;
        private static Menu geral;

        static void Main(string[] args)
        {
            GameEvent.OnGameLoad += On_LoadGame;
            Chat.PrintChat("Pyke");
        }

        private static void On_LoadGame()
        {
            Q = new Spell(SpellSlot.Q, 400f);
            Q.SetSkillshot(0.25f, 70f, 2000, true, SkillshotType.Line);
            Q.SetCharged("PykeQ", "PykeQ", 400, 1030, 3);
            E = new Spell(SpellSlot.E, 550f);
            E.SetSkillshot(0.275f, 70f, 500f, false, SkillshotType.Line);
            R = new Spell(SpellSlot.R, 750f);
            R.SetSkillshot(0.25f, 100f, float.MaxValue, false, SkillshotType.Circle);

            Q2 = new Spell(SpellSlot.Q, 350f);
            Q2.SetSkillshot(0.25f, 70f, 500f, false, SkillshotType.Line);
            CreateMenu();
            Game.OnTick += OnTick;
        }

        private static void CreateMenu()
        {
            var geral = new Menu("menu.base", "011110001.Pyke", true);

            var Combat = new Menu("combat", "Combo Settings");
            Combat.Add(PykeMenu.Combat.Q);
            Combat.Add(PykeMenu.Combat.Qhit);
            Combat.Add(PykeMenu.Combat.E);
            Combat.Add(PykeMenu.Combat.R);
            Combat.Add(PykeMenu.Combat.Rkill);

            var harass = new Menu("harass", "Harass Settings");
            harass.Add(PykeMenu.Harass.Q);
            harass.Add(PykeMenu.Harass.E);

            var clear = new Menu("Clear", "Lane Clear Settings");
            clear.Add(PykeMenu.Clear.Ec);
            clear.Add(PykeMenu.Clear.ehit);

            var ks = new Menu("killsteal", "KillSteal Settings");
            ks.Add(PykeMenu.KS.R);

            var misc = new Menu("misc", "Misc Settings");
            misc.Add(PykeMenu.misc.Qin);
            misc.Add(PykeMenu.misc.Qgap);

            var pred = new Menu("spred", "Spred");

            geral.Add(Combat);
            geral.Add(harass);
            geral.Add(clear);
            geral.Add(ks);
            //geral.Add(misc);
            geral.Add(pred);
            Prediction.Initialize(pred);
            geral.Attach();

        }

        private static void OnTick(EventArgs args)
        {
            if (PykeMenu.KS.R.Enabled)
                KS();
            switch (Orbwalker.ActiveMode)
            {
                case OrbwalkerMode.Combo:
                    Combo();
                    break;
                case OrbwalkerMode.Harass:
                    Harass();
                    break;
                case OrbwalkerMode.LaneClear:
                    Clear();
                    break;
            }
        }


        private static void KS()
        {
            var al = GameObjects.EnemyHeroes.Where(x => !x.IsDead &&  x.IsEnemy &&!x.IsInvulnerable && x.Health < R.GetDamage(x, DamageStage.Empowered) && x.DistanceToPlayer() < R.Range);
            var t = al.FirstOrDefault(x => x.IsValidTarget(R.Range));
            if (t != null && !ObjectManager.Player.IsRecalling())
            {
                R.SPredictionCast(t, HitChance.Medium);
            }
        }

        private static void Harass()
        {
            if (!Q.IsCharging && E.IsReady() && PykeMenu.Combat.E.Enabled)
            {
                var target = TargetSelector.GetTarget(E.Range);
                if (target != null && target.IsValidTarget(E.Range))
                {
                    var pred = E.GetSPrediction(target);
                    if (pred.HitChance >= HitChance.High)
                    {
                        E.SPredictionCast(target, HitChance.High);
                    }
                }
            }
            var qvalue = PykeMenu.Combat.Qhit.Value;
            var qhit = HitChance.High;
            switch (qvalue)
            {
                case 1:
                    qhit = HitChance.Low;
                    break;
                case 2:
                    qhit = HitChance.Medium;
                    break;
                case 3:
                    qhit = HitChance.High;
                    break;
                case 4:
                    qhit = HitChance.VeryHigh;
                    break;
            }
            if (Q.IsReady() && PykeMenu.Combat.Q.Enabled)
            {
                var target = TargetSelector.GetTarget(Q.ChargedMaxRange);
                if (target != null && target.IsValidTarget(Q.ChargedMaxRange))
                {
                    if (target.DistanceToPlayer() < 300)
                    {
                        Q2.Cast(target);
                    }
                    var pred = Q.GetPrediction(target);
                    if (pred.Hitchance >= HitChance.Medium)
                    {
                        Q.StartCharging();
                    }
                }
            }
            if (Q.IsReady() && Q.IsCharging)
            {
                var target = TargetSelector.GetTarget(Q.Range);
                if (target != null && target.IsValidTarget(Q.Range))
                {
                    var pred = Q.GetSPrediction(target);
                    if (pred.HitChance >= HitChance.High)
                    {
                        Q.ShootChargedSpell(pred.CastPosition);
                    }
                }
            }
        }

        private static void Combo()
        {
            if (!Q.IsCharging && E.IsReady() && PykeMenu.Combat.E.Enabled)
            {
                var target = TargetSelector.GetTarget(E.Range);
                if (target != null && target.IsValidTarget(E.Range))
                {
                    var pred = E.GetSPrediction(target);
                    if (pred.HitChance >= HitChance.High)
                    {
                        E.SPredictionCast(target, HitChance.High);
                    }
                }
            }
            var qvalue = PykeMenu.Combat.Qhit.Value;
            var qhit = HitChance.High;
            switch (qvalue)
            {
                case 1:
                    qhit = HitChance.Low;
                    break;
                case 2:
                    qhit = HitChance.Medium;
                    break;
                case 3:
                    qhit = HitChance.High;
                    break;
                case 4:
                    qhit = HitChance.VeryHigh;
                    break;
            }
            if (Q.IsReady() && PykeMenu.Combat.Q.Enabled)
            {
                var target = TargetSelector.GetTarget(Q.ChargedMaxRange);
                if (target != null && target.IsValidTarget(Q.ChargedMaxRange))
                {
                    if (target.DistanceToPlayer() < 300)
                    {
                        Q2.Cast(target);
                    }
                    var pred = Q.GetSPrediction(target);
                    if (pred.HitChance >= qhit)
                    {
                        Q.StartCharging();
                    }
                }
            }
            if (Q.IsReady() && Q.IsCharging)
            {
                var target = TargetSelector.GetTarget(Q.Range);
                if (target != null && target.IsValidTarget(Q.Range))
                {
                    var pred = Q.GetSPrediction(target);
                    if (pred.HitChance >= qhit)
                    {
                        Q.ShootChargedSpell(pred.CastPosition);
                    }
                }
            }
            if (R.IsReady() && PykeMenu.Combat.R.Enabled)
            {
                var rt = TargetSelector.GetTarget(R.Range);
                if (rt != null && rt.IsValidTarget(R.Range))
                {
                    if (PykeMenu.Combat.Rkill.Enabled && rt.Health > R.GetDamage(rt, DamageStage.Empowered))
                    {
                        return;
                    }
                    R.SPredictionCast(rt, HitChance.High);
                }
            }
        }
        private static void Clear()
        {

            if (PykeMenu.Clear.Ec && E.IsReady())
            {
                var minions = GameObjects.EnemyMinions.Where(x => x.IsValidTarget(E.Range) && x.IsMinion())
                            .Cast<AIBaseClient>().ToList();

                if (minions.Any())
                {
                    var eFarmLocation = E.GetLineFarmLocation(minions);
                    if (eFarmLocation.Position.IsValid() && eFarmLocation.MinionsHit >= PykeMenu.Clear.ehit.Value)
                    {
                        E.Cast(eFarmLocation.Position);
                    }
                }
            }
        }
    }
}
