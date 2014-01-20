using System;
using System.Linq;
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
        [TestMethod]
        public void 二つのVelocityを渡すと二つの結果がバラバラに返ってくる()
        {
            var velocities = new[] { 2.0d, 3.0d };
            var dice = new VelocityDice(velocities);

            var actual = Enumerable.Range(1, 100).Select(_ => dice.Cast());
            actual.Is(x => actual.Contains(2.0d) && actual.Contains(3.0d));
        }
    }
}
