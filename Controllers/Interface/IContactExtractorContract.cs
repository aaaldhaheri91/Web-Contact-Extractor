using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;
using System.Collections.Generic;
namespace Web_Contact_Extractor.Controllers
{
    public interface IContactExtractorContract
    {
        public Task<List<ContactDTO>> CrawlContactInfo(List<string> url);
    }
}