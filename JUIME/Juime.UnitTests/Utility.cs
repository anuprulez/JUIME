using System.IO;
using System.Xml.XPath;

namespace Juime.UnitTests
{
    public static class Utility
    {
        /// <summary>
        /// Gets the value of the attribute
        /// </summary>
        /// <param name="HtmlText">html string</param>
        /// <param name="Attribute">attribute name</param>
        /// <param name="startTag">start tag of the html</param>
        /// <returns>value of the attribute</returns>
        public static string GetAttribute(string HtmlText, string Attribute, string startTag)
        {
            string value = string.Empty;
            TextReader reader = new StringReader(HtmlText);
            XPathDocument xdoc = new XPathDocument(reader);
            XPathNavigator navigator = xdoc.CreateNavigator();
            XPathNavigator node = navigator.SelectSingleNode(startTag + "/@" + Attribute);
            if (node != null)
            {
                value = node.Value.ToString().StringReplace();
                return value;
            }
            else
            {
                return string.Empty;
            }
        }

        //navigator.SelectSingleNode("div").Value


        /// <summary>
        /// Gets the specified section's html
        /// </summary>
        /// <param name="HtmlText">html string</param>
        /// <param name="targetTag">tag name</param>
        /// <returns></returns>
        public static string GetSection(string HtmlText, string targetTag)
        {
            string value = string.Empty;
            TextReader reader = new StringReader(HtmlText);
            XPathDocument xdoc = new XPathDocument(reader);
            XPathNavigator navigator = xdoc.CreateNavigator();
            XPathNavigator node = navigator.SelectSingleNode(targetTag);
            if (node != null)
            {
                value = node.Value.ToString().StringReplace();
                return value;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Removes the escape characters from the html string
        /// </summary>
        /// <param name="stringValue">string variable</param>
        /// <returns></returns>
        public static string StringReplace(this string stringValue)
        {
            return stringValue.Replace("\t", "").Replace("\n", "").Replace("\r", "");
        }
    }
}
