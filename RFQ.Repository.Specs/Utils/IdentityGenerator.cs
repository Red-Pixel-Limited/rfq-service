namespace RFQ.Repository.Specs.Utils
{
    using System;

    internal static class IdentityGenerator
    {
        internal static string Generate()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
