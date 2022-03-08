namespace RFQ.Altex.Specs.Utils
{
    using Altex.Utils;
    using FluentAssertions;
    using Machine.Specifications;

    [Subject(typeof(ArgumentsParser))]
    public class when_no_arguments_provided
    {
        Because of = () => arguments = null;

        It should_provide_default_process_name =
            () => ArgumentsParser.GetProcessName(arguments).Should().Be(ArgumentsParser.DefaultProcessName);

        It should_provide_default_heartbeat_topic =
            () => ArgumentsParser.GetHeartbeatTopic(arguments).Should().Be(ArgumentsParser.DefaultHeartbeatTopic);

        static string[] arguments;
    }

    [Subject(typeof(ArgumentsParser))]
    public class when_arguments_empty
    {
        Because of = () => arguments = new string[0];

        It should_provide_default_process_name =
            () => ArgumentsParser.GetProcessName(arguments).Should().Be(ArgumentsParser.DefaultProcessName);

        It should_provide_default_heartbeat_topic =
            () => ArgumentsParser.GetHeartbeatTopic(arguments).Should().Be(ArgumentsParser.DefaultHeartbeatTopic);

        static string[] arguments;
    }

    [Subject(typeof(ArgumentsParser))]
    public class when_process_name_is_white_space_or_not_set
    {
        Because of = () => arguments = new[] { " " };

        It should_provide_default_process_name =
            () => ArgumentsParser.GetProcessName(arguments).Should().Be(ArgumentsParser.DefaultProcessName);

        static string[] arguments;
    }

    [Subject(typeof(ArgumentsParser))]
    public class when_heartbeat_topic_is_white_space_or_not_set
    {
        Because of = () => arguments = new[] { null, " " };

        It should_provide_default_heartbeat_topic =
            () => ArgumentsParser.GetHeartbeatTopic(arguments).Should().Be(ArgumentsParser.DefaultHeartbeatTopic);

        static string[] arguments;
    }

    [Subject(typeof(ArgumentsParser))]
    public class when_arguments_contains_process_name
    {
        Because of = () => arguments = new[] { test_name };

        It should_resolve_it =
            () => ArgumentsParser.GetProcessName(arguments).Should().Be(test_name);

        static string[] arguments;
        const string test_name = "test_name"; 
    }

    [Subject(typeof(ArgumentsParser))]
    public class when_arguments_contains_heartbeat_topic
    {
        Because of = () => arguments = new[] { null, test_topic };

        It should_resolve_it =
            () => ArgumentsParser.GetHeartbeatTopic(arguments).Should().Be(test_topic);

        static string[] arguments;
        const string test_topic = "test_topic"; 
    }
}
