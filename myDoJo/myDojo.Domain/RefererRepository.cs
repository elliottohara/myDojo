using System;
using Db4objects.Db4o;
using myDojo.Infrastructure;

namespace myDojo.Domain
{
    public class RefererRepository : IAggrigateRootRepository<Referer>
    {
        private readonly IObjectContainer _db;

        public RefererRepository(IObjectContainer db)
        {
            _db = db;
        }

        public void Store(Referer entity)
        {
            // only care about the user
            foreach (var user in entity.UsersBrought)
            {
                _db.Store(user);
            }
        }
        public Referer WithUrl(string url)
        {
            return new Referer(url);
        }
        public Referer GetById(Guid id)
        {
            return new Referer(null){Id = id};
        }
    }
}