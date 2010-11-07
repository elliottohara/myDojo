using System;

namespace myDojo.Infrastructure.CQRS.Commands
{
    public class Error : ICommandHandlerResult
    {
        public Exception Exception { get; set; }
       
        internal Error(Exception exception)
        {
            Exception = exception;
        }
        public override string ToString()
        {
            return Exception.Message;
        }
    }
}