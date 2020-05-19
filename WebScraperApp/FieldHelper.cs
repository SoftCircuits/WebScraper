using SoftCircuits.WebScraper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebScraper
{
    /// <summary>
    /// Helper class for working with <see cref="Field"/> classes.
    /// </summary>
    public static class FieldHelper
    {
        private class FieldInfo
        {
            public Type Type { get; set; }
            public string Symbol { get; set; }
            public string Description { get; set; }
        }

        private static readonly List<FieldInfo> Fields = new List<FieldInfo>
        {
            new FieldInfo { Type = typeof(TextField), Symbol = "Text", Description = "Text" },
            new FieldInfo { Type = typeof(AttributeField), Symbol = "Attribute", Description = "Attribute Value" },
            new FieldInfo { Type = typeof(InnerHtmlField), Symbol = "InnerHtml", Description = "Inner HTML" },
            new FieldInfo { Type = typeof(OuterHtmlField), Symbol = "OuterHtml", Description = "Outer HTML" },
        };

        /// <summary>
        /// Returns all the field types.
        /// </summary>
        public static IEnumerable<Type> GetTypes() => Fields.Select(f => f.Type);

        /// <summary>
        /// Returns all the field symbols.
        /// </summary>
        public static IEnumerable<string> GetSymbols() => Fields.Select(f => f.Symbol);

        /// <summary>
        /// Returns all the field descriptions.
        /// </summary>
        public static IEnumerable<string> GetDescriptions() => Fields.Select(f => f.Description);

        /// <summary>
        /// Returns the symbol for the given field type.
        /// </summary>
        public static string GetSymbol(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            FieldInfo info = Fields.FirstOrDefault(f => f.Type == type);
            return (info != null) ? info.Symbol : string.Empty;
        }

        /// <summary>
        /// Returns the description for the given field type.
        /// </summary>
        public static string GetDescription(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            FieldInfo info = Fields.FirstOrDefault(f => f.Type == type);
            return (info != null) ? info.Description : string.Empty;
        }

        /// <summary>
        /// Returns the field type for the given symbol.
        /// </summary>
        public static Type GetSymbolType(string symbol)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            FieldInfo info = Fields.FirstOrDefault(f => f.Symbol == symbol);
            return (info != null) ? info.Type : typeof(TextField);
        }

        /// <summary>
        /// Returns the field type for the given description.
        /// </summary>
        public static Type GetDescriptionType(string description)
        {
            if (description == null)
                throw new ArgumentNullException(nameof(description));
            FieldInfo info = Fields.FirstOrDefault(f => f.Description == description);
            return (info != null) ? info.Type : typeof(TextField);
        }

        /// <summary>
        /// Creates a field object of type <typeparamref name="T"/>.
        /// </summary>
        public static Field FieldFactory(Type type, string name, string selector, string attribute)
        {
            if (type == typeof(TextField))
                return new TextField(name, selector);
            if (type == typeof(AttributeField))
                return new AttributeField(name, selector, attribute);
            if (type == typeof(InnerHtmlField))
                return new InnerHtmlField(name, selector);
            if (type == typeof(OuterHtmlField))
                return new OuterHtmlField(name, selector);
            throw new InvalidOperationException("Unable to create invalid field type");
        }
    }
}
