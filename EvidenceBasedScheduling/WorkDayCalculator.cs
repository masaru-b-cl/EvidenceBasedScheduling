using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvidenceBasedScheduling
{
    public class WorkDayCalculator
    {
        private DateTime baseDate;

        public WorkDayCalculator(DateTime baseDate)
        {
            this.baseDate = baseDate;
        }

        public DateTime Calc(double remainingHours)
        {
            var remeiningDays = Math.Ceiling(remainingHours / 8.0d);
            return baseDate.AddDays(remeiningDays);
        }
    }
}
