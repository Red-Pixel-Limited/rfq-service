namespace RFQ.Altex.Mappings.Options
{
    using Core.Exceptions;
    using Utils;
    using Altex = global::Altex.MessageLibrary;
    using BO = Communication.Options;

    internal sealed class GRSPStatusMapper : IOptionsMapper<BO.GRSPStatus, Altex.GRSPStatus>
    {
        public Altex.GRSPStatus Map(BO.GRSPStatus status)
        {
            switch (status)
            {
                case BO.GRSPStatus.Unknown:
                    return Altex.GRSPStatus.Unknown;
                case BO.GRSPStatus.Attention:
                    return Altex.GRSPStatus.Attention;
                case BO.GRSPStatus.Started:
                    return Altex.GRSPStatus.Started;
                case BO.GRSPStatus.Stopped:
                    return Altex.GRSPStatus.Stopped;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(status, typeof(Altex.GRSPStatus)));
            }
        }

        public BO.GRSPStatus Map(Altex.GRSPStatus status)
        {
            switch (status)
            {
                case Altex.GRSPStatus.Unknown:
                    return BO.GRSPStatus.Unknown;
                case Altex.GRSPStatus.Attention:
                    return BO.GRSPStatus.Attention;
                case Altex.GRSPStatus.Started:
                    return BO.GRSPStatus.Started;
                case Altex.GRSPStatus.Stopped:
                    return BO.GRSPStatus.Stopped;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(status, typeof(BO.GRSPStatus)));
            }
        }
    }
}
