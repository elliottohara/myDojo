using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace myDojo.Infrastructure.Web.ModelMetaData
{
    public class MetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            var linkText = attributes.OfType<LinkText>().FirstOrDefault();
            if(linkText != null)
                metadata.AdditionalValues.Add("LinkText",linkText);
            return metadata;
        }

    }
    public class LinkText : Attribute
    {
        public string LinkFormatProperty { get; set; }
        public string LinkFormatString { get; set; }
    }
}