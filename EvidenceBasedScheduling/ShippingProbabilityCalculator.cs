using System;
using System.Collections.Generic;
using System.Linq;

namespace EvidenceBasedScheduling
{
    /// <summary>
    /// Calculate shipping probability and ship date.
    /// </summary>
    public class ShippingProbabilityCalculator
    {
        private IEnumerable<DateTime> simulatedShipDates;

        /// <summary>
        /// Initialize new ShipDateSimulator class instance with simulated ship dates.
        /// </summary>
        /// <param name="simulatedShipDates">Simulated ship dates.</param>
        public ShippingProbabilityCalculator(IEnumerable<DateTime> simulatedShipDates)
        {
            this.simulatedShipDates = simulatedShipDates;
        }

        /// <summary>
        /// Calculate shipping probability from target date.
        /// </summary>
        /// <param name="targetDate">Target date.</param>
        /// <returns>Shipping probability.</returns>
        public double CalcProbability(DateTime targetDate)
        {
            var cleared = simulatedShipDates.Count(x => x <= targetDate);

            return Math.Round(((double)cleared / simulatedShipDates.Count()) * 100d, 1);
        }

        /// <summary>
        /// Calculate ship date from probability.
        /// </summary>
        /// <param name="probability">Probability.</param>
        /// <returns>Ship date.</returns>
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
