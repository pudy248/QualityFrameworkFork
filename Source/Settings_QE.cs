using Verse;


namespace QualityExpanded
{
    public class Settings_QE : ModSettings
    {
        public static bool qualFramework = false;
        //Hit Points
        public static bool bldgHitQual = true;
        public static bool weapHitQual = true;
        public static bool appHitQual = true;
        public static bool stuffHitQual = true;
        public static bool ingHitQual = true;
        public static bool otherHitQual = true;

        public static bool bldgDeteriorates = true;
        public static bool weapDeteriorates = true;
        public static bool appDeteriorates = true;
        //public static bool stuffDeteriorates = false;
        //public static bool ingDeteriorates = false;
        //public static bool ing2Deteriorates = false;
        public static bool otherDeteriorates = true;

        public static float awfulHit = .5f;
        public static float poorHit = .75f;
        public static float normalHit = 1f;
        public static float goodHit = 1.25f;
        public static float excHit = 1.5f;
        public static float masterHit = 1.75f;
        public static float legHit = 2.0f;

        //Research Speed
        public static bool resQuality = true;
        public static float awfulRes = .8f;
        public static float poorRes = .9f;
        public static float normalRes = 1f;
        public static float goodRes = 1.1f;
        public static float excRes = 1.2f;
        public static float masterRes = 1.35f;
        public static float legRes = 1.5f;

        //Work Table Speed
        public static bool workQuality = false;
        public static float awfulWork = .8f;
        public static float poorWork = .9f;
        public static float normalWork = 1f;
        public static float goodWork = 1.1f;
        public static float excWork = 1.2f;
        public static float masterWork = 1.35f;
        public static float legWork = 1.5f;

        //Door Open Speed
        public static bool doorQuality = false;
        public static float awfulDoor = .8f;
        public static float poorDoor = .9f;
        public static float normalDoor = 1f;
        public static float goodDoor = 1.1f;
        public static float excDoor = 1.2f;
        public static float masterDoor = 1.35f;
        public static float legDoor = 1.5f;

        //Ranged Cooldown
        public static bool rangedQuality = false;
        public static float awfulRanged = .8f;
        public static float poorRanged = .9f;
        public static float normalRanged = 1f;
        public static float goodRanged = 1.1f;
        public static float excRanged = 1.2f;
        public static float masterRanged = 1.35f;
        public static float legRanged = 1.5f;

        //Melee Cooldown
        public static bool meleeQuality = false;
        public static float awfulMelee = .8f;
        public static float poorMelee = .9f;
        public static float normalMelee = 1f;
        public static float goodMelee = 1.1f;
        public static float excMelee = 1.2f;
        public static float masterMelee = 1.35f;
        public static float legMelee = 1.5f;

        //Medical Potency
        public static bool medQuality = false;
        public static float awfulMeds = .9f;
        public static float poorMeds = .95f;
        public static float normalMeds = 1f;
        public static float goodMeds = 1.05f;
        public static float excMeds = 1.1f;
        public static float masterMeds = 1.15f;
        public static float legMeds = 1.3f;

        //Turret Accuracy
        /*public static bool turretQuality = false;
        public static float awfulTurret = .8f;
        public static float poorTurret = .9f;
        public static float normalTurret = 1f;
        public static float goodTurret = 1.1f;
        public static float excTurret = 1.2f;
        public static float masterTurret = 1.35f;
        public static float legTurret = 1.5f;*/

