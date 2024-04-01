// Copyright (c) 2020-2024 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//

using System;
using System.Collections.Generic;

namespace SoftCircuits.WebScraper
{
    /// <summary>
    /// Handles iterating for a single URL placeholder.
    /// </summary>
    internal class PlaceholderIteratorItem : List<string>
    {
        /// <summary>
        /// Placeholder tag (name inside of curly braces).
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// Index of current placeholder value.
        /// </summary>
        private int Current;

        /// <summary>
        /// Constructs a new <see cref="PlaceholderIteratorItem"/> instance.
        /// </summary>
        /// <param name="placeholder"></param>
        public PlaceholderIteratorItem(Placeholder placeholder)
        {
#if NETSTANDARD2_0
            if (placeholder == null)
                throw new ArgumentNullException(nameof(placeholder));
#else
            ArgumentNullException.ThrowIfNull(placeholder);
#endif

            Placeholder = $"{{{placeholder.Name}}}";
            AddRange(placeholder.Values);
            Reset();
        }

        /// <summary>
        /// Initializes this iterator.
        /// </summary>
        public void Reset()
        {
            Current = 0;
        }

        /// <summary>
        /// If there are any more replacement values, advances to the next one and returns true.
        /// Otherwise, resets the iterator and returns false.
        /// </summary>
        public bool Next()
        {
            if (++Current < Count)
                return true;

            Reset();
            return false;
        }

        /// <summary>
        /// Returns the current replacement value.
        /// </summary>
        public string CurrentValue => (Current < Count) ? this[Current] : string.Empty;
    }
}
