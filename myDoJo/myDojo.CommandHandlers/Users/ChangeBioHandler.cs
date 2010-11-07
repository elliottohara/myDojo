using System;
using myDojo.Commands.Users;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.CommandHandlers.Users
{
    public class ChangeBioHandler : SimpleCommandHandler<ChangeBio>
    {
        private readonly IAggrigateRootRepository<MartialArtist> _martialArtistRepository;

        public ChangeBioHandler(IAggrigateRootRepository<MartialArtist> martialArtistRepository)
        {
            _martialArtistRepository = martialArtistRepository;
        }

        protected override void DoHandle(ChangeBio command)
        {
            var ma = _martialArtistRepository.GetById(command.UserId);
            ma.ChangeBioTo(command.Biography);
            _martialArtistRepository.Store(ma);
        }
    }
}