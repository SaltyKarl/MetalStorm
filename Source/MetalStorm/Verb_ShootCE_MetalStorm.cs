using CombatExtended;
using RimWorld;
using UnityEngine;
using Verse.Sound;
using Verse;

namespace MetalStorm
{
    public class Verb_ShootCE_MetalStorm : Verb_ShootCE
    {
        public override bool TryCastShot()
        {
            //Reduce ammunition
            if (CompAmmo != null)
            {
                if (ShooterPawn != null && CompAmmo.CurrentAmmo.GetModExtension<MetalStormCasingReturn>().returnCasing != null)
                {
                    Thing thing = ThingMaker.MakeThing(CompAmmo.CurrentAmmo.GetModExtension<MetalStormCasingReturn>().returnCasing);
                    thing.stackCount = 1;
                    ShooterPawn.inventory.innerContainer.TryAdd(thing);
                }

                if (!CompAmmo.TryReduceAmmoCount(((CompAmmo.Props.ammoSet != null) ? CompAmmo.Props.ammoSet.ammoConsumedPerShot : 1) * VerbPropsCE.ammoConsumedPerShotCount))
                {
                    return false;
                }
            }
            if (base.TryCastShot())
            {
                return OnCastSuccessful();
            }
            return false;
        }
    }
}
