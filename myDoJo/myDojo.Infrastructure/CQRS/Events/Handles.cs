namespace myDojo.Infrastructure.CQRS
{
    public interface Handles<T> where T:IDomainEvent
    {
        void Handle(T @event);
    }
}