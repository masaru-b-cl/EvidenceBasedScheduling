using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvidenceBasedScheduling.Test
{
    [TestClass]
    public class ShipDateSimulatorTest
    {
        [TestMethod]
        public void シミュレーションを100回行った結果を戻す()
        {
            var estimates = new[] { 4.0d, 16.0d };
            var velocities = new[] { 0.5d, 1.0d, 2.0d };
            var simulator = new ShipDateSimulator(estimates, velocities);

            var baseDate = DateTime.Parse("2014/1/6");
            var shipDates = simulator.Simulate(baseDate);

            shipDates.Is(x =>
                x.Contains(DateTime.Parse("2014/1/8"))
                && x.Contains(DateTime.Parse("2014/1/9"))
                && x.Contains(DateTime.Parse("2014/1/13"))
                );
        }
     }
}
