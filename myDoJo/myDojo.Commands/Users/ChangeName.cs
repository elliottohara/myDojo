using System;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Commands.Users
{
    public class ChangeName : ICommand
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }

        public ChangeName(Guid userId,string name )
        {
            UserId = userId;
            Name = name;
        }
    }
}