using System;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Events.MartialArtists
{
    public class MartialArtistChangedName : IDomainEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public MartialArtistChangedName(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}