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
    class DefPatch
    {
        static DefPatch()
        {
            Log.Message("Patch running");
            StatDef def;
            StatPart part;
            if (!Settings_QE.resQuality)
            {
                Log.Message("Looking for research speed");
                def = DefDatabase<StatDef>.GetNamedSilentFail(StatDefOf.ResearchSpeedFactor.defName);
                if (def != null) Log.Message("Found " + def.defName);
                for (int i = 0; i < def.parts.Count; i++)
                {
                    part = def.parts[i];
                    if (part.GetType() == typeof(StatPart_Quality)) def.parts.RemoveAt(i);
                    Log.Message("Quality Part removed");
                }
            }
        }

    }
}
