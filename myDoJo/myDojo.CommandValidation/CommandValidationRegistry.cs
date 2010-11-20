

using myDojo.Infrastructure.CQRS.Validation;
using StructureMap.Configuration.DSL;

namespace myDojo.Commands.Users.Validation
{
    public class CommandValidationRegistry : Registry 
    {
        public CommandValidationRegistry()
        {
            Scan(s =>
                     {
                         s.AssemblyContainingType(GetType());
                         s.ConnectImplementationsToTypesClosing(typeof (IValidate<>));

                     });
            For(typeof (ICommandValidator<>)).Use(typeof(CommandValidator<>));
        }
    }
}