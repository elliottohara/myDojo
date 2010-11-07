using System;
using myDojo.Commands.Users;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.CommandHandlers.Users
{
    public class EditMartialArtistInfoHandler : SimpleCommandHandler<EditMartialArtistInfo>
    {
        private readonly IAggrigateRootRepository<MartialArtist> _martialArtistRepository;

        public EditMartialArtistInfoHandler(IAggrigateRootRepository<MartialArtist> martialArtistRepository )
        {
            _martialArtistRepository = martialArtistRepository;
        }

        protected override void DoHandle(EditMartialArtistInfo command)
        {
            var ma = _martialArtistRepository.GetById(command.UserId);
            if (!String.IsNullOrEmpty(command.Name))
                ma.ChangeNameTo(command.Name);
            if (!String.IsNullOrEmpty(command.Biography))
                ma.ChangeBioTo(command.Biography);
            _martialArtistRepository.Store(ma);
        }
    }
}