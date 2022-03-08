namespace RFQ.Communication.Artifacts
{
    public class BrokerConfiguration
    {
        public string DisplayName { get; set; }
        public bool CanAutoConnect { get; set; }
        public object Credentials { get; set; }
        public string ProductId { get; set; }
        public string VenueId { get; set; }
    }
}