        public override void ExposeData()
        {
            //Hit Points
            Scribe_Values.Look<bool>(ref bldgHitQual, "bldgHitQual", true);
            Scribe_Values.Look<bool>(ref weapHitQual, "weapHitQual", true);
            Scribe_Values.Look<bool>(ref appHitQual, "appHitQual", true);
            Scribe_Values.Look<bool>(ref stuffHitQual, "stuffHitQual", true);
            Scribe_Values.Look<bool>(ref ingHitQual, "ingHitQual", true);
            Scribe_Values.Look<bool>(ref otherHitQual, "otherHitQual", true);
            Scribe_Values.Look<bool>(ref bldgDeteriorates, "bldgDeteriorates", true);
            Scribe_Values.Look<bool>(ref weapDeteriorates, "weapDeteriorates", true);
            Scribe_Values.Look<bool>(ref appDeteriorates, "appDeteriorates", true);
            //Scribe_Values.Look<bool>(ref stuffDeteriorates, "stuffDeteriorates", false);
            //Scribe_Values.Look<bool>(ref ingDeteriorates, "ingDeteriorates", false);
            //Scribe_Values.Look<bool>(ref ing2Deteriorates, "ing2Deteriorates", false);
            Scribe_Values.Look<bool>(ref otherDeteriorates, "otherDeteriorates", true);

            Scribe_Values.Look<float>(ref awfulHit, "awfulHit", .5f);
            Scribe_Values.Look<float>(ref poorHit, "poorHit", .75f);
            Scribe_Values.Look<float>(ref normalHit, "normalHit", 1f);
            Scribe_Values.Look<float>(ref goodHit, "goodHit", 1.25f);
            Scribe_Values.Look<float>(ref excHit, "exclHit", 1.5f);
            Scribe_Values.Look<float>(ref masterHit, "masterHit", 1.75f);
            Scribe_Values.Look<float>(ref legHit, "legHit", 2f);

            //Research Speed
            Scribe_Values.Look<bool>(ref resQuality, "resQuality", false);
            Scribe_Values.Look<float>(ref awfulRes, "awfulRes", .8f);
            Scribe_Values.Look<float>(ref poorRes, "poorRes", .9f);
            Scribe_Values.Look<float>(ref normalRes, "normalRes", 1f);
            Scribe_Values.Look<float>(ref goodRes, "goodRes", 1.1f);
            Scribe_Values.Look<float>(ref excRes, "excRes", 1.2f);
            Scribe_Values.Look<float>(ref masterRes, "masterRes", 1.35f);
            Scribe_Values.Look<float>(ref legRes, "legRes", 1.5f);

            //WorkTable Speed
            Scribe_Values.Look<bool>(ref workQuality, "workQuality", false);
            Scribe_Values.Look<float>(ref awfulWork, "awfulWork", .8f);
            Scribe_Values.Look<float>(ref poorWork, "poorWork", .9f);
            Scribe_Values.Look<float>(ref normalWork, "normalWork", 1f);
            Scribe_Values.Look<float>(ref goodWork, "goodWork", 1.1f);
            Scribe_Values.Look<float>(ref excWork, "excWork", 1.2f);
            Scribe_Values.Look<float>(ref masterWork, "masterWork", 1.35f);
            Scribe_Values.Look<float>(ref legWork, "legWork", 1.5f);

            //Door Open Speed
            Scribe_Values.Look<bool>(ref doorQuality, "doorQuality", false);
            Scribe_Values.Look<float>(ref awfulDoor, "awfulDoor", .8f);
            Scribe_Values.Look<float>(ref poorDoor, "poorDoor", .9f);
            Scribe_Values.Look<float>(ref normalDoor, "normalDoor", 1f);
            Scribe_Values.Look<float>(ref goodDoor, "goodDoor", 1.1f);
            Scribe_Values.Look<float>(ref excDoor, "excDoor", 1.2f);
            Scribe_Values.Look<float>(ref masterDoor, "masterDoor", 1.35f);
            Scribe_Values.Look<float>(ref legDoor, "legDoor", 1.5f);

            //Ranged Cooldown
            Scribe_Values.Look<bool>(ref rangedQuality, "rangedQuality", false);
            Scribe_Values.Look<float>(ref awfulRanged, "awfulRanged", .8f);
            Scribe_Values.Look<float>(ref poorRanged, "poorRanged", .9f);
            Scribe_Values.Look<float>(ref normalRanged, "normalRanged", 1f);
            Scribe_Values.Look<float>(ref goodRanged, "goodRanged", 1.1f);
            Scribe_Values.Look<float>(ref excRanged, "excRanged", 1.2f);
            Scribe_Values.Look<float>(ref masterRanged, "masterRanged", 1.35f);
            Scribe_Values.Look<float>(ref legRanged, "legRanged", 1.5f);

            //Melee Cooldown
            Scribe_Values.Look<bool>(ref meleeQuality, "meleeQuality", false);
            Scribe_Values.Look<float>(ref awfulMelee, "awfulMelee", .8f);
            Scribe_Values.Look<float>(ref poorMelee, "poorMelee", .9f);
            Scribe_Values.Look<float>(ref normalMelee, "normalMelee", 1f);
            Scribe_Values.Look<float>(ref goodMelee, "goodMelee", 1.1f);
            Scribe_Values.Look<float>(ref excMelee, "excMelee", 1.2f);
            Scribe_Values.Look<float>(ref masterMelee, "masterMelee", 1.35f);
            Scribe_Values.Look<float>(ref legMelee, "legMelee", 1.5f);

            //Medical Potency
            Scribe_Values.Look<bool>(ref medQuality, "medQuality", false);
            Scribe_Values.Look<float>(ref awfulMeds, "awfulMeds", .9f);
            Scribe_Values.Look<float>(ref poorMeds, "poorMeds", .95f);
            Scribe_Values.Look<float>(ref normalMeds, "normalMeds", 1f);
            Scribe_Values.Look<float>(ref goodMeds, "goodMeds", 1.05f);
            Scribe_Values.Look<float>(ref excMeds, "excMeds", 1.1f);
            Scribe_Values.Look<float>(ref masterMeds, "masterMeds", 1.15f);
            Scribe_Values.Look<float>(ref legMeds, "legMeds", 1.3f);

            //Turret Accuracy
            /*Scribe_Values.Look<bool>(ref turretQuality, "turretQuality", false);
            Scribe_Values.Look<float>(ref awfulTurret, "awfulTurret", .8f);
            Scribe_Values.Look<float>(ref poorTurret, "poorTurret", .9f);
            Scribe_Values.Look<float>(ref normalTurret, "normalTurret", 1f);
            Scribe_Values.Look<float>(ref goodTurret, "goodTurret", 1.1f);
            Scribe_Values.Look<float>(ref excTurret, "excTurret", 1.2f);
            Scribe_Values.Look<float>(ref masterTurret, "masterTurret", 1.35f);
            Scribe_Values.Look<float>(ref legTurret, "legTurret", 1.5f);*/
        }

