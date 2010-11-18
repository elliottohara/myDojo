using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Db4objects.Db4o;
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
                new { controller = "User", action = "Register", id = UrlParameter.Optional } // Parameter defaults

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

        public const string DbFileName = "myDojo3.db4o";
        
        protected void Application_Start()
        {

            StructureMapInitilizer.Initilize();

            new Bootstrapper(ObjectFactory.Container).BootstrapApplication();
            //TODO: make this stuff bootstrap classes
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            Db = OpenDatabase();

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory(ObjectFactory.Container));
            
        }
    }
}