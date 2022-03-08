namespace RFQ.Altex.Mappings.Options
{
    using Core.Exceptions;
    using Utils;
    using BO = Communication.Options;
    using global::Altex.MessageLibrary;

    internal sealed class PriceFormatMapper : IOptionsMapper<BO.PriceFormat, PriceFormatNorm>
    {
        public PriceFormatNorm Map(BO.PriceFormat priceFormat)
        {
            switch (priceFormat)
            {
                case BO.PriceFormat.Undefined:
                    return PriceFormatNorm.Undefined;
                case BO.PriceFormat.TreasuryNote32NDs:
                    return PriceFormatNorm._32nds;
                case BO.PriceFormat.TreasureNote64THs:
                    return PriceFormatNorm._64ths;
                case BO.PriceFormat.Whole32NDs:
                    return PriceFormatNorm.Whole32nds;
                case BO.PriceFormat.Decimals:
                    return PriceFormatNorm.Decimals;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(priceFormat, typeof(PriceFormatNorm)));
            }
        }

        public BO.PriceFormat Map(PriceFormatNorm priceFormat)
        {
            switch (priceFormat)
            {
                case PriceFormatNorm.Undefined:
                    return BO.PriceFormat.Undefined;
                case PriceFormatNorm._32nds:
                    return BO.PriceFormat.TreasuryNote32NDs;
                case PriceFormatNorm._64ths:
                    return BO.PriceFormat.TreasureNote64THs;
                case PriceFormatNorm.Whole32nds:
                    return BO.PriceFormat.Whole32NDs;
                case PriceFormatNorm.Decimals:
                    return BO.PriceFormat.Decimals;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(priceFormat, typeof(BO.PriceFormat)));
            }
        }
    }
}
