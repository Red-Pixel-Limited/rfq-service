namespace RFQ.Workflow.Specs.Utils
{
    using System;
    using Core.Exceptions;
    using FluentAssertions;
    using Machine.Specifications;
    using Workflow.Utils;

    [Subject(typeof(CalculationEvaluator))]
    public class when_calculating_integer_number_base
    {
        Because of = () => number_base = 323M.CalculateBase();

        It should_provide_1 = () => number_base.Should().Be(1L);

        static long number_base;
    }

    [Subject(typeof(CalculationEvaluator))]
    public class when_calculating_fractional_number_base
    {
        Because of = () => number_base = 323.3334M.CalculateBase();

        It should_detect_base_corresponding_to_fixed_point = () => number_base.Should().Be(expected_base);

        const long expected_base = 10000;
        static long number_base;
    }

    [Subject(typeof(CalculationEvaluator))]
    public class when_calculating_decimal_number_from_base
    {
        Because of = () => received_number = 3233334L.ToDecimal(10000);

        It should_provide_expected_number_with_fixed_point = () => received_number.Should().Be(expected_number);

        const decimal expected_number = 323.3334M;
        static decimal received_number;
    }

    [Subject(typeof(CalculationEvaluator))]
    public class when_calculating_decimal_number_from_negative_base
    {
        Because of = () => exception = Catch.Exception(() => 323L.ToDecimal(-1));

        It should_fail = () => exception.Should().BeOfType<RFQArithmeticException>();

        static Exception exception;
    }

    [Subject(typeof(CalculationEvaluator))]
    public class when_calculating_decimal_number_from_zero_base
    {
        Because of = () => exception = Catch.Exception(() => 323L.ToDecimal(0));

        It should_fail = () => exception.Should().BeOfType<RFQArithmeticException>();

        static Exception exception;
    }
}
