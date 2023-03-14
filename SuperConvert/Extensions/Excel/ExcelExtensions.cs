using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SuperConvert.Extensions.Excel
{
    public static class ExcelExtensions
    {
        public static string ToHex(this Color color)
        {
            byte[] numArray = new byte[4]
            {
                color.A,
                color.R,
                color.G,
                color.B
            };
            char[] chArray = new char[numArray.Length * 2];
            for (int index = 0; index < numArray.Length; ++index)
            {
                int num = numArray[index];
                chArray[index * 2] = digits[num >> 4];
                chArray[index * 2 + 1] = digits[num & 15];
            }
            return new string(chArray);
        }

        public static string RemoveSpecialCharacters(this string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char t in text)
            {
                if (char.IsLetterOrDigit(t) || t == '.' || t == '_')
                    stringBuilder.Append(t);
            }
            return stringBuilder.ToString();
        }

        public static int CharCount(this string instance, char c) => instance.Length - instance.Replace(c.ToString(), "").Length;

        public static bool HasDuplicates<T>(this IEnumerable<T> source)
        {
            HashSet<T> objSet = new HashSet<T>();
            foreach (T obj in source)
            {
                if (objSet.Contains(obj))
                    return true;
                objSet.Add(obj);
            }
            return false;
        }

        public static T CastTo<T>(this object o) => (T)Convert.ChangeType(o, typeof(T));

        private static readonly char[] digits = new char[16]
    {
      '0',
      '1',
      '2',
      '3',
      '4',
      '5',
      '6',
      '7',
      '8',
      '9',
      'A',
      'B',
      'C',
      'D',
      'E',
      'F'
    };

    }
}
