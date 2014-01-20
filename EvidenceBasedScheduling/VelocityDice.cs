using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvidenceBasedScheduling
{
    public class VelocityDice
    {
        private double[] velocities;

        public VelocityDice(double[] velocities)
        {
            this.velocities = velocities;
        }

        public double Cast()
        {
            return velocities[0];
        }
    }
}
