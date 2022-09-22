using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperConvert.Extentions.Interfaces;

public interface IDateConverter
{
    DateTime HijriToGregorian(DateTime date);
    DateTime GregorianToHijri(DateTime date);
}