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
        /// Converting any text to list of ascci numbers int[]
        /// </summary>
        /// <param name="textToConvert"></param>
        /// <returns></returns>
        public static int[] ToAsciiList(this string textToConvert)
        {
            return Helpers.ConvertStringToAscii(textToConvert);
        }
        /// <summary>
        /// Converting list of ascci numbers int[] to text string
        /// </summary>
        /// <param name="asciiArray"></param>
        /// <returns></returns>
        public static string ToAsciiList(this int[] asciiArray)
        {
            return Helpers.ConvertAsciiToString(asciiArray);
        }

    }
}
