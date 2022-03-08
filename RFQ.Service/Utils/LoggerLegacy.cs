namespace RFQ.Service.Utils
{
    using System.Globalization;
    using Core.Utils;
    using NLog;
    using NLog.Targets;
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class LoggerLegacy
    {
        internal static EventLogTarget EventLog
        {
            get
            {
                const string eventLogTargetName = "rfq-event-log";
                return LogManager.Configuration.FindTargetByName(eventLogTargetName) as EventLogTarget;
            }
        }

        internal static ColoredConsoleTarget ColoredConsole
        {
            get
            {
                const string consoleTargetName = "console";
                return LogManager.Configuration.FindTargetByName(consoleTargetName) as ColoredConsoleTarget;
            }
        }

        internal static string GetSourceName(this EventLogTarget target)
        {
            return target == null ? null : target.Source;
        }

        internal static void DispaySettings(this ColoredConsoleTarget target)
        {
            if (target == null)
                return;

            var levels = new Dictionary<string, string>
            {
                {LogLevel.Info.Name, Resources.InfoColorMessage},
                {LogLevel.Debug.Name, Resources.DebugColorMessage}, 
                {LogLevel.Trace.Name, Resources.TraceColorMessage},
                {LogLevel.Warn.Name, Resources.WarnColorMessage},
                {LogLevel.Error.Name, Resources.ErrorColorMessage},
                {LogLevel.Fatal.Name, Resources.FatalErrorColorMessage}
            };

            Console.WriteLine(Resources.TextColorMessage);
            Console.WriteLine();

            foreach (var rule in target.RowHighlightingRules)
            {
                var condition = rule.Condition.ToString();
                var level = levels.First(x => condition.Contains(x.Key));
                var color = MapToConsoleColor(rule.ForegroundColor);

                Console.ForegroundColor = color;
                Console.WriteLine(level.Value.FormatWith(color.GetName()));
            }
        }

        private static ConsoleColor MapToConsoleColor(ConsoleOutputColor outputColor)
        {
            ConsoleColor consoleColor;
            return (Enum.TryParse(outputColor.ToString(), true, out consoleColor)) ? 
                consoleColor : Console.ForegroundColor;
        }

        private static string GetName(this ConsoleColor color)
        {
            var name = color.ToString();
            var spaced = name.Aggregate("", (current, ch) => current + ((char.IsUpper(ch)) ? " " + ch : ch.ToString(CultureInfo.InvariantCulture)));
            return spaced.TrimStart(' ').ToUpper();
        }
    }
}
