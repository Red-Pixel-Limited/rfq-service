namespace RFQ.Communication.DTOs
{
    public sealed class InstrumentConfigurationDTO
    {
        public string Name { get; private set; }
        public string VenueId { get; private set; }
        public string ProductId { get; private set; }
        public bool IsAnonymous { get; private set; }
        public bool AllowMultiExecute { get; private set; }
        public int OrderRule { get; private set; }
        public string Magnitude { get; private set; }
        public long MinimumSize { get; private set; }
        public long MinimumSizeBase { get; private set; }
        public long DefaultSize { get; private set; }
        public long DefaultSizeBase { get; private set; }
        public long MaximumSize { get; private set; }
        public long MaximumSizeBase { get; private set; }
        public bool ShouldTradeByVWAP { get; private set; }
        public bool ShouldTradeByAON { get; private set; }
        public int RequestTimerDefault { get; private set; }
        public int RequestTimerMinimum { get; private set; }
        public int RequestTimerMaximum { get; private set; }
        public int ResponseTimerDefault { get; private set; }
        public int ResponseTimerMinimum { get; private set; }
        public int ResponseTimerMaximum { get; private set; }


        public InstrumentConfigurationDTO(string name,
                                          string venueId,
                                          string productId,
                                          bool isAnonymous,
                                          bool allowMultiExecute,
                                          int orderRule,
                                          string magnitude,
                                          long minimumSize,
                                          long minimumSizeBase,
                                          long defaultSize,
                                          long defaultSizeBase,
                                          long maximumSize,
                                          long maximumSizeBase,
                                          bool shouldTradeByVWAP,
                                          bool shouldTradeByAON,
                                          int requestTimerDefault,
                                          int requestTimerMinimum,
                                          int requestTimerMaximum,
                                          int responseTimerDefault,
                                          int responseTimerMinimum,
                                          int responseTimerMaximum)
        {
            ResponseTimerMaximum = responseTimerMaximum;
            ResponseTimerMinimum = responseTimerMinimum;
            ResponseTimerDefault = responseTimerDefault;
            RequestTimerMaximum = requestTimerMaximum;
            RequestTimerMinimum = requestTimerMinimum;
            RequestTimerDefault = requestTimerDefault;
            ShouldTradeByAON = shouldTradeByAON;
            ShouldTradeByVWAP = shouldTradeByVWAP;
            MaximumSizeBase = maximumSizeBase;
            MaximumSize = maximumSize;
            DefaultSizeBase = defaultSizeBase;
            DefaultSize = defaultSize;
            MinimumSizeBase = minimumSizeBase;
            MinimumSize = minimumSize;
            Magnitude = magnitude;
            OrderRule = orderRule;
            AllowMultiExecute = allowMultiExecute;
            IsAnonymous = isAnonymous;
            ProductId = productId;
            VenueId = venueId;
            Name = name;
        }
    }
}
