using System;

namespace RFQ.Core.Exceptions
{
    using Options;

    [Serializable]
    public class RFQRuntimeException : RFQException
    {
        public RFQRuntimeException(string message) 
            : base(message, Error.Runtime) {}

        public RFQRuntimeException(string message, Exception inner) 
            : base(message, Error.Runtime, inner) {}
    }
}
