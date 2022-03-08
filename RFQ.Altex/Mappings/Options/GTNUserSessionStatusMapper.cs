namespace RFQ.Altex.Mappings.Options
{
    using Communication.Options;
    using Core.Exceptions;
    using global::Altex.MessageLibrary;
    using Utils;

    internal sealed class GTNUserSessionStatusMapper : IOptionsMapper<GTNUserSessionStatus, SessionStatus>
    {
        public SessionStatus Map(GTNUserSessionStatus status)
        {
            switch (status)
            {
                case GTNUserSessionStatus.Unknown:
                    return SessionStatus.Unknown;
                case GTNUserSessionStatus.Connected:
                    return SessionStatus.Connected;
                case GTNUserSessionStatus.Disconnected:
                    return SessionStatus.Disconnected;
                case GTNUserSessionStatus.Destroyed:
                    return SessionStatus.Destroyed;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(status, typeof(SessionStatus)));
            }
        }

        public GTNUserSessionStatus Map(SessionStatus status)
        {
            switch (status)
            {
                case SessionStatus.Unknown:
                    return GTNUserSessionStatus.Unknown;
                case SessionStatus.Connected:
                    return GTNUserSessionStatus.Connected;
                case SessionStatus.Disconnected:
                    return GTNUserSessionStatus.Disconnected;
                case SessionStatus.Destroyed:
                    return GTNUserSessionStatus.Destroyed;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(status, typeof(GTNUserSessionStatus)));
            }
        }
    }
}
