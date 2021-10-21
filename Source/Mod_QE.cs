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
        private static int currentTab = 0;
        public static Settings_QE settings;

        public Mod_QE(ModContentPack content) : base(content)
        {
            settings = GetSettings<Settings_QE>();
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
            TextAnchor anchor = Text.Anchor;
            Rect rect = inRect;
            //rect.height -= 60f;
            //rect.y -= 60f;
            if (listing.ButtonText("Reset Settings", null)) Settings_QE.ResetDefaults();
            DoTabs(listing, inRect);
            //Settings_Config.DoStatParts(listing, inRect);
            Text.Anchor = anchor;
            listing.End();
            //DoStatParts(inRect);
            base.DoSettingsWindowContents(inRect);
        }

        public static void DoTabs(Listing_Standard listing, Rect canvas)
        {
            canvas = canvas.Rounded();
            canvas.height -= 30f;
            canvas.y += 30f;
            Widgets.DrawMenuSection(canvas);
            List<TabRecord> tabs = new List<TabRecord>()
            {
                new TabRecord("QExpanded.Tab0".Translate(), delegate ()
                {
                    currentTab = 0;
                    settings.Write();
                }, currentTab == 0),
                new TabRecord("QExpanded.Tab1".Translate(), delegate ()
                {
                    currentTab = 1;
                    settings.Write();
                }, currentTab == 1),
                new TabRecord("QExpanded.Tab2".Translate(), delegate ()
                {
                    currentTab = 2;
                    settings.Write();
                }, currentTab == 2),
                new TabRecord("QExpanded.Tab3".Translate(), delegate ()
                {
                    currentTab = 3;
                    settings.Write();
                }, currentTab == 3),
                new TabRecord("QExpanded.Tab4".Translate(), delegate ()
                {
                    currentTab = 4;
                    settings.Write();
                }, currentTab == 4)
            };
            TabDrawer.DrawTabs(canvas, tabs, 200f);
            if (currentTab == 0) Settings_Config.DoHitPoints(listing, canvas);
            if (currentTab == 1) Settings_Config.DoBldg(listing, canvas);



        }
    }
}
