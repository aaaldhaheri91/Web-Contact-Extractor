using System.Collections.Generic;
using Web_Contact_Extractor.DTOs;

namespace Web_Contact_Extractor.Adapter
{
    public class ContactAdapter : IContactAdapter
    {
        public ContactDTO ToContactDTO(string name, string title, string company, List<string> address, 
        List<string> phone, List<string> fax, List<string> email)
        {
            return new ContactDTO {
                Name = name,
                Title = title,
                Company = company,
                Address = address,
                Phone = phone,
                Fax = fax,
                Email = email
            };
        }
    }
}