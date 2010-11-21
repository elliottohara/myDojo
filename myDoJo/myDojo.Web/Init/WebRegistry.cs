using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using myDojo.Infrastructure;
using StructureMap.Configuration.DSL;
using Configuration = AutoMapper.Configuration;

namespace myDojo.Web.Init
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            ForSingletonOf<IMappingEngine>().Use(() => Mapper.Engine);
            For<RouteCollection>().Use(() => RouteTable.Routes);
            For<GlobalFilterCollection>().Use(() => GlobalFilters.Filters);
            For<ConnectionStringSettingsCollection>().Use(() => ConfigurationManager.ConnectionStrings);
            Scan(s =>
                     {
                         s.AssembliesFromApplicationBaseDirectory();
                         s.AddAllTypesOf<IStartupTask>();
                     });
        }        
    }
}