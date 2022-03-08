namespace RFQ.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public class User : EntityBase<int>
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Initials { get; set; }
        public virtual string Username { get; set; }
        public virtual string DefaultEmail { get; set; }
        public virtual string DefaultPhone { get; set; }
        public virtual string VenueId { get; set; }
        public virtual string ProductId { get; set; }
        public virtual string FusionId { get; set; }
        public virtual string ExternalId { get; set; }
        public virtual DateTime? LastLoggedIn { get; set; }
        public virtual DateTime? LastLoggedOut { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? LastModified { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ISet<Quote> Quotes { get; set; }
        public virtual ISet<RFQOffer> RFQOffers { get; set; }
    }
}
