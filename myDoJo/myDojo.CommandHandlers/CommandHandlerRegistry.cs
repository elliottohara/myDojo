using myDojo.Infrastructure.CQRS.Commands;
using StructureMap.Configuration.DSL;

namespace myDojo.CommandHandlers
{
    public class CommandHandlerRegistry : Registry
    {
        public CommandHandlerRegistry()
        {
            Scan(s =>
                     {
                         s.AssemblyContainingType(GetType());
                         s.ConnectImplementationsToTypesClosing(typeof (ICommandHandler<>));
                     });
        }
    }
}