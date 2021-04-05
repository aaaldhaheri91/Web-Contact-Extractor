using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Web_Contact_Extractor.Adapter;
using Web_Contact_Extractor.DTOs;

namespace Web_Contact_Extractor.Command
{
    public class Receiver : IReceiver
    {
        private string _url;
        private IContactAdapter _adapter;

        public Receiver(string url, IContactAdapter adapter)
        {
            _url = url;
            _adapter = adapter;
        }
        public Receiver(){}
        public void Action()
        {
            Console.WriteLine("Action receieved Command");
        }

        public async Task<ContactDTO> MakeHttpRequest()
        {
            var addressRegex = new System.Text.RegularExpressions.Regex(Regex.Regex.Address);
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(_url);
            string title = Title(document);
            string company = title;
            var contact = _adapter.ToContactDTO(Name(_url), title, company, AddressInfo(document), Phone(document), Fax(document), Email(document));
            return contact;
        }

        public List<string> Email(IDocument document)
        {
            var emails = new List<string>();
            var emailRegex = new System.Text.RegularExpressions.Regex(Regex.Regex.Email);
            var matches = emailRegex.Matches(document.DocumentElement.OuterHtml);
            Console.WriteLine("{0} email matches found in : ", matches.Count);
            foreach(Match match in matches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("email: {0}", groups[0].Value);
                emails.Add(groups[0].Value);
            }
            return emails;
        }

        public List<string> AddressInfo(IDocument document)
        {
            var addresses = new List<string>();
            var address = document.QuerySelectorAll("address");
            if (address.Length > 0)
            {
                foreach(var item in address)
                {
                    addresses.Add(item.TextContent);
                    Console.WriteLine("css selector: {0}", item.TextContent);
                }
                return addresses;
            }
            var addressRegex = new System.Text.RegularExpressions.Regex(Regex.Regex.Address);
            var addressMatches = addressRegex.Matches(document.DocumentElement.OuterHtml);
            Console.WriteLine("{0} address matches found in : ", addressMatches.Count);
            foreach(Match match in addressMatches)
            {
                GroupCollection groups = match.Groups;
                Console.WriteLine("address: {0}", groups[0].Value);
                addresses.Add(groups[0].Value);
            }
            return addresses;
        }

        public string Title(IDocument document)
        {
            var name = document.QuerySelector("title");
            // foreach(var item in name)
            // {
            //     Console.WriteLine("title tag content: {0}", item.TextContent);
            // }
            Console.WriteLine("title tag content: {0}", name.TextContent);
            return name.TextContent;
        }

        public string Name(string url)
        {
            var nameRegex = new System.Text.RegularExpressions.Regex(Regex.Regex.Name);
            var match = nameRegex.Match(url);
            // var group = match.Groups;
            Console.WriteLine("Name: {0}", match.Value);
            return match.Value;
        }

        public List<string> Phone(IDocument document)
        {
            var phones = new List<string>();
            var phoneRegex = new System.Text.RegularExpressions.Regex(Regex.Regex.Phone);
            var matches = phoneRegex.Matches(document.DocumentElement.OuterHtml);
            foreach(Match match in matches)
            {
                Console.WriteLine("Phone: {0}", match.Value);
                phones.Add(match.Value);
            }
            return phones;
        }
        public List<string> Fax(IDocument document)
        {
            var fax = new List<string>();
            var faxRegex = new System.Text.RegularExpressions.Regex(Regex.Regex.Fax);
            var matches = faxRegex.Matches(document.DocumentElement.OuterHtml);
            foreach(Match match in matches)
            {
                Console.WriteLine("Phone: {0}", match.Value);
                fax.Add(match.Value);
            }
            return fax;
        }
    }
}