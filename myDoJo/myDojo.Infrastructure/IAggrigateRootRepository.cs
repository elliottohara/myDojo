using System;

namespace myDojo.Infrastructure
{
    public interface IAggrigateRootRepository<T> where T : IObjectWithIdentity
    {
        void Store(T entity);
        T GetById(Guid id);
    }
}