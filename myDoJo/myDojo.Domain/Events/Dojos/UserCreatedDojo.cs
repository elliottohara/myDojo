using System;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Events.Dojos
{
    public class UserCreatedDojo : IDomainEvent
    {
        public Guid UserId { get; set; }
        public Guid DojoId { get; set; }

        public UserCreatedDojo(Guid userId, Guid dojoId)
        {
            UserId = userId;
            DojoId = dojoId;
        }
    }
}