using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;
namespace Web_Contact_Extractor.Controllers
{
    public interface IContactExtractorContract
    {
        public Task<ContactDTO> CrawlContactInfo(string url);
    }
}