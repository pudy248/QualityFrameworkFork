using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;
using HarmonyLib;


namespace QualityExpanded
{
    public class Mod_QE : Mod
    {
        Listing_Standard listing = new Listing_Standard();

        public Mod_QE(ModContentPack content) : base(content)
        {
            GetSettings<Settings_QE>();
            Harmony harmony = new Harmony("rimworld.qualityexpanded");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            //Log.Message("Quality Patch Ran");
        }

        public override string SettingsCategory()
        {
            return "Quality Expanded";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            listing.Begin(inRect);
            Rect rect = inRect;
            rect.height -= 60f;
            rect.y -= 60f;
            Settings_Config.DoStatParts(listing, inRect);
            listing.End();
            //DoStatParts(inRect);
            base.DoSettingsWindowContents(inRect);
        }
    }
}
