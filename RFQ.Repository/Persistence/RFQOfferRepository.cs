namespace RFQ.Repository.Persistence
{
    using Core.Persistence;
    using NHibernate;
    using Core.Entities;

    public sealed class RFQOfferRepository : RepositoryBase<RFQOffer, string>, IRFQOfferRepository
    {
        public RFQOfferRepository(ISession session) : base(session) {}
    }
}
