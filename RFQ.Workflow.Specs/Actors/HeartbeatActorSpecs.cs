namespace RFQ.Workflow.Specs.Actors
{
    using System.Threading;
    using Artifacts;
    using Communication;
    using Communication.Artifacts;
    using Communication.Messages.Outgoing;
    using Configuration;
    using Machine.Specifications;
    using Magnum.Extensions;
    using Messages;
    using Moq;
    using Sessions;
    using Stact;
    using Workflow.Actors;
    using Workflow.Utils;
    using It = Machine.Specifications.It;

    [Subject(typeof(HeartbeatActor))]
    public class when_brokers_got_setup
    {
        Establish context = () =>
        {
            communicator = new Mock<IBusCommunicator>();
            registry = ActorRegistryFactory.New(configurator => {});

            var settings = new WorkflowSettings(null, heartbeat_interval, 0, null, null);

            var dispatcher =
                ActorFactory.Create(inbox => new DispatchActor(inbox, communicator.Object, registry, settings)).GetActor();

            var heartbeater =
                ActorFactory.Create(inbox => new HeartbeatActor(inbox, registry, settings)).GetActor();

            registry.Register(Identities.HeartbeatActorId, heartbeater);
            registry.Register(Identities.DispatchActorId, dispatcher);
        };

        Because of = () =>
        {
            var configuration = new BrokerConfiguration();
            var brokerSession = IBBrokerSession.CreateFrom(configuration);
            registry.SendToHeartbeatActor(new SignHeartbeatForBroker(brokerSession));
        };

        It should_start_heartbeating = () =>
        {
            Thread.Sleep((int)(heartbeat_interval*1.5));
            communicator.Verify(x => x.Send(Moq.It.IsAny<BrokerHeartbeat>()), Times.AtLeastOnce);
        };

        Cleanup after = () =>
        {
            registry.Shutdown();
            Thread.Sleep(500.Milliseconds());
        };

        static ActorRegistry registry;
        const int heartbeat_interval = 1000;
        static Mock<IBusCommunicator> communicator;
    }
}
