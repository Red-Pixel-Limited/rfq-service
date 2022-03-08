namespace RFQ.Workflow.Actors
{
    using System;
    using System.Timers;
    using Artifacts;
    using Communication.Messages.Incoming;
    using Communication.Messages.Outgoing;
    using Communication.Options;
    using Configuration;
    using Magnum.Extensions;
    using Messages;
    using Registries;
    using Stact;
    using Utils;

    sealed class GTNActor :
        Actor
    {
        private const int DoNotIgnorableMissedHeartbeatsNumber = 4;

        private Timer _gtnTrackingTimer;
        private readonly GTNStatusRegistry _history;
        private readonly ActorRegistry _registry;

        public GTNActor(Inbox inbox, ActorRegistry registry, WorkflowSettings settings)
        {
            _registry = registry;
            _history = new GTNStatusRegistry();

            inbox.Loop(loop =>
            {
                loop.Receive<GTNHeartbeat>(heartbeat =>
                {
                    var lastKnownState = GetLastKnownState(heartbeat);
                    Register(heartbeat);

                    switch (heartbeat.Status)
                    {
                        case GTNStatus.Live:
                            var identity = heartbeat.GetGTNIdentity();
                            if (lastKnownState != GTNStatus.Live)
                                NotifyAboutStartup(identity);
                            ProcessLiveEvent(identity);
                            break;
                        case GTNStatus.Closed:
                        case GTNStatus.Attention:
                            if (lastKnownState == GTNStatus.Live)
                                NotifyAboutShutdown(heartbeat.GetGTNIdentity());
                            break;
                    }

                    loop.Continue();
                });

                loop.Receive<Exit>(message =>
                {
                    StopMonitorGTN();
                    inbox.Exit();
                    loop.Continue();
                });

                loop.Receive<Fault>(fault =>
                {
                    loop.Continue();
                });
            });

            StartMonitorGTN(settings.GTNTrackingInterval);
            SubscribeForGTNHeartbeats(settings.GTNHeartbeatsListenerId);
        }

        private void StartMonitorGTN(double trackingInterval)
        {
            _gtnTrackingTimer = new Timer(trackingInterval);
            _gtnTrackingTimer.Elapsed += DetermineAvailability;
            _gtnTrackingTimer.Start();
        }

        private void DetermineAvailability(object sender, ElapsedEventArgs args)
        {
            foreach (var log in _history)
            {
                var durationFromLastUpdate = (DateTime.Now.Subtract(log.LastStatusUpdateTime)).Duration();
                var timePeriodAfterServiceIsDown = (DoNotIgnorableMissedHeartbeatsNumber * log.HeartbeatInterval).Milliseconds();
                if (durationFromLastUpdate <= timePeriodAfterServiceIsDown)
                    continue;
                if (log.LastKnownState == GTNStatus.Live)
                {
                    NotifyAboutShutdown(log.GetGTNIdentity());
                }
                _history.TryRemove(log);
            }
        }

        private void StopMonitorGTN()
        {
            _gtnTrackingTimer.Elapsed -= DetermineAvailability;
            _gtnTrackingTimer.Stop();
            _gtnTrackingTimer.Dispose();
        }

        private void SubscribeForGTNHeartbeats(string listenerId)
        {
            _registry.SendToDispatchActor(new GTNHeartbeatsSubscription(listenerId));
        }

        private GTNStatus GetLastKnownState(GTNHeartbeat heartbeat)
        {
            var log = _history.GetFor(heartbeat);
            return (log == default(GTNStatusLog)) ? GTNStatus.Unknown : log.LastKnownState;
        }

        private void Register(GTNHeartbeat heartbeat)
        {
            var log = new GTNStatusLog(heartbeat);
            _history.AddOrUpdate(log);
        }

        private void NotifyAboutStartup(ObjectToken identity)
        {
            _registry.SendToBrokersActor(new GTNDetected(identity));
        }

        private void ProcessLiveEvent(ObjectToken identity)
        {
            _registry.SendToBrokersActor(new VerifyBrokersSessions(identity));
        }

        private void NotifyAboutShutdown(ObjectToken identity)
        {
            _registry.SendToBrokersActor(new DisconnectBrokers(identity));
        }
    }
}
