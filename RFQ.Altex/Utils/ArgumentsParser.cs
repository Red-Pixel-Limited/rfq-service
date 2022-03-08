namespace RFQ.Altex.Utils
{
    using System;

    internal static class ArgumentsParser
    {
        internal const string DefaultProcessName = "RFQService";
        internal const string DefaultHeartbeatTopic = "HB/ALTEX_RFQ";

        internal static string GetProcessName(string[] arguments)
        {
            return (arguments != null && arguments.Length > 0 && !String.IsNullOrWhiteSpace(arguments[0])) ? 
                arguments[0] : DefaultProcessName;
        }

        internal static string GetHeartbeatTopic(string[] arguments)
        {
            return (arguments != null && arguments.Length > 1 && !String.IsNullOrWhiteSpace(arguments[1])) ? 
                arguments[1] : DefaultHeartbeatTopic;
        }
    }
}