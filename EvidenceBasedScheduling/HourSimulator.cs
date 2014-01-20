using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvidenceBasedScheduling
{
    public class HourSimulator
    {
        private VelocityDice dice;

        public HourSimulator(VelocityDice dice)
        {
            this.dice = dice;
        }

        public double Simulate(double[] estimates)
        {
            return estimates.Sum(x => x / dice.Cast());
        }
    }
}
