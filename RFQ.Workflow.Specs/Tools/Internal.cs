namespace RFQ.Workflow.Specs.Tools
{
    using System;

    internal static class Internal
    {
        internal static DateTime WithoutTicks(this DateTime dateTime)
        {
            return dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond));
        }
    }
}
