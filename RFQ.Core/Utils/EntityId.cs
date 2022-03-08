namespace RFQ.Core.Utils
{
    using Magnum;

    internal static class EntityId
    {
        internal static string New()
        {
            return CombGuid.Generate().ToString("N");
        }
    }
}
