using System;
using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;

using myDojo.Infrastructure;
using myDojo.Infrastructure.Db4o;

namespace MyDojo.Query.Infrastructure
{
    public class Db4oReadModelRepository<T> :Db4oRepo<T>, IReadModelRepository<T> where T : IObjectWithIdentity,new()
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
    }
}