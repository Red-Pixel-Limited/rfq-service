namespace RFQ.Workflow.Messages
{
    using Artifacts;

    public class DisconnectBrokers
    {
        public ObjectToken Identity { get; private set; }

        public DisconnectBrokers(ObjectToken identity)
        {
            Identity = identity;
        }
    }
}
