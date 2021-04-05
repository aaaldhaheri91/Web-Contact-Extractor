using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;
using System.Collections.Generic;

namespace Web_Contact_Extractor.Command
{
    public class Invoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public async Task<List<ContactDTO>> ExecuteCommand()
        {
            return await _command.Execute();
        }
    }
}