using System;
using System.Collections.Generic;

namespace SH_SWAT.Usimba.EventOrientedModule
{
    public interface IServiceLocator
    {
        T Resolve<T>();
        object Resolve(Type type);

        T Resolve<T>(string key);
        object Resolve(Type type, string key);

        IEnumerable<T> ResolveAll<T>();
        IEnumerable<object> ResolveAll(Type type);
    }
}