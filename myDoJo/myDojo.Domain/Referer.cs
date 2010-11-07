using System.Collections.Generic;
using myDojo.Domain.Events;
using myDojo.Domain.Events.MartialArtists;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS;
using User = myDojo.Domain.Users.User;

namespace myDojo.Domain
{
    public class Referer : ObjectWithIdentity
    {
        public virtual IList<User> UsersBrought { get; set; }
        internal Referer(string url)
        {
            UsersBrought = new List<User>();
            Url = url;
        }

        public virtual string Url { get; set; }
        public void BroughtUser(string emailAddress)
        {
            var user = new MartialArtist(emailAddress);
            UsersBrought.Add(user);
            DomainEvents.Raise(new UserRegisterd(user.Id,emailAddress));
        }

    }
}