using System.Linq;
using myDojo.Infrastructure;
using StructureMap;

namespace myDojo.Web.Init
{
    public class Bootstrapper
    {
        private readonly IContainer _container;

        public Bootstrapper(IContainer container)
        {
            _container = container;
        }

        public void BootstrapApplication()
        {
            //Container will call ctor, all work is done in ctor. We're good.
            _container.GetAllInstances<IStartupTask>().ToList().ForEach(t => t.Execute());
        }
    }
}