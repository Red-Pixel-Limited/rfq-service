namespace RFQ.Workflow.Configuration
{
    public sealed class WorkflowSettings
    {
        private readonly string _serviceName;
        private readonly int _heartbeatInterval;
        private readonly int _gtnTrackingInterval;
        private readonly string _gtnHeartbeatsListenerId;
        private readonly string[] _communicationSettings;

        public WorkflowSettings(string serviceName,
                                int heartbeatInterval,
                                int gtnTrackingInterval,
                                string gtnHeartbeatsListenerId,
                                string[] communicationSettings)
        {
            _serviceName = serviceName;
            _heartbeatInterval = heartbeatInterval;
            _gtnTrackingInterval = gtnTrackingInterval;
            _gtnHeartbeatsListenerId = gtnHeartbeatsListenerId;
            _communicationSettings = communicationSettings;
        }

        public string ServiceName
        {
            get { return _serviceName; }
        }

        public int HeartbeatInterval
        {
            get { return _heartbeatInterval; }
        }

        public int GTNTrackingInterval
        {
            get { return _gtnTrackingInterval; }
        }

        public string GTNHeartbeatsListenerId
        {
            get { return _gtnHeartbeatsListenerId; }
        }

        public string[] Communication
        {
            get { return _communicationSettings; }
        }
    }
}
