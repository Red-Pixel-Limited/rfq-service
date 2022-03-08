namespace RFQ.Altex.Specs.Utils
{
    using System.Data;
    using System.Xml.Linq;
    using Altex.Utils;
    using Communication.Artifacts;
    using FluentAssertions;
    using Machine.Specifications;
    using Properties;

    [Subject(typeof(ConfigurationParser))]
    public class when_configuration_was_loaded
    {
        Establish context = () =>
        {
            var document = XDocument.Parse(Resources.GRSPConfig);
            configuration_set.ReadXml(document.CreateReader());
        };

        Because of = () =>
        {
            broker_configuration = ConfigurationParser.Parse(configuration_set)[0];
        };

        It should_retrieve_venue = 
            () => broker_configuration.VenueId.Should().Be("iSwapEVSP_Java");
        
        It should_retrieve_product = 
            () => broker_configuration.ProductId.Should().Be("product01");

        It should_retrieve_display_name =
            () => broker_configuration.DisplayName.Should().Be("Sample iSwap RFQ Service Provider");

        It should_retrieve_connection_option = 
            () => broker_configuration.CanAutoConnect.Should().BeTrue();

        It should_retrieve_password_credentials =
            () => broker_configuration.Credentials.Should().Be(
                new IBUserCredentials
                {
                    Username = "john_doe",
                    CurrentPassword = "supersecret"
                });

        static BrokerConfiguration broker_configuration;
        static readonly DataSet configuration_set = new DataSet();
    }
}
