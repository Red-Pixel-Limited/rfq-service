namespace RFQ.Altex.Mappings.Options
{
    using Communication.Options;
    using Core.Exceptions;
    using global::Altex.MessageLibrary;
    using Utils;

    internal sealed class SizeMagnitudeMapper : IOptionsMapper<SizeMagnitude, AmountMagnitudeNorm>
    {
        public AmountMagnitudeNorm Map(SizeMagnitude magnitude)
        {
            switch (magnitude)
            {
                case SizeMagnitude.Undefined:
                    return AmountMagnitudeNorm.Undefined;
                case SizeMagnitude.Units:
                    return AmountMagnitudeNorm.Units;
                case SizeMagnitude.Thousands:
                    return AmountMagnitudeNorm.Thousands;
                case SizeMagnitude.Millions:
                    return AmountMagnitudeNorm.Millions;
                case SizeMagnitude.Billions:
                    return AmountMagnitudeNorm.Billions;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(magnitude, typeof(AmountMagnitudeNorm)));
            }
        }

        public SizeMagnitude Map(AmountMagnitudeNorm magnitude)
        {
            switch (magnitude)
            {
                case AmountMagnitudeNorm.Undefined:
                    return SizeMagnitude.Undefined;
                case AmountMagnitudeNorm.Units:
                    return SizeMagnitude.Units;
                case AmountMagnitudeNorm.Thousands:
                    return SizeMagnitude.Thousands;
                case AmountMagnitudeNorm.Millions:
                    return SizeMagnitude.Millions;
                case AmountMagnitudeNorm.Billions:
                    return SizeMagnitude.Billions;
                default:
                    throw new RFQCommunicationException(MapperErrors.GetForOption(magnitude, typeof(SizeMagnitude)));
            }
        }
    }
}
