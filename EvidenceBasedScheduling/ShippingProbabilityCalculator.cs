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

        public double CalcProbability(DateTime targetDate)
        {
            var cleared = simulatedShipDates.Count(x => x <= targetDate);

            return Math.Round(((double)cleared / simulatedShipDates.Count()) * 100d, 1);
        }

        public DateTime CalcShipDate(double probability)
        {
            var count = 0;
            foreach(var shipDate in simulatedShipDates.OrderBy(x => x))
            {
                count++;
                var ratio = ((double)count / simulatedShipDates.Count()) * 100d;
                if (ratio >= probability)
                {
                    return shipDate;
                }
            }
            return simulatedShipDates.Max();
        }
    }
}
