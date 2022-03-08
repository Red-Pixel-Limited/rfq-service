namespace RFQ.Core.Utils
{
    public static class CoreExtensions
    {
        public static bool IsEmptyOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source) || string.Empty == source;
        }

        public static string FormatWith(this string format, params object[] args)
        {
            return !string.IsNullOrEmpty(format) ? string.Format(format, args) : format;
        }
    }
}
