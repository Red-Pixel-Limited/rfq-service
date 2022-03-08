namespace RFQ.Core.Entities
{
    using System;

    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global

    public class Broker : EntityBase<int>
    {
        public virtual string IBUsername { get; set; }
        public virtual string IBPassword { get; set; }
        public virtual bool CanAutoConnect { get; set; }
        public virtual string Notes { get; set; }
        public virtual string VenueId { get; set; }
        public virtual string ProductId { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? LastModified { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }
    }
}
