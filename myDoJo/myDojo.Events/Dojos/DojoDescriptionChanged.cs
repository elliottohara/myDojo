using System;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Events.Dojos
{
    public class DojoDescriptionChanged : IDomainEvent
    {
        public Guid DojoId { get; set; }
        public string Description { get; set; }

        public DojoDescriptionChanged(Guid dojoId,string description)
        {
            DojoId = dojoId;
            Description = description;
        }
    }
}