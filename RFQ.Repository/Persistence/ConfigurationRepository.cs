namespace RFQ.Repository.Persistence
{
    using Core.Persistence;
    using NHibernate;
    using Core.Entities;

    public sealed class ConfigurationRepository : RepositoryBase<InstrumentConfiguration, int>, IConfigurationRepository
    {
        public ConfigurationRepository(ISession session) : base(session) {}
    }
}
