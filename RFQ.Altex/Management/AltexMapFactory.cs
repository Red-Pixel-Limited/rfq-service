namespace RFQ.Altex.Management
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Core.Exceptions;
    using Properties;

    internal static class AltexMapFactory
    {
        internal static T Create<T>() where T : class
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return Create<T>(assembly);
        }

        private static T Create<T>(Assembly assembly) where T : class
        {
            var objectType = assembly.GetTypes().FirstOrDefault
                (t => typeof(T).IsAssignableFrom(t) && !t.IsInterface);
            if (null == objectType)
                throw new RFQRuntimeException(String.Format(Resources.NotSuchClassFoundMessage, typeof(T).Name));

            var instance = Activator.CreateInstance(objectType);
            return (T)instance;
        }
    }
}
