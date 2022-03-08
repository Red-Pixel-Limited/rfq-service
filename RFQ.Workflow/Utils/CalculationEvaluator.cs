namespace RFQ.Workflow.Utils
{
    using System;
    using Core.Exceptions;
    using Properties;

    internal static class CalculationEvaluator
    {
        internal static long CalculateBase(this decimal number)
        {
            var copy = number;
            var numberBase = 1L;
            while ((copy - Decimal.Floor(copy)) > 0)
            {
                numberBase *= 10;
                copy = number * numberBase;
            }
            return numberBase;
        }

        internal static decimal ToDecimal(this long number, long numberBase)
        {
            if (numberBase <= 0)
            {
                throw new RFQArithmeticException(String.Format(Resources.InvalidNumberBaseMessage, numberBase));
            }
            return (decimal)number / numberBase;
        }

        internal static long ToInteger(this decimal number, long numberBase)
        {
            return (long)(number * numberBase);
        }
    }
}
