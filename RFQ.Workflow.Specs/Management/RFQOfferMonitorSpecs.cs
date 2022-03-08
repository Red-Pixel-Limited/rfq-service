namespace RFQ.Workflow.Specs.Management
{
    using System;
    using System.Threading;
    using Artifacts;
    using Communication.Options;
    using Core.Artifacts;
    using Core.Entities;
    using FluentAssertions;
    using Machine.Specifications;
    using Magnum;
    using Messages;
    using Stact;
    using Workflow.Management;

    [Subject(typeof(RFQOfferMonitor))]
    public class when_rfq_cancellation_requested
    {
        Establish context = 
            () => monitor = new RFQOfferMonitor(RFQOfferFactory.CreateNew(), null);

        Because of = () =>
        {
            monitor.Start(3000);
            Thread.Sleep(1000);
            monitor.Cancel();
        };

        It should_cancel = () => monitor.Trackable.State.Should().Be(RFQState.Cancelled);

        It should_not_be_tracked_anymore = () => monitor.Started.Should().BeFalse();

        Cleanup after = () => monitor.Dispose();

        static RFQOfferMonitor monitor;
    }

    [Subject(typeof(RFQOfferMonitor))]
    public class when_rfq_initiated
    {
        Establish context = () => monitor = new RFQOfferMonitor(RFQOfferFactory.CreateNew(), null);

        Because of = () => monitor.Start(2000);

        It should_have_open_status_set = () => monitor.Trackable.State.Should().Be(RFQState.Open);

        It should_be_tracked = () => monitor.Started.Should().BeTrue();

        It should_have_remaining_time_left = () => monitor.GetRemainingTime().Should().NotBe(TimeSpan.Zero);

        Cleanup after = () => monitor.Dispose();

        static RFQOfferMonitor monitor;
    }

    // ReSharper disable ConvertToLambdaExpression

    [Subject(typeof(RFQOfferMonitor))]
    public class when_initiated_with_sync_timeout_set
    {
        Establish context = () =>
        {
            response = new Future<string>();
            registry = ActorRegistryFactory.New(configurator => {});

            var assistant = AnonymousActor.New(inbox =>
            {
                inbox.Loop(loop =>
                {
                    loop.Receive<SyncRequest>(message =>
                    {
                        response.Complete(message.MonitorId);
                        loop.Continue();
                    });

                    loop.Receive<Exit>(msg =>
                    {
                        inbox.Exit();
                        loop.Continue();
                    });
                });
            });

            registry.Register(Identities.RFQActorId, assistant);
            monitor = new RFQOfferMonitor(RFQOfferFactory.CreateNew(), registry);
        };

        Because of = () =>
        {
            const int syncAfter = 1*1000;
            const int expiresAfter = syncAfter*2;

            monitor.Start(expiresAfter, syncAfter);
            response.WaitUntilCompleted((int)(syncAfter*1.5));
        };

        It should_request_synchronization_update = 
            () => response.Value.Should().Be(monitor.Trackable.Id);

        Cleanup after = () =>
        {
            monitor.Dispose();
            registry.Shutdown();
            Thread.Sleep(10.Milliseconds());
        };

        static ActorRegistry registry;
        static Future<string> response;
        static RFQOfferMonitor monitor;
    }

    [Subject(typeof(RFQOfferMonitor))]
    public class when_rfq_expires
    {
        Establish context = () =>
        {
            response = new Future<string>();
            registry = ActorRegistryFactory.New(configurator => {});

            var assistant = AnonymousActor.New(inbox =>
            {
                inbox.Loop(loop =>
                {
                    loop.Receive<SyncRequest>(message =>
                    {
                        throw new InvalidOperationException("Should not be called!");
                    });

                    loop.Receive<MonitorExpired>(message =>
                    {
                        response.Complete(message.MonitorId);
                        loop.Continue();
                    });

                    loop.Receive<Exit>(msg =>
                    {
                        inbox.Exit();
                        loop.Continue();
                    });
                });
            });

            registry.Register(Identities.RFQActorId, assistant);
            monitor = new RFQOfferMonitor(RFQOfferFactory.CreateNew(), registry);
        };

        Because of = () =>
        {
            const int ms = expires_after*1000;
            monitor.Start(ms, ms);
            response.WaitUntilCompleted((int)(ms*1.5));
        };

        It should_have_expired_state_set = () => monitor.Trackable.State.Should().Be(RFQState.Expired);

        It should_not_be_tracked_anymore = () => monitor.Started.Should().BeFalse();

        It should_not_have_remaining_time_left = () => monitor.GetRemainingTime().Should().Be(TimeSpan.Zero);

        It should_been_initiated_known_time_ago = () => DateTime.UtcNow.Subtract(monitor.StartedAt).Seconds.Should().Be(expires_after);

        Cleanup after = () =>
        {
            monitor.Dispose();
            registry.Shutdown();
            Thread.Sleep(1.Seconds());
        };

        static ActorRegistry registry;
        static Future<string> response; 
        static RFQOfferMonitor monitor;

        const int expires_after = 2;
    }

    // ReSharper restore ConvertToLambdaExpression

    public static class RFQOfferFactory
    {
        public static RFQOffer CreateNew()
        {
            var instrument = new Instrument(CombGuid.Generate().ToString("N"), "BMW");
            return RFQOffer.New(new User(), instrument, 0, 1, Side.Both, "product_01", "GtnEVSP_Java");
        }
    }
}
