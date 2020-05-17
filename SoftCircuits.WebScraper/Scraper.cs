// Copyright (c) 2020 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//

using SoftCircuits.CsvParser;
using SoftCircuits.HtmlMonkey;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("WebScraper.Tests")]
namespace SoftCircuits.WebScraper
{
    /// <summary>
    /// Extracts content from web pages.
    /// </summary>
    /// <remarks>
    /// Enhancements:
    /// - Throttling
    /// - Downloading multiple URLs at once
    /// </remarks>
    public class Scraper
    {
        /// <summary>
        /// Gets or sets the URL to be scraped. This URL can include the <c>{page}</c>
        /// placeholder and any number of user placeholders enclosed in curly braces
        /// (<c>{</c> and <c>}</c>).
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the selector that identifies the element(s) that contains all
        /// the <see cref="ItemSelector"/>s. If this property is <c>null</c> or empty,
        /// the entire page is the container.
        /// </summary>
        public string ContainerSelector { get; set; }

        /// <summary>
        /// Gets or sets the selector that identifies the element(s) that enclosed all
        /// the fields for a single item.
        /// </summary>
        public string ItemSelector { get; set; }

        /// <summary>
        /// Gets or sets the selector that identifies the element(s) that, if present,
        /// indicate there is another page. Only used when the <c>{page}</c> placeholder
        /// is used.
        /// </summary>
        public string NextPageSelector { get; set; }

        /// <summary>
        /// Specifies the list of user placeholders.
        /// </summary>
        public List<Placeholder> Placeholders { get; private set; }

        /// <summary>
        /// Specifies the list of fields.
        /// </summary>
        public List<Field> Fields { get; private set; }

        /// <summary>
        /// Gets or sets whether column headers are written to the first row of
        /// the CSV file.
        /// </summary>
        public bool WriteColumnHeaders { get; set; }

        /// <summary>
        /// When more than one field value is found the values are concatenated together.
        /// This property is the text that appears between those values.
        /// </summary>
        public string DataSeparator { get; set; } = ",";

        /// <summary>
        /// Gets the number of URLs successfully scanned on the last pass.
        /// </summary>
        public int UrlsScanned { get; private set; }

        /// <summary>
        /// Get the number of URL errors on the last pass.
        /// </summary>
        public int UrlErrors { get; private set; }

        /// <summary>
        /// Event raised to provide current progress. Can also be used to
        /// cancel the scan.
        /// </summary>
        public event EventHandler<UpdateProgressEventArgs> UpdateProgress;

