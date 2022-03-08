namespace RFQ.Altex.Mappings.Options
{
    using Communication.Options;
    using Core.Exceptions;
    using global::Altex.MessageLibrary;
    using Utils;

    internal sealed class RFQStateMapper : IOptionsMapper<RFQState, RFQStateType>
    {
        public RFQStateType Map(RFQState state)
        {
            switch (state)
            {
                case RFQState.Unknown:
                    return RFQStateType.Unknown;
                case RFQState.Open:
                    return RFQStateType.Open;
                case RFQState.Cancelled:
                    return RFQStateType.Cancelled;
                case RFQState.Expired:
                    return RFQStateType.Expired;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(state, typeof(RFQStateType)));
            }
        }

        public RFQState Map(RFQStateType stateType)
        {
            switch (stateType)
            {
                case RFQStateType.Unknown:
                    return RFQState.Unknown;
                case RFQStateType.Open:
                    return RFQState.Open;
                case RFQStateType.Cancelled:
                    return RFQState.Cancelled;
                case RFQStateType.Expired:
                    return RFQState.Expired;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(stateType, typeof(RFQState)));
            }
        }
    }
}
