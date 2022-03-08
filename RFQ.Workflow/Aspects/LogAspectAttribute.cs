namespace RFQ.Workflow.Aspects
{
    using System;
    using NLog;
    using PostSharp.Aspects;

    [Serializable]
    public class LogAspectAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            LogManager.GetCurrentClassLogger().Debug("I'm entered!");
            base.OnEntry(args);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            LogManager.GetCurrentClassLogger().Debug("I'm exiting!");
            base.OnExit(args);
        }
    }
}
