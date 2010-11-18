using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Commands.Users
{
    public class RegisterUser : ICommand
    {
        public string EmailAddress { get; set; }
        public string ReferrerUrl { get; set; }
        public string Password { get; set; }

        public RegisterUser(string emailAddress,string referrerUrl,string password)
        {
            EmailAddress = emailAddress;
            ReferrerUrl = referrerUrl;
            Password = password;
        }
    }
}