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
    public class TabOptionBuilderTest
    {
        private const string _startTag = "div";
        private string returnHtml = string.Empty;
        private string actual = string.Empty;
        
        /// <summary>
        /// Checks the Css class
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void HtmlAttribute_SetsCssClassAttribute()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            TabOptionBuilder target = new TabOptionBuilder();
            string expected = target.CssClass = "Sample";
            //get the control html as string
            returnHtml = TabHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "class", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the Html attributes
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void HtmlAttribute_SetsCustomHtmlAttribute()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            TabOptionBuilder target = new TabOptionBuilder();
            target.HtmlAttributeList = new { CustomHtmlAttribute = "Sample"};
            string expected = "Sample";
            //get the control html as string
            returnHtml = TabHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "CustomHtmlAttribute", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the collapsible attribute 
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void HtmlAttribute_SetsCollapsibleAttribute()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            TabOptionBuilder target = new TabOptionBuilder();
            target.Collapsible = true;
            string expected = "{\"collapsible\":true}";
            //get the control html as string
            returnHtml = TabHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "data-control-options", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the Active attribute
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void HtmlAttribute_SetsActiveAttribute()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            TabOptionBuilder target = new TabOptionBuilder();
            target.Active = 1;
            string expected = "{\"active\":1}";
            //get the control html as string
            returnHtml = TabHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "data-control-options", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Returns the Html as string
        /// </summary>
        /// <param name="target">AccordionOptionBuilder object</param>
        /// <returns>accordion html as string</returns>
        public string TabHtmlBuilder(TabOptionBuilder target)
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
