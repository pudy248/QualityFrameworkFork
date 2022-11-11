using Verse;
using UnityEngine;

namespace QualityExpanded
{
    class Settings_Config
    {
        //private static Listing_Standard listing = new Listing_Standard();
        private static string awful = "QExpanded.Awful".Translate();
        private static string poor = "QExpanded.Poor".Translate();
        private static string normal = "QExpanded.Normal".Translate();
        private static string good = "QExpanded.Good".Translate();
        private static string excellent = "QExpanded.Excellent".Translate();
        private static string master = "QExpanded.Masterwork".Translate();
        private static string legendary = "QExpanded.Legendary".Translate();

        public static bool origSetting = Settings_QE.hitPointQuality;
        public static string buttonLabel;

        public static void DoDeterioration(Listing_Standard listing, Rect canvas)
        {
            Rect rect = new Rect(canvas.x + 5f, canvas.y + 5f, canvas.width - 10f, 190f);
            listing.Begin(rect);
            listing.ColumnWidth = rect.width / 2 - 12f;
            if (Settings_QE.hitPointQuality)
            {
                if (origSetting) buttonLabel = "QExpanded.Disable";
                else buttonLabel = "QExpanded.RestartReq";
                if (listing.ButtonText(buttonLabel.Translate()))
                {
                    Settings_QE.hitPointQuality = false;
                    Settings_QE.deteriorationQuality = true;
                }
            }
            else
            {
                if (origSetting) buttonLabel = "QExpanded.RestartReq";
                else buttonLabel = "QExpanded.Enable";
                if (listing.ButtonText(buttonLabel.Translate()))
                {
                    Settings_QE.hitPointQuality = true;
                    Settings_QE.deteriorationQuality = false;
                }
            }
            if (Settings_QE.hitPointQuality)
            {
                listing.CheckboxLabeled("QExpanded.BldgHit".Translate(), ref Settings_QE.bldgHitQual);
                listing.CheckboxLabeled("QExpanded.WeapHit".Translate(), ref Settings_QE.weapHitQual);
                listing.CheckboxLabeled("QExpanded.AppHit".Translate(), ref Settings_QE.appHitQual);
                listing.CheckboxLabeled("QExpanded.StuffHit".Translate(), ref Settings_QE.stuffHitQual);
                listing.CheckboxLabeled("QExpanded.IngHit".Translate(), ref Settings_QE.ingHitQual);
                listing.CheckboxLabeled("QExpanded.OtherHit".Translate(), ref Settings_QE.otherHitQual);
            }
            else
            {
                listing.Gap(144f);
            }
            listing.NewColumn();
            listing.Gap(8f);
            if (Settings_QE.hitPointQuality)
            {
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("QExpanded.Restart".Translate());
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(8f);
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
                if (Settings_QE.stuffHitQual || Settings_QE.ingHitQual || Settings_QE.otherHitQual)
                    listing.CheckboxLabeled("QExpanded.OtherDeteriorates".Translate(), ref Settings_QE.otherDeteriorates);
                else
                    listing.Gap(24f);
            }
            listing.Gap(48f);
            listing.End();

            listing.Begin(new Rect(canvas.x + 5f, canvas.y + 182f, canvas.width - 10f, 10f));
            listing.ColumnWidth = canvas.width - 10f;
            listing.GapLine(10f);
            listing.End();

            listing.Begin(new Rect(canvas.x + 5f, canvas.y + 190f, canvas.width - 10f, canvas.height - 40f));
            listing.ColumnWidth = rect.width / 2 - 12f;

            //Hit Points
            if (Settings_QE.hitPointQuality)
            {
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("QExpanded.NoRestart".Translate());
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Label("QExpanded.HitFactors".Translate());
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
            }
            listing.NewColumn();
            Text.Anchor = TextAnchor.MiddleCenter;
            listing.Label("QExpanded.Restart".Translate());
            listing.Label("QExpanded.Vanilla".Translate());
            listing.GapLine(8f);
            Text.Anchor = TextAnchor.MiddleLeft;
            listing.CheckboxLabeled("QExpanded.Beauty".Translate(), ref Settings_QE.beautyQuality);
            listing.CheckboxLabeled("QExpanded.BedRest".Translate(), ref Settings_QE.bedQuality);
            listing.CheckboxLabeled("QExpanded.Comfort".Translate(), ref Settings_QE.comfortQuality);
            listing.CheckboxLabeled("QExpanded.Deterioration".Translate(), ref Settings_QE.deteriorationQuality);
            //listing.GapLine(6f);
            listing.End();
        }

