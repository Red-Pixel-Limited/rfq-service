namespace RFQ.Altex.Mappings.Options
{
    using Communication.Options;
    using Core.Exceptions;
    using global::Altex.MessageLibrary;
    using Utils;

    internal sealed class SideMapper : IOptionsMapper<Side, SideType>
    {
        public SideType Map(Side side)
        {
            switch (side)
            {
                case Side.Undefined:
                    return SideType.Undefined;
                case Side.Buy:
                    return SideType.Buy;
                case Side.Sell:
                    return SideType.Sell;
                case Side.Both:
                    return SideType.Both;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(side, typeof(SideType)));
            }
        }

        public Side Map(SideType sideType)
        {
            switch (sideType)
            {
                case SideType.Undefined:
                    return Side.Undefined;
                case SideType.Buy:
                    return Side.Buy;
                case SideType.Sell:
                    return Side.Sell;
                case SideType.Both:
                    return Side.Both;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(sideType, typeof(Side)));
            }
        }
    }
}
