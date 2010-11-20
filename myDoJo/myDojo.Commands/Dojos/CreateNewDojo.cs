using System;
using myDojo.Infrastructure.Core;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Commands.Dojos
{
    public class CreateNewDojo : ICommand
    {
        public Guid UserId { get; set; }
        public Guid SchoolId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public CreateNewDojo(Guid userId,Guid schoolId,
            string name,Address address)
        {
            UserId = userId;
            SchoolId = schoolId;
            Name = name;
            Address = address;
        }
    }
}