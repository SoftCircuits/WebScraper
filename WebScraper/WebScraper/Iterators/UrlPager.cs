using SoftCircuits.HtmlMonkey;
using System.Linq;

namespace WebScraper
{
    /// <summary>
    /// Normal page iterator
    /// </summary>
    public class UrlPager : IUrlPager
    {
        private string UrlTemplate { get; set; }
        private int Page { get; set; }
        private SelectorCollection NextPageSelector { get; set; }

        public UrlPager(SelectorCollection nextPageSelector)
        {
            NextPageSelector = nextPageSelector;
            Page = 0;
        }

        public void Reset(string urlTemplate)
        {
            UrlTemplate = urlTemplate;
            Page = 0;
        }

        public string GetUrl()
        {
            return UrlTemplate.Replace(UrlPlaceholder.PagePlaceholder, (++Page).ToString());
        }

        public bool NextPage(HtmlDocument document)
        {
            return NextPageSelector.Find(document.RootNodes).Any();
        }
    }
}
