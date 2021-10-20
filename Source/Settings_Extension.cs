using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using Verse.Sound;
using UnityEngine;

namespace QualityExpanded
{
    class Settings_Extension
    {
        public static void LabeledFloatEntry(Rect rect, string label, ref float value, ref string editBuffer, float multiplier, float largeMultiplier, float min, float max)
        {
            rect.width -= 8f;
            float num = rect.width / 8f;
            rect.x += 8f;
            Widgets.Label(rect, label);
            if (multiplier != largeMultiplier)
            {
                if (Widgets.ButtonText(new Rect(rect.xMax - num * 5f - 5f, rect.yMin, (float)num, rect.height), "--", true, true, true))
                {
                    value -= largeMultiplier * GenUI.CurrentAdjustmentMultiplier();
                    value = (float)Mathf.Round(value * 100f) / 100f;
                    editBuffer = value.ToString();
                    SoundDefOf.Checkbox_TurnedOff.PlayOneShotOnCamera(null);
                }
                if (Widgets.ButtonText(new Rect(rect.xMax - num, rect.yMin, num, rect.height), "++", true, true, true))
                {
                    value += largeMultiplier * GenUI.CurrentAdjustmentMultiplier();
                    value = (float)Mathf.Round(value * 100f) / 100f;
                    editBuffer = value.ToString();
                    SoundDefOf.Checkbox_TurnedOn.PlayOneShotOnCamera(null);
                }
            }
            if (Widgets.ButtonText(new Rect(rect.xMax - num * 4f - 5f, rect.yMin, num, rect.height), "-", true, true, true))
            {
                value -= multiplier * GenUI.CurrentAdjustmentMultiplier();
                value = (float)Mathf.Round(value * 100f) / 100f;
                editBuffer = value.ToString();
                SoundDefOf.Checkbox_TurnedOff.PlayOneShotOnCamera(null);
            }
            if (Widgets.ButtonText(new Rect(rect.xMax - (num * 2f), rect.yMin, num, rect.height), "+", true, true, true))
            {
                value += multiplier * GenUI.CurrentAdjustmentMultiplier();
                value = (float)Mathf.Round(value * 100f) / 100f;
                editBuffer = value.ToString();
                SoundDefOf.Checkbox_TurnedOn.PlayOneShotOnCamera(null);
            }
            Widgets.TextFieldNumeric<float>(new Rect(rect.xMax - (num * 3f) - 5f, rect.yMin, num + 4f, rect.height), ref value, ref editBuffer, min, max);
        }
    }
}
