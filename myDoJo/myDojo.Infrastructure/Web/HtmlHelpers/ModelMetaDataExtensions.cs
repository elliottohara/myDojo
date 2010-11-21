using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myDojo.Infrastructure.Web.MvcModelMetaData;
using myDojo.Infrastructure.Web.MvcModelMetaData.Builders;

namespace myDojo.Infrastructure.Web.HtmlHelpers
{
    public static class ModelMetaDataExtensions
    {
        public static ModelLinkViewModel LinkToModelDetails<TModel>(this HtmlHelper<TModel> helper)
        {
            var displayProperty = helper.ViewData.ModelMetadata.Properties.FirstOrDefault(p => p.AdditionalValues.ContainsKey("LinkText"));
            var linkTextAttribute = (LinkText)displayProperty.AdditionalValues["LinkText"];
            var linkFormat = linkTextAttribute.LinkFormatString;
            var linkProperty = helper.ViewData.ModelMetadata.Properties.First(p => p.PropertyName == linkTextAttribute.LinkFormatProperty);
            var request = ServiceLocation.CurrentContainer.GetInstance<HttpRequestBase>();

            var link = request.Resolve(String.Format(linkFormat, linkProperty.Model));
            if(! (displayProperty.Model is string))
                throw new InvalidOperationException(String.Format("[LinkText] can only be used on String properties. {0} is a {1}",displayProperty.PropertyName, displayProperty.ContainerType.Name));
            var text = (String)displayProperty.Model;
            return new ModelLinkViewModel(link, text);

        }
        public static ModelMetadata PrimaryDisplayProperty<T>(this ViewDataDictionary<T> viewData)
        {
            return viewData.ModelMetadata.Properties.FirstOrDefault(p => p.AdditionalValues.ContainsKey(PrimaryDisplayModelMetadataBuilder.PrimaryDisplayKey));
        }
        public static IEnumerable<ModelMetadata> PropertiesForDisplay<T>(this ViewDataDictionary<T> viewData)
        {
            return viewData.ModelMetadata
                .Properties
                .Where(
                    pm =>
                    pm.PropertyName != viewData.ModelMetadata.DisplayName
                    && pm.ShowForDisplay &&
                    !viewData.TemplateInfo.Visited(pm))
                .Where(pm =>
                           {
                               if (viewData.PrimaryDisplayProperty() == null) return true;
                               return pm.PropertyName != viewData.PrimaryDisplayProperty().PropertyName;
                           });
        }
    }
}
