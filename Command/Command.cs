using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;

namespace Web_Contact_Extractor.Command
{
    public abstract class Command : ICommand
    {
        protected IReceiver receiver;

        public Command() 
        {

        }
        public abstract Task<ContactDTO> Execute();
    }
}