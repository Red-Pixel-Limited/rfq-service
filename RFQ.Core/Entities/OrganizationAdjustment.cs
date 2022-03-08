namespace RFQ.Core.Entities
{
    using System;

    public class OrganizationAdjustment : EntityBase<int>
    {
        public virtual Organization Organization { get; set; }
        public virtual InstrumentConfiguration Configuration { get; set; }
        public virtual bool IsMarketMaker { get; set; }
        public virtual int? UserId { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? LastModified { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }
    }
}
