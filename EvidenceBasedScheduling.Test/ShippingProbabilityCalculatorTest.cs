using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvidenceBasedScheduling.Test
{
    public class ShippingProbabilityCalculatorTest
    {
        [TestClass]
        public class 日付から確率を求める
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
                var probability = calculator.CalcProbability(targetDate);

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
                var probability = calculator.CalcProbability(targetDate);

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
                var probability = calculator.CalcProbability(targetDate);

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
                var probability = calculator.CalcProbability(targetDate);

                probability.Is(0d);
            }
        }

        [TestClass]
        public class 確率から日付を求める
        {
            [TestMethod]
            public void 確率100パーセントはシミュレーション結果日のうち一番先の日付を戻す()
            {
                var simulatedShipDates = new[]
                {
                    DateTime.Parse("2013/1/15"),
                    DateTime.Parse("2013/1/16"),
                };

                var calculator = new ShippingProbabilityCalculator(simulatedShipDates);
                var probability = 100.0d;
                var shipDate = calculator.CalcShipDate(probability);

                shipDate.Is(DateTime.Parse("2013/1/16"));
            }
            [TestMethod]
            public void 確率50パーセントはシミュレーション結果日を順に並べて半分になった日付を戻す()
            {
                var simulatedShipDates = new[]
                {
                    DateTime.Parse("2013/1/16"),
                    DateTime.Parse("2013/1/15"),
                    DateTime.Parse("2013/1/14"),
               };

                var calculator = new ShippingProbabilityCalculator(simulatedShipDates);
                var probability = 50.0;
                var shipDate = calculator.CalcShipDate(probability);

                shipDate.Is(DateTime.Parse("2013/1/15"));
            }
            [TestMethod]
            public void 確率30パーセントはシミュレーション結果日を順に並べて十分の三になった日付を戻す()
            {
                var simulatedShipDates = new[]
                {
                    DateTime.Parse("2013/1/15"),
                    DateTime.Parse("2013/1/15"),
                    DateTime.Parse("2013/1/14"),
                };
                var calculator = new ShippingProbabilityCalculator(simulatedShipDates);
                var probability = 30.0d;
                var shipDate = calculator.CalcShipDate(probability);

                shipDate.Is(DateTime.Parse("2013/1/14"));
            }
            [TestMethod]
            public void 確率0パーセント未満はエラー()
            {
                var simulatedShipDates = new[]
                {
                    DateTime.Parse("2013/1/16"),
                    DateTime.Parse("2013/1/15"),
                    DateTime.Parse("2013/1/14"),
                };
                var calculator = new ShippingProbabilityCalculator(simulatedShipDates);
                var probability = 0.0d;
                var shipDate = calculator.CalcShipDate(probability);

                shipDate.Is(DateTime.Parse("2013/1/14"));
            }
        }
    }
}
