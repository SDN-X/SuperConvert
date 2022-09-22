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
        public static int[] ToAsciiList(this string textToConvert) => string.IsNullOrEmpty(textToConvert)
                ? throw new ArgumentNullException("String can not be empty or null!")
                : Helpers.ConvertStringToAscii(textToConvert);
        /// <summary>
        /// Converting list of ascii numbers int[] to text string
        /// </summary>
        /// <param name="asciiArray"></param>
        /// <returns></returns>
        public static string AsciiToString(this int[] asciiArray)
            => (asciiArray == null || asciiArray.Length == 0)
                ? throw new ArgumentNullException("Ascci Array can not be empty or null!")
                : Helpers.ConvertAsciiToString(asciiArray);

    }
}
