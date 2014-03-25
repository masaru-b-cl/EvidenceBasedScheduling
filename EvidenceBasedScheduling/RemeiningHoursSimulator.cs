using System;
using System.Linq;

namespace EvidenceBasedScheduling
{
    /// <summary>
    /// Simulate remaining hours.
    /// </summary>
    public class RemeiningHoursSimulator
    {
        private VelocityDice dice;

        /// <summary>
        /// Initialize new RemeiningHoursSimulator class instance with velocity dice.
        /// </summary>
        /// <param name="dice">Velocity dice.</param>
        public RemeiningHoursSimulator(VelocityDice dice)
        {
            this.dice = dice;
        }

        /// <summary>
        /// Simulate remaining hours from estimates.
        /// </summary>
        /// <param name="estimates">Estimates.</param>
        /// <returns>Remaining hours.</returns>
        public double Simulate(double[] estimates)
        {
            return estimates.Sum(x => x / dice.Cast());
        }
    }
}
