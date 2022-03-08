namespace RFQ.Altex.Utils 
{
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Communication.Artifacts;

    internal static class ConfigurationParser 
    {
        internal static IList<BrokerConfiguration> Parse(DataSet dataSet)
        {
            const string configRootKey = "GRSPConfig";
            const string displayNameKey = "DisplayName";
            const string autoConnectKey = "AutoConnect";
            const string ibCredentialsKey = "IBCredentials";
            const string productKey = "Product";
            const string venueKey = "Venue";

            var document = GetXmlDocument(dataSet);
            var settings = document.Descendants(configRootKey)
                                   .Select(parent => new BrokerConfiguration
                                   {
                                       VenueId = (string)parent.Element(venueKey),
                                       ProductId = (string)parent.Element(productKey),
                                       DisplayName = (string)parent.Element(displayNameKey),
                                       CanAutoConnect = (bool)parent.Element(autoConnectKey),
                                       Credentials = parent.Element(ibCredentialsKey).AsCredentials()
                                   });
            return settings.ToList();
        }

        private static object AsCredentials(this XContainer element)
        {
            var credentials = GetUserCredentials(element) ?? GetFirmCredentials(element);
            return credentials;
        }

        private static object GetUserCredentials(XContainer element)
        {
            const string passwordCredentialsKey = "PasswordCredentials";
            const string usernameKey = "Username";
            const string passwordKey = "Password";

            if (!element.Descendants(passwordCredentialsKey).Any())
                return null;

            return new IBUserCredentials
            {
                Username = element.Descendants(usernameKey).First().Value,
                CurrentPassword = element.Descendants(passwordKey).First().Value
            };
        }

        private static object GetFirmCredentials(XContainer element)
        {
            const string userCredentialsKey = "UserFirmCredentials";
            const string userIdKey = "UserId";
            const string firmIdKey = "FirmId";

            if (!element.Descendants(userCredentialsKey).Any())
                return null;

            return new IBFirmCredentials
            {
                UserId = element.Descendants(userIdKey).First().Value,
                FirmId = element.Descendants(firmIdKey).First().Value
            };
        }

        private static XDocument GetXmlDocument(DataSet dataSet)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    var serializer = new XmlSerializer(typeof(DataSet));
                    serializer.Serialize(streamWriter, dataSet);
                    var text = Encoding.UTF8.GetString(memoryStream.ToArray());
                    return XDocument.Parse(text);
                }
            }
        }
    }
}
