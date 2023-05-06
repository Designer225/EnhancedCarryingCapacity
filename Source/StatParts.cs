using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace EnhancedCarryingCapacity
{
    internal sealed class StatPart_MassModifier : StatPart
    {
        public override string ExplanationPart(StatRequest req)
        {
            return "StatsReport_MassModifier".Translate() + ": x" + EnhancedCarryingCapacitySettings.Instance.MassMultiplier;
        }

        public override void TransformValue(StatRequest req, ref float val)
        {
            val *= EnhancedCarryingCapacitySettings.Instance.MassMultiplier;
        }
    }

    internal sealed class StatPart_BulkModifier : StatPart
    {
        public override string ExplanationPart(StatRequest req)
        {
            return "StatsReport_BulkModifier".Translate() + ": x" + EnhancedCarryingCapacitySettings.Instance.BulkMultiplier;
        }

        public override void TransformValue(StatRequest req, ref float val)
        {
            val *= EnhancedCarryingCapacitySettings.Instance.BulkMultiplier;
        }
    }
}
