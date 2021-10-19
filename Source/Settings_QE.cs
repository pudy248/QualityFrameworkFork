using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;


namespace QualityExpanded 
{
    public class Settings_QE : ModSettings
    { 
        //Hit Points
        public static bool hitQuality = true;
        public static float awfulHit = .5f;
        public static float poorHit = .75f;
        public static float normalHit = 1f;
        public static float goodHit = 1.25f;
        public static float excHit = 1.5f;
        public static float masterHit = 1.75f;
        public static float legHit = 2.0f;

        //Research Speed
        public static bool resQuality = true;
        public static float awfulRes = .6f;
        public static float poorRes = .8f;
        public static float normalRes = 1f;
        public static float goodRes = 1.2f;
        public static float excRes = 1.4f;
        public static float masterRes = 1.6f;
        public static float legRes = 1.8f;

        //Work Table Speed
        public static bool workQuality = true;
        public static float awfulWork = .6f;
        public static float poorWork = .8f;
        public static float normalWork = 1f;
        public static float goodWork = 1.2f;
        public static float excWork = 1.4f;
        public static float masterWork = 1.6f;
        public static float legWork = 1.8f;

        public override void ExposeData()
        {
            //Hit Points
            Scribe_Values.Look<bool>(ref hitQuality, "hitQuality", true);
            Scribe_Values.Look<float>(ref awfulHit, "awfulHit", .5f);
            Scribe_Values.Look<float>(ref poorHit, "poorHit", .75f);
            Scribe_Values.Look<float>(ref normalHit, "normalHit", 1f);
            Scribe_Values.Look<float>(ref goodHit, "goodHit", 1.25f);
            Scribe_Values.Look<float>(ref excHit, "exclHit", 1.5f);
            Scribe_Values.Look<float>(ref masterHit, "masterHit", 1.75f);
            Scribe_Values.Look<float>(ref legHit, "legHit", 2f);

            //Research Speed
            Scribe_Values.Look<bool>(ref resQuality, "resQuality", true);
            Scribe_Values.Look<float>(ref awfulRes, "awfulRes", .5f);
            Scribe_Values.Look<float>(ref poorRes, "poorRes", .75f);
            Scribe_Values.Look<float>(ref normalRes, "normalRes", 1f);
            Scribe_Values.Look<float>(ref goodRes, "goodRes", 1.25f);
            Scribe_Values.Look<float>(ref excRes, "excRes", 1.5f);
            Scribe_Values.Look<float>(ref masterRes, "masterRes", 1.75f);
            Scribe_Values.Look<float>(ref legRes, "legRes", 2f);

            //WorkTable Speed
            Scribe_Values.Look<bool>(ref workQuality, "workQuality", true);
            Scribe_Values.Look<float>(ref awfulWork, "awfulWork", .5f);
            Scribe_Values.Look<float>(ref poorWork, "poorWork", .75f);
            Scribe_Values.Look<float>(ref normalWork, "normalWork", 1f);
            Scribe_Values.Look<float>(ref goodWork, "goodWork", 1.25f);
            Scribe_Values.Look<float>(ref excWork, "excWork", 1.5f);
            Scribe_Values.Look<float>(ref masterWork, "masterWork", 1.75f);
            Scribe_Values.Look<float>(ref legWork, "legWork", 2f);
        }
    }
}

