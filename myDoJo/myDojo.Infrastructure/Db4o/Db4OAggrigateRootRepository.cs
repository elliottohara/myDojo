using System;
using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;

namespace myDojo.Infrastructure.Db4o
{

    public class Db4OAggrigateRootRepository<T> : Db4oRepo<T>, IAggrigateRootRepository<T> where T : ObjectWithIdentity
    {
       public Db4OAggrigateRootRepository(IObjectContainer db):base(db){}
    }
}