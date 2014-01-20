using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvidenceBasedScheduling;

namespace EvidenceBasedScheduling.Test
{
    [TestClass]
    public class ShippingProbabilityCalculatorTest
    {
        [TestMethod]
        public void すべてのシミュレーション結果以降の日付であれば100パーセントを戻す()
        {
            var simulatedShipDates = new[]
          {
              DateTime.Parse("2013/1/15"),
          };

            var calculator = new ShippingProbabilityCalculator(simulatedShipDates);
            var targetDate = DateTime.Parse("2013/1/15");
            var probability = calculator.Calc(targetDate);

            probability.Is(100d);
        }

        [TestMethod]
        public void 半分のシミュレーション結果以降の日付であれば50パーセントを戻す()
        {
            var simulatedShipDates = new[]
          {
              DateTime.Parse("2013/1/15"),
              DateTime.Parse("2013/1/16"),
          };

            var calculator = new ShippingProbabilityCalculator(simulatedShipDates);
            var targetDate = DateTime.Parse("2013/1/15");
            var probability = calculator.Calc(targetDate);

            probability.Is(50d);
        }

        [TestMethod]
        public void 三分の一のシミュレーション結果以降の日付であれば50パーセントを戻す()
        {
            var simulatedShipDates = new[]
          {
              DateTime.Parse("2013/1/15"),
              DateTime.Parse("2013/1/16"),
              DateTime.Parse("2013/1/16"),
          };

            var calculator = new ShippingProbabilityCalculator(simulatedShipDates);
            var targetDate = DateTime.Parse("2013/1/15");
            var probability = calculator.Calc(targetDate);

            probability.Is(33.3d);
        }

        [TestMethod]
        public void すべてのシミュレーション結果以前の日付であれば0パーセントを戻す()
        {
            var simulatedShipDates = new[]
          {
              DateTime.Parse("2013/1/16"),
          };

            var calculator = new ShippingProbabilityCalculator(simulatedShipDates);
            var targetDate = DateTime.Parse("2013/1/15");
            var probability = calculator.Calc(targetDate);

            probability.Is(0d);
        }
    }
}
