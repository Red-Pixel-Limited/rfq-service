namespace RFQ.Repository.Specs.Setup
{
    using System;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    using Repository.Mappings;

    internal class DatabaseConfigurator : IDisposable
    {
        private bool _isDisposed;
        private readonly Configuration _configuration;
        private readonly ISessionFactory _sessionFactory;

        internal DatabaseConfigurator()
        {
            var configuration = CreateConfiguration();
            _sessionFactory = configuration.BuildSessionFactory();
            _configuration = configuration;
        }

        ~DatabaseConfigurator()
        {
            Dispose(false);
        }

        private static Configuration CreateConfiguration()
        {

            return Fluently.Configure()
                           .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                           .Mappings(m => m.FluentMappings
                                           .Add<BrokerMap>()
                                           .Add<AttributeMap>()
                                           .Add<InstrumentConfigurationMap>()
                                           .Add<OrganizationAdjustmentMap>()
                                           .Add<OrganizationMap>()
                                           .Add<UserMap>()
                                           .Add<QuoteMap>()
                                           .Add<RFQOfferMap>())
                           .BuildConfiguration();
        }

        internal ISession OpenSession()
        {
            var session = _sessionFactory.OpenSession();

            var export = new SchemaExport(_configuration);
            export.Execute(true, true, false, session.Connection, null);

            return session;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing && _sessionFactory != null)
            {
                if (!_sessionFactory.IsClosed)
                    _sessionFactory.Close();

                _sessionFactory.Dispose();
            }

            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
