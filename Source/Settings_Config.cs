using System;
using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.Sound;
using UnityEngine;

namespace QualityExpanded
{
    class Settings_Config
    {
        //private static Listing_Standard listing = new Listing_Standard();
        private static string awful = "Awful".Translate();
        private static string poor = "Poor".Translate();
        private static string normal = "Normal".Translate();
        private static string good = "Good".Translate();
        private static string excellent = "Excellent".Translate();
        private static string master = "Master".Translate();
        private static string legendary = "Legendary".Translate();

        public static void DoHitPoints(Listing_Standard listing, Rect canvas)
        {
            Rect rect = new Rect(canvas.x + 5f, canvas.y + 5f, canvas.width - 10f, 168f);
            listing.Begin(rect);
            listing.ColumnWidth = rect.width / 2 - 12f;
            Text.Anchor = TextAnchor.MiddleLeft;
            listing.CheckboxLabeled("QExpanded.BldgHit".Translate(), ref Settings_QE.bldgHitQual);
            listing.CheckboxLabeled("QExpanded.WeapHit".Translate(), ref Settings_QE.weapHitQual);
            listing.CheckboxLabeled("QExpanded.AppHit".Translate(), ref Settings_QE.appHitQual);
            listing.CheckboxLabeled("QExpanded.StuffHit".Translate(), ref Settings_QE.stuffHitQual);
            listing.CheckboxLabeled("QExpanded.IngHit".Translate(), ref Settings_QE.ingHitQual);
            listing.Gap(24f);
            listing.CheckboxLabeled("QExpanded.OtherHit".Translate(), ref Settings_QE.otherHitQual);
            listing.NewColumn();
            if (Settings_QE.bldgHitQual) 
                listing.CheckboxLabeled("QExpanded.BldgDeteriorates".Translate(), ref Settings_QE.bldgDeteriorates);
            else 
                listing.Gap(24f);
            if (Settings_QE.weapHitQual)
                listing.CheckboxLabeled("QExpanded.WeapDeteriorates".Translate(), ref Settings_QE.weapDeteriorates);
            else 
                listing.Gap(24f);
            if (Settings_QE.appHitQual)
                listing.CheckboxLabeled("QExpanded.AppDeteriorates".Translate(), ref Settings_QE.appDeteriorates);
            else 
                listing.Gap(24f);
            if (Settings_QE.ingHitQual)
            {
                listing.CheckboxLabeled("QExpanded.IngDeteriorates".Translate(), ref Settings_QE.ingDeteriorates);
                listing.CheckboxLabeled("QExpanded.Ing2Det".Translate(), ref Settings_QE.ing2Deteriorates);
            }
            else
                listing.Gap(24f);
            if (Settings_QE.otherHitQual)
                listing.CheckboxLabeled("QExpanded.OtherDeteriorates".Translate(), ref Settings_QE.otherDeteriorates);
            else
                listing.Gap(24f);
            listing.End();

            listing.Begin(new Rect(canvas.x + 5f, canvas.y + 120f, canvas.width - 10f, 10f));
            listing.ColumnWidth = canvas.width - 10f;
            listing.GapLine(10f);
            listing.End();

            listing.Begin(new Rect(canvas.x + 5f, canvas.y + 130f, canvas.width - 10f, canvas.height - 36f));
            listing.ColumnWidth = rect.width / 3 - 10f;

            //Hit Points
            listing.Label("Hit Point Factors:");
            Text.Anchor = TextAnchor.MiddleLeft;
            string awfulHit = Settings_QE.awfulHit.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulHit, ref awfulHit, .05f, .5f, .05f, 10f);
            string poorHit = Settings_QE.poorHit.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorHit, ref poorHit, .05f, .5f, .05f, 10f);
            string normHit = Settings_QE.normalHit.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalHit, ref normHit, .05f, .5f, .05f, 10f);
            string goodHit = Settings_QE.goodHit.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodHit, ref goodHit, .05f, .5f, .05f, 10f);
            string excHit = Settings_QE.excHit.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excHit, ref excHit, .05f, .5f, .05f, 10f);
            string masterHit = Settings_QE.masterHit.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterHit, ref masterHit, .05f, .5f, .05f, 10f);
            string legHit = Settings_QE.legHit.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legHit, ref legHit, .05f, .5f, .05f, 10f);
            listing.GapLine(6f);
            listing.End();
        }

        
        public static void DoBldg(Listing_Standard listing, Rect rect)
        {
            //Research Speed
            listing.CheckboxLabeled("Quality affects research speed:", ref Settings_QE.resQuality);
            if (ModLister.HasActiveModWithName("XML Extensions"))
            {
                string awfulRes = Settings_QE.awfulRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulRes, ref awfulRes, .05f, .5f, .05f, 10f);
                string poorRes = Settings_QE.poorRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorRes, ref poorRes, .05f, .5f, .05f, 10f);
                string normRes = Settings_QE.normalRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalRes, ref normRes, .05f, .5f, .05f, 10f);
                string goodRes = Settings_QE.goodRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodRes, ref goodRes, .05f, .5f, .05f, 10f);
                string excRes = Settings_QE.excRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excRes, ref excRes, .05f, .5f, .05f, 10f);
                string masterRes = Settings_QE.masterRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterRes, ref masterRes, .05f, .5f, .05f, 10f);
                string legRes = Settings_QE.legRes.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legRes, ref legRes, .05f, .5f, .05f, 10f);
            }
            else
            {
                listing.Gap(72f);
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(72f);
            }
            listing.GapLine(6f);

            //Work Table Speed
            listing.NewColumn();
            listing.CheckboxLabeled("Quality affects work speed:", ref Settings_QE.workQuality);
            if (ModLister.HasActiveModWithName("XML Extensions"))
            {
                string awfulWork = Settings_QE.awfulWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulWork, ref awfulWork, .05f, .5f, .05f, 10f);
                string poorWork = Settings_QE.poorWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorWork, ref poorWork, .05f, .5f, .05f, 10f);
                string normWork = Settings_QE.normalWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalWork, ref normWork, .05f, .5f, .05f, 10f);
                string goodWork = Settings_QE.goodWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodWork, ref goodWork, .05f, .5f, .05f, 10f);
                string excWork = Settings_QE.excWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excWork, ref excWork, .05f, .5f, .05f, 10f);
                string masterWork = Settings_QE.masterWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterWork, ref masterWork, .05f, .5f, .05f, 10f);
                string legWork = Settings_QE.legWork.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legWork, ref legWork, .05f, .5f, .05f, 10f);
            }
            else
            {
                listing.Gap(72f);
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(72f);
            }
            listing.GapLine(6f);

            listing.NewColumn();
            listing.CheckboxLabeled("Quality affects door open speed:", ref Settings_QE.doorQuality);
            if (ModLister.HasActiveModWithName("XML Extensions"))
            {
                string awfulDoor = Settings_QE.awfulDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulDoor, ref awfulDoor, .05f, .5f, .05f, 10f);
                string poorDoor = Settings_QE.poorDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorDoor, ref poorDoor, .05f, .5f, .05f, 10f);
                string normDoor = Settings_QE.normalDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalDoor, ref normDoor, .05f, .5f, .05f, 10f);
                string goodDoor = Settings_QE.goodDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodDoor, ref goodDoor, .05f, .5f, .05f, 10f);
                string excDoor = Settings_QE.excDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excDoor, ref excDoor, .05f, .5f, .05f, 10f);
                string masterDoor = Settings_QE.masterDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterDoor, ref masterDoor, .05f, .5f, .05f, 10f);
                string legDoor = Settings_QE.legDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legDoor, ref legDoor, .05f, .5f, .05f, 10f);
           }
            else
            {
                listing.Gap(72f);
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(72f);
            }



        }
    }
}
