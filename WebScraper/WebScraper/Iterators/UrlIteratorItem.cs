using System.Collections.Generic;

namespace WebScraper
{
    public class UrlIteratorItem : List<string>
    {
        public string Placeholder { get; set; }
        public int Counter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="placeholder">Placeholder text.</param>
        /// <param name="items">Comma-delimited list of replacement items.</param>
        public UrlIteratorItem(UrlPlaceholder placeholder)
        {
            Placeholder = placeholder.GetEncodedPlaceholder();
            AddRange(placeholder.ParseReplacementItems());
            Counter = 0;
        }

        public string GetValue() => this[Counter];

        public void Reset() => Counter = 0;

        /// <summary>
        /// Advances to the next item in this collection.
        /// Returns true if another item was available, false if counter was reset.
        /// </summary>
        /// <returns></returns>
        public bool Next()
        {
            if (Counter < (Count - 1))
            {
                Counter++;
                return true;
            }
            else
            {
                Counter = 0;
                return false;
            }
        }
    }
}
