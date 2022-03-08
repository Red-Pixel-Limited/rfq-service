namespace RFQ.Workflow.Management
{
    using Core.Entities;
    using Messages;
    using Stact;
    using Utils;

    internal sealed class QuoteMonitor : EntityMonitor<Quote>
    {
        private readonly ActorRegistry _registry;

        internal QuoteMonitor(Quote entity, ActorRegistry registry)
            : base(entity)
        {
            _registry = registry;
        }

        protected override void SendExpiryAlert()
        {
            _registry.SendToQuotesActor(new MonitorExpired(Trackable.Id));
        }
    }
}
