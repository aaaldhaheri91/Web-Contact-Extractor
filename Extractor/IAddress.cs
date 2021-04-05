using System.Collections.Generic;

namespace Web_Contact_Extractor.Extractor
{
    public interface IAddress
    {
        public List<string> RemoveHtmlTags(List<string> list);
        public List<string> RemoveTabsAndNewLines(List<string> list);
        public string RemoveTabsAndNewLines(string str);
        public List<string> RemoveHtmlSpace(List<string> list);
    }
}