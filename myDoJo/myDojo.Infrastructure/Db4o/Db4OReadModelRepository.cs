using System;
using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;

using myDojo.Infrastructure;
using myDojo.Infrastructure.Db4o;

namespace MyDojo.Query.Infrastructure
{
    public class Db4oReadModelRepository<T> : Db4oRepo<T>, IReadModelRepository<T> where T : class,IObjectWithIdentity, new()
    {
        public Db4oReadModelRepository(IObjectContainer db):base(db){}
        public IEnumerable<T> Get(Predicate<T> query)
        {
            return base.Get(query);
        }

        public T GetSingle(Predicate<T> query)
        {
            return Db.Query(query).FirstOrDefault();
        }
       
        public IEnumerable<T> GetAll()
        {
            return Db.Query<T>();
        }

        public T GetOrCreate(Guid id)
        {
            var item = GetSingle(i => i.Id == id);
            if (item != null) return item;
            item = new T{Id = id};
            Store(item);
            return item;
        }

        public T Change(Guid id, Action<T> doThis)
        {
            var thing = GetOrCreate(id);
            doThis(thing);
            Store(thing);
            return thing;
        }
    }
}