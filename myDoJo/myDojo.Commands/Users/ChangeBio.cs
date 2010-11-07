using System;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Commands.Users
{
    public class ChangeBio : ICommand
    {
        public Guid UserId { get; set; }
        public string Biography { get; set; }

        public ChangeBio(Guid userId,string biography)
        {
            UserId = userId;
            Biography = biography;
        }
    }
}