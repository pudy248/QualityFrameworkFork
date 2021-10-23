using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using RimWorld;
using Verse;
using HarmonyLib;

namespace QualityExpanded
{
    [StaticConstructorOnStartup]
    class StatPatch
    {
        static StatPatch()
        {
            Log.Message("Patch running");
            if (ModLister.HasActiveModWithName("Quality Framework")) Settings_QE.qualFramework = true;
            StatDef def;
            StatPart part;

            //Buildings
            if (!Settings_QE.resQuality)
            {
                Log.Message("Looking for research speed");
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.ResearchSpeedFactor.defName);
                if (def?.parts != null) Log.Message("Found " + def.defName);
                for (int i = 0; i < def.parts.Count; i++)
                {
                    part = def.parts[i];
                    if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    Log.Message("Quality Part removed");
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
