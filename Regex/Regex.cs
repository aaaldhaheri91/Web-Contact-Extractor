
namespace Web_Contact_Extractor.Regex
{
    public static class Regex
    {
        private static string _emailRegex = @"\w+@\w+\.com";
        private static string _addressRegex = @"\d{4,5} +.+(?=AL|AK|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT|NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY)[A-Z]{2}[, ]+\d{5}(?:-\d{4})?";
        private static string _addressRegexNoZipCode = @"\d+.+(?=AL|AK|AS|AZ|AR|CA|CO|CT|DE|DC|FM|FL|GA|GU|HI|ID|IL|IN|IA|KS|KY|LA|ME|MH|MD|MA|MI|MN|MS|MO|MT|NE|NV|NH|NJ|NM|NY|NC|ND|MP|OH|OK|OR|PW|PA|PR|RI|SC|SD|TN|TX|UT|VT|VI|VA|WA|WV|WI|WY)[A-Z]{2}[, ]+(?:-\d{4})?";
        private static string _nameRegex = "(?:[-a-zA-Z0-9@:%_\\+~.#=]{2,256}\\.)?([-a-zA-Z0-9@:%_\\+~#=]*)\\.[a-z]{2,6}\\b(?:[-a-zA-Z0-9@:%_\\+.~#?&\\/\\/=]*)";
        private static string _titleRegex = "";
        private static string _companyRegex = "";
        private static string _phoneRegex = "(\\(\\d{3}\\)[\\s.-]+\\d{3}[\\s.-]+\\d{4})|(\\d{3}[\\s.-]+\\d{3}[\\s.-]+\\d{4})";
        private static string _faxRegex = "([fF]{1}ax: \\(\\d{3}\\)[\\s.-]+\\d{3}[\\s.-]+\\d{4})|([fF]{1}ax: \\d{3}[\\s.-]+\\d{3}[\\s.-]+\\d{4})";
        private static string _htmlTags = "(<([^>]+)>)";
        public static string Email
        {
            get
            {
                return _emailRegex;
            }
        }

        public static string Address
        {
            get
            {
                return _addressRegex;
            }
        }

        public static string AddressNoZipCode
        {
            get
            {
                return _addressRegexNoZipCode;
            }
        }

        public static string Name
        {
            get
            {
                return _nameRegex;
            }
        }

        public static string Title
        {
            get
            {
                return _titleRegex;
            }
        }

        public static string Company
        {
            get
            {
                return _companyRegex;
            }
        }

        public static string Phone
        {
            get
            {
                return _phoneRegex;
            }
        }

        public static string Fax
        {
            get
            {
                return _faxRegex;
            }
        }

        public static string HtmlTags 
        {
            get 
            {
                return _htmlTags;
            }
        }
    }
}