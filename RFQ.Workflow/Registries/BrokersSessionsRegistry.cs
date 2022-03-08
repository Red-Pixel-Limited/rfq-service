namespace RFQ.Workflow.Registries
{
    using Artifacts;
    using Messages;
    using Sessions;

    sealed class BrokersSessionsRegistry : CacheRegistry<ObjectToken, IBBrokerSession>
    {
        internal BrokersSessionsRegistry() : base(value => new ObjectToken(value.VenueId, value.ProductId)) {}

        internal IBBrokerSession FindOverFor(GTNDetected availableGTN)
        {
            return GetById(availableGTN.Identity);
        }
    }
}
