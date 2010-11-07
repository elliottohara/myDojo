using System;
using myDojo.Commands.Users;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.CommandHandlers.Users
{
    public class ChangeNameHandler : SimpleCommandHandler<ChangeName>
    {
        private readonly IAggrigateRootRepository<MartialArtist> _martialArtistRepository;

        public ChangeNameHandler(IAggrigateRootRepository<MartialArtist> martialArtistRepository)
        {
            _martialArtistRepository = martialArtistRepository;
        }

        protected override void DoHandle(ChangeName command)
        {
            var martialArtist = _martialArtistRepository.GetById(command.UserId);
            martialArtist.ChangeNameTo(command.Name);
            _martialArtistRepository.Store(martialArtist);
        }

        
    }
}