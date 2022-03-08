namespace RFQ.Core.Entities
{
    using System;
    using Communication.Options;
    using Options;

    public partial class Quote : EntityBase<string>, ITrackable
    {
        public virtual long? SellPrice { get; set; }
        public virtual long? SellPriceBase { get; set; }
        public virtual long? BuyPrice { get; set; }
        public virtual long? BuyPriceBase { get; set; }
        public virtual User Owner { get; protected set; }
        public virtual RFQOffer RFQ { get; protected set; }
        public virtual QuoteState State { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual DateTime? LastModified { get; protected set; }

        public virtual void Visit(Reason reason)
        {
            switch (reason)
            {
                case Reason.Initiated:
                    State = QuoteState.Open;
                    LastModified = DateTime.UtcNow;
                    break;
                case Reason.Expires:
                    State = QuoteState.Expired;
                    LastModified = DateTime.UtcNow;
                    break;
                case Reason.Cancelled:
                    State = QuoteState.Cancelled;
                    LastModified = DateTime.UtcNow;
                    break;
            }
        }
    }
}
