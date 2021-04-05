using System.Collections.Generic;
using Web_Contact_Extractor.DTOs;

namespace Web_Contact_Extractor.Adapter
{
    public class ContactAdapter : IContactAdapter
    {
        public ContactDTO ToContactDTO(string name, string title, string company, List<string> address, 
        List<string> phone, List<string> fax, List<string> email)
        {
            var contact = new ContactDTO();
            contact.Name = name;
            contact.Title = title;
            contact.Company = company;
            contact.Address = address;
            contact.Phone = phone;
            contact.Fax = fax;
            contact.Email = email;
            return contact;
            // return new ContactDTO {
            //     Name = name,
            //     Title = title,
            //     Company = company,
            //     Address = address,
            //     Phone = phone,
            //     Fax = fax,
            //     Email = email
            // };
        }
    }
}