using System;
using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;

namespace myDojo.Infrastructure.Db4o
{
    public abstract class Db4oRepo<T>  where T:IObjectWithIdentity
    {
        protected IObjectContainer Db { get; private set; }

        public Db4oRepo(IObjectContainer db)
        {
            Db = db;
        }
        public virtual void Store(T entity)
        {
            entity.Version++;
            Db.Ext().Store(entity,3);
        }
        public virtual T GetById(Guid id)
        {
            return Db.Query<T>(t => t.Id == id).First();
        }
        protected virtual IEnumerable<T> Get(Predicate<T> query)
        {
            return Db.Query(query);
        }
        
    }
}