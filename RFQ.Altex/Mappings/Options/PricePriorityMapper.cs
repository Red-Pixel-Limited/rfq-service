namespace RFQ.Altex.Mappings.Options
{
    using Communication.Options;
    using Core.Exceptions;
    using global::Altex.MessageLibrary;
    using Utils;

    internal sealed class PricePriorityMapper : IOptionsMapper<PricePriority, PricePriorityType>
    {
        public PricePriorityType Map(PricePriority priority)
        {
            switch (priority)
            {
                case PricePriority.Undefined:
                    return PricePriorityType.Undefined;
                case PricePriority.HigherIsBetter:
                    return PricePriorityType.HigherIsBetter;
                case PricePriority.LowerIsBetter:
                    return PricePriorityType.LowerIsBetter;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(priority, typeof(PricePriorityType)));
            }
        }

        public PricePriority Map(PricePriorityType priority)
        {
            switch (priority)
            {
                case PricePriorityType.Undefined:
                    return PricePriority.Undefined;
                case PricePriorityType.HigherIsBetter:
                    return PricePriority.HigherIsBetter;
                case PricePriorityType.LowerIsBetter:
                    return PricePriority.LowerIsBetter;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(priority, typeof(PricePriority)));
            }
        }
    }
}
