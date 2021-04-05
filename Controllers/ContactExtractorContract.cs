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
        private IContext _context;

        public ContactExtractorContract(ILogger<IContactExtractorContract> logger, IContactAdapter adapter, IContact contact, IContext context)
        {
            _logger = logger;
            _adapter = adapter;
            _contact = contact;
            _context = context;
        }

        public void SetContext(List<string> url)
        {
            List<string> urls = DecodeUrls(url);
            _context.Receiver.Urls = url;
            _context.Invoker.SetCommand(_context.Command);
        }
        public async Task<List<ContactDTO>> CrawlContactInfo(List<string> url)
        {
            // Invoke Command Object
            SetContext(url);
            return await _context.Invoker.ExecuteCommand();
        }

        public async Task<List<ContactDTO>> CrawlContactInfo(List<string> url, int deepCrawl)
        {
            SetContext(url);
            return await _context.Invoker.ExecuteCommand();
        }

        public List<string> DecodeUrls(List<string> urls)
        {
            List<string> decodedUrls = new List<string>();
            foreach(string url in urls)
            {
                decodedUrls.Add(HttpUtility.UrlDecode(url));
            }  
            return decodedUrls;      
        }

    }

    public class Context : IContext
    {
        IReceiver _crawler_receiver;
        ICommand _command;
        IInovker _crawler_invoker;

        public Context(IReceiver receiver, ICommand command, IInovker invoker)
        {
            _crawler_receiver = receiver;
            _command = command;
            _crawler_invoker = invoker; 
        }

        public IReceiver Receiver
        {
            get 
            {
                return _crawler_receiver;
            }
        }

        public ICommand Command
        {
            get 
            {
                return _command;
            }
        }

        public IInovker Invoker
        {
            get
            {
                return _crawler_invoker;
            }
        }
    }

    public interface IContext 
    {
        public IReceiver Receiver { get; }
        public ICommand Command { get; }
        public IInovker Invoker { get; }
    }
}