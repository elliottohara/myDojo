using System;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Events.Dojos
{
    public class DojoRemovedFromSite : IDomainEvent
    {
        public Guid DojoId { get; set; }

        public DojoRemovedFromSite(Guid dojoId)
        {
            DojoId = dojoId;
        }
    }
}