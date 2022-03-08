namespace RFQ.Workflow.Messages
{
    using Artifacts;

    public class VerifyBrokersSessions
    {
        public ObjectToken Identity { get; private set; }

        public VerifyBrokersSessions(ObjectToken identity)
        {
            Identity = identity;
        }
    }
}