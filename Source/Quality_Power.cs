using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using RimWorld;
using Verse;
using HarmonyLib;

namespace QualityExpanded
{
    public class Quality_Power
    {
        static readonly FieldInfo fEfficiency = AccessTools.Field(typeof(CompProperties_Battery), nameof(CompProperties_Battery.efficiency));
        static readonly FieldInfo fParent = AccessTools.Field(typeof(CompPowerBattery), nameof(CompPowerBattery.parent));
        static readonly MethodInfo mQualityFactor = AccessTools.Method(typeof(Quality_Power), "PowerQualityFactor");

        public static void PowerOutput_QualPostfix(CompPowerTrader __instance)
        {
            if (__instance.Props.basePowerConsumption < 0f)
            {
                //Log.Message("Changing result from " + __instance.powerOutputInt + " to " + __instance.powerOutputInt * PowerOutQualityFactor(qc));
                __instance.powerOutputInt = __instance.powerOutputInt * PowerQualityFactor(__instance.parent);
            }
            if (__instance.Props.basePowerConsumption > 0f)
            {
                __instance.powerOutputInt = __instance.powerOutputInt / PowerQualityFactor(__instance.parent);
            }
        }

        public static IEnumerable<CodeInstruction> AddEnergy_Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = instructions.ToList();
            var idx = list.FindIndex(code => code.LoadsField(fEfficiency));
            idx++;
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
                if (i == idx && list[i].opcode == OpCodes.Mul)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldfld, fParent);
                    yield return new CodeInstruction(OpCodes.Call, mQualityFactor);
                    yield return new CodeInstruction(OpCodes.Mul);
                }
            }
            yield break;
        }

        public static IEnumerable<CodeInstruction> InspectString_Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = instructions.ToList();
            var idx = list.FindIndex(code => code.LoadsField(fEfficiency));
            idx += 2;
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
                if (i == idx && list[i].opcode == OpCodes.Mul)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldfld, fParent);
                    yield return new CodeInstruction(OpCodes.Call, mQualityFactor);
                    yield return new CodeInstruction(OpCodes.Mul);
                }
            }
        }

        public static IEnumerable<CodeInstruction> AmountCanAccept_Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> list = instructions.ToList();
            var idx = list.FindIndex(code => code.LoadsField(fEfficiency));
            idx++;
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
                if (i == idx && list[i].opcode == OpCodes.Div)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Ldfld, fParent);
                    yield return new CodeInstruction(OpCodes.Call, mQualityFactor);
                    yield return new CodeInstruction(OpCodes.Div);
                }
            }
            yield break;
        }

        public static float PowerQualityFactor(Thing thing)
        {
            if (!Settings_QE.powerQuality)
            {
                return 1f;
            }
            QualityCategory qc;
            if (!thing.TryGetQuality(out qc))
            {
                return 1f;
            }
            switch (qc)
            {
                case QualityCategory.Awful:
                    return Settings_QE.awfulPower;
                case QualityCategory.Poor:
                    return Settings_QE.poorPower;
                case QualityCategory.Normal:
                    return Settings_QE.normalPower;
                case QualityCategory.Good:
                    return Settings_QE.goodPower;
                case QualityCategory.Excellent:
                    return Settings_QE.excPower;
                case QualityCategory.Masterwork:
                    return Settings_QE.masterPower;
                case QualityCategory.Legendary:
                    return Settings_QE.legPower;
                default:
                    return 1f;
            }
        }

    }
}
