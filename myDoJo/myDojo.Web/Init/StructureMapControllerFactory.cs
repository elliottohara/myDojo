using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Db4objects.Db4o;
using myDojo.Infrastructure;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace myDojo.Web.Init
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        private const string ContainerKey = "Container";
        private readonly IContainer _container;

        public StructureMapControllerFactory(IContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null) return null;
            var nestedContainer = _container.GetNestedContainer();
            nestedContainer.Configure(c => c.AddRegistry(new PerRequestRegistry(requestContext)));
            requestContext.HttpContext.Items[ContainerKey] = nestedContainer;
            ServiceLocation.CurrentContainer = nestedContainer;
            return (IController) nestedContainer.GetInstance(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            var baseController = controller as Controller;
            if (baseController != null)
            {
                var nestedContainer = (IContainer) baseController.HttpContext.Items[ContainerKey];
                var db = nestedContainer.GetInstance<IObjectContainer>();
                db.Close();
                nestedContainer.Dispose();
            }
            base.ReleaseController(controller);
        }
    }

    public class PerRequestRegistry : Registry
    {
        public PerRequestRegistry(RequestContext requestContext)
        {
            ForSingletonOf<IObjectContainer>().Use(c => MvcApplication.Db.Ext().OpenSession());
            For<RequestContext>().Use(requestContext);
            For<HttpContextBase>().Use(requestContext.HttpContext);
            For<HttpRequestBase>().Use(requestContext.HttpContext.Request);
        }
    }
}