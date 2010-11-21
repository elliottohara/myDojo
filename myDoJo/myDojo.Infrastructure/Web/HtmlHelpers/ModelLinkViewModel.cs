namespace myDojo.Infrastructure.Web.HtmlHelpers
{
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