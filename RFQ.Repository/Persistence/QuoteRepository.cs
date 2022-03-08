namespace RFQ.Repository.Persistence
{
    using Core.Persistence;
    using NHibernate;
    using Core.Entities;

    public sealed class QuoteRepository : RepositoryBase<Quote, string>, IQuoteRepository
    {
        public QuoteRepository(ISession session) : base(session) {}
    }
}
