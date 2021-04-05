using System.Collections.Generic;

namespace Web_Contact_Extractor.Extractor
{
    public class Address : IAddress
    {
        public List<string> RemoveHtmlTags(List<string> list)
        {
            List<string> newList = new List<string>();
            var regex = new System.Text.RegularExpressions.Regex(Regex.Regex.HtmlTags);
            foreach(string str in list)
            {
                newList.Add(regex.Replace(str, " "));
            }
            return RemoveTabsAndNewLines(newList);
        }

        public List<string> RemoveTabsAndNewLines(List<string> list)
        {
            List<string> newList = new List<string>();
            var regexNewLine = new System.Text.RegularExpressions.Regex(@"(\n|\r)");
            var regexTabs = new System.Text.RegularExpressions.Regex(@"\t");
            foreach(string str in list)
            {
                string removeLines = regexNewLine.Replace(str, " ");
                newList.Add(regexTabs.Replace(removeLines, ""));
            }
            return RemoveHtmlSpace(newList);
        }

        public string RemoveTabsAndNewLines(string str)
        {
            string newStr;
            var regexNewLine = new System.Text.RegularExpressions.Regex(@"(\n|\r)");
            var regexTabs = new System.Text.RegularExpressions.Regex(@"\t");
            newStr = regexNewLine.Replace(str, " ");
            newStr = regexTabs.Replace(newStr, "");
            return newStr;
        }

        public List<string> RemoveHtmlSpace(List<string> list)
        {
            List<string> newList = new List<string>();
            foreach(string str in list)
            {
                newList.Add(str.Replace("&nbsp;", ""));
            }
            return newList;
        }
    }
}