// Copyright (c) 2020-2024 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//

using SoftCircuits.HtmlMonkey;
using System;
using System.Linq;

namespace SoftCircuits.WebScraper
{
    /// <summary>
    /// Class to iterate through all variations of any number of <see cref="PlaceholderIteratorItem"/>s.
    /// </summary>
    internal class PageIterator
    {
        public const string PagePlaceholder = "{page}";

        private readonly SelectorCollection NextPageSelectors;
        private string UrlTemplate;
        private int Page;

        /// <summary>
        /// Constructs a new <see cref="PageIterator"/> instance.
        /// </summary>
        /// <param name="nextPageSelectors">Selector used to detect there are more pages.
        /// May be empty.</param>
        public PageIterator(SelectorCollection nextPageSelectors)
        {
            NextPageSelectors = nextPageSelectors ?? throw new ArgumentNullException(nameof(nextPageSelectors));
            UrlTemplate = string.Empty;
        }

        /// <summary>
        /// Resets the page iterator for the new URL.
        /// </summary>
        /// <param name="urlTemplate"></param>
        public void Reset(string urlTemplate)
        {
            UrlTemplate = urlTemplate ?? throw new ArgumentNullException(nameof(urlTemplate));
            Page = 1;
        }

        /// <summary>
        /// Determines if the given document contains markup that indicates there are
        /// additional pages. If <see cref="NextPageSelectors"/> is empty, this method
        /// always returns <c>false</c>.
        /// </summary>
        /// <param name="document">The document examine.</param>
        /// <returns>True if markup was found indicating there are additional pages.</returns>
        public bool CheckIfMorePages(HtmlDocument document) => NextPageSelectors.Find(document.RootNodes).Any();

        /// <summary>
        /// Returns the URL for the current page.
        /// </summary>
        /// <returns>The URL for the current page.</returns>
        public string GetCurrentPageUrl() => UrlTemplate.Replace(PagePlaceholder, (Page++).ToString());
    }
}
