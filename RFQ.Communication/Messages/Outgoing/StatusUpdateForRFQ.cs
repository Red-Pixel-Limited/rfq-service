namespace RFQ.Communication.Messages.Outgoing
{
    using System;
    using Options;

    public sealed class StatusUpdateForRFQ : InstanceMessage
    {
        public string RFQId { get; private set; }
        public string InstrumentId { get; private set; }
        public string InstrumentName { get; private set; }
        public string InitiatorId { get; private set; }
        public string InitiatorGTNSessionId { get; private set; }
        public long Size { get; private set; }
        public long SizeBase { get; private set; }
        public Side Side { get; private set; }
        public DateTime Started { get; private set; }
        public long Remains { get; private set; }
        public RFQState CurrentState { get; private set; }
        public bool IsSnapshot { get; private set; }
        public UpdateAction UpdateAction { get;  private set; }
        public bool ShouldTradeByVWAP { get; private set; }
        public int AmountOfResponces { get; private set; }

        public StatusUpdateForRFQ(string requestId,
                                  string venueId,
                                  string productId,
                                  string instanceId,
                                  string rfqId,
                                  string instrumentId,
                                  string instrumentName,
                                  string initiatorId,
                                  string initiatorGTNSessionId,
                                  long size,
                                  long sizeBase,
                                  Side side,
                                  DateTime started,
                                  long remains,
                                  RFQState currentState,
                                  bool isSnapshot,
                                  UpdateAction updateAction,
                                  bool shouldTradeByVWAP,
                                  int amountOfResponces)
            : base(requestId, venueId, productId, instanceId)
        {
            RFQId = rfqId;
            InstrumentId = instrumentId;
            InstrumentName = instrumentName;
            InitiatorId = initiatorId;
            InitiatorGTNSessionId = initiatorGTNSessionId;
            Size = size;
            SizeBase = sizeBase;
            Side = side;
            Started = started;
            Remains = remains;
            CurrentState = currentState;
            IsSnapshot = isSnapshot;
            UpdateAction = updateAction;
            ShouldTradeByVWAP = shouldTradeByVWAP;
            AmountOfResponces = amountOfResponces;
        }
    }
}
