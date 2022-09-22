using SuperConvert.Extentions.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperConvert.Extentions;

public static class DateConverter
{
    private static string arLangCulture = "ar-SA";
    private static string enLangCulture = "en-US";
    public static DateTime GregorianToHijri(DateTime date)
    {
        if (date.Year >= 1900)
        {
            var result = DateTime.Parse(ConvertDateCalendar(date, Enums.Calender.Hijri, arLangCulture));
            return result;
        }
        return date;
    }
    public static DateTime HijriToGregorian(DateTime date)
    {
        if (date.Year < 1900)
        {
            var result = DateTime.Parse(ConvertDateCalendar(date, Enums.Calender.Gregorian, enLangCulture));
            return result;
        }
        return date;
    }


    public static string ConvertDateCalendar(DateTime date, Enums.Calender calendar, string dateLangCulture)
    {
        dateLangCulture = dateLangCulture.ToLower();

        if (calendar == Enums.Calender.Hijri && dateLangCulture == enLangCulture)
            dateLangCulture = arLangCulture;

        DateTimeFormatInfo dateTimeFormatInfo = new CultureInfo(dateLangCulture, false).DateTimeFormat;

        switch (calendar)
        {
            case Enums.Calender.Hijri:
                dateTimeFormatInfo.Calendar = new HijriCalendar();
                break;

            case Enums.Calender.Gregorian:
                dateTimeFormatInfo.Calendar = new GregorianCalendar();
                break;

            default:
                return "";
        }
        dateTimeFormatInfo.ShortDatePattern = "yyyy-MM-dd";
        return (date.Date.ToString("yyyy-MM-dd", dateTimeFormatInfo));
    }
}