using System;
using System.Globalization;

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
        /// <summary>
        /// Checks if current birthday's age is bigger than specified age
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns>bool</returns>
        public static bool IsAgeGreaterThan(this DateTime birthDate, int age) => birthDate < DateTime.UtcNow.Subtract(new TimeSpan(365 * age, 0, 0, 0));

        /// <summary>
        /// Checks if current birthday's age is smaller than specified age
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns>bool</returns>
        public static bool IsAgeLessThan(this DateTime birthDate, int age) => birthDate > DateTime.UtcNow.Subtract(new TimeSpan(365 * age, 0, 0, 0));
        /// <summary>
        /// Checks if current birthday's age is equals than specified age
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns>bool</returns>
        public static bool IsAgeEqualsTo(this DateTime birthDate, int age) => age == DateTime.Now.Year - birthDate.Year;
    }
}