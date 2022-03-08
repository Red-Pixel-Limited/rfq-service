namespace RFQ.Communication.Messages
{
    public abstract class CommunicationMessage
    {
        public string RequestId { get; private set; }

        protected CommunicationMessage(string requestId)
        {
            RequestId = requestId;
        }
    }
}
