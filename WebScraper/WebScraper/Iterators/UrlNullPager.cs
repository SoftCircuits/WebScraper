using SoftCircuits.HtmlMonkey;

namespace WebScraper
{
    /// <summary>
    /// Page iterator for when paging is not implemented
    /// </summary>
    public class UrlNullPager : IUrlPager
    {
        private string Url { get; set; }

        public void Reset(string urlTemplate)
        {
            Url = urlTemplate;
        }

        public string GetUrl()
        {
            return Url;
        }

        public bool NextPage(HtmlDocument document)
        {
            return false;
        }
    }
}
