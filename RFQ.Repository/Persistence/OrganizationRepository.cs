namespace RFQ.Repository.Persistence
{
    using Core.Entities;
    using Core.Persistence;
    using NHibernate;

    public sealed class OrganizationRepository : RepositoryBase<Organization, int>, IOrganizationRepository
    {
        public OrganizationRepository(ISession session) : base(session) {}
    }
}
