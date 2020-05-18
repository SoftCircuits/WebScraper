using System.Collections.Generic;

namespace WebScraper
{
    public class UrlIterator : List<UrlIteratorItem>
    {
        public string UrlTemplate { get; set; }

        public UrlIterator(string urlTemplate)
        {
            UrlTemplate = urlTemplate;
        }

        public new void Add(UrlIteratorItem item)
        {
            if (item.Count > 0 && UrlTemplate.Contains(item.Placeholder))
                base.Add(item);
        }

        public void Reset(out string result)
        {
            foreach (UrlIteratorItem item in this)
                item.Reset();

            result = UrlTemplate;
            foreach (UrlIteratorItem item in this)
                result = result.Replace(item.Placeholder, item.GetValue());
        }

        public bool Next(out string result)
        {
            bool gotValue = false;

            for (int i = Count - 1; i >= 0; i--)
            {
                // Advance this iterator
                gotValue = this[i].Next();
                // We're done if this iterator has another value
                // Otherwise, continue to advance next iterator
                if (gotValue)
                    break;
            }
            // Test for all iterators exhausted
            if (gotValue == false)
            {
                result = null;
                return false;
            }
            //
            result = UrlTemplate;
            foreach (UrlIteratorItem item in this)
                result = result.Replace(item.Placeholder, item.GetValue());
            return true;
        }
    }
}
