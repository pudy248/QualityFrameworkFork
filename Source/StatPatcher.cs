using RimWorld;
using Verse;

namespace QualityExpanded
{
    [StaticConstructorOnStartup]
    class StatPatcher
    {
        static StatPatcher()
        {
            if (ModLister.HasActiveModWithName("Quality Framework"))
            {
                Settings_QE.qualFramework = true;
            }
            //Log.Message("Patch running");
            StatDef def;
            StatPart part;

            //Vanilla Factors
            if (!Settings_QE.beautyQuality)
            {
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.Beauty.defName);
                if (def?.parts != null) //Log.Message("Found " + def.defName);
                    for (int i = 0; i < def.parts.Count; i++)
                    {
                        part = def.parts[i];
                        if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    }
            }
            if (!Settings_QE.bedQuality)
            {
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.BedRestEffectiveness.defName);
                if (def?.parts != null) //Log.Message("Found " + def.defName);
                    for (int i = 0; i < def.parts.Count; i++)
                    {
                        part = def.parts[i];
                        if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    }
            }
            if (!Settings_QE.comfortQuality)
            {
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.Comfort.defName);
                if (def?.parts != null) //Log.Message("Found " + def.defName);
                    for (int i = 0; i < def.parts.Count; i++)
                    {
                        part = def.parts[i];
                        if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    }
            }
            if (!Settings_QE.deteriorationQuality)
            {
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.DeteriorationRate.defName);
                if (def?.parts != null) //Log.Message("Found " + def.defName);
                    for (int i = 0; i < def.parts.Count; i++)
                    {
                        part = def.parts[i];
                        if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    }
            }


            //Buildings
            if (!Settings_QE.resQuality)
            {
                //Log.Message("Looking for research speed");
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.ResearchSpeedFactor.defName);
                if (def?.parts != null) //Log.Message("Found " + def.defName);
                for (int i = 0; i < def.parts.Count; i++)
                {
                    part = def.parts[i];
                    if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    //Log.Message("Quality Part removed");
                }
            }
            if (!Settings_QE.workQuality)
            {
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.WorkTableWorkSpeedFactor.defName);
                if (def?.parts != null)
                for (int i = 0; i < def.parts.Count; i++)
                {
                    part = def.parts[i];
                    if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                }
            }
            if (!Settings_QE.doorQuality)
            {
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.DoorOpenSpeed.defName);
                if (def?.parts != null)
                    for (int i = 0; i < def.parts.Count; i++)
                    {
                        part = def.parts[i];
                        if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    }
            }
            if (!Settings_QE.rangedQuality)
            {
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.RangedWeapon_Cooldown.defName);
                if (def?.parts != null)
                    for (int i = 0; i < def.parts.Count; i++)
                    {
                        part = def.parts[i];
                        if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    }
            }
            if (!Settings_QE.meleeQuality)
            {
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.MeleeWeapon_CooldownMultiplier.defName);
                if (def?.parts != null)
                    for (int i = 0; i < def.parts.Count; i++)
                    {
                        part = def.parts[i];
                        if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    }
            }
            if (!Settings_QE.trapQuality)
			{
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.TrapMeleeDamage.defName);
                if (def?.parts != null)
                    for (int i = 0; i < def.parts.Count; i++)
                    {
                        part = def.parts[i];
                        if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    }
			}
			if (!Settings_QE.foodQuality)
			{
				def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.Nutrition.defName);
				if (def?.parts != null)
					for (int i = 0; i < def.parts.Count; i++)
					{
						part = def.parts[i];
						if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
					}
			}
			if (!Settings_QE.medQuality)
            {
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.MedicalPotency.defName);
                if (def?.parts != null)
                    for (int i = 0; i < def.parts.Count; i++)
                    {
                        part = def.parts[i];
                        if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    }
            }
            /*if (!Settings_QE.turretQuality)
            {
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.ShootingAccuracyTurret.defName);
                if (def?.parts != null)
                    for (int i = 0; i < def.parts.Count; i++)
                    {
                        part = def.parts[i];
                        if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    }
            }*/
        }
    }
}
