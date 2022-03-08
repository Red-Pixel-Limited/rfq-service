using RFQ.Communication.DTOs;

namespace RFQ.Communication.Messages.Incoming
{
    public sealed class GTNUserSessionResponse : InstanceMessage
    {
        public GTNUserSessionDTO GTNUserSession { get; private set; }

        public GTNUserSessionResponse(string requestId,
                                      string venueId,
                                      string productId,
                                      string instanceId,
                                      GTNUserSessionDTO session)
            : base(requestId, venueId, productId, instanceId)
        {
            GTNUserSession = session;
        }
    }
}
