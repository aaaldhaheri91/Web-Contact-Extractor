using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;

namespace Web_Contact_Extractor.Command
{
    public class ConcreteCommand : Command, ICommand
    {
        private IReceiver _receiver;
        public ConcreteCommand(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public async override Task<ContactDTO> Execute()
        {
            return await _receiver.MakeHttpRequest();
        }
    }
}