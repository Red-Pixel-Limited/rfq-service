namespace RFQ.Workflow.Messages
{
    public class SyncRequest
    {
        public string MonitorId { get; private set; }

        public SyncRequest(string monitorId)
        {
            MonitorId = monitorId;
        }
    }
}
