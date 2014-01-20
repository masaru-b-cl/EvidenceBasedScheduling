using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvidenceBasedScheduling
{
    public class WorkDayCalculator
    {
        private DateTime baseDate;
        private DateTime[] holidays;

        public WorkDayCalculator(DateTime baseDate)
        {
            this.baseDate = baseDate;
            this.holidays = new DateTime[0];
        }

        public WorkDayCalculator(DateTime baseDate, DateTime[] holidays)
        {
            this.baseDate = baseDate;
            this.holidays = holidays;
        }

        public DateTime Calc(double remainingHours)
        {
            var remeiningDays = Math.Ceiling(remainingHours / 8.0d);

            var candidateWorkday = baseDate;
            while (remeiningDays != 0)
            {
                candidateWorkday = candidateWorkday.AddDays(1);
                switch (candidateWorkday.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        candidateWorkday = candidateWorkday.AddDays(2);
                        break;
                }
                if (holidays.Contains(candidateWorkday))
                {
                    candidateWorkday = candidateWorkday.AddDays(1);
                }
                remeiningDays = remeiningDays - 1;
            }
            return candidateWorkday;
        }
    }
}
