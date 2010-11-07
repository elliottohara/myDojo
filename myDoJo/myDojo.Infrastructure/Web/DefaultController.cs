using System;
using System.Web.Mvc;
using myDojo.Infrastructure.CQRS.Commands;

namespace myDojo.Infrastructure.Web
{
    public class DefaultController : Controller
    {
        
        public DefaultController()
        {
            DefaultFailureResult = () => View();
            DefaultCommandFailedResult = c => View();
        }
        protected Func<ActionResult> DefaultFailureResult { get; set; }
        protected Func<ICommandHandlerResult, ActionResult> DefaultCommandFailedResult { get; set; }
        public CommandActionResult<TCommand> Command<TCommand>(TCommand command,Func<ICommandHandlerResult,ActionResult> commandFailedResult, Func<ActionResult> validationFailedResult, Func<ActionResult> successResult) where TCommand:ICommand
        {
            var commandActionResult = new CommandActionResult<TCommand>
                                          {
                                              Command = command,
                                              CommandFailedResult = commandFailedResult,
                                              ValidationFailedResult = validationFailedResult,
                                              Success = successResult
                                          };
            return commandActionResult;
        }
        public CommandActionResult<TCommand> Command<TCommand>(TCommand command,Func<ActionResult> success) where TCommand:ICommand
        {
            return new CommandActionResult<TCommand>
                       {
                           Command = command,
                           CommandFailedResult = DefaultCommandFailedResult,
                           ValidationFailedResult = DefaultFailureResult,
                           Success = success,
                       };
        }
        
    }
}