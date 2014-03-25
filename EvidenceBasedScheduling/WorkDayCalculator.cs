using System;
using System.Collections.Generic;
using System.Linq;

namespace EvidenceBasedScheduling
{
    /// <summary>
    /// Calculate workday from base date and holidays.
    /// </summary>
    public class WorkDayCalculator
    {
        private DateTime baseDate;
        private IEnumerable<DateTime> holidays;

        /// <summary>
        /// Initialize new WorkDayCalculator class instance with base date.
        /// </summary>
        /// <param name="baseDate">Base dates.</param>
        public WorkDayCalculator(DateTime baseDate)
          : this(baseDate, new DateTime[0])
        {
        }

        /// <summary>
        /// Initialize new WorkDayCalculator class instance with base date and holidays.
        /// </summary>
        /// <param name="baseDate">Base dates.</param>
        /// <param name="holidays">Holidays.</param>
        public WorkDayCalculator(DateTime baseDate, IEnumerable<DateTime> holidays)
        {
            this.baseDate = baseDate;
            this.holidays = holidays;
        }

        /// <summary>
        /// Caluculate workday from remaining hours.
        /// </summary>
        /// <param name="remainingHours">Remaining hours.</param>
        /// <returns>Work day.</returns>
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
