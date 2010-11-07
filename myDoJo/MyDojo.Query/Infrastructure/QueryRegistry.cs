
using myDojo.Domain.Events;
using myDojo.Domain.Users;
using myDojo.Infrastructure;
using myDojo.Infrastructure.CQRS;
using StructureMap.Configuration.DSL;

namespace MyDojo.Query.Infrastructure
{
    public class QueryRegistry : Registry
    {
        public QueryRegistry()
        {
            For(typeof (IReadModelRepository<>)).Use(typeof (Db4oReadModelRepository<>));
            Scan(scanner =>
                     {
                         scanner.AssemblyContainingType(GetType());
                         scanner.AssemblyContainingType<MartialArtist>();
                         scanner.AddAllTypesOf(typeof (Handles<>));
                         scanner.WithDefaultConventions();
                     });
        }
    }
}