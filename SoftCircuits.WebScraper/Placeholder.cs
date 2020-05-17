// Copyright (c) 2020 Jonathan Wood (www.softcircuits.com)
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
    }
}
