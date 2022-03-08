namespace RFQ.Workflow.Registries
{
    using System;
    using Core.Entities;
    using Management;

    sealed class MonitorsRegistry<TKey, TEntity> : CacheRegistry<TKey, EntityMonitor<TEntity>>
        where TEntity : ITrackable
    {
        public MonitorsRegistry(Func<EntityMonitor<TEntity>, TKey> keySelector) 
            : base(keySelector) {}
    }
}
