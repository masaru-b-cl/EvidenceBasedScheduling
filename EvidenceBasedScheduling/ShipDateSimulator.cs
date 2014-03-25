using System;
using System.Collections.Generic;
using System.Linq;

namespace EvidenceBasedScheduling
{
    /// <summary>
    /// Simulation ship date from estimates and velocities.
    /// </summary>
    public class ShipDateSimulator
    {
        private double[] estimates;
        private double[] velocities;

        /// <summary>
        /// Initialize new ShipDateSimulator class instance with estimates and velocities.
        /// </summary>
        /// <param name="estimates">Estimates.</param>
        /// <param name="velocities">Velocities.</param>
        public ShipDateSimulator(double[] estimates, double[] velocities)
        {
            this.estimates = estimates;
            this.velocities = velocities;
        }

        /// <summary>
        /// Simulation ship dates.
        /// </summary>
        /// <param name="baseDate">Base date.</param>
        /// <returns>Ship dates.</returns>
        public IEnumerable<DateTime> Simulate(DateTime baseDate)
        {
          return Simulate(baseDate, new DateTime[] { });
        }

        /// <summary>
        /// Simulation ship dates.
        /// </summary>
        /// <param name="baseDate">Base date.</param>
        /// <param name="holidays">Horidays.</param>
        /// <returns>Ship dates.</returns>
        public IEnumerable<DateTime> Simulate(DateTime baseDate, IEnumerable<DateTime> holidays)
        {
            var dice = new VelocityDice(velocities);
            var simulator = new RemeiningHoursSimulator(dice);
            var calculator = new WorkDayCalculator(baseDate, holidays);

            return Enumerable.Range(1, 1000)
                .Select(_ => simulator.Simulate(estimates))
                .Select(r => calculator.Calc(r));
        }
    }
}
