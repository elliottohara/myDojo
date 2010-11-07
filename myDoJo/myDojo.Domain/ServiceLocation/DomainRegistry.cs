using myDojo.Infrastructure;
using myDojo.Infrastructure.Db4o;
using StructureMap.Configuration.DSL;

namespace myDojo.Domain.ServiceLocation
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            Scan(s =>
                     {
                         s.AssemblyContainingType(GetType());
                         s.WithDefaultConventions();

                     });
            For(typeof (IAggrigateRootRepository<>)).Use(typeof(Db4OAggrigateRootRepository<>));
        }

    }
}