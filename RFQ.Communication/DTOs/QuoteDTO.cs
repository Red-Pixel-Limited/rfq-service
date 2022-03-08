namespace RFQ.Communication.DTOs
{
    public sealed class QuoteDTO
    {
        public long BuyPrice { get; private set; }
        public long BuyPriceBase { get; private set; }
        public long SellPrice { get; private set; }
        public long SellPriceBase { get; private set; }
        public long DurationTime { get; private set; }
        public string TraderOrgId { get; private set; }
        public string InstrumentId { get; private set; }
        public string TraderUserId { get; private set; }

        public QuoteDTO(long buyPrice, 
                        long buyPriceBase, 
                        long sellPrice, 
                        long sellPriceBase, 
                        long durationTime,
                        string traderOrgId, 
                        string instrumentId, 
                        string traderUserId)
        {
            TraderUserId = traderUserId;
            InstrumentId = instrumentId;
            TraderOrgId = traderOrgId;
            DurationTime = durationTime;
            SellPriceBase = sellPriceBase;
            SellPrice = sellPrice;
            BuyPriceBase = buyPriceBase;
            BuyPrice = buyPrice;
        }
    }
}
