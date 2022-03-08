namespace RFQ.Altex.Mappings.Messages.Outgoing
{
    using Communication.Messages.Outgoing;
    using global::Altex.MessageLibrary;
    using global::Altex.MessageLibrary.Msg.Norm;

    public sealed class GTNHeartbeatsSubscriptionMapper : IOutgoingMessageMapper<GTNHeartbeatsSubscription>
    {
        public MsgBase Map(GTNHeartbeatsSubscription message)
        {
            return new SubscribeEVSPHeartbeats
            {
                RequestId = message.RequestId
            };
        }
    }
}
