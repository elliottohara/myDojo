namespace myDojo.Infrastructure.Web
{
    public interface IMembershipProvider
    {
        bool Validate(string userName, string password);
        void CreateUser(string username, string password);
        void SignIn(string userName, bool persistLoginInfo);
        void SignOut();
    }
}