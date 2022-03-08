namespace RFQ.Core.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    public abstract class ObjectActivatorRegistry
    {
        readonly IDictionary<Type, Delegate> _activators = 
            new Dictionary<Type, Delegate>();

        protected IDictionary<Type, Delegate> Activators
        {
            get { return _activators; }
        } 

        public T Construct<T>(params object[] args)
        {
            var objectType = typeof(T);

            if (_activators.ContainsKey(objectType))
                return ((ObjectActivator<T>)_activators[objectType])(args);

            var activator = GetActivator<T>(objectType.GetConstructors()[0]);
            _activators.Add(objectType, activator);

            var someObject = activator(args);
            return someObject;
        }

        public void Reset()
        {
            _activators.Clear();
        }

        private static ObjectActivator<T> GetActivator<T>(ConstructorInfo ctor)
        {
            var paramsInfo = ctor.GetParameters();
            var param = Expression.Parameter(typeof(object[]), "args");
            var argsExp = new Expression[paramsInfo.Length];

            for (var i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp =
                    Expression.ArrayIndex(param, index);

                Expression paramCastExp =
                    Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            var newExp = Expression.New(ctor, argsExp);

            var lambdaExp =
                Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            var compiled = (ObjectActivator<T>)lambdaExp.Compile();
            return compiled;
        }
    }
}
