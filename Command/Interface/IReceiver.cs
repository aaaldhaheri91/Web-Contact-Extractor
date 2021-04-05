using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;

namespace Web_Contact_Extractor.Command
{
    public interface IReceiver 
    {
        public void Action();
        public Task<ContactDTO> MakeHttpRequest();
    }
}