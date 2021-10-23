using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Verse;
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
            //Log.Message("Current y is " + inRect.y);
            //Log.Message("Height is " + inRect.height);
            //Log.Message("Hight point is " + inRect.yMin);
            //Log.Message("Low point is " + inRect.yMax);

            listing.Begin(inRect);
            TextAnchor anchor = Text.Anchor;
            Rect rect = inRect;
            rect.height -= 60f;
            if (listing.ButtonText("Reset Settings", null)) Settings_QE.ResetDefaults();
            DoTabs(listing, rect);
            listing.End();

            listing.Begin(new Rect(inRect.x + inRect.width / 3, 590f, inRect.width / 2, 48f));
            Text.Anchor = TextAnchor.MiddleCenter;
            Text.Font = GameFont.Medium;
            if (currentTab == 0) listing.Label("QExpanded.DetRestart".Translate());
            else listing.Label("QExpanded.Restart".Translate());;
            Text.Anchor = anchor;
            listing.End();
            base.DoSettingsWindowContents(inRect);
        }

        public static void DoTabs(Listing_Standard listing, Rect canvas)
        {
            canvas = canvas.Rounded();
            canvas.height -= 50f;
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
                /*new TabRecord("QExpanded.Tab2".Translate(), delegate ()
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
                }, currentTab == 4)*/
            };
            TabDrawer.DrawTabs(canvas, tabs, 200f);
            if (currentTab == 0) Settings_Config.DoDeterioration(listing, canvas);
            if (currentTab == 1) Settings_Config.DoExpanded(listing, canvas);
            //if (currentTab == 2) Settings_Config.DoWeapons(listing, canvas);



        }
    }
}
