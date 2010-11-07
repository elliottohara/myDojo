namespace myDojo.Infrastructure.CQRS.Commands
{
    public interface ICommandHandler<in T> where T:ICommand
    {
        ICommandHandlerResult Handle(T command);
    }
}