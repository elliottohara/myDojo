using System;

namespace myDojo.Infrastructure
{
    public interface IAggrigateRootRepository<T> where T : ObjectWithIdentity
    {
        void Store(T entity);
        T GetById(Guid id);
    }
}