using System;

namespace myDojo.Infrastructure.Web.MvcModelMetaData
{
    public class LinkText : Attribute
    {
        public string LinkFormatProperty { get; set; }
        public string LinkFormatString { get; set; }
    }
}