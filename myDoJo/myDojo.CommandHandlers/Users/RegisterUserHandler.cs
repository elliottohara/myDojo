using System;
using myDojo.Commands.Users;
using myDojo.Domain;
using myDojo.Infrastructure.CQRS.Commands;
using myDojo.Infrastructure.Web;

namespace myDojo.CommandHandlers.Users
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly RefererRepository _refererRepository;
        private readonly IMembershipProvider _membershipProvider;

        public RegisterUserHandler(RefererRepository refererRepository,IMembershipProvider membershipProvider)
        {
            _refererRepository = refererRepository;
            _membershipProvider = membershipProvider;
        }

        public ICommandHandlerResult Handle(RegisterUser command)
        {
            var referrer = _refererRepository.WithUrl(command.ReferrerUrl);
            referrer.BroughtUser(command.EmailAddress);
            _refererRepository.Store(referrer);
            _membershipProvider.CreateUser(command.EmailAddress,command.Password);
            return Results.Success();
        }
    }
}