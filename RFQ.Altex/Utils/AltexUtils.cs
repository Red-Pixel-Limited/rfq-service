namespace RFQ.Altex.Utils
{
    using System;
    using System.Text;

    internal static class AltexUtils
    {
        #region Characters BASE64 supports, but Altex doesn't
        private const char Plus = '+';
        private const char Slash = '/';
        private const char AnEquals = '=';
        #endregion

        #region Characters Altex supports, but BASE64 doesn't
        private const char Minus = '-';
        private const char Underscore = '_';
        #endregion

        #region Escaped strings to escape other characters Base supports but Altex doesn't
        private const string DoubleUnderscore = "__";
        private const string UnderscoreE = "_e";
        #endregion

        internal static string EncodeToAltexEncoding(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var base64 = Convert.ToBase64String(bytes);
            var result = new StringBuilder();

            foreach (var symbol in base64)
            {
                switch (symbol)
                {
                    case Plus:
                        result.Append(Minus);
                        break;
                    case Slash:
                        result.Append(DoubleUnderscore);
                        break;
                    case AnEquals:
                        result.Append(UnderscoreE);
                        break;
                    default:
                        result.Append(symbol);
                        break;
                }
            }
            return result.ToString();
        }

        public static string DecodeFromAltexEncoding(this string value)
        {
            var result = new StringBuilder();
            var isEscaped = false;
            foreach (var symbol in value)
            {
                if (symbol == Minus)
                {
                    result.Append(Plus);
                }
                else if (!isEscaped && symbol == Underscore) // First underscore
                {
                    isEscaped = true;
                    continue;
                }
                else if (isEscaped && symbol == Underscore) // __ to /
                {
                    result.Append(Slash);
                }
                else if (isEscaped && symbol == 'e') // _e to =
                {
                    result.Append(AnEquals);
                }
                else
                {
                    result.Append(symbol);
                }
                isEscaped = false;
            }
            byte[] bytes = { };
            try
            {
                bytes = Convert.FromBase64String(result.ToString());
            }
            catch (FormatException)
            {
            }
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
