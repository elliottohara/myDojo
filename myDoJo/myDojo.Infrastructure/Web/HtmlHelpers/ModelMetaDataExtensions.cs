using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myDojo.Infrastructure.Web.HtmlHelpers
{
    public static class ModelMetaDataExtensions
    {
        public static ModelLinkViewModel LinkToModelDetails<TModel>(this HtmlHelper<TModel> helper)
        {
            var displayProperty = helper.ViewData.ModelMetadata.Properties.FirstOrDefault(p => p.AdditionalValues.ContainsKey("LinkText"));
            var linkTextAttribute = (ModelMetaData.LinkText)displayProperty.AdditionalValues["LinkText"];
            var linkFormat = linkTextAttribute.LinkFormatString;
            var linkProperty = helper.ViewData.ModelMetadata.Properties.First(p => p.PropertyName == linkTextAttribute.LinkFormatProperty);
            var request = ServiceLocation.CurrentContainer.GetInstance<HttpRequestBase>();

            var link = request.Resolve(String.Format(linkFormat, linkProperty.Model));
            if(! (displayProperty.Model is string))
                throw new InvalidOperationException(String.Format("[LinkText] can only be used on String properties. {0} is a {1}",displayProperty.PropertyName, displayProperty.ContainerType.Name));
            var text = (String)displayProperty.Model;
            return new ModelLinkViewModel(link, text);

        }
    }

    public class ModelLinkViewModel
    {
        public ModelLinkViewModel()
        {

        }
        public ModelLinkViewModel(string link, string text)
        {
            Url = link;
            Text = text;
        }

        public string Text { get; set; }
        public string Url { get; set; }
    }
}
