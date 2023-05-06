using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace EnhancedCarryingCapacity
{
    internal sealed class EnhancedCarryingCapacitySettings : ModSettings
    {
        public const float DefaultMassMultiplier = 1f; // carrying capacity (vanilla) OR weight (CE)
        public const float DefaultBulkMultiplier = 1f; // bulk (CE)

        private static EnhancedCarryingCapacitySettings instance;
        public static EnhancedCarryingCapacitySettings Instance
        {
            get
            {
                if (instance == default) instance = LoadedModManager.GetMod<EnhancedCarryingCapacity>().GetSettings<EnhancedCarryingCapacitySettings>();
                return instance;
            }
        }

        private float m_massMultiplier = DefaultMassMultiplier;
        public float MassMultiplier => m_massMultiplier;

        private float m_bulkMultiplier = DefaultBulkMultiplier;
        public float BulkMultiplier => m_bulkMultiplier;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref m_massMultiplier, "MassMultiplier", DefaultMassMultiplier);
            Scribe_Values.Look(ref m_bulkMultiplier, "BulkMultiplier", DefaultBulkMultiplier);
            base.ExposeData();
        }


        public void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            m_massMultiplier = listingStandard.SliderLabeled(
                "EnhancedCarryingCapacity.MassMultiplier".Translate(), m_massMultiplier,
                0.1f, 10f, tooltip: "EnhancedCarryingCapacity.MassMultiplier.Tooltip".Translate());
            if (EnhancedCarryingCapacity.Instance.CombatExtendedActive)
            {
                m_bulkMultiplier = listingStandard.SliderLabeled(
                    "EnhancedCarryingCapacity.BulkMultiplier".Translate(), m_bulkMultiplier,
                    0.1f, 10f, tooltip: "EnhancedCarryingCapacity.BulkMultiplier.Tooltip".Translate());
            }
        }
    }
}
