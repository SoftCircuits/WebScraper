using SoftCircuits.HtmlMonkey;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace WebScraper
{
    public class ProgressEventArgs : EventArgs
    {
        public string CurrentUrl { get; set; }
        public bool Cancel { get; set; }
    }

    public class X_Scraper
    {
        public delegate void ProgressEventHandler(object sender, ProgressEventArgs a);

        public ProgressEventHandler OnUpdateProgress;
        public int UrlsScanned { get; set; }
        public int UrlErrors { get; set; }
        public bool WriteColumnHeaders { get; set; }

        public X_Scraper()
        {
        }

        public void Run(FileData data, CsvFileWriter writer, Logger logger)
        {
            // Build selectors
            SelectorCollection containerSelector = Selector.ParseSelector(data.Container);
            SelectorCollection itemSelector = Selector.ParseSelector(data.Item);
            SelectorCollection nextPageSelector = Selector.ParseSelector(data.NextPage);
            foreach (Field field in data.Fields)
                field.Selectors = Selector.ParseSelector(field.SelectorText);

            // Set up URL iterator and placeholders
            UrlIterator iterator = new UrlIterator(data.Url);
            foreach (UrlPlaceholder placeholder in data.UrlPlaceholders)
                iterator.Add(new UrlIteratorItem(placeholder));

            // Set up paging
            bool usePaging = iterator.UrlTemplate.Contains(UrlPlaceholder.PagePlaceholder) && nextPageSelector.Any();
            IUrlPager pager = usePaging ? (IUrlPager)new UrlPager(nextPageSelector) : new UrlNullPager();
            bool nextPage = false;

            // Set up events
            ProgressEventArgs args = new ProgressEventArgs();
            UrlsScanned = UrlErrors = 0;

            // Write headers if requested
            if (WriteColumnHeaders)
                writer.WriteRow(data.Fields.Select(f => f.Name).ToList());

            iterator.Reset(out string url);
            do
            {
                pager.Reset(url);
                do
                {
                    try
                    {
                        // Get URL for this page
                        url = pager.GetUrl();
                        logger.Log("Scraping: {0}", url);

                        // Raise progress event
                        args.CurrentUrl = url;
                        OnUpdateProgress?.Invoke(this, args);
                        if (args.Cancel == true)
                            return;

                        // Download and parse this page
                        string html = DownloadUrl(url);
                        HtmlDocument document = HtmlDocument.FromHtml(html);
                        // Find containers on page
                        nextPage = pager.NextPage(document);
                        var containers = containerSelector.Find(document.RootNodes);
                        var items = itemSelector.Find(containers);

                        // Find fields in each item container and write to output
                        foreach (var item in items)
                        {
                            foreach (Field field in data.Fields)
                            {
                                var nodes = field.Selectors.Find(new[] { item });
                                field.Value = (nodes.Any()) ? string.Join(data.TextSeparator, nodes.Select(n => field.ExtractContent(n))) : string.Empty;
                            }
                            writer.WriteRow(data.Fields.Select(f => f.Value).ToList());
                        }
                        UrlsScanned++;
                    }
                    catch (Exception ex)
                    {
                        // Log error
                        logger.Log("ERROR : {0}", ex.Message);
                        // We stop next page to avoid repeating a page that won't download
                        // But the result is that a temporary server error could cause us to lose pages
                        nextPage = false;
                        UrlErrors++;
                    }
                } while (nextPage);
            } while (iterator.Next(out url));
        }

        public string DownloadUrl(string url)
        {
            using (WebClient client = new WebClient())
            {
                using (Stream data = client.OpenRead(url))
                using (StreamReader reader = new StreamReader(data))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
