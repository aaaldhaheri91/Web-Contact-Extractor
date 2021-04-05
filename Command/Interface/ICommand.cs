using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;

namespace Web_Contact_Extractor.Command
{
    public interface ICommand
    {
        public abstract Task<ContactDTO> Execute();
    }
}