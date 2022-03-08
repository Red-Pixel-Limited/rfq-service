namespace RFQ.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public class InstrumentConfiguration : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual int? RequestTimerDefault { get; set; }
        public virtual int? RequestTimerMinimum { get; set; }
        public virtual int? RequestTimerMaximum { get; set; }
        public virtual int? ResponseTimerDefault { get; set; }
        public virtual int? ResponseTimerMinimum { get; set; }
        public virtual int? ResponseTimerMaximum { get; set; }
        public virtual int? MinimumNumOfMarketMakers { get; set; }
        public virtual int? DefaultSize { get; set; }
        public virtual int? MinimumSize { get; set; }
        public virtual long? MaximumSize { get; set; }
        public virtual bool IsAnonymous { get; set; }
        public virtual bool IsMultipleExecutionAllowed { get; set; }
        public virtual bool ShouldTradeByVWAP { get; set; }
        public virtual bool ShouldTradeByAON { get; set; }
        public virtual string ClearingType { get; set; }
        public virtual int? ConfigurationType { get; set; }
        public virtual string RuleLevel { get; set; }
        public virtual int OrderRule { get; set; }
        public virtual string Magnitude { get; set; }
        public virtual string TradeDisclosureToMissedResponders { get; set; }
        public virtual string TradeDisclosureToMarketData { get; set; }
        public virtual string InstrumentSizeValidationRules { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? LastModified { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual string VenueId { get; set; }
        public virtual string ProductId { get; set; } 
        public virtual ISet<Attribute> Attributes { get; set; }
        public virtual ISet<OrganizationAdjustment> Adjustments { get; set; } 
    }
}
