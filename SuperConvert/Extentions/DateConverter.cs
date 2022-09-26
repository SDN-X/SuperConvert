using SuperConvert.Extentions.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperConvert.Extentions
{
    public static class DateConverter
    {
        public static DateTime GregorianToHijri(DateTime date)
        {
            if (date.Year >= 1900)
            {
                var result = ConvertDateCalendar(date, Enums.Calender.Hijri);
                return DateTime.Parse(result);
            }
            return date;
        }
        public static DateTime HijriToGregorian(DateTime date)
        {
            if (date.Year < 1900)
            {
                var result = ConvertDateCalendar(date, Enums.Calender.Gregorian);
                return DateTime.Parse(result);


            }
            return date;
        }


        private static string ConvertDateCalendar(DateTime date, Enums.Calender Calendar)
        {
            string result = string.Empty;
            switch (Calendar)
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