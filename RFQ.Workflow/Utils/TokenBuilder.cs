namespace RFQ.Workflow.Utils
{
    using Artifacts;
    using Communication.Messages;
    using Communication.Messages.Incoming;

    public static class TokenBuilder
    {
        public static ObjectToken GetGTNIdentity(this GTNHeartbeat heartbeat)
        {
            return new ObjectToken(heartbeat.VenueId, heartbeat.ProductId);
        }

        public static ObjectToken GetGTNIdentity(this GTNStatusLog log)
        {
            return new ObjectToken(log.VenueId, log.ProductId);
        } 

        public static ObjectToken ExtractId(this ProductVenueMessage message)
        {
            return Build(message.VenueId, message.ProductId);
        }

        private static ObjectToken Build(string venueId, string productId)
        {
            return new ObjectToken(venueId, productId);
        }
    }
}
