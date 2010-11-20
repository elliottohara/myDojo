using myDojo.Infrastructure;
using myDojo.Infrastructure.Core;
using myDojo.Infrastructure.Web.ModelMetaData;

namespace MyDojo.Query.ViewModels.Dojos
{
    public class DojoDetails : ObjectWithIdentity 
    {
        [LinkText(LinkFormatProperty = "Id",LinkFormatString = "~/Dojos/Details/{0}")]
        public virtual string Name { get; set; }
        public virtual Address Address { get; set; }
    }
}