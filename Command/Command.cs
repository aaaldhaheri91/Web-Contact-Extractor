using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;
using System.Collections.Generic;
namespace Web_Contact_Extractor.Command
{
    public abstract class Command : ICommand
    {
        protected IReceiver receiver;

        public Command() 
        {

        }
        public abstract Task<List<ContactDTO>> Execute();
        public abstract Task<List<ContactDTO>> Execute(int deepCrawl);
    }
}