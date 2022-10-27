using SuperConvert.Extensions.Helpers;
using System;

namespace SuperConvert.Extensions
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
                : SuperHelper.ConvertStringToAscii(textToConvert);
        /// <summary>
        /// Converting list of ascii numbers int[] to text string
        /// </summary>
        /// <param name="asciiArray"></param>
        /// <returns></returns>
        public static string AsciiToString(this int[] asciiArray)
            => (asciiArray == null || asciiArray.Length == 0)
                ? throw new ArgumentNullException("Ascci Array can not be empty or null!")
                : SuperHelper.ConvertAsciiToString(asciiArray);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns>Converted Value</returns>
        public static byte ToByte(this bool boolValue) => (byte)(boolValue ? 1 : 0);
        public static byte ToByte(this char charValue) => (byte)charValue;
        public static byte ToByte(this byte byteValue) => byteValue;
        public static byte ToByte(this short shortValue) => shortValue < 0 || shortValue > 255 ? throw new StackOverflowException() : (byte)shortValue;
        public static byte ToByte(this ushort ushortValue) => ushortValue < 0 || ushortValue > 255 ? throw new StackOverflowException() : (byte)ushortValue;
        public static byte ToByte(this int intValue) => intValue < 0 || intValue > 255 ? throw new StackOverflowException() : (byte)intValue;
        public static byte ToByte(this uint uintValue) => uintValue < 0 || uintValue > 255 ? throw new StackOverflowException() : (byte)uintValue;
        public static byte ToByte(this long longValue) => longValue < 0 || longValue > 255 ? throw new StackOverflowException() : (byte)longValue;
        public static byte ToByte(this ulong ulongValue) => ulongValue < 0 || ulongValue > 255 ? throw new StackOverflowException() : (byte)ulongValue;
        public static byte ToByte(this float floatValue) => floatValue < 0f || floatValue > 255f ? throw new StackOverflowException() : (byte)floatValue;
        public static byte ToByte(this double doubleValue) => doubleValue < 0.0 || doubleValue > 255.0 ? throw new StackOverflowException() : (byte)doubleValue;
        public static byte ToByte(this decimal decimalValue) => decimalValue < 0.0m || decimalValue > 255.0m ? throw new StackOverflowException() : (byte)decimalValue;

        //TODO add other dataTypes

    }
}
