namespace RFQ.Workflow
{
    using System;
    using Actors;
    using Artifacts;
    using Communication;
    using Configuration;
    using Core.Management;
    using Stact;

    public sealed class RFQWorkflow
    {
        ActorRegistry _actors;
        readonly WorkflowSettings _settings;
        readonly IBusCommunicator _communicator;
        readonly IUnitOfWorkFactory _unitOfWorkFactory;
        readonly IRepositoryFactory _repositoryFactory;

        public RFQWorkflow(WorkflowSettings settings,
                           IBusCommunicator communicator,
                           IUnitOfWorkFactory unitOfWorkFactory,
                           IRepositoryFactory repositoryFactory)
        {
            _settings = settings;
            _communicator = communicator;
            _unitOfWorkFactory = unitOfWorkFactory;
            _repositoryFactory = repositoryFactory;
        }

        public WorkflowSettings Settings { get { return _settings; } }

        public void Activate(string actorsUri = "loopback://localhost/")
        {
            _actors = ActorRegistryFactory.New(cfg => cfg.Remote(x => x.ListenTo(new Uri(actorsUri))));

            var quoteFactory = ActorFactory.Create(inbox => new QuotesActor(inbox, _unitOfWorkFactory, _repositoryFactory));
            var heartbeatFactory = ActorFactory.Create(inbox => new HeartbeatActor(inbox, _actors, _settings));
            var brokersFactory = ActorFactory.Create(inbox => new BrokersActor(inbox, _actors, _unitOfWorkFactory, _repositoryFactory));
            var dispatcherFactory = ActorFactory.Create(inbox => new DispatchActor(inbox, _communicator, _actors, _settings));
            var gtnFactory = ActorFactory.Create(inbox => new GTNActor(inbox, _actors, _settings));

            _actors.Register(Identities.QuotesActorId, quoteFactory.GetActor());
            _actors.Register(Identities.HeartbeatActorId, heartbeatFactory.GetActor());
            _actors.Register(Identities.BrokersActorId, brokersFactory.GetActor());
            _actors.Register(Identities.DispatchActorId, dispatcherFactory.GetActor());
            _actors.Register(Identities.GTNActorId, gtnFactory.GetActor());
        }

        public void Terminate()
        {
            _actors.Shutdown();
            _unitOfWorkFactory.Dispose();
        }
    }
}
