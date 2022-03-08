namespace RFQ.Service.Utils
{
    using System;
    using Applications;
    using Core.Utils;
    using Options;
    using Properties;

    internal class EnvironmentConfigurator
    {
        readonly ConfigurationReader _configuration;

        private EnvironmentConfigurator()
        {
            _configuration = new ConfigurationReader();
        }

        internal static EnvironmentConfigurator New()
        {
            return new EnvironmentConfigurator();
        }

        internal EnvironmentConfigurator RegisterUnhandledExceptionHandler(UnhandledExceptionEventHandler handler)
        {
            AppDomain.CurrentDomain.UnhandledException += handler;
            return this;
        }

        internal IApplication BuildApplication()
        {
            var workflow = WorkflowAssembler.Assemble(_configuration);
            var option = _configuration.GetStartAsOption();

            switch (option)
            {
                case StartAs.Console:
                    return new ConsoleApp(workflow);
                case StartAs.Service:
                    var name = LoggerLegacy.EventLog.GetSourceName();
                    return new ServiceApp(workflow, name);
                default:
                    throw new NotSupportedException(Resources.OptionNotSupportedErrorMessage.FormatWith(option));
            }
        }
    }
}
