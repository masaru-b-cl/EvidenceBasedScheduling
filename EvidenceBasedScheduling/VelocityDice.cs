using System;

namespace EvidenceBasedScheduling
{
    /// <summary>
    /// Cast velocity.
    /// </summary>
    public class VelocityDice
    {
        Random rand = new Random();
        private readonly double[] velocities;

        /// <summary>
        /// Initialize new VelocityDice class instance with velocities.
        /// </summary>
        /// <param name="velocities">Velocities.</param>
        public VelocityDice(double[] velocities)
        {
            this.velocities = velocities;
        }

        /// <summary>
        /// Cast velocity.
        /// </summary>
        /// <returns>Velocity.</returns>
        public double Cast()
        {
            var index = rand.Next(velocities.Length);
            return velocities[index];
        }
    }
}
