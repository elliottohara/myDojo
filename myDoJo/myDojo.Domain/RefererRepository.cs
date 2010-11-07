using Db4objects.Db4o;
using myDojo.Infrastructure;
using myDojo.Infrastructure.Db4o;
using User = myDojo.Domain.Users.User;

namespace myDojo.Domain
{
    public class RefererRepository : Db4OAggrigateRootRepository<Referer>, IAggrigateRootRepository<Referer>
    {
        public RefererRepository(IObjectContainer db) : base(db)
        {
        }

        #region IAggrigateRootRepository<Referer> Members

        public void Store(Referer entity)
        {
            // only care about the user
            foreach (User user in entity.UsersBrought)
            {
                Db.Store(user);
            }
        }

        #endregion

        public Referer WithUrl(string url)
        {
            return new Referer(url);
        }
    }
}