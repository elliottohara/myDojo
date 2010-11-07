using System;
using System.Web.Mvc;
using myDojo.Infrastructure.CQRS.Commands;
using StructureMap;

namespace myDojo.Infrastructure.Web
{
    public class CommandActionResult<TCommand> : ActionResult where TCommand:ICommand
    {
        private static IContainer Container
        {
            get
            {
                return ServiceLocation.CurrentContainer;
            }
        }
        public Func<ActionResult> Success { get; set; }
        public Func<ICommandHandlerResult, ActionResult> CommandFailedResult { get; set; }
        public Func<ActionResult> ValidationFailedResult { get; set; }
        public TCommand Command { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            
            if (!context.Controller.ViewData.ModelState.IsValid)
            {
                ValidationFailedResult().ExecuteResult(context);
                return;
            }
            ICommandHandlerResult result = null;
           
            var handler = Container.GetInstance<ICommandHandler<TCommand>>();
            result = handler.Handle(Command);
            if(result is Success)
            {
                Success().ExecuteResult(context);
                return;
            }
            CommandFailedResult(result).ExecuteResult(context);
        }
    }

    
}