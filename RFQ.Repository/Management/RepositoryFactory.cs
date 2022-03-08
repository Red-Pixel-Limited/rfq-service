namespace RFQ.Repository.Management
{
    using System;
    using Core.Management;
    using Core.Persistence;
    using NHibernate;
    using Persistence;

    public sealed class RepositoryFactory : IRepositoryFactory
    {
        public IUserRepository CreateForUser(IUnitOfWork uow)
        {
            return Create(session => new UserRepository(session), uow);
        }

        public IQuoteRepository CreateForQuote(IUnitOfWork uow)
        {
            return Create(session => new QuoteRepository(session), uow);
        }

        public IRFQOfferRepository CreateForRFQOffer(IUnitOfWork uow)
        {
            return Create(session => new RFQOfferRepository(session), uow);
        }

        public IAttributeRepository CreateForAttribute(IUnitOfWork uow)
        {
            return Create(session => new AttributeRepository(session), uow);
        }

        public IBrokerRepository CreateForBroker(IUnitOfWork uow)
        {
            return Create(session => new BrokerRepository(session), uow);
        }

        public IOrganizationRepository CreateForOrganization(IUnitOfWork uow)
        {
            return Create(session => new OrganizationRepository(session), uow);
        }

        public IConfigurationRepository CreateForConfiguration(IUnitOfWork uow)
        {
            return Create(session => new ConfigurationRepository(session), uow);
        }

        private static T Create<T>(Func<ISession, T> create, IUnitOfWork uow)
        {
            var session = ((UnitOfWork)uow).Session;
            return create(session);
        }
    }
}
