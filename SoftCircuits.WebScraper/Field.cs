// Copyright (c) 2020-2021 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//

using SoftCircuits.HtmlMonkey;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftCircuits.WebScraper
{
    /// <summary>
    /// Abstract base class for all field classes.
    /// </summary>
    public abstract class Field
    {
        /// <summary>
        /// Gets the name that describe this field.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the selector text that identifies the element associated with this field.
        /// </summary>
        public string Selector { get; private set; }

        #region Internal members

        /// <summary>
        /// Holds the parsed selectors for this field.
        /// </summary>
        internal SelectorCollection? Selectors { get; set; }

        /// <summary>
        /// Holds the resulting value.
        /// </summary>
        internal string Value { get; set; }

        /// <summary>
        /// Abstract class constructor.
        /// </summary>
        /// <param name="name">Field name.</param>
        /// <param name="selector">Field selector.</param>
        internal Field(string name, string selector)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Selector = selector ?? throw new ArgumentNullException(nameof(selector));
            Selectors = null;
            Value = string.Empty;
        }

        /// <summary>
        /// Recursively finds all the matching field elements from the given node.
        /// </summary>
        /// <param name="node">Root node to search.</param>
        /// <returns>All the matching field elements from the given node.</returns>
        internal IEnumerable<HtmlElementNode> FindValue(HtmlElementNode node) => (Selectors != null) ?
            Selectors.Find(node) :
            Enumerable.Empty<HtmlElementNode>();

        /// <summary>
        /// Extracts this field value from the given node.
        /// </summary>
        internal abstract string GetValueFromNode(HtmlElementNode node);

        #endregion

    }

    /// <summary>
    /// Defines a field that retrieves data from an element's text.
    /// </summary>
    public class TextField : Field
    {
        public TextField(string name, string selector)
            : base(name, selector)
        {
        }

        internal override string GetValueFromNode(HtmlElementNode node) => node.Text;
    }

    /// <summary>
    /// Defines a field that retrieves data from an element's attribute value.
    /// </summary>
    public class AttributeField : Field
    {
        public string AttributeName { get; private set; }

        public AttributeField(string name, string selector, string attributeName)
            : base(name, selector)
        {
            AttributeName = attributeName ?? throw new ArgumentNullException(nameof(attributeName));
        }

        internal override string GetValueFromNode(HtmlElementNode node) => node.Attributes[AttributeName]?.Value ?? string.Empty;
    }

    /// <summary>
    /// Defines a field that retrieves data from an element's inner HTML.
    /// </summary>
    public class InnerHtmlField : Field
    {
        public InnerHtmlField(string name, string selector)
            : base(name, selector)
        {
        }

        internal override string GetValueFromNode(HtmlElementNode node) => node.InnerHtml;
    }

    /// <summary>
    /// Defines a field that retrieves data from an element's outer HTML.
    /// </summary>
    public class OuterHtmlField : Field
    {
        public OuterHtmlField(string name, string selector)
            : base(name, selector)
        {
        }

        internal override string GetValueFromNode(HtmlElementNode node) => node.OuterHtml;
    }
}
