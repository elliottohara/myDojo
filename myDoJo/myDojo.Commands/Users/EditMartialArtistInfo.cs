using System;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Commands.Users
{
    public class EditMartialArtistInfo : ICommand
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }

        public EditMartialArtistInfo(Guid userId, string name, string biography)
        {
            UserId = userId;
            Name = name;
            Biography = biography;
        }
    }
}