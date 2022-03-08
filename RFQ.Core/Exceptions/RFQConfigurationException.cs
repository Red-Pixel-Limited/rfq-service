namespace RFQ.Core.Exceptions
{
    using System;
    using Options;

    [Serializable]
    public class RFQConfigurationException : RFQException
    {
        public RFQConfigurationException(string message) 
            : base(message, Error.Configuration) {}

        public RFQConfigurationException(string message, Exception inner) 
            : base(message, Error.Configuration, inner) {}
    }
}
