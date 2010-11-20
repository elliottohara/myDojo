using System;
using myDojo.Infrastructure.Core;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Events.Dojos
{
    public class DojoChangedAddress : IDomainEvent
    {
        public Guid DojoId { get; set; }
        public Address Address { get; set; }

        public DojoChangedAddress(Guid dojoId, Address address)
        {
            DojoId = dojoId;
            Address = address;
        }
    }
}