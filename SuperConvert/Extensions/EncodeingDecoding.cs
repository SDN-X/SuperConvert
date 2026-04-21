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
                ? throw new ArgumentNullException(nameof(textToConvert), "String cannot be empty or null.")
                : SuperHelper.ConvertStringToAscii(textToConvert);
        /// <summary>
        /// Converting list of ascii numbers int[] to text string
        /// </summary>
        /// <param name="asciiArray"></param>
        /// <returns></returns>
        public static string AsciiToString(this int[] asciiArray)
            => (asciiArray == null || asciiArray.Length == 0)
                ? throw new ArgumentNullException(nameof(asciiArray), "Ascii array cannot be empty or null.")
                : SuperHelper.ConvertAsciiToString(asciiArray);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns>Converted Value</returns>
        public static byte ToByte(this bool boolValue) => (byte)(boolValue ? 1 : 0);
        public static byte ToByte(this char charValue) => (byte)charValue;
        public static byte ToByte(this byte byteValue) => byteValue;
        public static byte ToByte(this short shortValue) => shortValue < byte.MinValue || shortValue > byte.MaxValue ? throw new OverflowException() : (byte)shortValue;
        public static byte ToByte(this ushort ushortValue) => ushortValue > byte.MaxValue ? throw new OverflowException() : (byte)ushortValue;
        public static byte ToByte(this int intValue) => intValue < byte.MinValue || intValue > byte.MaxValue ? throw new OverflowException() : (byte)intValue;
        public static byte ToByte(this uint uintValue) => uintValue > byte.MaxValue ? throw new OverflowException() : (byte)uintValue;
        public static byte ToByte(this long longValue) => longValue < byte.MinValue || longValue > byte.MaxValue ? throw new OverflowException() : (byte)longValue;
        public static byte ToByte(this ulong ulongValue) => ulongValue > byte.MaxValue ? throw new OverflowException() : (byte)ulongValue;
        public static byte ToByte(this float floatValue) => floatValue < byte.MinValue || floatValue > byte.MaxValue ? throw new OverflowException() : (byte)floatValue;
        public static byte ToByte(this double doubleValue) => doubleValue < byte.MinValue || doubleValue > byte.MaxValue ? throw new OverflowException() : (byte)doubleValue;
        public static byte ToByte(this decimal decimalValue) => decimalValue < byte.MinValue || decimalValue > byte.MaxValue ? throw new OverflowException() : (byte)decimalValue;

        //TODO add other dataTypes

    }
}
