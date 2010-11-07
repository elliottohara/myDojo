using System;
using myDojo.Commands.Users;
using myDojo.Domain;
using myDojo.Infrastructure.CQRS.Commands;
namespace myDojo.CommandHandlers.Users
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly RefererRepository _refererRepository;

        public RegisterUserHandler(RefererRepository refererRepository)
        {
            _refererRepository = refererRepository;
        }

        public ICommandHandlerResult Handle(RegisterUser command)
        {
            var referrer = _refererRepository.WithUrl(command.ReferrerUrl);
            referrer.BroughtUser(command.EmailAddress);
            _refererRepository.Store(referrer);
            return Results.Success();
        }
    }
}