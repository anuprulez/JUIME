using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Juime.Builder;
using Juime.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juime.UnitTests
{
    /// <summary>
    ///This is a test class for AutocompleteBindBuilderTest and is intended
    ///to contain all AutocompleteBindBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AutocompleteBindBuilderTest
    {
        private const string _startTag = "input";
        private string returnHtml = string.Empty;
        private string actual = string.Empty;

        /// <summary>
        /// Checks the Data type of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void Constructor_SetsDataType()
        {
            actual = string.Empty;
            AutoCompleteBindBuilder target = new AutoCompleteBindBuilder();
            actual = "text";
            Assert.AreEqual(target.BindControl.DataType, actual);
        }

        /// <summary>
        /// Checks the value
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void HtmlAttribute_SetsBindValue()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            AutoCompleteBindBuilder target = new AutoCompleteBindBuilder();
            string expected = target.Value = "Sample";
            //get the control html as string
            returnHtml = AutoCompleteHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "value", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the source
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void HtmlAttribute_SetsBindSource()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            AutoCompleteBindBuilder target = new AutoCompleteBindBuilder();
            target.Source = new List<string> { "India", "US" };
            string expected = "{\"source\":[\"India\",\"US\"]}";
            //get the control html as string
            returnHtml = AutoCompleteHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "data-control-bind-source", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the entire html
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void HtmlAttribute_SetsCompleteBind()
        {
            actual = string.Empty;
            AutoCompleteBindBuilder target = new AutoCompleteBindBuilder();
            target.Value = "Sample";
            target.Source = new List<string> { "India", "US" };
            string expected = "<input data-control-bind-source=\"{&quot;source&quot;:[&quot;India&quot;,&quot;US&quot;]}\" value=\"Sample\" type=\"text\" />";
            //get the control html as string
            actual = AutoCompleteHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Returns the Html as string
        /// </summary>
        /// <param name="target">AccordionBindBuilder object</param>
        /// <returns>accordion html as string</returns>
        public string AutoCompleteHtmlBuilder(AutoCompleteBindBuilder target)
        {
            string Htmltext = string.Empty;
            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);                
                target.BindControl.Render(writer);
                writer.RenderBeginTag(_startTag);
                writer.RenderEndTag();
                Htmltext = stringWriter.ToString();
            }
            return Htmltext;
        }
    }
}
