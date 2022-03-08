namespace RFQ.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using Communication.Options;
    using Options;

    public partial class RFQOffer : EntityBase<string>, ITrackable
    {
        public virtual User Owner { get; protected set; }
        public virtual long Size { get; protected set; }
        public virtual long SizeBase { get; protected set; }
        public virtual Side Side { get; protected set; }
        public virtual RFQState State { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual DateTime? LastModified { get; protected set; }
        public virtual string VenueId { get; protected set; }
        public virtual string ProductId { get; protected set; }
        public virtual string InstrumentId { get; protected set; }
        public virtual string InstrumentName { get; protected set; }
        public virtual ISet<Quote> Quotes { get; protected set; }

        public virtual void Visit(Reason reason)
        {
            switch (reason)
            {
                case Reason.Initiated:
                    State = RFQState.Open;
                    LastModified = DateTime.UtcNow;
                    break;
                case Reason.Expires:
                    State = RFQState.Expired;
                    LastModified = DateTime.UtcNow;
                    break;
                case Reason.Cancelled:
                    State = RFQState.Cancelled;
                    LastModified = DateTime.UtcNow;
                    break;
            }
        }
    }
}
