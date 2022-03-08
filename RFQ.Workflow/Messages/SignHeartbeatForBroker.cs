namespace RFQ.Workflow.Messages
{
    using Sessions;

    public class SignHeartbeatForBroker
    {
        public IBBrokerSession BrokerSession { get; private set; }

        public SignHeartbeatForBroker(IBBrokerSession session)
        {
            BrokerSession = session;
        }
    }
}
