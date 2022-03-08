namespace RFQ.Altex.Mappings.Options
{
    using Communication.Options;
    using Core.Exceptions;
    using global::Altex.MessageLibrary;
    using Utils;

    internal sealed class QuoteStateMapper : IOptionsMapper<QuoteState, QuoteStateType>
    {
        public QuoteStateType Map(QuoteState state)
        {
            switch (state)
            {
                case QuoteState.Unknown:
                    return QuoteStateType.Unknown;
                case QuoteState.Open:
                    return QuoteStateType.Open;
                case QuoteState.Cancelled:
                    return QuoteStateType.Cancelled;
                case QuoteState.Expired:
                    return QuoteStateType.Expired;
                case QuoteState.Refused:
                case QuoteState.Traded:
                case QuoteState.Filled:
                    return QuoteStateType.Filled;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(state, typeof(QuoteStateType)));
            }
        }

        public QuoteState Map(QuoteStateType stateType)
        {
            switch (stateType)
            {
                case QuoteStateType.Unknown:
                    return QuoteState.Unknown;
                case QuoteStateType.Open:
                    return QuoteState.Open;
                case QuoteStateType.Cancelled:
                    return QuoteState.Cancelled;
                case QuoteStateType.Expired:
                    return QuoteState.Expired;
                case QuoteStateType.Filled:
                    return QuoteState.Filled;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(stateType, typeof(QuoteState)));
            }
        }
    }
}
