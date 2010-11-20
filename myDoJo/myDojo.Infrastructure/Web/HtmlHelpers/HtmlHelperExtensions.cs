using System.Web;
using System.Web.Mvc;

namespace myDojo.Infrastructure.Web.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static string Resolve(this HtmlHelper helper, string virtualUrl)
        {
            if (!virtualUrl.StartsWith("~/"))
                return virtualUrl;

            virtualUrl = virtualUrl.Remove(0, 2);

            string applicationPath = helper.ViewContext.HttpContext.Request.ApplicationPath;
            if (string.IsNullOrEmpty(applicationPath) || !applicationPath.EndsWith("/"))
            {
                applicationPath = applicationPath + "/";
            }

            return applicationPath + virtualUrl;
        }
        public static string Resolve(this HttpRequestBase request, string virtualUrl)
        {
            if (!virtualUrl.StartsWith("~/"))
                return virtualUrl;

            virtualUrl = virtualUrl.Remove(0, 2);

            string applicationPath = request.ApplicationPath;
            if (string.IsNullOrEmpty(applicationPath) || !applicationPath.EndsWith("/"))
            {
                applicationPath = applicationPath + "/";
            }

            return applicationPath + virtualUrl;
        }
    }
}