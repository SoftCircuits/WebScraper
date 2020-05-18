using SoftCircuits.HtmlMonkey;

namespace WebScraper
{
    /// <summary>
    /// Common interface
    /// </summary>
    public interface IUrlPager
    {
        void Reset(string urlTemplate);
        string GetUrl();
        bool NextPage(HtmlDocument document);
    }
}
