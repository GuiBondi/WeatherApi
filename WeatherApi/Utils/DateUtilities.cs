using System.Collections.Generic;
using System;

namespace WeatherApi.Utilities
{
    public static class DateUtilities
    {
        public static List<DateTime> GetPreviousWeekDays(DateTime currentDate)
        {
            var previousDates = new List<DateTime>();
            switch (currentDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    previousDates.Add(currentDate.AddDays(-1));
                    break;
                case DayOfWeek.Wednesday:
                    previousDates.Add(currentDate.AddDays(-1));
                    previousDates.Add(currentDate.AddDays(-2));
                    break;
                case DayOfWeek.Thursday:
                    previousDates.Add(currentDate.AddDays(-1));
                    previousDates.Add(currentDate.AddDays(-2));
                    previousDates.Add(currentDate.AddDays(-3));
                    break;
                case DayOfWeek.Friday:
                    previousDates.Add(currentDate.AddDays(-1));
                    previousDates.Add(currentDate.AddDays(-2));
                    previousDates.Add(currentDate.AddDays(-3));
                    previousDates.Add(currentDate.AddDays(-4));
                    break;
                case DayOfWeek.Saturday:
                    previousDates.Add(currentDate.AddDays(-1));
                    previousDates.Add(currentDate.AddDays(-2));
                    previousDates.Add(currentDate.AddDays(-3));
                    previousDates.Add(currentDate.AddDays(-4));
                    previousDates.Add(currentDate.AddDays(-5));
                    break;
                case DayOfWeek.Sunday:
                    previousDates.Add(currentDate.AddDays(-1));
                    previousDates.Add(currentDate.AddDays(-2));
                    previousDates.Add(currentDate.AddDays(-3));
                    previousDates.Add(currentDate.AddDays(-4));
                    previousDates.Add(currentDate.AddDays(-5));
                    previousDates.Add(currentDate.AddDays(-6));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return previousDates;
        }

        public static int GetDaysRemaining()
        {
            int daysUntilSunday = (DayOfWeek.Sunday - DateTime.Now.DayOfWeek + 7) % 7;
            return daysUntilSunday == 0 ? 7 : daysUntilSunday;
        }
    }
}