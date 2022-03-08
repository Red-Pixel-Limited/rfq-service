namespace RFQ.Repository.Persistence
{
    using Core.Entities;
    using Core.Persistence;
    using NHibernate;

    public sealed class BrokerRepository : RepositoryBase<Broker, int>, IBrokerRepository
    {
        public BrokerRepository(ISession session) : base(session) {}
    }
}
