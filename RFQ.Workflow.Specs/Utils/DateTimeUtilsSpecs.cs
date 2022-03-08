namespace RFQ.Workflow.Specs.Utils
{
    using System;
    using FluentAssertions;
    using Machine.Specifications;
    using Tools;
    using Workflow.Utils;

    [Subject(typeof(DateTimeUtils))]
    public class when_converting_back_datetime_from_unix_timestamp
    {
        Because of = () => unix_timestamp = original_datetime.ToUnixTimestamp();

        It should_result_original_value = () => unix_timestamp.ToDateTime().Should().Be(original_datetime);

        static long unix_timestamp;
        static DateTime original_datetime = DateTime.UtcNow.WithoutTicks();
    }
}
