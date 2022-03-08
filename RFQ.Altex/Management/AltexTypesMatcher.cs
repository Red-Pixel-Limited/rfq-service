﻿namespace RFQ.Altex.Management
﻿{
﻿    using System;
﻿    using System.Collections.Generic;
﻿    using Communication.Messages;
﻿    using Communication.Messages.Incoming;
﻿    using global::Altex.MessageLibrary;

﻿    internal sealed class AltexTypesMatcher
﻿    {
﻿        private static readonly Lazy<AltexTypesMatcher> Constructor =
﻿            new Lazy<AltexTypesMatcher>(() => new AltexTypesMatcher());

﻿        private readonly IDictionary<Type, MsgType> _messageTypesMap = new Dictionary<Type, MsgType>
﻿        {
﻿            {typeof(GTNHeartbeat), MsgType.EVSPHeartbeat},
            {typeof(GTNUserSessionCreated), MsgType.SessionCreated},
            {typeof(GTNUserSessionExists), MsgType.SessionExists},
            {typeof(GTNRequestFailed), MsgType.SessionFailed},
            {typeof(GTNUserSessionDestroyed), MsgType.SessionDestroyed},
            {typeof(GTNUserSessionDisconnected), MsgType.SessionDisconnected},
            {typeof(LoginFailed), MsgType.LoginFailed},
﻿            {typeof(GTNUserSessionResponse), MsgType.SessionDetailsResponse},
﻿            {typeof(StartBrokerSession), MsgType.StartVenue},
﻿            {typeof(StopBrokerSession), MsgType.StopVenue},
﻿            {typeof(RespondVenueConfiguration), MsgType.GetVenueConfiguration},
﻿            {typeof(StoreBrokerConfiguration), MsgType.SaveVenueConfiguration},
﻿            {typeof(YieldBrokersHeartbeats), MsgType.SubscribeGRSPHeartbeats},
﻿            {typeof(BrokerSessionDestroyed), MsgType.DestroySession},
﻿            {typeof(YieldInstrumentConfigurations), MsgType.GetInstrumentConfigurations},
﻿            {typeof(YieldCurrentlyActiveOrganizations), MsgType.AllRFQFirmsRequest},
﻿            {typeof(YieldOrganizationAdjustments), MsgType.GetRFQFirmsByRuleRequest},
﻿            {typeof(YieldEmployees), MsgType.RFQUserByFirmRequest},
﻿            {typeof(DetectWhetherMarketMaker), MsgType.MarketMakerValidation},
﻿            {typeof(RespondInstrumentConfiguration), MsgType.RequestRFQConfiguration},
﻿            {typeof(StoreInstrumentConfiguration), MsgType.SaveInstrumentConfiguration},
﻿            {typeof(RemoveInstrumentConfiguration), MsgType.InstrumentDelete},
﻿            {typeof(InstrumentStaticDataResponse), MsgType.InstrumentStaticDataResponse},
﻿            {typeof(StoreOrganizationsAdjustment), MsgType.RFQSaveFirmsRuleRequest},
﻿            {typeof(StoreRuleOrder), MsgType.RFQSaveRuleOrderRequest},
﻿            {typeof(ApplyForRFQ), MsgType.SubscribeRFQSession},
﻿            {typeof(NewRFQ), MsgType.NewRFQ},
﻿            {typeof(CancelRFQ), MsgType.CancelRFQ},
﻿            {typeof(YieldQuotesStatuses), MsgType.SubscribeQuoteStatus},
﻿            {typeof(NewQuote), MsgType.NewQuote},
﻿            {typeof(AcceptQuote), MsgType.AcceptQuote},
﻿            {typeof(CancelQuote), MsgType.CancelQuote},
﻿            {typeof(PassRFQ), MsgType.PassRFQ},
﻿            {typeof(RequestFailed), MsgType.RequestFailed},
﻿            {typeof(RequestSucceeded), MsgType.RequestSucceeded}
﻿        };

﻿        private AltexTypesMatcher() {}

﻿        public static AltexTypesMatcher Created
﻿        {
﻿            get { return Constructor.Value; }
﻿        }

﻿        public MsgType MatchMessageType(Type typeOfMessage)
﻿        {
﻿            return _messageTypesMap[typeOfMessage];
﻿        }
﻿    }
﻿}