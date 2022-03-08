namespace RFQ.Service
{
    using System;
    using NLog;
    using Properties;
    using Utils;

    public class Program
    {
        public static void Main(string[] args)
        {
            var application =
                EnvironmentConfigurator.New()
                    .RegisterUnhandledExceptionHandler(LogUnhandledException)
                    .BuildApplication();

            application.Run();
        }

        private static void LogUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var logger = LogManager.GetLogger(sender.GetType().FullName);
            logger.Fatal(Resources.UnhandledExceptionMessage, (Exception)args.ExceptionObject);
        }
    }
}
