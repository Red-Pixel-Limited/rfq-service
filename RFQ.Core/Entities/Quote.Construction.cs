namespace RFQ.Core.Entities
{
    using System;
    using Communication.Options;
    using Tools;
    using Utils;

    public partial class Quote
    {
        protected Quote() {}

        public static Quote New([NotNull] User by, [NotNull] RFQOffer forWhat,
                                long sellPrice, long sellPriceBase,
                                long buyPrice, long buyPriceBase)
        {
            return new Quote
            {
                Id = EntityId.New(),
                Owner = by,
                RFQ = forWhat,
                BuyPrice = buyPrice,
                BuyPriceBase = buyPriceBase,
                SellPrice = sellPrice,
                SellPriceBase = sellPriceBase,
                State = QuoteState.Unknown,
                Created = DateTime.UtcNow
            };
        }

        public static Quote Pass([NotNull] User by, [NotNull] RFQOffer forWhat)
        {
            return new Quote
            {
                Id = EntityId.New(),
                Owner = by,
                RFQ = forWhat,
                State = QuoteState.Passed,
                Created = DateTime.UtcNow
            };
        }
    }
}
