using System.Collections.Generic;
using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;

namespace Web_Contact_Extractor.Command
{
    public interface IInovker
    {
        public void SetCommand(ICommand command);
        public Task<List<ContactDTO>> ExecuteCommand();
        public Task<List<ContactDTO>> ExecuteCommand(int deepCrawl);
    }
}