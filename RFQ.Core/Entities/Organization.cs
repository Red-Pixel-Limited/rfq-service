namespace RFQ.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public class Organization : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual string MISCode { get; set; }
        public virtual string HitRatio { get; set; }
        public virtual string SuccessfulExecution { get; set; }
        public virtual string TotalRequest { get; set; }
        public virtual string ExternalId { get; set; }
        public virtual string VenueId { get; set; }
        public virtual string ProductId { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? LastModified { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual ISet<User> Users { get; set; }
        public virtual ISet<OrganizationAdjustment> ConfigurationDetails { get; set; } 
    }
}
