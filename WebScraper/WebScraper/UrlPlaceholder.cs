using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    public class UrlPlaceholder
    {
        public static readonly string PagePlaceholder = "{page}";

        public string Placeholder { get; set; }
        public string ReplacementItems { get; set; }

        /// <summary>
        /// Returns the placeholder wrapped in curly braces.
        /// </summary>
        /// <returns></returns>
        public string GetEncodedPlaceholder()
        {
            string result = Placeholder?.Trim() ?? string.Empty;
            if (!result.StartsWith("{"))
                result = "{" + result;
            if (!result.EndsWith("}"))
                result = result + "}";
            return result;
        }

        /// <summary>
        /// Returns the replacement items list as a collection.
        /// </summary>
        public IEnumerable<string> ParseReplacementItems()
        {
            return ReplacementItems.Split(',').Select(s => s.Trim());
        }

        public override string ToString()
        {
            return string.Format("{0}={1}", Placeholder ?? "(null)", ReplacementItems ?? "(null)");
        }
    }
}
