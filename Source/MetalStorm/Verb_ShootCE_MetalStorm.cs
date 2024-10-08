﻿using CombatExtended;
using Verse;

namespace MetalStorm
{
    public class Verb_ShootCE_MetalStorm : Verb_ShootCE
    {
        public override bool TryCastShot()
        {
            if (ShooterPawn is not null && CompAmmo.CurrentAmmo.GetModExtension<MetalStormCasingReturn>().returnCasing is not null)
            {
                Thing thing = ThingMaker.MakeThing(CompAmmo.CurrentAmmo.GetModExtension<MetalStormCasingReturn>().returnCasing);
                thing.stackCount = 1;
                ShooterPawn.inventory.innerContainer.TryAdd(thing);
            }
            return base.TryCastShot();
        }
    }
}
