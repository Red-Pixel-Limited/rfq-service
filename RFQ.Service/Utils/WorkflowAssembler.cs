namespace RFQ.Service.Utils
{
    using Altex;
    using Communication;
    using Core.Management;
    using Repository.Management;
    using Repository.Setup;
    using Workflow;
    using Workflow.Configuration;

    internal static class WorkflowAssembler
    {
        public static RFQWorkflow Assemble(ConfigurationReader configuration)
        {
            IBusCommunicator communicator = new AltexCommunicator();

            IUnitOfWorkFactory uowFactory =
                new UnitOfWorkFactory(DatabaseConfigurator.SetupConnection(ConfigurationReader.ConnectionStringKey));

            IRepositoryFactory dbFactory = new RepositoryFactory();

            var settings = new WorkflowSettings(configuration.GetServiceName(),
                                                configuration.GetHeartbeatInterval(),
                                                configuration.GetGTNTrackingInterval(),
                                                configuration.GetGTNHeartbeatsListenerId(),
                                                configuration.GetAltexSettings());

            return new RFQWorkflow(settings, communicator, uowFactory, dbFactory);
        }
    }
}