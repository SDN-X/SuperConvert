using System;
using System.Linq;

namespace SuperConvert.Extentions.Helpers
{
    internal class SuperException : Exception
    {
        public string TechnicalMessage { get; }
        public int ErrorCode { get; }
        public SuperException(string technicalMessage, int errorCode)
        {
            TechnicalMessage = technicalMessage;
            ErrorCode = errorCode;
        }
    }
}
