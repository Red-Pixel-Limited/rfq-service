namespace RFQ.Workflow.Specs.Utils
{
    using Artifacts;
    using Communication.Messages;
    using FluentAssertions;
    using Machine.Specifications;
    using Tools;
    using Workflow.Utils;
    using It = Machine.Specifications.It;

    [Subject(typeof(TokenBuilder))]
    public class when_extracting_id_from_accountable_message
    {
        Establish context = () =>
        {
            message = new TestMessage(request_id, venue_id, product_id);
        };

        Because of = () => id = message.ExtractId();

        It should_be_build_from_venue_and_product_identities = 
            () => id.Should().Be(new ObjectToken(venue_id, product_id));

        const string request_id = "Request888";
        const string venue_id = "GtnEvsp_Java";
        const string product_id = "Product_01";
        
        static ObjectToken id;
        static ProductVenueMessage message;
    }
}
