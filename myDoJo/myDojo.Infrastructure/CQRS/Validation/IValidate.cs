using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Infrastructure.CQRS.Validation
{
    public interface IValidate<TCommand> where TCommand : ICommand
    {
        bool IsValid(TCommand command);
    }
}