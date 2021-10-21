using RimWorld;
using UnityEngine;
using Verse;
using HarmonyLib;

namespace QualityExpanded
{
    [HarmonyPatch]
    public class QualityLoss
    {
        [HarmonyPatch(typeof(ListerBuildingsRepairable), "Notify_BuildingTookDamage")]
        [HarmonyPostfix]
        public static void BuildingQualityLoss_Damaged(Building b)
        {
            if (Settings_QE.bldgDeteriorates) CheckQualityLoss(b);
        }

        [HarmonyPatch(typeof(ListerBuildingsRepairable), "Notify_BuildingSpawned")]
        [HarmonyPostfix]
        public static void BuildingQualityLoss_Spawned(Building b)
        {
            if (Settings_QE.bldgDeteriorates) CheckQualityLoss(b);
        }

        [HarmonyPatch(typeof(Pawn_ApparelTracker), "TakeWearoutDamageForDay")]
        [HarmonyPostfix]
        public static void ApparelQualityLoss_Daily(Thing ap)
        {
            if (Settings_QE.appDeteriorates) CheckQualityLoss(ap);
        }

        [HarmonyPatch(typeof(Pawn_ApparelTracker), "Notify_ApparelChanged")]
        [HarmonyPostfix]
        public static void ApparelQualityLoss_Changed(Thing apparel)
        {
            if (Settings_QE.appDeteriorates) CheckQualityLoss(apparel);
        }

        [HarmonyPatch(typeof(ArmorUtility), "ApplyArmor")]
        [HarmonyPostfix]
        public static void ArmorQualityLoss_Absorbed(Thing armorThing)
        {
            if (Settings_QE.appDeteriorates && armorThing != null) CheckQualityLoss(armorThing);
        }

        [HarmonyPatch(typeof(Pawn_EquipmentTracker), "Notify_EquipmentRemoved")]
        [HarmonyPostfix]
        public static void EquipmentQualityLoss_Unequip(ThingWithComps eq)
        {
            if (Settings_QE.weapDeteriorates) CheckQualityLoss(eq);
        }

        [HarmonyPatch(typeof(Pawn_EquipmentTracker), "Notify_EquipmentAdded")]
        [HarmonyPostfix]
        public static void EquipmentQualityLoss_Equip(ThingWithComps eq)
        {
            if (Settings_QE.weapDeteriorates) CheckQualityLoss(eq);
            Log.Message(eq.Label + " added to equipment");
        }

        public static void CheckQualityLoss(Thing thing)
        {
            CompQuality comp = thing.TryGetComp<CompQuality>(); Log.Message("Checking for quality loss for " + thing.Label);
            if (comp == null) 
                return;
            int quality = (int)comp.Quality;
            if (quality <= 0) 
                return;
            float num = 1f;
            if (quality > 4 && thing.TryGetComp<CompArt>()?.TaleRef != null)
            {
                num += quality - 4;
                quality = 4;
            }
            float factor = Quality_HitPoints.GetQualityFactor((QualityCategory)(quality - 1)); //Log.Message("Chance is " + ((float)(1f - thing.HitPoints / (thing.MaxHitPoints * factor)) / num).ToString());
            if (Rand.Value < (1f - thing.HitPoints / (thing.MaxHitPoints * factor)) / num)
            {
                comp.SetQuality((QualityCategory)(quality - 1), ArtGenerationContext.Colony); Log.Message("Lost quality");
            }
        }
    }
}