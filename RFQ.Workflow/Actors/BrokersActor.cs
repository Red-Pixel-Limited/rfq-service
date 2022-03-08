namespace RFQ.Workflow.Actors
{
    using System.Collections.Generic;
    using Aspects;
    using Communication.Artifacts;
    using Core.Management;
    using Messages;
    using Registries;
    using Sessions;
    using Stact;
    using Utils;

    sealed class BrokersActor :
        Actor
    {
        readonly IUnitOfWorkFactory _uowFactory;
        readonly IRepositoryFactory _repositories;
        readonly BrokersSessionsRegistry _brokersSessions;

        public BrokersActor(Inbox inbox,
                            ActorRegistry registry,
                            IUnitOfWorkFactory uowFactory,
                            IRepositoryFactory repositories)
        {
            _uowFactory = uowFactory;
            _repositories = repositories;
            _brokersSessions = new BrokersSessionsRegistry();

            inbox.Loop(loop =>
            {
                loop.Receive<IList<BrokerConfiguration>>(configurations =>
                {
                    foreach (var configuration in configurations)
                    {
                        var brokerSession = IBBrokerSession.CreateFrom(configuration);
                        _brokersSessions.AddOrUpdate(brokerSession);
                        registry.SendToHeartbeatActor(new SignHeartbeatForBroker(brokerSession));
                    }
                    loop.Continue();
                });

                loop.Receive<GTNDetected>(availableGTN =>
                {
                    var matchingSession = _brokersSessions.FindOverFor(availableGTN);
                    if (matchingSession != null)
                        AutoConnectBrokerSession(matchingSession);
                    loop.Continue();
                });

                loop.Receive<VerifyBrokersSessions>(message =>
                {
                    loop.Continue();
                });

                loop.Receive<DisconnectBrokers>(message =>
                {
                    loop.Continue();
                });

                loop.Receive<Exit>(message =>
                {
                    inbox.Exit();
                    loop.Continue();
                });

                loop.Receive<Fault>(fault =>
                {
                    loop.Continue();
                });
            });
        }

        [LogAspect]
        private void AutoConnectBrokerSession(IBBrokerSession session)
        {
            session.Connecting += RequestUnderliningGTNSessionCreation;
            session.AutoConnect();
            session.Connecting -= RequestUnderliningGTNSessionCreation;
        }

        private void RequestUnderliningGTNSessionCreation(IBBrokerSession session)
        {
            using (var uow = _uowFactory.Create())
            {
                var repository = _repositories.CreateForBroker(uow);
                var broker = repository.GetFirstBy(x => x.ProductId == session.ProductId &&
                                                        x.VenueId == session.VenueId);
                uow.Commit();
            }
        }

        #region TODO
        //            var grsp = GRSPDb.GetGRSP(_evspId.VenueId, _evspId.ProductId);
        //            var evspInstanceId = EvspManager.GetInstance().GetEvspInstanceByMinLoadFactor(_evspId.VenueId, _evspId.ProductId);
        //
        //            if (evspInstanceId == null)
        //            {
        //                Log.Warn("Cannot create IB Broker Session because of no available EVSPs");
        //                return false;
        //            }
        //
        //            if (grsp != null)
        //            {
        //                if (!string.IsNullOrEmpty(grsp.IBPassword) && !string.IsNullOrEmpty(grsp.IBUsername))
        //                {
        //                    return _evspSessionService.CreateEvspSession(evspInstanceId,
        //                        new PasswordCredentials { CurrentPassword = grsp.IBPassword, Username = grsp.IBUsername }, this);
        //                }
        //            }
        //
        //            return _evspSessionService.CreateEvspSession(evspInstanceId, BrokerSession.Credentials, this);
        //
        //            var requestId = Guid.NewGuid().ToString();
        //            _sessionCreateResponseHandlers.TryAdd(requestId, responseHandler);
        //
        //            var createSession = new CreateSessionMessage
        //            {
        //                RequestId = requestId,
        //                VenueId = evspInstanceId.EvspID.VenueId,
        //                ProductId = evspInstanceId.EvspID.ProductId,
        //                InstanceId = evspInstanceId.InstanceId,
        //                Credentials = credentials
        //            };
        //
        //            _communicationProvider.SendMessage(createSession);
        //            return true;
        //            return true;
        #endregion
    }
}
