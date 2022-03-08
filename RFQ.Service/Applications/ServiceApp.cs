namespace RFQ.Service.Applications
{
    using System.ServiceProcess;
    using Core.Tools;
    using Core.Utils;
    using Workflow;

    public sealed class ServiceApp : ServiceBase, IApplication
    {
        private bool _isDisposed;
        private readonly RFQWorkflow _workflow;

        public ServiceApp([NotNull] RFQWorkflow workflow, string serviceName)
        {
            AutoLog = !serviceName.IsEmptyOrWhiteSpace();
            ServiceName = serviceName;
            _workflow = workflow;
        }

        public void Run()
        {
            _workflow.Activate();
            Run(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                _workflow.Terminate();
                _isDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
