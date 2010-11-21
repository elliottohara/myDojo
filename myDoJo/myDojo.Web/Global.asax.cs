using System.Web;
using myDojo.Infrastructure;
using myDojo.Web.Init;
using StructureMap;

namespace myDojo.Web
{
    public class MvcApplication : HttpApplication
    {
        public override void Dispose()
        {
            base.Dispose();
            if(ObjectContainerProvider.Db != null)
                ObjectContainerProvider.Db.Dispose();
        }
        
        protected void Application_Start()
        {
            StructureMapInitilizer.Initilize();
            ObjectFactory.Container.GetInstance<Bootstrapper>().BootstrapApplication();
        }
    }
}