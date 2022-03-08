namespace RFQ.Workflow.Messages
{
    public class MonitorExpired
    {
        public string MonitorId { get; private set; }

        public MonitorExpired(string monitorId)
        {
            MonitorId = monitorId;
        }
    }
}
