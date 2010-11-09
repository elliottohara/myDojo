using AutoMapper;
using myDojo.Infrastructure;
using StructureMap.Configuration.DSL;

namespace myDojo.Web.Init
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            ForSingletonOf<IMappingEngine>().Use(() => Mapper.Engine);
            Scan(s =>
                     {
                         s.AssembliesFromApplicationBaseDirectory();
                         s.AddAllTypesOf<IStartupTask>();
                     });
        }        
    }
}