namespace RFQ.Workflow.Actors
{
    using System.Timers;
    using Communication.Messages.Outgoing;
    using Configuration;
    using Messages;
    using Registries;
    using Stact;
    using Utils;

    sealed class HeartbeatActor :
        Actor
    {
        private Timer _heartbeatTimer;
        private readonly ActorRegistry _registry;
        private readonly HeartbeatsRegistry _heartbeats;

        public HeartbeatActor(Inbox inbox, ActorRegistry registry, WorkflowSettings settings)
        {
            _registry = registry;
            _heartbeats = new HeartbeatsRegistry();

            inbox.Loop(loop =>
            {
                loop.Receive<SignHeartbeatForBroker>(message =>
                {
                    _heartbeatTimer.Stop();
                    var brokerSession = message.BrokerSession;
                    var heartbeat = new BrokerHeartbeat(brokerSession.DisplayName,
                                                        settings.HeartbeatInterval,
                                                        brokerSession.Status,
                                                        brokerSession.VenueId,
                                                        brokerSession.ProductId);
                    _heartbeats.AddOrUpdate(heartbeat);
                    _heartbeatTimer.Start();
                    loop.Continue();
                });

                loop.Receive<Exit>(message =>
                {
                    StopBroadcast();
                    inbox.Exit();
                    loop.Continue();
                });

                loop.Receive<Fault>(fault =>
                {
                    loop.Continue();
                });
            });

            StartBroadcast(settings.HeartbeatInterval);
        }

        private void StartBroadcast(double interval)
        {
            _heartbeatTimer = new Timer(interval);
            _heartbeatTimer.Elapsed += SendHeartbeats;
            _heartbeatTimer.Start();
        }

        private void StopBroadcast()
        {
            _heartbeatTimer.Elapsed -= SendHeartbeats;
            _heartbeatTimer.Stop();
            _heartbeatTimer.Dispose();
        }

        private void SendHeartbeats(object sender, ElapsedEventArgs arguments)
        {
            foreach (var heartbeat in _heartbeats)
            {
                _registry.SendToDispatchActor(heartbeat);
            }
        }
    }
}
