using System;
using System.Collections.Generic;
using System.Reflection;

namespace Task1
{
    public class Container
    {
        private readonly Dictionary<string, object> _objectPool;

        public Container()
        {
            _objectPool = new Dictionary<string, object>();
        }

        public void AddAssembly(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public void AddType(Type type)
        {
            throw new NotImplementedException();
        }

        public void AddType(Type type, Type baseType)
        {
            throw new NotImplementedException();
        }

        public T Get<T>()
        {
            throw new NotImplementedException();
        }
    }
}