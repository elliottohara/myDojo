using System.ComponentModel.DataAnnotations;
using myDojo.Infrastructure;
using myDojo.Infrastructure.Core;
using myDojo.Infrastructure.Web.ModelMetaData;

namespace MyDojo.Query.ViewModels.Dojos
{
    [DisplayColumn("Name")]
    public class DojoDetails : ObjectWithIdentity 
    {
        [LinkText(LinkFormatProperty = "Id",LinkFormatString = "~/Schools/Details/{0}")]
        public virtual string Name { get; set; }
        public virtual Address Address { get; set; }
        [DataType(DataType.Html)]
        public virtual string Description { get; set; }
    }
}