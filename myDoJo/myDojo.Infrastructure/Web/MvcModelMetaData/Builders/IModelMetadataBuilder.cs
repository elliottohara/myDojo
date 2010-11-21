using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace myDojo.Infrastructure.Web.MvcModelMetaData.Builders
{
    public interface IModelMetadataBuilder
    {
        ModelMetadata BuildUp(ModelMetadata metaData, IEnumerable<Attribute> attributes, Type containerType,
                              Func<object> modelAccessor, Type modelType, string propertyName);
    }

}