using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Core.Interfaces
{
    public interface IRepository<T> 
    {
        List<T> List(Func<T, bool> Criteria);

        T Find(Guid Id);

        T Add(T Obj);

        void Remove(T Obj);

        T Update(T Obj);

        void Save();
    }
}
