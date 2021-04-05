using System.Collections.Generic;
namespace Web_Contact_Extractor.DTOs
{
    public class ContactDTO
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public List<string> Address { get; set; }
        public List<string> Phone { get; set; }
        public List<string> Fax { get; set; }
        public List<string> Email { get; set; }
    }
}