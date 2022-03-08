namespace RFQ.Workflow.Registries
{
    using Artifacts;
    using Communication.Messages.Incoming;

    sealed class GTNStatusRegistry : CacheRegistry<ObjectToken, GTNStatusLog>
    {
        internal GTNStatusRegistry() : base(value => new ObjectToken(value.VenueId, value.ProductId, value.InstanceId)) {}

        internal GTNStatusLog GetFor(GTNHeartbeat heartbeat)
        {
            return GetById(new ObjectToken(heartbeat.VenueId, heartbeat.ProductId, heartbeat.InstanceId));
        }
    }
}
