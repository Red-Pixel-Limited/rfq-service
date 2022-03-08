namespace RFQ.Workflow.Artifacts
{
    using System;
    using Communication.Messages.Incoming;
    using Communication.Options;

    public sealed class GTNStatusLog
    {
        public string VenueId { get; private set; }
        public string ProductId { get; private set; }
        public string InstanceId { get; private set; }
        public int HeartbeatInterval { get; private set; }
        public GTNStatus LastKnownState { get; private set; }
        public DateTime LastStatusUpdateTime { get; private set; }
        public int LoadFactor { get; private set; }

        public GTNStatusLog(GTNHeartbeat heartbeat)
        {
            VenueId = heartbeat.VenueId;
            ProductId = heartbeat.ProductId;
            InstanceId = heartbeat.InstanceId;
            LastKnownState = heartbeat.Status;
            LastStatusUpdateTime = DateTime.Now;
            HeartbeatInterval = heartbeat.HeartbeatInterval;
            LoadFactor = heartbeat.LoadFactor;
        }
    }
}
