namespace RFQ.Altex.Mappings.Options
{
    using Communication.Options;
    using Core.Exceptions;
    using global::Altex.MessageLibrary;
    using Utils;

    internal sealed class GTNStatusMapper : IOptionsMapper<GTNStatus, HeartbeatUpdateType>
    {
        public HeartbeatUpdateType Map(GTNStatus status)
        {
            switch (status)
            {
                case GTNStatus.Unknown:
                    return HeartbeatUpdateType.Unknown;
                case GTNStatus.Attention:
                    return HeartbeatUpdateType.Attention;
                case GTNStatus.Live:
                    return HeartbeatUpdateType.Live;
                case GTNStatus.Closed:
                    return HeartbeatUpdateType.Closed;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(status, typeof(HeartbeatUpdateType)));
            }
        }

        public GTNStatus Map(HeartbeatUpdateType heartbeatUpdateType)
        {
            switch (heartbeatUpdateType)
            {
                case HeartbeatUpdateType.Unknown:
                    return GTNStatus.Unknown;
                case HeartbeatUpdateType.Attention:
                    return GTNStatus.Attention;
                case HeartbeatUpdateType.Live:
                    return GTNStatus.Live;
                case HeartbeatUpdateType.Closed:
                    return GTNStatus.Closed;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(heartbeatUpdateType, typeof(GTNStatus)));
            }
        }
    }
}