        /// <summary>
        /// Constructs a new <see cref="Scraper"/> instance.
        /// </summary>
        public Scraper()
        {
            Placeholders = new List<Placeholder>();
            Fields = new List<Field>();
            WriteColumnHeaders = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csvFile"></param>
        public async Task RunAsync(string csvFile)
        {
            UrlsScanned = UrlErrors = 0;
            bool hasMorePages = false;

            // Check for obvious errors
            if (string.IsNullOrWhiteSpace(Url))
                throw new Exception("A valid URL is required.");

            // Verify an output file was specified
            if (csvFile == null)
                throw new ArgumentNullException(nameof(csvFile));

            // Parse selectors
            SelectorCollection containerSelectors = Selector.ParseSelector(ContainerSelector);
            SelectorCollection itemSelectors = Selector.ParseSelector(ItemSelector);
            SelectorCollection nextPageSelectors = Selector.ParseSelector(NextPageSelector);
            foreach (Field field in Fields)
                field.Selectors = Selector.ParseSelector(field.Selector);

            // Validate selectors (ContainerSelector is optional)
            if (!itemSelectors.Any())
                throw new Exception($"A valid {nameof(ItemSelector)} is required.");
            if (Url.UrlContainsTag(PageIterator.PagePlaceholder) && !nextPageSelectors.Any())
                throw new Exception($"A valid {nameof(NextPageSelector)} is required when a {{page}} placeholder is used.");

            // Initialize placeholder iterator
            PlaceholderIterator placeholderIterator = new PlaceholderIterator(Url);
            foreach (var placeholder in Placeholders)
                placeholderIterator.Add(new PlaceholderIteratorItem(placeholder));

            // Initialize page iterator
            PageIterator pageIterator = new PageIterator(nextPageSelectors);

            // Initialize UpdateProgress event arguments
            UpdateProgressEventArgs eventArgs = new UpdateProgressEventArgs
            {
                Status = null,
                Maximum = placeholderIterator.GetTotalUrlCount(),
                Current = 0,
                Cancel = false,
            };

            if (DataSeparator == null)
                DataSeparator = string.Empty;

            using (CsvWriter writer = new CsvWriter(csvFile))
            {
                // Write column headers
                if (WriteColumnHeaders)
                    writer.WriteRow(Fields.Select(f => f.Name));

                // Scan URLs
                placeholderIterator.Reset(out string url);
                do
                {
                    pageIterator.Reset(url);
                    do
                    {
                        try
                        {
                            // Get next URL
                            url = pageIterator.GetCurrentPageUrl();
                            eventArgs.Status = $"Scanning '{url}'";
                            OnUpdateProgress(eventArgs);

                            // Handle cancel request
                            if (eventArgs.Cancel)
                            {
                                eventArgs.Status = "Aborting scan";
                                eventArgs.Current = eventArgs.Maximum;
                                OnUpdateProgress(eventArgs);
                                return;
                            }

                            // Download next web page
                            string html = await DownloadUrlAsync(url);
                            HtmlDocument document = HtmlDocument.FromHtml(html);

                            // Find containers
                            IEnumerable<HtmlElementNode> containers = (containerSelectors.Any()) ?
                                containerSelectors.Find(document.RootNodes) :
                                document.RootNodes.OfType<HtmlElementNode>();
                            IEnumerable<HtmlElementNode> nodes = itemSelectors.Find(containers);
                            hasMorePages = pageIterator.CheckIfMorePages(document);

                            // Find fields in each item container and write to output
                            foreach (HtmlElementNode node in nodes)
                            {
                                foreach (Field field in Fields)
                                {
                                    IEnumerable<HtmlElementNode> matchingNodes = field.Selectors.Find(new[] { node });
                                    field.Value = string.Join(DataSeparator, matchingNodes.Select(n => field.GetValueFromNode(n)));
                                }
                                writer.WriteRow(Fields.Select(f => f.Value /*?? string.Empty*/));
                            }
                            UrlsScanned++;
                        }
                        catch (Exception ex)
                        {
                            UrlErrors++;
                            hasMorePages = false;
                            eventArgs.Status = $"ERROR : '{url}' : {ex.Message}";
                            OnUpdateProgress(eventArgs);

                            // Handle cancel request
                            if (eventArgs.Cancel)
                            {
                                eventArgs.Status = "Aborting scan";
                                eventArgs.Current = eventArgs.Maximum;
                                OnUpdateProgress(eventArgs);
                                return;
                            }

                        }
                    }
                    while (hasMorePages);
                    eventArgs.Current++;
                } while (placeholderIterator.Next(out url));

                eventArgs.Status = "Scan complete";
                eventArgs.Current = eventArgs.Maximum;
                OnUpdateProgress(eventArgs);
            }
        }

        /// <summary>
        /// Downloads the specified URL. Does not block the current thread.
        /// </summary>
        /// <param name="url">The URL to download.</param>
        /// <returns>The content of the given URL.</returns>
        private async Task<string> DownloadUrlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            using (Stream data = await client.GetStreamAsync(url))
            using (StreamReader reader = new StreamReader(data))
            {
                return await reader.ReadToEndAsync();
            }
        }

        protected virtual void OnUpdateProgress(UpdateProgressEventArgs e) => UpdateProgress?.Invoke(this, e);
    }
}
