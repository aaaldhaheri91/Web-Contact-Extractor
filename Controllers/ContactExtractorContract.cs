using System;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;
using Web_Contact_Extractor.Adapter;
using Microsoft.Extensions.Logging;
using Web_Contact_Extractor.Command;
using Web_Contact_Extractor.DTOs;
using Web_Contact_Extractor.Extractor;

namespace Web_Contact_Extractor.Controllers
{
    public class ContactExtractorContract : IContactExtractorContract
    {
        private readonly ILogger<IContactExtractorContract> _logger;
        private IContactAdapter _adapter;
        private IContact _contact;

        public ContactExtractorContract(ILogger<IContactExtractorContract> logger, IContactAdapter adapter, IContact contact)
        {
            _logger = logger;
            _adapter = adapter;
            _contact = contact;
        }

        public async Task<ContactDTO> CrawlContactInfo(string url)
        {
            // Invoke Command Object
            url = HttpUtility.UrlDecode(url);
            _logger.LogInformation("url: "  + url);
            IReceiver crawler_receiver = new Receiver(url, _adapter, _contact);
            ICommand command = new ConcreteCommand(crawler_receiver);
            Invoker crawler_invoker = new Invoker();
            crawler_invoker.SetCommand(command);
            return await crawler_invoker.ExecuteCommand();
        }
    }
}