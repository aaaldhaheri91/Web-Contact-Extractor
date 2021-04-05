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
using Web_Contact_Extractor.Extractor;
namespace Web_Contact_Extractor.Command
{
    public class Receiver : IReceiver
    {
        private string _url;
        private IContactAdapter _adapter;
        private IContact _contact;
        public Receiver(string url, IContactAdapter adapter, IContact contact)
        {
            _url = url;
            _adapter = adapter;
            _contact = contact;
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
            var contact = _adapter.ToContactDTO(_contact.Name(_url), _contact.Title(document), _contact.Company(document), _contact.Address(document), _contact.Phone(document), _contact.Fax(document), _contact.Email(document));
            return contact;
        }

    }
}