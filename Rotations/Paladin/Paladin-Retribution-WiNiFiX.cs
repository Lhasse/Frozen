﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Frozen.Helpers;

namespace Frozen.Rotation
{
    public class Paladin_Retribution : CombatRoutine
    {
        public override string Name => "Frozen Retribution";

        public override string Class => "Paladin";

        public override Form SettingsForm
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }


        public override void Initialize()
        {
            Log.DrawHorizontalLine();
            Log.WriteFrozen("Welcome to Frozen Retributin", Color.Black);
            Log.Write("Supported Talents: 2132212", Color.Red);
        }

        public override void Stop()
        {
        }

        public override void Pulse()
        {
            if (!WoW.HasTarget || WoW.TargetIsFriend)
            {
                if (!WoW.PlayerHasBuff("Greater Blessing of Kings"))
                    if (WoW.CanCast("Greater Blessing of Kings"))
                    {
                        WoW.CastSpell("Greater Blessing of Kings");
                        return;
                    }

                if (!WoW.PlayerHasBuff("Greater Blessing of Wisdom"))
                    if (WoW.CanCast("Greater Blessing of Wisdom"))
                    {
                        WoW.CastSpell("Greater Blessing of Wisdom");
                        return;
                    }
                //Log.Write("Player Spec: " + WoW.PlayerSpec);
                //Log.Write("Player Race: " + WoW.PlayerRace);
                Log.Write("Rotation On: " + WoW.RotationOn);
            }

            if (!WoW.HasTarget || !WoW.TargetIsEnemy) return;

            if (WoW.CanCast("Judgment") && WoW.UnitPower >= 5)
            {
                WoW.CastSpell("Judgment");
                return;
            }

            if (WoW.UnitPower == 0 && WoW.CanCast("Wake of Ashes"))
            {
                WoW.CastSpell("Wake of Ashes");
                return;
            }

            if (WoW.CanCast("Crusade") && WoW.UnitPower >= 5 && WoW.TargetHasDebuff("Judgment"))
            {
                WoW.CastSpell("Crusade");
                return;
            }

            //if (WoW.CanCast("Avenging Wrath") && WoW.UnitPower >= 5 && WoW.TargetHasDebuff("Judgment")) {
            //    WoW.CastSpell("Avenging Wrath");
            //    return;
            //}

            if (WoW.CanCast("Execution Sentence") && WoW.UnitPower >= 3 && WoW.TargetHasDebuff("Judgment") &&
                !WoW.TargetHasDebuff("Execution Sentence"))
            {
                WoW.CastSpell("Execution Sentence");
                return;
            }

            if (WoW.CanCast("Templars Verdict") && WoW.UnitPower >= 3 && WoW.TargetHasDebuff("Judgment"))
            {
                WoW.CastSpell("Templars Verdict");
                return;
            }

            if (WoW.CanCast("Blade of Justice") && WoW.UnitPower <= 3
            ) // Higher Priority because it can generate 2 holy power in 1 go
            {
                WoW.CastSpell("Blade of Justice");
                return;
            }

            if (WoW.CanCast("Crusader Strike") && WoW.UnitPower < 5 && WoW.PlayerSpellCharges("Crusader Strike") >= 0)
            {
                WoW.CastSpell("Crusader Strike");
                return;
            }

            if (WoW.CanCast("Blade of Justice"))
            {
                WoW.CastSpell("Blade of Justice");
            }
        }
    }
}