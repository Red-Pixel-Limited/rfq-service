namespace RFQ.Service.Settings.Altex
{
    using System.Configuration;

    public class AltexSettingsSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty SettingsSectionProperty = new ConfigurationProperty(null,
            typeof(AltexSettings), null, ConfigurationPropertyOptions.IsDefaultCollection);

        private static readonly ConfigurationPropertyCollection ConfigProperties = new ConfigurationPropertyCollection();

        static AltexSettingsSection()
        {
            ConfigProperties.Add(SettingsSectionProperty);
        }

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public AltexSettings Settings
        {
            get { return (AltexSettings)base[SettingsSectionProperty]; }
        }

        public static string Name
        {
            get { return "altexSettings"; }
        }
    }
}
