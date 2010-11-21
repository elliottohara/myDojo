using System;
using System.Web.Mvc;
using System.Web.Routing;
using myDojo.Infrastructure;

namespace myDojo.Web.Init
{
    public class RouteRegister : IStartupTask 
    {
        private readonly RouteCollection _routes;

        public RouteRegister(RouteCollection routes)
        {
            _routes = routes;
        }

        public void Execute()
        {
            _routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            _routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "User", action = "Register", id = UrlParameter.Optional } // Parameter defaults

            );
            AreaRegistration.RegisterAllAreas();
            
        }
    }
}