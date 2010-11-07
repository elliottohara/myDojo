using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Db4objects.Db4o;
using myDojo.Domain.Events;
using myDojo.Domain.ServiceLocation;
using myDojo.Domain.Users;
using MyDojo.Query.Infrastructure;
using MyDojo.Query.ViewModels;
using myDojo.Web.Init;
using StructureMap;

namespace myDojo.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }
        public override void Dispose()
        {
            base.Dispose();
            if(Db!=null)
                Db.Dispose();
            
        }
        public static IEmbeddedObjectContainer Db { get; private set; }
        private IEmbeddedObjectContainer OpenDatabase()
        {
            string relativePath = DbFileName;
            string filePath = HttpContext.Current.Server.MapPath(relativePath);
            return Db4oEmbedded.OpenFile(filePath);
        }

        public const string DbFileName = "myDojo.db4o";
        
        protected void Application_Start()
        {
            
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            Db = OpenDatabase();

            ObjectFactory.Configure(c =>
                                        {
                                            c.Scan(s =>
                                                       {
                                                           s.AssembliesFromApplicationBaseDirectory();
                                                           s.LookForRegistries();
                                                       });
                                            
                                        });
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory(ObjectFactory.Container));
            
        }
    }
}