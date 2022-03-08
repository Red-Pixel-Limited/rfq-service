namespace RFQ.Altex.Utils
{
    using System;
    using Core.Utils;
    using Properties;

    internal static class MapperErrors
    {
        internal static string GetForOption<TEnum>(TEnum missingField, Type targetType) where TEnum : struct
        {
            return Resources.UnsupportedFieldErrorMessage.FormatWith(missingField, targetType.Name);
        }
    }
}
