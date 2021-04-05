using AngleSharp.Dom;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace Web_Contact_Extractor.Extractor 
{
    public class Contact : IContact
    {
        private IAddress _address;
        public Contact(IAddress address)
        {
            _address = address;
        }
        public List<string> ExtractList(IDocument document, string regex)
        {
            var list = new List<string>();
            var regularExpression = new System.Text.RegularExpressions.Regex(regex);
            var matches = regularExpression.Matches(document.DocumentElement.OuterHtml);
            foreach(Match match in matches)
            {
                list.Add(match.Value);
            }
            return list;
        }

        public string ExtractCssSelector(IDocument document, string cssselector)
        {
            return document.QuerySelector(cssselector).TextContent;
        }

        public string ExtractMatch(string source, string regex)
        {
            var regularExpression = new System.Text.RegularExpressions.Regex(regex);
            var match = regularExpression.Match(source);
            return match.Value;
        }

        public List<string> Address(IDocument document)
        {   var addresses = new List<string>();
            var address = document.QuerySelectorAll("address");
            if (address.Length > 0)
            {
                foreach(var item in address)
                {
                    addresses.Add(item.TextContent);
                    Console.WriteLine("css selector: {0}", item.TextContent);
                }
                return _address.RemoveHtmlTags(addresses);
            }
            return _address.RemoveHtmlTags(ExtractList(document, Regex.Regex.Address));
        }

        public List<string> Email(IDocument document)
        {
            return ExtractList(document, Regex.Regex.Email);
        }

        public string Title(IDocument document)
        {
            string title = ExtractCssSelector(document, "title");
            if (title.ToLower().Contains("contact us - ") || title.ToLower().Contains("contact us today - "))
            {
                title = title.Split('-')[1];
            } else if (title.ToLower().Contains("contact us today –") || title.ToLower().Contains("contact us –"))
            {
                title = title.Split("–")[1];
            } else if (title.ToLower().Contains("contact |"))
            {
                title = title.Split("|")[1];
            }
            return _address.RemoveTabsAndNewLines(title);
        }

        public string Company(IDocument document)
        {
            return Title(document);
        }

        public string Name(string url)
        {
            return ExtractMatch(url, Regex.Regex.Name);
        }

        public List<string> Phone(IDocument document)
        {
            return ExtractList(document, Regex.Regex.Phone);
        }

        public List<string> Fax(IDocument document)
        {
            return ExtractList(document, Regex.Regex.Fax);
        }

    }
}