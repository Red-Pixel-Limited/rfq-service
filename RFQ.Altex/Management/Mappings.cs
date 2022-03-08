namespace RFQ.Altex.Management
{
    using System;
    using System.Collections.Generic;

    sealed class Mappings
    {
        static readonly Lazy<Mappings> Constructor = 
            new Lazy<Mappings>(() => new Mappings());

        readonly IDictionary<Type, object> _options = 
            new Dictionary<Type, object>();

        Mappings() {}

        internal static Mappings Options
        {
            get { return Constructor.Value; }
        }
    }
}
