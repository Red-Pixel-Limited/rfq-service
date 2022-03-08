namespace RFQ.Service.Utils
{
    using System;
    using System.Configuration;
    using System.Reflection;
    using Core.Exceptions;
    using Core.Utils;
    using Options;
    using Properties;
    using Settings.Altex;

    sealed class ConfigurationReader
    {
        const string StartAsKey = "StartAs";
        const string ComponentNameKey = "ComponentName";
        const string HeartbeatTopicKey = "HeartbeatTopic";
        const string HeartbeatIntervalKey = "HeartbeatInterval";
        const string GTNTrackingIntervalKey = "GTNTrackingInterval";
        const string GTNHeartbeatsListenerIdKey = "GTNHeartbeatsListenerId";

        internal const string ConnectionStringKey = "RFQ_DB";

        internal StartAs GetStartAsOption()
        {
            var value = ConfigurationManager.AppSettings[StartAsKey];
            StartAs option;
            if (!Enum.TryParse(value, out option))
                throw new RFQConfigurationException(Resources.StartAsReadErrorMessage);

            return option;
        }

        internal string GetServiceName()
        {
            object[] attributes =
                Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);

            return ((AssemblyTitleAttribute)attributes[0]).Title;
        }

        internal int GetHeartbeatInterval()
        {
            var value = ConfigurationManager.AppSettings[HeartbeatIntervalKey];
            int interval;
            if (!int.TryParse(value, out interval))
                throw new RFQConfigurationException(Resources.RFQHeartbeatIntervalReadErrorMessage);

            return interval;
        }

        internal int GetGTNTrackingInterval()
        {
            var value = ConfigurationManager.AppSettings[GTNTrackingIntervalKey];
            int interval;
            if (!int.TryParse(value, out interval))
                throw new RFQConfigurationException(Resources.GTNTrackingIntervalReadErrorMessage);

            return interval;
        }

        internal string GetGTNHeartbeatsListenerId()
        {
            var value = ConfigurationManager.AppSettings[GTNHeartbeatsListenerIdKey];
            return value.IsEmptyOrWhiteSpace() ? "RFQServiceRequest" : value;
        }

        internal string[] GetAltexSettings()
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var section = configuration.GetSection(AltexSettingsSection.Name) as AltexSettingsSection;

            if (section == null)
                throw new RFQConfigurationException(
                    String.Format(Resources.AltexSettingsReadErrorMessage, AltexSettingsSection.Name));

            var componentName = section.Settings[ComponentNameKey];
            if (componentName == null)
                throw new RFQConfigurationException(Resources.ComponentNameReadErrorMessage);

            var heartbeatTopic = section.Settings[HeartbeatTopicKey];
            if (heartbeatTopic == null)
                throw new RFQConfigurationException(Resources.HeartbeatTopicReadErrorMessage);

            return new[] {componentName.Value, heartbeatTopic.Value};
        }
    }
}
