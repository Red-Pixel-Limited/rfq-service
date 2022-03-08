namespace RFQ.Communication.DTOs
{
    using Options;

    public sealed class TradeParticipantDTO
    {
        public Side Side { get; private set; }
        public long Size { get; private set; }
        public long SizeBase { get; private set; }
        public long Price { get; private set; }
        public long PriceBase { get; private set; }
        public string TraderOrgId { get; private set; }
        public string TraderUserId { get; private set; }

        public TradeParticipantDTO(Side side, 
                                   long size, 
                                   long sizeBase, 
                                   long price, 
                                   long priceBase, 
                                   string traderOrgId,
                                   string traderUserId)
        {
            TraderUserId = traderUserId;
            TraderOrgId = traderOrgId;
            SizeBase = sizeBase;
            PriceBase = priceBase;
            Price = price;
            Side = side;
            Size = size;
        }
    }
}
