namespace RFQ.Core.Exceptions
{
    using System;
    using Options;

    [Serializable]
    public sealed class RFQCommunicationException : RFQException
    {
        public RFQCommunicationException(string message) 
            : base(message, Error.Communication) {}

        public RFQCommunicationException(string message, Exception inner) 
            : base(message, Error.Communication, inner) {}
    }
}
