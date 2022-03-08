namespace RFQ.Workflow.Registries
{
    using Artifacts;
    using Communication.Messages.Outgoing;

    sealed class HeartbeatsRegistry : CacheRegistry<ObjectToken, BrokerHeartbeat>
    {
        internal HeartbeatsRegistry() : base(value => new ObjectToken(value.VenueId, value.ProductId)) {}
    }
}
