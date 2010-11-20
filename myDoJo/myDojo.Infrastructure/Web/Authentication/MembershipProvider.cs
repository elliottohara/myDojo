using System.Linq;
using System.Web.Security;
using Db4objects.Db4o;

namespace myDojo.Infrastructure.Web
{
    public class MembershipProvider : IMembershipProvider
    {
        private readonly IObjectContainer _container;

        public MembershipProvider(IObjectContainer container)
        {
            _container = container;
        }

        public bool Validate(string userName, string password)
        {
            return _container.Query<LoginCredentials>(lc => lc.UserName == userName && lc.Password == password).Any();
        }

        public void CreateUser(string username, string password)
        {
            if (_container.Query<LoginCredentials>(c => c.UserName == username).Any())
                throw new DuplicateUserException(username);
            _container.Store(new LoginCredentials{Password = password,UserName = username});
        }

        public void SignIn(string userName, bool persistLoginInfo)
        {
            FormsAuthentication.SetAuthCookie(userName,persistLoginInfo);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}