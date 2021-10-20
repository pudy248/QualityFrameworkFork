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
            Text.Anchor = TextAnchor.MiddleLeft;
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
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.UpperLeft;
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
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.UpperLeft;
                listing.Gap(72f);
            }
            listing.GapLine(6f);

            listing.CheckboxLabeled("Quality affects door open speed:", ref Settings_QE.doorQuality);
            //if (ModLister.HasActiveModWithName("XML Extensions"))
            //{
                //string awfulDoor = Settings_QE.awfulDoor.ToString();
                Settings_QE.awfulDoor = (int)(Widgets.HorizontalSlider(listing.GetRect(30f), Settings_QE.awfulDoor, .1f, 4f, false, null, "Awful Factor", Settings_QE.awfulDoor.ToString()) * 100) / 100f;
                Settings_QE.poorDoor = (int)(Widgets.HorizontalSlider(listing.GetRect(30f), Settings_QE.poorDoor, .1f, 4f, false, null, "Poor Factor", Settings_QE.poorDoor.ToString()) * 100) / 100f;
                Settings_QE.normalDoor = (int)(Widgets.HorizontalSlider(listing.GetRect(30f), Settings_QE.normalDoor, .1f, 4f, false, null, "Normal Factor", Settings_QE.normalDoor.ToString()) * 100) / 100f;
            //Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulDoor, ref awfulDoor, .05f, .5f, 0f, 10f);
                /*string poorDoor = Settings_QE.poorDoor.ToString();
                //Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorDoor, ref poorDoor, .05f, .5f, 0f, 10f);
                string normDoor = Settings_QE.normalDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalDoor, ref normDoor, .05f, .5f, 0f, 10f);
                string goodDoor = Settings_QE.goodDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodDoor, ref goodDoor, .05f, .5f, 0f, 10f);
                string excDoor = Settings_QE.excDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excDoor, ref excDoor, .05f, .5f, 0f, 10f);
                string masterDoor = Settings_QE.masterDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterDoor, ref masterDoor, .05f, .5f, 0f, 10f);
                string legDoor = Settings_QE.legDoor.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legDoor, ref legDoor, .05f, .5f, 0f, 10f);*/
           //}
            



        }
    }
}
