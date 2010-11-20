using System;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Events.MartialArtists
{
    public class MartialArtistChangedBio : IDomainEvent
    {
        public Guid Id { get; set; }
        public string Bio { get; set; }

        public MartialArtistChangedBio(Guid id, string bio)
        {
            Id = id;
            Bio = bio;
        }
    }
}