        public static void ResetDefaults()
        {
            bldgHitQual = true;
            weapHitQual = true;
            appHitQual = true;
            stuffHitQual = true;
            ingHitQual = true;
            otherHitQual = true;

            bldgDeteriorates = true;
            weapDeteriorates = true;
            appDeteriorates = true;
            // stuffDeteriorates = false;
            // ingDeteriorates = false;
            // ing2Deteriorates = false;
            otherDeteriorates = true;

            awfulHit = .5f;
            poorHit = .75f;
            normalHit = 1f;
            goodHit = 1.25f;
            excHit = 1.5f;
            masterHit = 1.75f;
            legHit = 2.0f;

            //Research Speed
            resQuality = true;
            awfulRes = .8f;
            poorRes = .9f;
            normalRes = 1f;
            goodRes = 1.1f;
            excRes = 1.2f;
            masterRes = 1.35f;
            legRes = 1.5f;

            //Work Table Speed
            workQuality = false;
            awfulWork = .8f;
            poorWork = .9f;
            normalWork = 1f;
            goodWork = 1.1f;
            excWork = 1.2f;
            masterWork = 1.35f;
            legWork = 1.5f;

            //Door Open Speed
            doorQuality = false;
            awfulDoor = .8f;
            poorDoor = .9f;
            normalDoor = 1f;
            goodDoor = 1.1f;
            excDoor = 1.2f;
            masterDoor = 1.35f;
            legDoor = 1.5f;

            //Ranged Cooldown
            rangedQuality = false;
            awfulRanged = .8f;
            poorRanged = .9f;
            normalRanged = 1f;
            goodRanged = 1.1f;
            excRanged = 1.2f;
            masterRanged = 1.35f;
            legRanged = 1.5f;

            //Melee Cooldown
            meleeQuality = false;
            awfulMelee = .8f;
            poorMelee = .9f;
            normalMelee = 1f;
            goodMelee = 1.1f;
            excMelee = 1.2f;
            masterMelee = 1.35f;
            legMelee = 1.5f;

            //Medical Potency
            medQuality = false;
            awfulMeds = .9f;
            poorMeds = .95f;
            normalMeds = 1f;
            goodMeds = 1.05f;
            excMeds = 1.1f;
            masterMeds = 1.15f;
            legMeds = 1.3f;

            //Turret Accuracy
            /*turretQuality = false;
            awfulTurret = .8f;
            poorTurret = .9f;
            normalTurret = 1f;
            goodTurret = 1.1f;
            excTurret = 1.2f;
            masterTurret = 1.35f;
            legTurret = 1.5f;*/
        }
    }
}


