// Copyright (c) 2020-2024 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//

using System;

namespace SoftCircuits.WebScraper
{
    internal static class StringExtensions
    {
        /// <summary>
        /// Performs a case-insensitive replace.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="find">The string to be replaced.</param>
        /// <param name="replace">The string to replace all occurrences of <paramref name="find"/>.</param>
        /// <returns>The modified string.</returns>
        public static string CaseInsensitiveReplace(this string s, string find, string replace)
        {
            int pos = 0;
            while (pos < s.Length)
            {
                int nextPos = s.IndexOf(find, pos, StringComparison.OrdinalIgnoreCase);
                if (nextPos >= 0)
                {
#if NETSTANDARD2_0
                    s = string.Concat(s.Substring(0, nextPos), replace, s.Substring(nextPos + find.Length));
#else
                    s = string.Concat(s[..nextPos], replace, s[(nextPos + find.Length)..]);
#endif
                    pos = nextPos + replace.Length;
                }
                else pos = s.Length;
            }
            return s;
        }
    }
}
