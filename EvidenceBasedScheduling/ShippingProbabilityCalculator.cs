using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvidenceBasedScheduling
{
    public class ShippingProbabilityCalculator
    {
        private DateTime[] simulatedShipDates;

        public ShippingProbabilityCalculator(DateTime[] simulatedShipDates)
        {
            this.simulatedShipDates = simulatedShipDates;
        }

        public double Calc(DateTime targetDate)
        {
            var cleared = simulatedShipDates.Count(x => x <= targetDate);

            return cleared / simulatedShipDates.Count() * 100d;
        }
    }
}
