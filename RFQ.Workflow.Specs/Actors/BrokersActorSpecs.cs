namespace RFQ.Workflow.Specs.Actors
{
    using System.Collections.Generic;
    using System.Threading;
    using Artifacts;
    using Communication.Artifacts;
    using FluentAssertions;
    using Machine.Specifications;
    using Messages;
    using Sessions;
    using Stact;
    using Workflow.Actors;
    using Workflow.Utils;

    // ReSharper disable once ConvertToLambdaExpression

    [Subject(typeof(BrokersActor))]
    public class when_configuration_received
    {
        Establish context = () =>
        {
            response = new Future<IBBrokerSession>();
            registry = ActorRegistryFactory.New(configurator => {});
            configuration = new BrokerConfiguration
            {
                DisplayName = "Supervisor Broker",
                CanAutoConnect = true,
                ProductId = "product_01",
                VenueId = "GtnEVSP_Java"
            };

            var brokers = 
                ActorFactory.Create(inbox => new BrokersActor(inbox, registry, null, null)).GetActor();

            var assistant = AnonymousActor.New(inbox =>
            {
                inbox.Loop(loop =>
                {
                    loop.Receive<SignHeartbeatForBroker>(message =>
                    {
                        response.Complete(message.BrokerSession);
                        loop.Continue();
                    });

                    loop.Receive<Exit>(msg =>
                    {
                        inbox.Exit();
                        loop.Continue();
                    });
                });
            });
            
            registry.Register(Identities.BrokersActorId, brokers);
            registry.Register(Identities.HeartbeatActorId, assistant);
        };

        Because of = () =>
        {
            IList<BrokerConfiguration> configurations = 
                new List<BrokerConfiguration> {configuration};

            registry.SendToBrokersActor(configurations);

            response.WaitUntilCompleted(500.Milliseconds());
        };

        It should_create_session_for_broker = () => 
            response.Value.ShouldBeEquivalentTo(configuration, options => options.Excluding(o => o.Status));

        Cleanup after = () =>
        {
            registry.Shutdown();
            Thread.Sleep(500.Milliseconds());
        };

        static ActorRegistry registry;
        static Future<IBBrokerSession> response;
        static BrokerConfiguration configuration;
    }
}
