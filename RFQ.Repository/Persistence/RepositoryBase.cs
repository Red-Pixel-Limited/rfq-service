namespace RFQ.Repository.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Entities;
    using Core.Persistence;
    using NHibernate;
    using NHibernate.Linq;

    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> 
        where TEntity : EntityBase<TKey>
    {
        private readonly ISession _session;

        protected ISession Session
        {
            get { return _session; }
        }

        protected RepositoryBase(ISession session)
        {
            _session = session;
        }

        public TEntity GetById(TKey id)
        {
            return _session.Get<TEntity>(id);
        }

        public TEntity GetFirstBy(Func<TEntity, bool> expression)
        {
            return Session.Query<TEntity>().FirstOrDefault(expression);
        }

        public IEnumerable<TEntity> FindBy(Func<TEntity, bool> expression)
        {
            return Session.Query<TEntity>().Where(expression);
        }

        public void SaveOrUpdate(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public void Delete(TEntity entity)
        {
            _session.Delete(entity);
        }
    }
}
