using System;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Events.MartialArtists
{
    public class UserRegisterd : IDomainEvent
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }

        public UserRegisterd(Guid id, string emailAddress)
        {
            Id = id;
            EmailAddress = emailAddress;

        }
    }
}