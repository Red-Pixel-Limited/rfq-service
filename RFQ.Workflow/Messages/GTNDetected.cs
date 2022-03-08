namespace RFQ.Workflow.Messages
{
    using Artifacts;

    public class GTNDetected
    {
        public ObjectToken Identity { get; private set; }

        public GTNDetected(ObjectToken identity)
        {
            Identity = identity;
        }
    }
}
