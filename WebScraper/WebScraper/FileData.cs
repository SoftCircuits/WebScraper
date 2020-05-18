using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebScraper
{
    public struct FileDataLabels
    {
        public static readonly string General = "General";
        public static readonly string Fields = "Fields";
        public static readonly string UrlPlaceholders = "UrlPlaceholders";

        public static readonly string Url = "Url";
        public static readonly string Container = "Container";
        public static readonly string Item = "Item";
        public static readonly string NextPage = "NextPage";
        public static readonly string TextSeparator = "TextSeparator";
    }

    public enum FileDataValidation
    {
        Valid,
        Warning,
        Error
    }

    public class FileData
    {
        public static readonly string DefaultTextSeparator = ", ";

        public string FilePath { get; set; } = null;

        public string Url { get; set; }

        public List<UrlPlaceholder> UrlPlaceholders { get; private set; }

        public string Container { get; set; }
        public string Item { get; set; }
        public string NextPage { get; set; }
        public string TextSeparator { get; set; }

        public List<Field> Fields { get; private set; }

        public FileData()
        {
            Clear();
        }

        public void Read(string path)
        {
            IniFile file = new IniFile();

            file.Load(path);

            Url = file.GetSetting(FileDataLabels.General, FileDataLabels.Url, string.Empty);
            Container = file.GetSetting(FileDataLabels.General, FileDataLabels.Container, string.Empty);
            Item = file.GetSetting(FileDataLabels.General, FileDataLabels.Item, string.Empty);
            NextPage = file.GetSetting(FileDataLabels.General, FileDataLabels.NextPage, string.Empty);
            TextSeparator = file.GetSetting(FileDataLabels.General, FileDataLabels.TextSeparator, DefaultTextSeparator);

            UrlPlaceholders = new List<UrlPlaceholder>();
            IEnumerable<IniSetting> placeholders = file.GetSectionSettings(FileDataLabels.UrlPlaceholders);
            foreach (IniSetting placeholder in placeholders)
                UrlPlaceholders.Add(new UrlPlaceholder { Placeholder = placeholder.Name, ReplacementItems = placeholder.Value });

            Fields = new List<Field>();
            IEnumerable<IniSetting> fields = file.GetSectionSettings(FileDataLabels.Fields);
            foreach (IniSetting field in fields)
                Fields.Add(Field.FromIniValue(field.Name, field.Value));

            FilePath = path;
        }

        public void Write(string path)
        {
            IniFile file = new IniFile();

            file.SetSetting(FileDataLabels.General, FileDataLabels.Url, Url);
            file.SetSetting(FileDataLabels.General, FileDataLabels.Container, Container);
            file.SetSetting(FileDataLabels.General, FileDataLabels.Item, Item);
            file.SetSetting(FileDataLabels.General, FileDataLabels.NextPage, NextPage);
            file.SetSetting(FileDataLabels.General, FileDataLabels.TextSeparator, TextSeparator);

            foreach (UrlPlaceholder placeholder in UrlPlaceholders)
                file.SetSetting(FileDataLabels.UrlPlaceholders, placeholder.Placeholder, placeholder.ReplacementItems);

            foreach (Field field in Fields)
                file.SetSetting(FileDataLabels.Fields, field.Name, field.IniValue);

            file.Save(path);
            FilePath = path;
        }

        public void Clear()
        {
            Url = string.Empty;
            Container = string.Empty;
            Item = string.Empty;
            NextPage = string.Empty;
            TextSeparator = DefaultTextSeparator;
            UrlPlaceholders = new List<UrlPlaceholder>();
            Fields = new List<Field>();
            FilePath = null;
        }

        public FileDataValidation Validate(out string message)
        {
            List<string> errors = new List<string>();
            List<string> warnings = new List<string>();

            if (TextSeparator == null)
                TextSeparator = string.Empty;
            if (string.IsNullOrWhiteSpace(Url))
                errors.Add("URL is required.");
            // No URL placeholders are required
            string url = Url ?? string.Empty;
            foreach (UrlPlaceholder placeholder in UrlPlaceholders)
            {
                if (!url.Contains(placeholder.Placeholder))
                    warnings.Add($"Placeholder '{placeholder.Placeholder}' defined but not referenced by URL.");
            }
            if (string.IsNullOrWhiteSpace(Container))
                errors.Add("A Container selector is required.");
            if (string.IsNullOrWhiteSpace(Item))
                errors.Add("An Item selector is required.");
            // NextPage is not required
            if (Fields == null || !Fields.Any())
                errors.Add("At least one field must be defined.");

            StringBuilder builder = new StringBuilder();
            foreach (string s in errors)
                builder.AppendLine("ERROR : " + s);
            foreach (string s in warnings)
                builder.AppendLine("WARNING : " + s);
            message = builder.ToString();
            return errors.Any() ? FileDataValidation.Error : warnings.Any() ? FileDataValidation.Warning : FileDataValidation.Valid;
        }
    }
}
