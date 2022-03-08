namespace RFQ.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using Options;

    [Serializable]
    public abstract class RFQException
        : Exception
    {
        private readonly Error _error;

        protected RFQException(string message, Error error) 
            : base(message) { _error = error; }

        protected RFQException(string message, Error error, Exception inner) 
            : base(message, inner) { _error = error; }

        protected RFQException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
                _error = (Error)((int)info.GetValue("Error code", typeof(int)));
        }

        public int GetErrorCode()
        {
            return (int)_error;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Error code", GetErrorCode());
        }
    }
}
