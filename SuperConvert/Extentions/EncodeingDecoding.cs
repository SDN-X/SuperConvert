using SuperConvert.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperConvert.Extentions
{
    public static class EncodeingDecoding
    {
        /// <summary>
        /// Converting any text to list of ascii numbers int[]
        /// </summary>
        /// <param name="textToConvert"></param>
        /// <returns></returns>
        public static int[] ToAsciiArray(this string textToConvert) => string.IsNullOrEmpty(textToConvert)
                ? throw new ArgumentNullException("String can not be empty or null!")
                : Helper.ConvertStringToAscii(textToConvert);
        /// <summary>
        /// Converting list of ascii numbers int[] to text string
        /// </summary>
        /// <param name="asciiArray"></param>
        /// <returns></returns>
        public static string AsciiToString(this int[] asciiArray)
            => (asciiArray == null || asciiArray.Length == 0)
                ? throw new ArgumentNullException("Ascci Array can not be empty or null!")
                : Helper.ConvertAsciiToString(asciiArray);

    }
}