        public static void DoBldgExpanded(Listing_Standard listing, Rect canvas)
        {
            Rect rect = new Rect(canvas.x + 5f, canvas.y + 5f, canvas.width - 10f, canvas.height - 5f);
            listing.Begin(rect);
            listing.ColumnWidth = rect.width / 3 - 14f;
            //Research Speed
            listing.Gap(8f);
            Text.Anchor = TextAnchor.MiddleCenter;
            listing.Label("QExpanded.AllRestart".Translate());
            Text.Anchor = TextAnchor.MiddleLeft;
            listing.CheckboxLabeled("QExpanded.ResSpeed".Translate(), ref Settings_QE.resQuality);
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
                listing.Gap(78f);
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(78f);
            }
            listing.GapLine(12f);

            //Power Output
            Text.Anchor = TextAnchor.MiddleCenter;
            listing.Label("QExpanded.Restart".Translate());
            Text.Anchor = TextAnchor.MiddleLeft;
            listing.CheckboxLabeled("QExpanded.Power".Translate(), ref Settings_QE.powerQuality);
            string awfulPower = Settings_QE.awfulPower.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulPower, ref awfulPower, .05f, .5f, .05f, 10f);
            string poorPower = Settings_QE.poorPower.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorPower, ref poorPower, .05f, .5f, .05f, 10f);
            string normPower = Settings_QE.normalPower.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalPower, ref normPower, .05f, .5f, .05f, 10f);
            string goodPower = Settings_QE.goodPower.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodPower, ref goodPower, .05f, .5f, .05f, 10f);
            string excPower = Settings_QE.excPower.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excPower, ref excPower, .05f, .5f, .05f, 10f);
            string masterPower = Settings_QE.masterPower.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterPower, ref masterPower, .05f, .5f, .05f, 10f);
            string legPower = Settings_QE.legPower.ToString();
            Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legPower, ref legPower, .05f, .5f, .05f, 10f);


            listing.NewColumn();
            listing.Gap(8f);
            //Work Table Speed
            Text.Anchor = TextAnchor.MiddleCenter;
            listing.Label("QExpanded.AllRestart".Translate());
            Text.Anchor = TextAnchor.MiddleLeft;
            listing.CheckboxLabeled("QExpanded.WorkSpeed".Translate(), ref Settings_QE.workQuality);
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
                listing.Gap(78f);
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(78f);
            }
            listing.GapLine(12f);

            listing.NewColumn();
            listing.Gap(8f);
            //Door Open Speed
            Text.Anchor = TextAnchor.MiddleCenter;
            listing.Label("QExpanded.AllRestart".Translate());
            Text.Anchor = TextAnchor.MiddleLeft;
            listing.CheckboxLabeled("QExpanded.DoorSpeed".Translate(), ref Settings_QE.doorQuality);
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
                listing.Gap(78f);
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(78f);
            }
            listing.GapLine(12f);
            listing.End();
        }

        public static void DoItemExpanded(Listing_Standard listing, Rect canvas)
        {
            Rect rect = new Rect(canvas.x + 5f, canvas.y + 5f, canvas.width - 10f, canvas.height - 5f);
            listing.Begin(rect);
            listing.ColumnWidth = rect.width / 3 - 14f;
            listing.Gap(8f);
            //Ranged Cooldown
            Text.Anchor = TextAnchor.MiddleCenter;
            listing.Label("QExpanded.AllRestart".Translate());
            Text.Anchor = TextAnchor.MiddleLeft;
            listing.CheckboxLabeled("QExpanded.RangedCD".Translate(), ref Settings_QE.rangedQuality);
            if (ModLister.HasActiveModWithName("XML Extensions"))
            {
                string awfulRanged = Settings_QE.awfulRanged.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulRanged, ref awfulRanged, .05f, .5f, .05f, 10f);
                string poorRanged = Settings_QE.poorRanged.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorRanged, ref poorRanged, .05f, .5f, .05f, 10f);
                string normRanged = Settings_QE.normalRanged.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalRanged, ref normRanged, .05f, .5f, .05f, 10f);
                string goodRanged = Settings_QE.goodRanged.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodRanged, ref goodRanged, .05f, .5f, .05f, 10f);
                string excRanged = Settings_QE.excRanged.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excRanged, ref excRanged, .05f, .5f, .05f, 10f);
                string masterRanged = Settings_QE.masterRanged.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterRanged, ref masterRanged, .05f, .5f, .05f, 10f);
                string legRanged = Settings_QE.legRanged.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legRanged, ref legRanged, .05f, .5f, .05f, 10f);
            }
            else
            {
                listing.Gap(78f);
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(78f);
            }
            listing.GapLine(12f);
            
            //Trap Damage
            Text.Anchor = TextAnchor.MiddleCenter;
            listing.Label("QExpanded.AllRestart".Translate());
            Text.Anchor = TextAnchor.MiddleLeft;
            listing.CheckboxLabeled("QExpanded.TrapDamage".Translate(), ref Settings_QE.trapQuality);
            if (ModLister.HasActiveModWithName("XML Extensions"))
            {
                string awfulTrap = Settings_QE.awfulTrap.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulTrap, ref awfulTrap, .05f, .5f, .05f, 10f);
                string poorTrap = Settings_QE.poorTrap.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorTrap, ref poorTrap, .05f, .5f, .05f, 10f);
                string normTrap = Settings_QE.normalTrap.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalTrap, ref normTrap, .05f, .5f, .05f, 10f);
                string goodTrap = Settings_QE.goodTrap.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodTrap, ref goodTrap, .05f, .5f, .05f, 10f);
                string excTrap = Settings_QE.excTrap.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excTrap, ref excTrap, .05f, .5f, .05f, 10f);
                string masterTrap = Settings_QE.masterTrap.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterTrap, ref masterTrap, .05f, .5f, .05f, 10f);
                string legTrap = Settings_QE.legTrap.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legTrap, ref legTrap, .05f, .5f, .05f, 10f);
            }
            else
            {
                listing.Gap(78f);
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(78f);
            }
            listing.GapLine(12f);

            listing.NewColumn();
            listing.Gap(8f);
            //Melee Cooldown
            Text.Anchor = TextAnchor.MiddleCenter;
            listing.Label("QExpanded.AllRestart".Translate());
            Text.Anchor = TextAnchor.MiddleLeft;
            listing.CheckboxLabeled("QExpanded.MeleeCD".Translate(), ref Settings_QE.meleeQuality);
            if (ModLister.HasActiveModWithName("XML Extensions"))
            {
                string awfulMelee = Settings_QE.awfulMelee.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulMelee, ref awfulMelee, .05f, .5f, .05f, 10f);
                string poorMelee = Settings_QE.poorMelee.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorMelee, ref poorMelee, .05f, .5f, .05f, 10f);
                string normMelee = Settings_QE.normalMelee.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalMelee, ref normMelee, .05f, .5f, .05f, 10f);
                string goodMelee = Settings_QE.goodMelee.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodMelee, ref goodMelee, .05f, .5f, .05f, 10f);
                string excMelee = Settings_QE.excMelee.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excMelee, ref excMelee, .05f, .5f, .05f, 10f);
                string masterMelee = Settings_QE.masterMelee.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterMelee, ref masterMelee, .05f, .5f, .05f, 10f);
                string legMelee = Settings_QE.legMelee.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legMelee, ref legMelee, .05f, .5f, .05f, 10f);
            }
            else
            {
                listing.Gap(78f);
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(78f);
            }
            listing.GapLine(12f);

            listing.NewColumn();
            listing.Gap(8f);
            //Medical Potency
            Text.Anchor = TextAnchor.MiddleCenter;
            listing.Label("QExpanded.AllRestart".Translate());
            Text.Anchor = TextAnchor.MiddleLeft;
            listing.CheckboxLabeled("QExpanded.MedPotency".Translate(), ref Settings_QE.medQuality);
            if (ModLister.HasActiveModWithName("XML Extensions"))
            {
                string awfulMeds = Settings_QE.awfulMeds.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), awful, ref Settings_QE.awfulMeds, ref awfulMeds, .05f, .5f, .05f, 10f);
                string poorMeds = Settings_QE.poorMeds.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), poor, ref Settings_QE.poorMeds, ref poorMeds, .05f, .5f, .05f, 10f);
                string normMeds = Settings_QE.normalMeds.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), normal, ref Settings_QE.normalMeds, ref normMeds, .05f, .5f, .05f, 10f);
                string goodMeds = Settings_QE.goodMeds.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), good, ref Settings_QE.goodMeds, ref goodMeds, .05f, .5f, .05f, 10f);
                string excMeds = Settings_QE.excMeds.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), excellent, ref Settings_QE.excMeds, ref excMeds, .05f, .5f, .05f, 10f);
                string masterMeds = Settings_QE.masterMeds.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), master, ref Settings_QE.masterMeds, ref masterMeds, .05f, .5f, .05f, 10f);
                string legMeds = Settings_QE.legMeds.ToString();
                Settings_Extension.LabeledFloatEntry(listing.GetRect(24f), legendary, ref Settings_QE.legMeds, ref legMeds, .05f, .5f, .05f, 10f);
            }
            else
            {
                listing.Gap(78f);
                Text.Anchor = TextAnchor.MiddleCenter;
                listing.Label("Requires XML Extensions");
                Text.Anchor = TextAnchor.MiddleLeft;
                listing.Gap(78f);
            }
            listing.GapLine(12f);
            listing.End();
        }
    }
}
