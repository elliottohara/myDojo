using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using myDojo.Infrastructure.Web.MvcModelMetaData.Attributes;

namespace myDojo.Infrastructure.Web.MvcModelMetaData.Builders
{
    public class PrimaryDisplayModelMetadataBuilder : IModelMetadataBuilder
    {
        public const string PrimaryDisplayKey = "PrimaryDisplay";
        public ModelMetadata BuildUp(ModelMetadata metaData, IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
           var isPrimary = attributes.OfType<PrimaryDisplayProperty>().FirstOrDefault() != null;
            if (isPrimary)
                metaData.AdditionalValues.Add(PrimaryDisplayKey, true);
            return metaData;
        }
    }
}