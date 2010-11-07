using System;
using System.Collections.Generic;
using myDojo.Domain.Events;
using myDojo.Domain.Events.Dojos;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Users
{
    public class User : ObjectWithIdentity
    {
        protected internal User(string EmailAddress)
        {
            this.EmailAddress = EmailAddress;
            DojosCreated = new List<Dojo>();
        }

        protected internal User()
        {
            
        }

        protected internal virtual IList<Dojo> DojosCreated { get; set; }
        protected internal virtual String EmailAddress { get; set; }
        public User CreateDojoWithId(Guid dojoId)
        {
            var newDojo = new Dojo(dojoId,this);
            DojosCreated.Add(newDojo);
            DomainEvents.Raise(new UserCreatedDojo(Id,dojoId));
            return this;
        }
    }
}