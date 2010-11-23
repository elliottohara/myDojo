using System;
using myDojo.Domain.Events.Dojos;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS;
using MyDojo.Query.ViewModels.Dojos;

namespace MyDojo.Query.ViewModels
{
    public class StudentRegistrationViewWriter : Handles<StudentRegistered>
    {
        private readonly IReadModelRepository<StudentRegistrationView> _studentRegistrationRepo;
        private readonly IReadModelRepository<DojoDetails> _dojoDetailsRepository;
        private readonly IReadModelRepository<MartialArtistDetails> _martialArtistRepository;

        public StudentRegistrationViewWriter(IReadModelRepository<StudentRegistrationView> studentRegistrationRepo,IReadModelRepository<DojoDetails> dojoDetailsRepository,IReadModelRepository<MartialArtistDetails> martialArtistRepository )
        {
            _studentRegistrationRepo = studentRegistrationRepo;
            _dojoDetailsRepository = dojoDetailsRepository;
            _martialArtistRepository = martialArtistRepository;
        }

        public void Handle(StudentRegistered @event)
        {
            var registration =_studentRegistrationRepo.GetOrCreate(Guid.NewGuid());
            var dojo = _dojoDetailsRepository.GetById(@event.DojoId);
            var student = _martialArtistRepository.GetById(@event.StudentId);
            registration.StudentId = @event.StudentId;
            registration.DojoId = @event.DojoId;
            registration.DojoName = dojo.Name;
            registration.StudentName = student.Name;
            _studentRegistrationRepo.Store(registration);
        }
    }
}