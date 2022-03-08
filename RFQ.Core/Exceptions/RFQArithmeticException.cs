namespace RFQ.Core.Exceptions
{
    using System;
    using Options;

    [Serializable]
    public sealed class RFQArithmeticException : RFQException
    {
        public RFQArithmeticException(string message) 
            : base(message, Error.Arithmetic) {}

        public RFQArithmeticException(string message, Exception inner) 
            : base(message, Error.Arithmetic, inner) {}
    }
}
