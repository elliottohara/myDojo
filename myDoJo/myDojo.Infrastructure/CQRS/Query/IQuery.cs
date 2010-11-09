namespace myDojo.Infrastructure.CQRS.Query
{
    public interface IQuery
    {
        object Execute();
    }
}