using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvidenceBasedScheduling;

namespace EvidenceBasedScheduling.Test
{
    [TestClass]
    public class HourSimulatorTest
    {
        [TestMethod]
        public void ランダムに選択されたVelocityによるシミュレーション結果返ってくる()
        {
            var dice = new VelocityDice(new[] { 1.0d, 0.5d });
            var simulator = new HourSimulator(dice);

            var estimates = new[] { 1.0d, 1.0d };
            var actual = Enumerable.Range(1, 100).Select(_ => simulator.Simulate(estimates));
            actual.Is(x => actual.Contains(4.0d)
                && actual.Contains(3.0d)
                && actual.Contains(2.0d));
        }
    }
}
