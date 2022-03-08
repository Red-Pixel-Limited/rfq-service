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

    // ReSharper disable once ConvertToLambdaExpression

    [Subject(typeof(QuoteMonitor))]
    public class when_quote_expires
    {
        Establish context = () =>
        {
            response = new Future<string>();
            registry = ActorRegistryFactory.New(configurator => {});

            var assistant = AnonymousActor.New(inbox =>
            {
                inbox.Loop(loop =>
                {
                    loop.Receive<MonitorExpired>(message =>
                    {
                        response.Complete(message.MonitorId);
                        loop.Continue();
                    });

                    loop.Receive<Exit>(message =>
                    {
                        inbox.Exit();
                        loop.Continue();
                    });
                });
            });

            registry.Register(Identities.QuotesActorId, assistant);

            monitor = new QuoteMonitor(QuoteFactory.CreateNew(), registry);
        };

        Because of = () =>
        {
            const int ms = expires_after * 1000;

            monitor.Start(ms);
            response.WaitUntilCompleted((int)(ms * 1.5));
        };

        It should_have_expired_state_set = () => monitor.Trackable.State.Should().Be(QuoteState.Expired);

        It should_not_be_tracked_anymore = () => monitor.Started.Should().BeFalse();

        It should_provide_expected_monitor_id = () => response.Value.Should().Be(monitor.Trackable.Id);

        It should_not_have_remaining_time_left = () => monitor.GetRemainingTime().Should().Be(TimeSpan.Zero);

        It should_been_initiated_known_time_ago = () => DateTime.UtcNow.Subtract(monitor.StartedAt).Seconds.Should().Be(expires_after);

        Cleanup after = () =>
        {
            monitor.Dispose();
            registry.Shutdown();
            Thread.Sleep(10.Milliseconds());
        };

        static QuoteMonitor monitor;
        static ActorRegistry registry;
        static Future<string> response;

        const int expires_after = 2;
    }

    [Subject(typeof(QuoteMonitor))]
    public class when_quote_cancellation_requested
    {
        Establish context = 
            () => monitor = new QuoteMonitor(QuoteFactory.CreateNew(), null);

        Because of = () =>
        {
            monitor.Start(2000);
            Thread.Sleep(1000);
            monitor.Cancel();
        };

        It should_cancel = () => monitor.Trackable.State.Should().Be(QuoteState.Cancelled);

        It should_not_be_tracked_anymore = () => monitor.Started.Should().BeFalse();

        Cleanup after = () => monitor.Dispose();

        static QuoteMonitor monitor;
    }

    [Subject(typeof(QuoteMonitor))]
    public class when_quote_initiated
    {
        Establish context = () => monitor = new QuoteMonitor(QuoteFactory.CreateNew(), null);

        Because of = () => monitor.Start(2000);

        It should_have_open_status_set = () => monitor.Trackable.State.Should().Be(QuoteState.Open);

        It should_be_tracked = () => monitor.Started.Should().BeTrue();

        It should_have_remaining_time_left = () => monitor.GetRemainingTime().Should().NotBe(TimeSpan.Zero);

        Cleanup after = () => monitor.Dispose();

        static QuoteMonitor monitor;
    }

    public static class QuoteFactory
    {
        public static Quote CreateNew()
        {
            var instrument = new Instrument(CombGuid.Generate().ToString("N"), "BMW");
            var offer = RFQOffer.New(new User {Name = "Alex"}, instrument, 0, 1, Side.Both, "product_01", "GtnEVSP_Java");
            return Quote.New(new User {Name = "James"}, offer, 0, 1, 0, 1);
        }
    }
}
