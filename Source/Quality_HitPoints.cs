using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static int AdjustMaxHitPoints(int __result, Thing __instance)
        {
            CompQuality comp = __instance.TryGetComp<CompQuality>();
            if (comp != null)
            {
                //return Mathf.RoundToInt(__result * GetQualityFactor(comp.Quality));
            }
            return __result;
        }

        [HarmonyPatch(typeof(CompQuality), "SetQuality")]
        [HarmonyPostfix]
        public static void AdjustCurHitPoints(CompQuality __instance)
        {
            if (__instance.parent.HitPoints > __instance.parent.MaxHitPoints)
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
