using System.Collections.Generic;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Infrastructure.CQRS.Validation
{
    public interface ICommandValidator<TCommand> where TCommand : ICommand
    {
        bool IsValid(TCommand command);
        IEnumerable<IValidate<TCommand>> FailedRules { get; }
    }
}