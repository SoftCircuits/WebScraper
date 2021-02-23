// Copyright (c) 2020-2021 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//

using System;
using System.Collections.Generic;

namespace SoftCircuits.WebScraper
{
    /// <summary>
    /// Describes a placeholder that appears within the URL. For each placholder value, a
    /// version of the URL will be generated with that values replacing the placeholder.
    /// </summary>
    public class Placeholder
    {
        /// <summary>
        /// Gets or sets the name of this placeholder. This name must appear within the URL
        /// enclosed in curly braces (<c>{</c> and <c>}</c>), but this property value must
        /// not include the curly braces.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Specifies the replacement values for this placeholder. A URL will be
        /// generated with each value replacing the placeholder.
        /// </summary>
        public List<string> Values { get; private set; }

        /// <summary>
        /// Constructs a <see cref="Placeholder"/> instance.
        /// </summary>
        /// <param name="name">The name for this placeholder. This name must appear
        /// within the URL enclosed in curly braces (<c>{</c> and <c>}</c>), but
        /// this property value must not include the curly braces.</param>
        public Placeholder(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Values = new List<string>();
        }

        /// <summary>
        /// Constructs a <see cref="Placeholder"/> instance.
        /// </summary>
        /// <param name="name">The name for this placeholder. This name must appear
        /// within the URL enclosed in curly braces (<c>{</c> and <c>}</c>), but
        /// this property value must not include the curly braces.</param>
        /// <param name="values">The replacement values for this placeholder.</param>
        public Placeholder(string name, IEnumerable<string> values)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            Values = new List<string>(values);
        }

        /// <summary>
        /// Returns this placeholder as a URL tag by wrapping the placeholder name in
        /// curly braces (<c>{</c> and <c>}</c>).
        /// </summary>
        /// <returns>This placeholder as a URL tag.</returns>
        public string GetUrlPlaceholder() => $"{{{Name}}}";

        /// <summary>
        /// Determines if the given URL contains a tag for this placeholder.
        /// </summary>
        /// <param name="url">The URL to search for</param>
        /// <returns>True if the URL contains a tag for this placeholder.</returns>
        public bool UrlContainsPlaceholder(string url) => UrlContainsPlaceholder(url, GetUrlPlaceholder());

        /// <summary>
        /// Determines if the given URL contains the given placeholder tag.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static bool UrlContainsPlaceholder(string url, string tag)
        {
            if (url == null || tag == null)
                return false;
            return url.IndexOf(tag, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
