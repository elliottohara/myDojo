using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using myDojo.Infrastructure.Web.MvcModelMetaData;
using StructureMap;

namespace myDojo.Infrastructure.Web.ModelMetaData
{
    public class MetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly IContainer _container;

        public MetadataProvider(IContainer container)
        {
            _container = container;
        }

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            var allBuilders = _container.GetAllInstances<IModelMetadataBuilder>();
            foreach (var builder in allBuilders)
            {
                builder.BuildUp(metadata, attributes, containerType, modelAccessor, modelType, propertyName);
            }
            return metadata;
        }

    }
    public class LinkText : Attribute
    {
        public string LinkFormatProperty { get; set; }
        public string LinkFormatString { get; set; }
    }
}