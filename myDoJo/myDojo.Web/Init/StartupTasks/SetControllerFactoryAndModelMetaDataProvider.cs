using System;
using System.Web.Mvc;
using myDojo.Infrastructure;
using myDojo.Infrastructure.Web.MvcModelMetaData;
using StructureMap;

namespace myDojo.Web.Init
{
    public class SetControllerFactoryAndModelMetaDataProvider : IStartupTask
    {
        public void Execute()
        {
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory(ObjectFactory.Container));
            ModelMetadataProviders.Current = ObjectFactory.Container.GetInstance<MetadataProvider>();
        }
    }
}