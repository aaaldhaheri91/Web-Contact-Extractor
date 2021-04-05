using System.Collections.Generic;
using AngleSharp.Dom;

namespace Web_Contact_Extractor.Extractor
{
    public interface IContact
    {
        public List<string> ExtractList(IDocument document, string regex);
        public string ExtractCssSelector(IDocument document, string cssselector);
        public string ExtractMatch(string source, string regex);
        public List<string> Address(IDocument document);
        public List<string> Email(IDocument document);
        public string Title(IDocument document);
        public string Company(IDocument document);
        public string Name(string url);
        public List<string> Phone(IDocument document);
        public List<string> Fax(IDocument document);
    }
}