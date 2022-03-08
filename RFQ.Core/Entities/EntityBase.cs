namespace RFQ.Core.Entities
{
    public abstract class EntityBase<TId>
    {
        public virtual TId Id { get; protected set; }

        protected bool IsTransient
        {
            get { return Equals(Id, default(TId)); }
        }

        public override bool Equals(object obj)
        {
            return EntityEquals(obj as EntityBase<TId>);
        }

        protected bool EntityEquals(EntityBase<TId> other)
        {
            if (other == null || !GetType().IsInstanceOfType(other))
                return false;
            
            // One entity is transient and the other is persistent.
            if (IsTransient ^ other.IsTransient)
                return false;
            
            // Both entities are not saved.
            if (IsTransient && other.IsTransient)
                return ReferenceEquals(this, other);

            // Compare transient instances.
            return Equals(Id, other.Id);
        }

        // The hash code is cached because a requirement of a hash code is that
        // it does not change once calculated. For example, if this entity was
        // added to a hashed collection when transient and then saved, we need
        // the same hash code or else it could get lost because it would no 
        // longer live in the same bin.
        private int? _cachedHashCode;

        public override int GetHashCode()
        {
            if (_cachedHashCode.HasValue) 
                return _cachedHashCode.Value;

            _cachedHashCode = IsTransient ? base.GetHashCode() : Id.GetHashCode();
            return _cachedHashCode.Value;
        }

        // Maintain equality operator semantics for entities.
        public static bool operator ==(EntityBase<TId> x, EntityBase<TId> y)
        {
            // By default, == and Equals compares references. In order to 
            // maintain these semantics with entities, we need to compare by 
            // identity value. The Equals(x, y) override is used to guard 
            // against null values; it then calls EntityEquals().
            return Equals(x, y);
        }

        // Maintain inequality operator semantics for entities. 
        public static bool operator !=(EntityBase<TId> x, EntityBase<TId> y)
        {
            return !(x == y);
        }
    }
}
