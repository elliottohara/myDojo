using System;
using myDojo.Commands.Dojos;
using myDojo.Domain.Dojos;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.CommandHandlers.Dojos
{
    public class CreateNewDojoHandler : SimpleCommandHandler<CreateNewDojo>
    {
        private readonly IAggrigateRootRepository<User> _userRepo;
        private readonly IAggrigateRootRepository<Dojo> _dojoRepo;

        public CreateNewDojoHandler(IAggrigateRootRepository<User> userRepo,IAggrigateRootRepository<Dojo> dojoRepo)
        {
            _userRepo = userRepo;
            _dojoRepo = dojoRepo;
        }

        protected override void DoHandle(CreateNewDojo command)
        {
            var user = _userRepo.GetById(command.UserId);
            user.CreateDojoWithId(command.SchoolId);
            _userRepo.Store(user);

            var dojo = _dojoRepo.GetById(command.SchoolId);

            dojo.ChangeNameTo(command.Name)
                .ChangeAddressTo(command.Address)
                .ChangeDescription(command.Description);

            _dojoRepo.Store(dojo);
        }

       
    }
}