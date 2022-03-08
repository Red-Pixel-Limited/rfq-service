namespace RFQ.Workflow.Specs.Tools
{
    using Communication.Messages;

    public class TestMessage : ProductVenueMessage
    {
        public TestMessage(string requestId, string venueId, string productId) 
            : base(requestId, venueId, productId) {}
    }
}