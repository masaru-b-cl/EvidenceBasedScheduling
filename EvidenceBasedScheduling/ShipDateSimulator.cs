using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvidenceBasedScheduling
{
    public class ShipDateSimulator
    {
        private double[] estimates;
        private double[] velocities;

        public ShipDateSimulator(double[] estimates, double[] velocities)
        {
            this.estimates = estimates;
            this.velocities = velocities;
        }

        public DateTime[] Simulate(DateTime baseDate)
        {
            var dice = new VelocityDice(velocities);
            var simulator = new RemeiningHoursSimulator(dice);
            var calculator = new WorkDayCalculator(baseDate);

            return Enumerable.Range(1, 1000)
                .Select(_ => simulator.Simulate(estimates))
                .Select(r => calculator.Calc(r))
                .ToArray();
        }
    }
}
