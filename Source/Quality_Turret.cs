using RimWorld;
using Verse;

namespace QualityExpanded
{
    public class Quality_Turret
    {
        public static void TurretCooldown(ref float __result, Building_TurretGun __instance)
        {
            if(__instance.def.building.turretBurstCooldownTime >= 0f)
            {
                __result *= QualityCooldownFactor(__instance);
            }
        }

        public static float QualityCooldownFactor(Thing thing)
        {
            QualityCategory qc;
            if (!thing.TryGetQuality(out qc))
            {
                return 1f;
            }
            switch (qc)
            {
                case QualityCategory.Awful:
                    return Settings_QE.awfulRanged;
                case QualityCategory.Poor:
                    return Settings_QE.poorRanged;
                case QualityCategory.Normal:
                    return Settings_QE.normalRanged;
                case QualityCategory.Good:
                    return Settings_QE.goodRanged;
                case QualityCategory.Excellent:
                    return Settings_QE.excRanged;
                case QualityCategory.Masterwork:
                    return Settings_QE.masterRanged;
                case QualityCategory.Legendary:
                    return Settings_QE.legRanged;
                default:
                    return 1f;
            }
        }
    }
}
