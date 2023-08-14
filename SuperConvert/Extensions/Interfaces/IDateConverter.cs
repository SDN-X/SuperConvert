using System;

namespace SuperConvert.Extensions.Interfaces
{
    public interface IDateConverter
    {
        DateTime HijriToGregorian(DateTime date);
        DateTime GregorianToHijri(DateTime date);
    }
}