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
    class Settings_Config
    {
        //private static Listing_Standard listing = new Listing_Standard();

        public static void DoStatParts(Listing_Standard listing, Rect rect)
        {
            string awful = "Awful".Translate();
            string poor = "Poor".Translate();
            string normal = "Normal".Translate();
            string good = "Good".Translate();
            string excellent = "Excellent".Translate();
            string master = "Master".Translate();
            string legendary = "Legendary".Translate();

            //listing.Begin(rect);
            listing.ColumnWidth = rect.width / 3 - 12f;
            
            //Hit Points
            listing.CheckboxLabeled("Quality affects max hit points:", ref Settings_QE.hitQuality);
            if (ModLister.HasActiveModWithName("XML Extensions"))
            {
                string awfulHit = Settings_QE.awfulHit.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulHit, ref awfulHit, .05f, .5f, 0f, 10f);
                string poorHit = Settings_QE.poorHit.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorHit, ref poorHit, .05f, .5f, 0f, 10f);
                string normHit = Settings_QE.normalHit.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalHit, ref normHit, .05f, .5f, 0f, 10f);
                string goodHit = Settings_QE.goodHit.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodHit, ref goodHit, .05f, .5f, 0f, 10f);
                string excHit = Settings_QE.excHit.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excHit, ref excHit, .05f, .5f, 0f, 10f);
                string masterHit = Settings_QE.masterHit.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterHit, ref masterHit, .05f, .5f, 0f, 10f);
                string legHit = Settings_QE.legHit.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legHit, ref legHit, .05f, .5f, 0f, 10f);
            }
            else
            {
                listing.Gap(72f);
                listing.Label("Requires XML Extensions for Configuration");
                listing.Gap(72f);
            }
            listing.GapLine(6f);

            //Research Speed
            listing.NewColumn();
            listing.CheckboxLabeled("Quality affects research speed:", ref Settings_QE.resQuality);
            if (ModLister.HasActiveModWithName("XML Extensions"))
            {
                string awfulRes = Settings_QE.awfulRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulRes, ref awfulRes, .05f, .5f, 0f, 10f);
                string poorRes = Settings_QE.poorRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorRes, ref poorRes, .05f, .5f, 0f, 10f);
                string normRes = Settings_QE.normalRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalRes, ref normRes, .05f, .5f, 0f, 10f);
                string goodRes = Settings_QE.goodRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodRes, ref goodRes, .05f, .5f, 0f, 10f);
                string excRes = Settings_QE.excRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excRes, ref excRes, .05f, .5f, 0f, 10f);
                string masterRes = Settings_QE.masterRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterRes, ref masterRes, .05f, .5f, 0f, 10f);
                string legRes = Settings_QE.legRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legRes, ref legRes, .05f, .5f, 0f, 10f);
            }
            else
            {
                listing.Gap(72f);
                listing.Label("Requires XML Extensions for Configuration");
                listing.Gap(72f);
            }
            listing.GapLine(6f);

            //Work Table Speed
            listing.NewColumn();
            listing.CheckboxLabeled("Quality affects work speed:", ref Settings_QE.workQuality);
            if (ModLister.HasActiveModWithName("XML Extensions"))
            {
                string awfulWork = Settings_QE.awfulWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulWork, ref awfulWork, .05f, .5f, 0f, 10f);
                string poorWork = Settings_QE.poorWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorWork, ref poorWork, .05f, .5f, 0f, 10f);
                string normWork = Settings_QE.normalWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalWork, ref normWork, .05f, .5f, 0f, 10f);
                string goodWork = Settings_QE.goodWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodWork, ref goodWork, .05f, .5f, 0f, 10f);
                string excWork = Settings_QE.excWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excWork, ref excWork, .05f, .5f, 0f, 10f);
                string masterWork = Settings_QE.masterWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterWork, ref masterWork, .05f, .5f, 0f, 10f);
                string legWork = Settings_QE.legWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legWork, ref legWork, .05f, .5f, 0f, 10f);
            }
            else
            {
                listing.Gap(72f);
                listing.Label("Requires XML Extensions for Configuration");
                listing.Gap(72f);
            }
            listing.GapLine(6f);
        }
    }
}
