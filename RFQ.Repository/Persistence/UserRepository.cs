namespace RFQ.Repository.Persistence
{
    using Core.Persistence;
    using NHibernate;
    using Core.Entities;

    public sealed class UserRepository : RepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(ISession session) : base(session) {}
    }
}
