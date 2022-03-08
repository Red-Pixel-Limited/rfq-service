namespace RFQ.Altex.Mappings.Options
{
    using Communication.Options;
    using Core.Exceptions;
    using global::Altex.MessageLibrary;
    using Utils;

    internal sealed class PriceMapper : IOptionsMapper<Price, PriceTypeNorm>
    {
        public PriceTypeNorm Map(Price price)
        {
            switch (price)
            {
                case Price.Undefined:
                    return PriceTypeNorm.Undefined;
                case Price.CashPrice:
                    return PriceTypeNorm.CashPrice;
                case Price.Yield:
                    return PriceTypeNorm.Yield;
                case Price.YieldDifference:
                    return PriceTypeNorm.YieldDifference;
                case Price.Basis:
                    return PriceTypeNorm.Basis;
                case Price.Spread:
                    return PriceTypeNorm.Spread;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(price, typeof(PriceTypeNorm)));
            }
        }

        public Price Map(PriceTypeNorm priceType)
        {
            switch (priceType)
            {
                case PriceTypeNorm.Undefined:
                    return Price.Undefined;
                case PriceTypeNorm.CashPrice:
                    return Price.CashPrice;
                case PriceTypeNorm.Yield:
                    return Price.Yield;
                case PriceTypeNorm.YieldDifference:
                    return Price.YieldDifference;
                case PriceTypeNorm.Basis:
                    return Price.Basis;
                case PriceTypeNorm.Spread:
                    return Price.Spread;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(priceType, typeof(Price)));
            }
        }
    }
}
