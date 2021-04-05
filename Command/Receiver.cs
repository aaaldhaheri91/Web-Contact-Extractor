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
        private IList<string> _urls;
        private IContactAdapter _adapter;
        private IContact _contact;
        public Receiver(IContactAdapter adapter, IContact contact)
        {
            _adapter = adapter;
            _contact = contact;
        }

        public IList<string> Urls
        {
            set 
            {
                _urls = value;
            }
            get
            {
                return _urls;
            }
        }
        public void Action()
        {
            Console.WriteLine("Action receieved Command");
        }

        public async Task<List<ContactDTO>> GetContactInfo()
        {
            List<ContactDTO> contacts = new List<ContactDTO>();
            
            var addressRegex = new System.Text.RegularExpressions.Regex(Regex.Regex.Address);
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            foreach(string url in _urls)
            {
                var document = await context.OpenAsync(url);
                contacts.Add(_adapter.ToContactDTO(_contact.Name(url), _contact.Title(document), _contact.Company(document), _contact.Address(document), _contact.Phone(document), _contact.Fax(document), _contact.Email(document)));
            }
            
            return contacts;
        }

        public async Task<List<ContactDTO>> GetContactInfo(int deepCrawl)
        {
            return await GetContactInfo();
        }

        // private async Task<List<ContactDTO>> GetContactInfoTask(IList<string> urls)
        // {
            
        // }

    }
}