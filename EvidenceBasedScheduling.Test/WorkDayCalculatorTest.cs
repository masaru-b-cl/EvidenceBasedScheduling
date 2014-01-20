using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvidenceBasedScheduling;

namespace EvidenceBasedScheduling.Test
{
    [TestClass]
    public class WorkDayCalculatorTest
    {
        [TestMethod]
        public void 残時間に0を渡すと基準日を戻す()
        {
            var baseDate = DateTime.Parse("2014/1/6");
            var remainingHours = 0.0d;
            var calculator = new WorkDayCalculator(baseDate);
            var workDay = calculator.Calc(remainingHours);

            workDay.Is(DateTime.Parse("2014/1/6"));
        }

        [TestMethod]
        public void 残時間に8を渡すと翌日を戻す()
        {
            var baseDate = DateTime.Parse("2014/1/6");
            var remainingHours = 8.0d;
            var calculator = new WorkDayCalculator(baseDate);
            var workDay = calculator.Calc(remainingHours);

            workDay.Is(DateTime.Parse("2014/1/7"));
        }

        [TestMethod]
        public void 残時間に0以上8未満の自然数を渡すと翌日を戻す()
        {
            var baseDate = DateTime.Parse("2014/1/6");
            var remainingHours = 7.9d;
            var calculator = new WorkDayCalculator(baseDate);
            var workDay = calculator.Calc(remainingHours);

            workDay.Is(DateTime.Parse("2014/1/7"));
        }

        [TestMethod]
        public void 残時間に8を超える自然数を渡すと翌々日を戻す()
        {
            var baseDate = DateTime.Parse("2014/1/6");
            var remainingHours = 8.1d;
            var calculator = new WorkDayCalculator(baseDate);
            var workDay = calculator.Calc(remainingHours);

            workDay.Is(DateTime.Parse("2014/1/8"));
        }

        [TestMethod]
        public void 金曜日の翌営業日は翌週月曜()
        {
            var baseDate = DateTime.Parse("2014/1/17");
            var remainingHours = 0.1d;
            var calculator = new WorkDayCalculator(baseDate);
            var workDay = calculator.Calc(remainingHours);

            workDay.Is(DateTime.Parse("2014/1/20"));
        }

        [TestMethod]
        public void 金曜日の6営業日後は翌々週の月曜()
        {
            var baseDate = DateTime.Parse("2014/1/17");
            var remainingHours = 6.0d /* day */ * 8.0d /* working hours per day */;
            var calculator = new WorkDayCalculator(baseDate);
            var workDay = calculator.Calc(remainingHours);

            workDay.Is(DateTime.Parse("2014/1/27"));
        }

        [TestMethod]
        public void 指定した休日はスキップする()
        {
            var holidays = new[] { DateTime.Parse("2014/1/13") };
            var baseDate = DateTime.Parse("2014/1/10");
            var remainingHours = 0.1d;
            var calculator = new WorkDayCalculator(baseDate, holidays);
            var workDay = calculator.Calc(remainingHours);

            workDay.Is(DateTime.Parse("2014/1/14"));
        }
    }
}
