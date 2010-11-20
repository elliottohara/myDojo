using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS.Validation;
using MyDojo.Query.ViewModels;

namespace myDojo.Commands.Users.Validation
{
    public class EmailAddressMustBeUnique : IValidate<RegisterUser>
    {
        private readonly IReadModelRepository<MartialArtistDetails> _readModelRepository;
        private RegisterUser _command;

        public EmailAddressMustBeUnique(IReadModelRepository<MartialArtistDetails> readModelRepository)
        {
            _readModelRepository = readModelRepository;
        }

        public bool IsValid(RegisterUser command)
        {
            _command = command;
            return _readModelRepository.GetSingle(m => m.EmailAddress == command.EmailAddress) == null;
        }
        public override string ToString()
        {
            return string.Format("the email address {0} is already registered. Did you forget your password?", _command.EmailAddress);
        }
    }
}