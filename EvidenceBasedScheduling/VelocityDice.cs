﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvidenceBasedScheduling
{
    public class VelocityDice
    {
        Random rand = new Random();
        private readonly double[] velocities;

        public VelocityDice(double[] velocities)
        {
            this.velocities = velocities;
        }

        public double Cast()
        {
            var index = rand.Next(velocities.Length);
            return velocities[index];
        }
    }
}
