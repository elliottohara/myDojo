using System.Collections.Generic;
using myDojo.Domain.Events.MartialArtists;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain
{
    public class Referer : ObjectWithIdentity
    {
        internal Referer(string url)
        {
            UsersBrought = new List<User>();
            Url = url;
        }

        public virtual IList<User> UsersBrought { get; set; }

        public virtual string Url { get; set; }

        public void BroughtUser(string emailAddress)
        {
            var user = new MartialArtist(emailAddress);
            UsersBrought.Add(user);
            DomainEvents.Raise(new UserRegisterd(user.Id, emailAddress));
        }
    }
}