namespace RFQ.Repository.Persistence
{
    using Core.Entities;
    using Core.Persistence;
    using NHibernate;

    public sealed class AttributeRepository : RepositoryBase<Attribute, int>, IAttributeRepository
    {
        public AttributeRepository(ISession session) : base(session) {}
    }
}
