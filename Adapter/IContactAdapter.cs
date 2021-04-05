using Web_Contact_Extractor.DTOs;
using System.Collections.Generic;

namespace Web_Contact_Extractor.Adapter
{
    public interface IContactAdapter
    {
        ContactDTO ToContactDTO(string name, string title, string company, List<string> address, List<string> phone, List<string> fax, List<string> email);
    }
}