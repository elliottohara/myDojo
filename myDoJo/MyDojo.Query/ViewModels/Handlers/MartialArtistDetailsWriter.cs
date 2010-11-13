using System;
using myDojo.Domain.Events.MartialArtists;
using myDojo.Events.MartialArtists;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS;

namespace MyDojo.Query.ViewModels
{
    public class MartialArtistDetailsWriter : 
        Handles<UserRegisterd>,
        Handles<MartialArtistChangedName>,
        Handles<MartialArtistChangedBio>,
        Handles<StudentPromoted>
    {
        private readonly IReadModelRepository<MartialArtistDetails> _detailsReadModelRepository;

        public MartialArtistDetailsWriter(IReadModelRepository<MartialArtistDetails> detailsReadModelRepository)
        {
            _detailsReadModelRepository = detailsReadModelRepository;
        }

        public void Handle(UserRegisterd @event)
        {
            var details = _detailsReadModelRepository.GetSingle(d => d.EmailAddress == @event.EmailAddress) ??
                          new MartialArtistDetails(@event.Id);
            details.EmailAddress = @event.EmailAddress;
            details.Id = @event.Id;
            _detailsReadModelRepository.Store(details);
        }

        public void Handle(MartialArtistChangedName @event)
        {
            var details = TheDetailsForMartialArtistWithIdOf(@event.Id);
            details.Name = @event.Name;
            _detailsReadModelRepository.Store(details);
        }

        private MartialArtistDetails TheDetailsForMartialArtistWithIdOf(Guid id)
        {
            return _detailsReadModelRepository.GetById(id) ?? new MartialArtistDetails(id);
        }

        public void Handle(MartialArtistChangedBio @event)
        {
            var details = TheDetailsForMartialArtistWithIdOf(@event.Id);
            details.Biography = @event.Bio;
            _detailsReadModelRepository.Store(details);
        }

        public void Handle(StudentPromoted @event)
        {
            var details = TheDetailsForMartialArtistWithIdOf(@event.StudentId);
            details.Belt = @event.Belt;
            details.Stripes = @event.Stripes;
            
        }
    }
}