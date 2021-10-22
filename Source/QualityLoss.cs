using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;
using HarmonyLib;

namespace QualityExpanded
{
    [HarmonyPatch]
    public class QualityLoss : MapComponent
    {
        public int lastQualityLossTick = -1;
        public bool qualFramework = false;

        public QualityLoss(Map map) : base(map)
        {
        }

        public override void MapComponentTick()
        {
            int ticksGame = Find.TickManager.TicksGame;
            if (lastQualityLossTick < 0)
            {
                lastQualityLossTick = ticksGame;
            }
            int curTicks = ticksGame - lastQualityLossTick;
            if (curTicks >= 60000)
            {
                lastQualityLossTick = ticksGame;
                if (Settings_QE.weapHitQual && Settings_QE.weapDeteriorates)
                {
                    CheckWeapons();
                }
                if (Settings_QE.otherDeteriorates && qualFramework)
                {
                    CheckOther();
                }
            }
        }

        public void CheckWeapons()
        {
            Thing thing;
            List<Pawn> colonists = map.mapPawns.FreeColonistsSpawned;
            if (colonists != null)
            {
                for (int i = 0; i < colonists.Count; i++)
                {
                    Pawn_EquipmentTracker eq = colonists[i].equipment;
                    if (eq != null && eq.HasAnything())
                    {
                        for (int j = 0; j < eq.AllEquipmentListForReading.Count; j++)
                        {
                            thing = eq.AllEquipmentListForReading[j];
                            if (!thing.def.IsIngestible && !thing.def.IsStuff)
                            {
                                CheckQualityLoss(thing);
                            }
                        }
                    }
                }
            }
            List<Thing> weapons = map.listerThings.ThingsInGroup(ThingRequestGroup.Weapon);
            if (weapons != null)
            {
                for (int j = 0; j < weapons.Count; j++)
                {
                    thing = weapons[j];
                    if (!thing.def.IsIngestible && !thing.def.IsStuff)
                    {
                        CheckQualityLoss(thing);
                    }
                }
            }
        }

        public void CheckOther()
        {
            Thing thing;
            List<Thing> things = map.listerThings.ThingsInGroup(ThingRequestGroup.HaulableAlways);
            for (int i = 0; i < things.Count; i++)
            {
                thing = things[i];
                if (thing.def.IsStuff && Settings_QE.stuffHitQual) CheckQualityLoss(thing);
                else if (thing.def.IsIngestible && Settings_QE.ingHitQual) CheckQualityLoss(thing);
                else if (thing.def.building == null && !thing.def.IsWeapon && !thing.def.IsApparel) CheckQualityLoss(thing);
            }
        }

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

        [HarmonyPatch(typeof(ArmorUtility), "ApplyArmor")]
        [HarmonyPostfix]
        public static void ArmorQualityLoss_Absorbed(Thing armorThing)
        {
            if (Settings_QE.appDeteriorates && armorThing != null) CheckQualityLoss(armorThing);
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