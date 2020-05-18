using System;
using System.ComponentModel;
using System.Diagnostics;
using SoftCircuits.HtmlMonkey;

namespace WebScraper
{
    public enum FieldSourceMode
    {
        [Description("Text")]
        Text,
        [Description("Attribute Value")]
        AttributeValue,
        [Description("Inner HTML")]
        InnerHtml,
        [Description("Outer HTML")]
        OuterHtml,
    }

    public class Field
    {
        public string Name { get; set; }
        public string SelectorText { get; set; }
        public SelectorCollection Selectors { get; set; }
        public string Value { get; set; }

        public FieldSourceMode Mode { get; private set; }
        public string AttributeName { get; private set; }   // Used for FieldSourceMode.AttributeValue
        private readonly Func<HtmlElementNode, string> Extractor;

        public Field(string name, string selectorText, FieldSourceMode mode, string attributeName)
        {
            Name = name;
            SelectorText = selectorText;

            Mode = mode;
            AttributeName = attributeName;
            switch (Mode)
            {
                case FieldSourceMode.AttributeValue:
                    Debug.Assert(!string.IsNullOrWhiteSpace(AttributeName));
                    Extractor = ExtractAttribute;
                    break;
                case FieldSourceMode.InnerHtml:
                    Extractor = ExtractInnerHtml;
                    break;
                case FieldSourceMode.OuterHtml:
                    Extractor = ExtractOuterHtml;
                    break;
                case FieldSourceMode.Text:
                default:
                    Extractor = ExtractText;
                    break;
            }

            Selectors = null;
            Value = string.Empty;
        }

        public override string ToString()
        {
            string mode = Mode.GetEnumDescription();
            if (Mode == FieldSourceMode.AttributeValue)
                mode += $":{AttributeName ?? "(null)"}";
            return $"{Name ?? "(null)"}={SelectorText ?? "(null)"} ({mode})";
        }

        #region Extraction methods

        public string ExtractContent(HtmlElementNode node) => Extractor(node);

        private string ExtractText(HtmlElementNode node)
        {
            return node.Text;
        }

        private string ExtractAttribute(HtmlElementNode node)
        {
            return node.Attributes[AttributeName]?.Value ?? string.Empty;
        }

        private string ExtractInnerHtml(HtmlElementNode node)
        {
            return node.InnerHtml;
        }

        private string ExtractOuterHtml(HtmlElementNode node)
        {
            return node.OuterHtml;
        }

        #endregion

        #region INI setting support

        /// <summary>
        /// Builds a field description for an INI file.
        /// </summary>
        public string IniValue => $"{SelectorText}|{Mode}|{AttributeName ?? string.Empty}";

        /// <summary>
        /// Returns a Field object that corresponds to the given INI values.
        /// </summary>
        /// <param name="name">Field name.</param>
        /// <param name="value">Field description from INI file.</param>
        /// <returns>A new Field object.</returns>
        public static Field FromIniValue(string name, string value)
        {
            Debug.Assert(value != null);
            string selectorText = string.Empty;
            FieldSourceMode mode = FieldSourceMode.Text;
            string attributeName = string.Empty;
            string[] tokens = value.Split('|');

            if (tokens.Length > 0)
            {
                selectorText = tokens[0];
                if (tokens.Length > 1)
                {
                    Enum.TryParse(tokens[1], out mode);
                    if (tokens.Length > 2)
                        attributeName = tokens[2];
                }
            }
            return new Field(name, selectorText, mode, attributeName);
        }

        #endregion

    }

    /// <summary>
    /// Used to store a <see cref="FieldSourceMode"/> in a ListBox so that the descriptions
    /// are displayed in the list
    /// </summary>
    public class FieldSourceModeListItem
    {
        public FieldSourceMode Mode { get; set; }
        public override string ToString()
        {
            return Mode.GetEnumDescription();
        }

        public FieldSourceModeListItem(FieldSourceMode mode)
        {
            Mode = mode;
        }
    }
}
