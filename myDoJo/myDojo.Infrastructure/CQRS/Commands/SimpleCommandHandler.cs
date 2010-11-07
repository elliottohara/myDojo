using System;

namespace myDojo.Infrastructure.CQRS.Commands
{
    public abstract class SimpleCommandHandler<TCommand> : ICommandHandler<TCommand> where  TCommand:ICommand
    {
        protected abstract void DoHandle(TCommand command);
        public ICommandHandlerResult Handle(TCommand command)
        {
            DoHandle(command);
            return Results.Success();
        }
    }
}