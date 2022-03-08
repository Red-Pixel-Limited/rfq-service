namespace RFQ.Workflow.Management
{
    using Core.Entities;
    using Messages;
    using Stact;
    using Utils;

    internal sealed class RFQOfferMonitor : EntityMonitor<RFQOffer>
    {
        private readonly ActorRegistry _registry;

        internal RFQOfferMonitor(RFQOffer entity, ActorRegistry registry) 
            : base(entity)
        {
            _registry = registry;
        }

        protected override void SendSyncRequest()
        {
            _registry.SendToRFQActor(new SyncRequest(Trackable.Id));
        }

        protected override void SendExpiryAlert()
        {
            _registry.SendToRFQActor(new MonitorExpired(Trackable.Id));
        }
    }
}
