using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvidenceBasedScheduling;

namespace EvidenceBasedScheduling.Test
{
    [TestClass]
    public class VelocityDiceTest
    {
        [TestMethod]
        public void 一つのVelocityを渡すと同じ結果が返ってくる()
        {
            var velocities = new[] { 1.0d };
            var dice = new VelocityDice(velocities);

            var velocity = dice.Cast();
            velocity.Is(1.0d);
        }
    }
}
