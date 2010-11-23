using System;
using myDojo.Commands.Dojos;
using myDojo.Domain.Dojos;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.CommandHandlers.Dojos
{
    public class RegisterStudentHandler : SimpleCommandHandler<RegisterStudent>
    {
        private readonly IAggrigateRootRepository<Dojo> _dojoRepository;
        private readonly IAggrigateRootRepository<MartialArtist> _martialArtistRepository;

        public RegisterStudentHandler(IAggrigateRootRepository<Dojo> dojoRepository, IAggrigateRootRepository<MartialArtist> martialArtistRepository)
        {
            _dojoRepository = dojoRepository;
            _martialArtistRepository = martialArtistRepository;
        }

        protected override void DoHandle(RegisterStudent command)
        {
            var dojo = _dojoRepository.GetById(command.DojoId);
            var student = _martialArtistRepository.GetById(command.StudentId);
            dojo.Register(student);
            _dojoRepository.Store(dojo);
        }
    }
}