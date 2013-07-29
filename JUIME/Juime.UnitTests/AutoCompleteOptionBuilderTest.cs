using System.IO;
using System.Web.UI;
using Juime.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juime.UnitTests
{
    /// <summary>
    ///This is a test class for AccordionOptionBuilderTest and is intended
    ///to contain all AccordionOptionBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AutoCompleteOptionBuilderTest
    {
        private const string _startTag = "input";
        private string returnHtml = string.Empty;
        private string actual = string.Empty;
        
        /// <summary>
        /// Checks the Css class
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void HtmlAttribute_SetsCssClassAttribute()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            AutoCompleteOptionBuilder target = new AutoCompleteOptionBuilder();
            string expected = target.CssClass = "Sample";
            //get the control html as string
            returnHtml = AutoCompleteHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "class", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the Html attributes
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void HtmlAttribute_SetsCustomHtmlAttribute()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            AutoCompleteOptionBuilder target = new AutoCompleteOptionBuilder();
            target.HtmlAttributeList = new { CustomHtmlAttribute = "Sample"};
            string expected = "Sample";
            //get the control html as string
            returnHtml = AutoCompleteHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "CustomHtmlAttribute", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the Disabled attribute
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void HtmlAttribute_SetsDisabledAttribute()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            AutoCompleteOptionBuilder target = new AutoCompleteOptionBuilder();
            target.Disabled = true;
            string expected = "{\"disabled\":true}";
            //get the control html as string
            returnHtml = AutoCompleteHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "data-control-options", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Returns the Html as string
        /// </summary>
        /// <param name="target">AccordionOptionBuilder object</param>
        /// <returns>accordion html as string</returns>
        public string AutoCompleteHtmlBuilder(AutoCompleteOptionBuilder target)
        {
            string Htmltext = string.Empty;
            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
                target.OptionControl.Render(writer);
                writer.RenderBeginTag(_startTag);
                writer.RenderEndTag();
                Htmltext = stringWriter.ToString();
            }
            return Htmltext;
        }
    }
}
