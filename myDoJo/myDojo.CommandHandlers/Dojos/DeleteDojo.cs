using System;
using myDojo.Commands.Dojos;
using myDojo.Domain.Dojos;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.CommandHandlers.Dojos
{
    public class DeleteDojoHandler : SimpleCommandHandler<DeleteDojo>
    {
        private readonly IAggrigateRootRepository<Dojo> _dojoRepository;

        public DeleteDojoHandler(IAggrigateRootRepository<Dojo> dojoRepository)
        {
            _dojoRepository = dojoRepository;
        }

        protected override void DoHandle(DeleteDojo command)
        {
            var dojo = _dojoRepository.GetById(command.DojoId);
            dojo.RemoveFromSite();
            _dojoRepository.Store(dojo);
        }
    }
}