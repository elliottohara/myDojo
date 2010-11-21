using System;
using System.Collections.Generic;
using System.Linq;
using myDojo.Domain.Events.Dojos;
using myDojo.Domain.Users;
using myDojo.Events.Dojos;
using myDojo.Infrastructure;
using myDojo.Infrastructure.Core;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Dojos
{
    public class Dojo : ObjectWithIdentity
    {
        internal protected virtual User Creator { get; set; }
        protected internal virtual bool IsActive { get; set; }
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
            DomainEvents.Raise(new StudentRegistered(Id,martialArtist.Id,DateTime.Now));
            return this;

        }
        public virtual Dojo ChangeNameTo(string schoolName)
        {
            DomainEvents.Raise(new DojoChangedName(Id,schoolName));
            return this;
        }
        public virtual Dojo ChangeAddressTo(Address address)
        {
            DomainEvents.Raise(new DojoChangedAddress(Id,address));
            return this;
        }
        public virtual Dojo ChangeDescription(string description)
        {
            DomainEvents.Raise(new DojoDescriptionChanged(Id,description));
            return this;
        }
        protected internal IList<Registration> Registrations { get; set; }

        public void RemoveFromSite()
        {
            IsActive = false;
            DomainEvents.Raise(new DojoRemovedFromSite(Id));
        }
    }
}