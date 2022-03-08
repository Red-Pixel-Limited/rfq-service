namespace RFQ.Core.Persistence
{
    using System;
    using System.Collections.Generic;
    using Entities;

    public interface IRepository<TEntity, in TKey> 
        where TEntity : EntityBase<TKey>
    {
        TEntity GetById(TKey id);
        TEntity GetFirstBy(Func<TEntity, bool> expression);
        IEnumerable<TEntity> FindBy(Func<TEntity, bool> expression);
        void SaveOrUpdate(TEntity entity);
        void Delete(TEntity entity);
    }
}
