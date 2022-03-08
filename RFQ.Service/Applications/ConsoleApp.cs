namespace RFQ.Service.Applications
{
    using System;
    using Artifacts;
    using Core.Tools;
    using Options;
    using Properties;
    using Utils;
    using Workflow;

    public sealed class ConsoleApp : IApplication
    {
        readonly RFQWorkflow _workflow;
        ConsoleRoutineHandler _consoleEventHandler;

        public ConsoleApp([NotNull] RFQWorkflow workflow)
        {
            _workflow = workflow;
        }

        public void Run()
        {
            Console.Title = _workflow.Settings.ServiceName;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Resources.WelcomeMessage);
            Console.WriteLine();

            LoggerLegacy.ColoredConsole.DispaySettings();

            _workflow.Activate();

            _consoleEventHandler = ExitConsole;
            Win32API.SetConsoleCtrlHandler(_consoleEventHandler, true);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Resources.PressKeyToStopMessage);
            Console.ReadLine();

            _workflow.Terminate();

            Win32API.SetConsoleCtrlHandler(_consoleEventHandler, false);

            Console.WriteLine(Resources.PressKeyToExitMessage);
            Console.ReadLine();
        }

        private bool ExitConsole(ConsoleEvent consoleEvent)
        {
            Win32API.SetConsoleCtrlHandler(_consoleEventHandler, false);
            _workflow.Terminate();
            return true;
        }
    }
}
