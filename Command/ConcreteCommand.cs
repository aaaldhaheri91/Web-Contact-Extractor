using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;
using System.Collections.Generic;
namespace Web_Contact_Extractor.Command
{
    public class ConcreteCommand : Command, ICommand
    {
        private IReceiver _receiver;
        public ConcreteCommand(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public async override Task<List<ContactDTO>> Execute()
        {
            return await _receiver.GetContactInfo();
        }

        public async override Task<List<ContactDTO>> Execute(int deepCrawl)
        {
            return await _receiver.GetContactInfo(deepCrawl);
        }
    }
}