namespace RFQ.Repository.Specs.Setup
{
    using Machine.Specifications;
    using NHibernate;

    public class SharedSessionContext : IAssemblyContext
    {
        public static ISession TestSession { get; private set; }

        public void OnAssemblyStart()
        {
            using (var configurator = new DatabaseConfigurator())
                TestSession = configurator.OpenSession();
        }

        public void OnAssemblyComplete()
        {
            if (TestSession != null)
                TestSession.Dispose();
        }
    }
}
