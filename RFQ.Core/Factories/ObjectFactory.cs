namespace RFQ.Core.Factories
{
    using System;
    using System.Linq;
    using Exceptions;
    using Magnum.Extensions;
    using Properties;

    public static class ObjectFactory
    {
        public static T Create<T>(params object[] args)
            where T : class
        {
            var baseObjectType = typeof(T);
            var assembly = baseObjectType.Assembly;
            var derivedObjectType =
                assembly.GetTypes().FirstOrDefault(t => baseObjectType.IsAssignableFrom(t) && !t.IsInterface);

            if (null == derivedObjectType)
                throw new RFQRuntimeException(Resources.NotSuchClassFoundMessage.FormatWith(baseObjectType.Name));

            var instance = Activator.CreateInstance(derivedObjectType, args);
            return (T)instance;
        }
    }
}
