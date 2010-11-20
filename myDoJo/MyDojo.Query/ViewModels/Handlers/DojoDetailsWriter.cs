using System;
using myDojo.Domain.Dojos;
using myDojo.Domain.Events.Dojos;
using myDojo.Events.Dojos;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS;
using MyDojo.Query.ViewModels.Dojos;

namespace MyDojo.Query.ViewModels
{
    public class DojoDetailsWriter : 
        Handles<UserCreatedDojo>,
        Handles<DojoChangedName>,
        Handles<DojoChangedAddress>
    {
        private readonly IReadModelRepository<DojoDetails> _dojoDetailsRepository;

        public DojoDetailsWriter(IReadModelRepository<DojoDetails> dojoDetailsRepository)
        {
            _dojoDetailsRepository = dojoDetailsRepository;
        }

        public void Handle(UserCreatedDojo @event)
        {
            _dojoDetailsRepository.GetOrCreate(@event.DojoId);
        }

        public void Handle(DojoChangedName @event)
        {
            _dojoDetailsRepository.Change(@event.DojoId, dojo => dojo.Name = @event.SchoolName);
        }

        public void Handle(DojoChangedAddress @event)
        {
            _dojoDetailsRepository.Change(@event.DojoId, dojo => dojo.Address = @event.Address);
        }
    }
}