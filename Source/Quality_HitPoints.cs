using RimWorld;
using UnityEngine;
using Verse;
using HarmonyLib;

namespace QualityExpanded
{
    [HarmonyPatch]
    public class Quality_HitPoints
    {
        [HarmonyPatch(typeof(Thing), "MaxHitPoints", MethodType.Getter)]
        [HarmonyPostfix]
        [HarmonyPriority(Priority.High)]
        public static void GetMaxHitPoints(ref int __result, out int __state)
        {
            __state = __result;
        }

        [HarmonyPatch(typeof(Thing), "MaxHitPoints", MethodType.Getter)]
        [HarmonyPostfix]
        [HarmonyPriority(Priority.VeryLow)]
        public static void AdjustMaxHitPoints(ref int __result, Thing __instance, int __state)
        {
            if (__instance.def.building != null)
            {
                if (!Settings_QE.bldgHitQual) return;
            }
            else if (__instance.def.IsStuff)
            {
                if (!Settings_QE.stuffHitQual) return;
            }
            else if (__instance.def.IsIngestible)
            {
                if (!Settings_QE.ingHitQual) return;
            }
            else if (__instance.def.IsWeapon)
            {
                if (!Settings_QE.weapHitQual) return;
            }
            else if (__instance.def.IsApparel)
            {
                if (!Settings_QE.appHitQual) return;
            }
            else if (!Settings_QE.otherHitQual) return;
            CompQuality comp = __instance.TryGetComp<CompQuality>();
            if (comp != null)
            {
                __result = Mathf.RoundToInt(__state * GetQualityFactor(comp.Quality));
            }
            return;
        }

        [HarmonyPatch(typeof(CompQuality), "SetQuality")]
        [HarmonyPostfix]
        public static void AdjustCurHitPoints(CompQuality __instance)
        {
            __instance.parent.HitPoints = __instance.parent.MaxHitPoints;
        }

        public static float GetQualityFactor(QualityCategory q)
        {
            //Log.Message("Getting Quality Factor");
            switch (q)
            {
                case QualityCategory.Awful:
                    return Settings_QE.awfulHit;  
                case QualityCategory.Poor:
                    return Settings_QE.poorHit;
                case QualityCategory.Normal:
                    return Settings_QE.normalHit;
                case QualityCategory.Good:
                    return Settings_QE.goodHit;
                case QualityCategory.Excellent:
                    return Settings_QE.excHit;
                case QualityCategory.Masterwork:
                    return Settings_QE.masterHit;
                case QualityCategory.Legendary:
                    return Settings_QE.legHit;
                default:
                    return 1f;
            }
        }
    }
}
