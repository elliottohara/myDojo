using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Commands.Users
{
    public class RegisterUser : ICommand
    {
        public string EmailAddress { get; set; }
        public string ReferrerUrl { get; set; }

        public RegisterUser(string emailAddress,string referrerUrl)
        {
            EmailAddress = emailAddress;
            ReferrerUrl = referrerUrl;
        }
    }
}