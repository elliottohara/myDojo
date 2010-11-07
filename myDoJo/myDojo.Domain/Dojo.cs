using System;
using System.Collections.Generic;
using System.Linq;
using myDojo.Domain.Events;
using myDojo.Domain.Events.Dojos;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain
{
    public class Dojo : ObjectWithIdentity
    {
        internal protected virtual User Creator { get; set; }

        public Dojo(Guid id,User creator):base(id)
        {
            Creator = creator;
           Registrations = new List<Registration>();
        }
        public virtual Dojo Register(MartialArtist martialArtist)
        {
            var registration = new Registration {StudentId = martialArtist.Id, Active = true, DojoId = Id};
            if (Registrations.Any(r => r.StudentId == martialArtist.Id))
                throw new StudentAlreadyRegisteredException(this, martialArtist);
            Registrations.Add(registration);
            DomainEvents.Raise(new StudentRegistered(registration));
            return this;

        }
        protected internal IList<Registration> Registrations { get; set; }
        
    }
}