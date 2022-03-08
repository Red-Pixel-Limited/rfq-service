namespace RFQ.Communication.Messages.Incoming
{
    using Options;

    public sealed class GTNHeartbeat : InstanceMessage
    {
        public string DisplayName { get; private set; }
        public int HeartbeatInterval { get; private set; }
        public int LoadFactor { get; private set; }
        public GTNStatus Status { get; private set; }
        public string ErrorCode { get; private set; }
        public string ErrorReason { get; private set; }

        public GTNHeartbeat(string requestId,
                            string venueId,
                            string productId,
                            string instanceId,
                            string displayName,
                            int heartbeatInterval,
                            int loadFactor,
                            GTNStatus status,
                            string errorCode,
                            string errorReason)
            : base(requestId, venueId, productId, instanceId)
        {
            DisplayName = displayName;
            HeartbeatInterval = heartbeatInterval;
            LoadFactor = loadFactor;
            Status = status;
            ErrorCode = errorCode;
            ErrorReason = errorReason;
        }
    }
}
