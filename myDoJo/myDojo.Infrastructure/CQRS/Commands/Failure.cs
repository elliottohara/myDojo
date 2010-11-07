namespace myDojo.Infrastructure.CQRS.Commands
{
    public class Failure : ICommandHandlerResult
    {
        public string Reason { get; set; }

        internal Failure(string reason)
        {
            Reason = reason;
        }
        public override string ToString()
        {
            return Reason;
        }
    }
}