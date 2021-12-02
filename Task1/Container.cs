using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Task1
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _types;

        public Container()
        {
            _types = new Dictionary<Type, Type>();
        }

        public void AddAssembly(Assembly assembly)
        {
            var types = from t in assembly.GetTypes() where t.IsClass &&
                        t.GetTypeInfo().GetCustomAttribute<CompilerGeneratedAttribute>() == null                        
                        select t;

            foreach(var type in types)
            {
                var interfaceTypes = type.GetTypeInfo().GetInterfaces();
                if(interfaceTypes.Length == 0)
                {
                    if (TypeExist(type))
                        throw new Exception();

                    _types.Add(type, type);
                }
                else
                {
                    foreach(var interfaceType in interfaceTypes)
                    {
                        if (TypeExist(interfaceType))
                            throw new Exception();

                        _types.Add(interfaceType, type);
                    }
                }
            }
        }

        private bool TypeExist(Type type)
        {
            return _types.ContainsKey(type);
        }

        public void AddType(Type type)
        {
            if (TypeExist(type))
                throw new Exception();

            _types.Add(type, type);
        }

        public void AddType(Type type, Type baseType)
        {
            if (TypeExist(baseType))
                throw new Exception();

            _types.Add(baseType, type);
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        public object Get(Type type)
        {
            var exactType = _types[type];

            var constructor = exactType.GetConstructors()[0];

            var constructorParams = constructor.GetParameters();

            var parameters = constructorParams.Select(param => Get(param.ParameterType)).ToArray();

            return constructor.Invoke(parameters);
        }
    }
}