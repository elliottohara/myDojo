using System;
using System.Web.Mvc;
using myDojo.Infrastructure.CQRS.Commands;
using myDojo.Infrastructure.CQRS.Query;

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
        public QueryActionResult<TQuery> Query<TQuery>(Action<TQuery> buildUpQuery=null,string viewName=null) where TQuery: IQuery
        {
            var result = new QueryActionResult<TQuery>
                       {
                          BuildUpQuery = buildUpQuery,
                          
                       };
            if (!String.IsNullOrEmpty(viewName))
                result.ViewName = viewName;
            return result;
        }
        public ActionResult MappedQuery<TQuery,TDestination>(Action<TQuery> buildUpQuery=null) where TQuery:IQuery
        {
            return new MappedQueryViewResult<TQuery, TDestination>(buildUpQuery);
        }
        
    }
}