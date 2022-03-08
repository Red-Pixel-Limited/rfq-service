namespace RFQ.Communication.Messages.Incoming
{
    public sealed class YieldBrokersHeartbeats : CommunicationMessage
    {
        public YieldBrokersHeartbeats(string requestId) 
            : base(requestId) {}
    }
}
