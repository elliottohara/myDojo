using System;

namespace myDojo.Infrastructure.CQRS.Commands
{
    public static class Results
    {
        public static Success Success()
        {
            return new Success();
        }
        public static Failure Failure(string reason)
        {
            return new Failure(reason);
        }
        public static Error Error(Exception exception)
        {
            return new Error(exception);
        }
    }
}