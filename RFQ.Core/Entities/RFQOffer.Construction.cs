namespace RFQ.Core.Entities
{
    using System;
    using Artifacts;
    using Communication.Options;
    using Iesi.Collections.Generic;
    using Tools;
    using Utils;

    public partial class RFQOffer
    {
        protected RFQOffer() {}

        public static RFQOffer New([NotNull] User by,
                                   [NotNull] Instrument forWhat,
                                   long size, long sizeBase, Side side,
                                   [NotNull] string productId,
                                   [NotNull] string venueId)
        {
            return new RFQOffer
            {
                Id = EntityId.New(),
                Owner = by,
                Size = size,
                SizeBase = sizeBase,
                Side = side,
                State = RFQState.Unknown,
                Created = DateTime.UtcNow,
                InstrumentId = forWhat.Id,
                InstrumentName = forWhat.Name,
                VenueId = venueId,
                ProductId = productId,
                Quotes = new LinkedHashSet<Quote>()
            };
        }
    }
}
