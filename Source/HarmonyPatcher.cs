using System;
using System.Reflection;
using RimWorld;
using Verse;
using HarmonyLib;

namespace QualityExpanded
{
    public class HarmonyPatcher
    {
        public static void RunHarmony()
        {
            Harmony harmony = new Harmony("rimworld.qualityexpanded");
            if (Settings_QE.powerQuality)
            {
                PowerPatcher(harmony);
            }
            if (Settings_QE.rangedQuality)
            {
                harmony.Patch(AccessTools.Method(typeof(Building_TurretGun), "BurstCooldownTime"), postfix: new HarmonyMethod(typeof(Quality_Turret), "TurretCooldown"));
            }
            if (!Settings_QE.hitPointQuality)
            {
                DeteriorationPatcher(harmony);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
        }

        public static void PowerPatcher(Harmony harmony)
        {
            Type power = typeof(Quality_Power);
            Log.Message("Running Power Patch");
            harmony.Patch(AccessTools.PropertySetter(typeof(CompPowerTrader), "PowerOutput"), postfix: new HarmonyMethod(power, "PowerOutput_QualPostfix"));
            harmony.Patch(AccessTools.PropertyGetter(typeof(CompPowerBattery), "AmountCanAccept"), null, null, new HarmonyMethod(power, "AmountCanAccept_Transpiler"));
            harmony.Patch(AccessTools.Method(typeof(CompPowerBattery), "AddEnergy"), null, null, new HarmonyMethod(power, "AddEnergy_Transpiler"));
            harmony.Patch(AccessTools.Method(typeof(CompPowerBattery), "CompInspectStringExtra"), null, null, new HarmonyMethod(power, "InspectString_Transpiler"));
        }

        public static void DeteriorationPatcher(Harmony harmony)
        {
            Type deterioration = typeof(QualityLoss);
            if (Settings_QE.bldgDeteriorates)
            {
                harmony.Patch(AccessTools.Method(typeof(ListerBuildingsRepairable), "Notify_BuildingTookDamage"), null, new HarmonyMethod(deterioration, "BuildingQualityLoss_Damaged"));
                harmony.Patch(AccessTools.Method(typeof(ListerBuildingsRepairable), "Notify_BuildingSpawned"), null, new HarmonyMethod(deterioration, "BuildingQualityLoss_Spawned"));
            }
            if (Settings_QE.appDeteriorates)
            {
                harmony.Patch(AccessTools.Method(typeof(Pawn_ApparelTracker), "TakeWearoutDamageForDay"), null, new HarmonyMethod(deterioration, "ApparelQualityLoss_Daily"));
                harmony.Patch(AccessTools.Method(typeof(ArmorUtility), "ApplyArmor"), null, new HarmonyMethod(deterioration, "ArmorQualityLoss_Absorbed"));
            }
        }
    }
}
