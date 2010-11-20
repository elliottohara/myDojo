using StructureMap.Configuration.DSL;

namespace myDojo.Infrastructure
{
    public class InfrastructureRegistry : Registry
    {
        public InfrastructureRegistry()
        {
            Scan(s =>
                     {
                         s.Assembly(GetType().Assembly);
                         s.WithDefaultConventions();
                     });
        }
    }
}