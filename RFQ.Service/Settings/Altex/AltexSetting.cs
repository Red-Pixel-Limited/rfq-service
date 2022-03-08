namespace RFQ.Service.Settings.Altex
{
    using System.Configuration;

    public class AltexSetting : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)base["value"]; }
            set { base["value"] = value; }
        }

        public override bool IsReadOnly()
        {
            return true;
        }
    }
}
