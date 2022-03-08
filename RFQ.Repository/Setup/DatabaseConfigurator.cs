namespace RFQ.Repository.Setup
{
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using Mappings;
    using NHibernate;

    public static class DatabaseConfigurator
    {
        public static ISessionFactory SetupConnection(string connectionStringKey)
        {
            return Fluently.Configure()
                           .Database(MsSqlConfiguration
                               .MsSql2008
                               .ConnectionString(cn => cn.FromConnectionStringWithKey(connectionStringKey))
                               .ShowSql())
                           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AttributeMap>())
                           .BuildSessionFactory();
        }
    }
}
