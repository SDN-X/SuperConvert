using SuperConvert.Extensions.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperConvert.Extensions
{
    public static class DateConverter
    {
        /// <summary>
        /// Convert gregorian date to hijri date
        /// </summary>
        /// <param name="gregorianDate"></param>
        /// <returns>Hijri date</returns>
        public static DateTime GregorianToHijri(DateTime gregorianDate)
        {
            if (gregorianDate.Year >= 1900)
            {
                var result = ConvertDateUsingCalender(gregorianDate, Enums.Calender.Hijri);
                return DateTime.Parse(result);
            }
            return gregorianDate;
        }
        /// <summary>
        /// Convert hijri date to gregorian date
        /// </summary>
        /// <param name="hijriDate"></param>
        /// <returns></returns>
        public static DateTime HijriToGregorian(DateTime hijriDate)
        {
            if (hijriDate.Year < 1900)
            {
                var result = ConvertDateUsingCalender(hijriDate, Enums.Calender.Gregorian);
                return DateTime.Parse(result);


            }
            return hijriDate;
        }
        /// <summary>
        /// Convert date method to hijri date or gregorian date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        private static string ConvertDateUsingCalender(DateTime date, Enums.Calender calendar)
        {
            string result = string.Empty;
            switch (calendar)
            {
                case Enums.Calender.Hijri:
                    CultureInfo cultureInfo = new CultureInfo("ar-SA");
                    cultureInfo.DateTimeFormat.Calendar = new HijriCalendar();
                    cultureInfo.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
                    result = date.ToString("d", cultureInfo);
                    break;

                case Enums.Calender.Gregorian:
                    Calendar umAlQuraCalendar = new UmAlQuraCalendar();
                    DateTime dt = new DateTime(date.Year, date.Month, date.Day, umAlQuraCalendar);
                    result = dt.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}