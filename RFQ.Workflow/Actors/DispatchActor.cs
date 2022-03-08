namespace RFQ.Workflow.Actors
{
    using Communication;
    using Communication.Messages.Incoming;
    using Communication.Messages.Outgoing;
    using Configuration;
    using Stact;
    using Utils;

    sealed class DispatchActor :
        Actor
    {
        private readonly IBusCommunicator _communicator;

        public DispatchActor(Inbox inbox, IBusCommunicator communicator, ActorRegistry registry, WorkflowSettings settings)
        {
            _communicator = communicator;

            inbox.Loop(loop =>
            {
                loop.Receive<GTNHeartbeatsSubscription>(subscription =>
                {
                    _communicator.Send(subscription);
                    loop.Continue();
                });

                loop.Receive<BrokerHeartbeat>(heartbeat =>
                {
                    _communicator.Send(heartbeat);
                    loop.Continue();
                });

                loop.Receive<Exit>(message =>
                {
                    _communicator.Disconnect();
                    _communicator.Dispose();
                    inbox.Exit();
                    loop.Continue();
                });

                loop.Receive<Fault>(fault =>
                {
                    loop.Continue();
                });
            });

            registry.BrokersActorExecute(actor => _communicator.BrokersDetected += actor.Send);

            _communicator.Connect(settings.Communication);
            _communicator.SubscribeFor<GTNHeartbeat>(registry.SendToGTNActor); // TODO: need some coordinator for responses and validation
            _communicator.SubscribeFor<PassRFQ>(registry.SendToQuotesActor);
        }
    }
}
