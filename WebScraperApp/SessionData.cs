using SoftCircuits.WebScraper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WebScraper
{
    public class SessionData
    {
        public static readonly string DefaultDataSeparator = ",";

        public string Url { get; set; }
        public string Container { get; set; }
        public string Item { get; set; }
        public string NextPage { get; set; }
        public string DataSeparator { get; set; }
        public List<Placeholder> Placeholders { get; private set; }
        public List<Field> Fields { get; private set; }
        public string FilePath { get; set; }

        public SessionData()
        {
            Reset();
        }

        public void Reset()
        {
            Url = string.Empty;
            Container = string.Empty;
            Item = string.Empty;
            NextPage = string.Empty;
            DataSeparator = DefaultDataSeparator;
            Placeholders = new List<Placeholder>();
            Fields = new List<Field>();
            FilePath = null;
        }

        public void Read(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            Reset();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlElement root = doc.DocumentElement;
            if (root.Name != DataFiles.AppName)
                throw new Exception("Invalid data file format");

            foreach (XmlElement element in root.ChildNodes.OfType<XmlElement>())
            {
                switch (element.Name)
                {
                    case "Url":
                        Url = element.InnerText.Trim();
                        break;
                    case "ContainerSelector":
                        Container = element.InnerText.Trim();
                        break;
                    case "ItemSelector":
                        Item = element.InnerText.Trim();
                        break;
                    case "NextPageSelector":
                        NextPage = element.InnerText.Trim();
                        break;
                    case "DataSeparator":
                        DataSeparator = element.InnerText;
                        break;
                    case "Placeholders":
                        foreach (XmlElement placeholderElement in element.ChildNodes.OfType<XmlElement>())
                        {
                            Placeholder placeholder = new Placeholder(placeholderElement.GetAttribute("Name"));
                            foreach (XmlElement valueElement in placeholderElement.ChildNodes.OfType<XmlElement>())
                                placeholder.Values.Add(valueElement.InnerText.Trim());
                            Placeholders.Add(placeholder);
                        }
                        break;
                    case "Fields":
                        foreach (XmlElement fieldElement in element.ChildNodes.OfType<XmlElement>())
                        {
                            Fields.Add(FieldHelper.FieldFactory(FieldHelper.GetSymbolType(fieldElement.GetAttribute("Type")),
                                fieldElement.GetAttribute("Name"),
                                fieldElement.GetAttribute("Selector"),
                                fieldElement.GetAttribute("AttributeName")));
                        }
                        break;
                    default:
                        break;
                }
            }
            FilePath = path;
        }

        public void Write(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateNode(XmlNodeType.XmlDeclaration, null, null));
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement(DataFiles.AppName));

            XmlElement element = (XmlElement)root.AppendChild(doc.CreateElement("Url"));
            element.InnerText = Url;
            element = (XmlElement)root.AppendChild(doc.CreateElement("ContainerSelector"));
            element.InnerText = Container;
            element = (XmlElement)root.AppendChild(doc.CreateElement("ItemSelector"));
            element.InnerText = Item;
            element = (XmlElement)root.AppendChild(doc.CreateElement("NextPageSelector"));
            element.InnerText = NextPage;
            element = (XmlElement)root.AppendChild(doc.CreateElement("DataSeparator"));
            element.InnerText = DataSeparator;

            XmlElement placeholdersRoot = (XmlElement)root.AppendChild(doc.CreateElement("Placeholders"));
            foreach (Placeholder placeholder in Placeholders)
            {
                XmlElement placeholderRoot = (XmlElement)placeholdersRoot.AppendChild(doc.CreateElement("Placeholder"));
                placeholderRoot.SetAttribute("Name", placeholder.Name);
                foreach (string value in placeholder.Values)
                {
                    element = (XmlElement)placeholderRoot.AppendChild(doc.CreateElement("Value"));
                    element.InnerText = value;
                }
            }

            XmlElement fieldsRoot = (XmlElement)root.AppendChild(doc.CreateElement("Fields"));
            foreach (Field field in Fields)
            {
                element = (XmlElement)fieldsRoot.AppendChild(doc.CreateElement("Field"));
                element.SetAttribute("Name", field.Name);
                element.SetAttribute("Type", FieldHelper.GetSymbol(field.GetType()));
                element.SetAttribute("Selector", field.Selector);
                if (field is AttributeField attributeField)
                    element.SetAttribute("AttributeName", attributeField.AttributeName);
            }

            using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }
        }
    }
}
