using System.IO;
using System.Web.UI;
using Juime.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juime.UnitTests
{
    /// <summary>
    ///This is a test class for AccordionSectionBuilderTest and is intended
    ///to contain all AccordionSectionBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccordionSectionBuilderTest
    {
        private const string _startTag = "div";
        private string returnHtml = string.Empty;
        private string actual = string.Empty;

        /// <summary>
        /// Checks the sections headers
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void HtmlAttribute_SetsSectionHeader()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            AccordionSectionBuilder target = new AccordionSectionBuilder();
            string expected = target.Header = "first";
            //get the control html as string
            returnHtml = AccordionHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetSection(returnHtml, "div/h3");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the sections text
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void HtmlAttribute_SetsSectionText()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            AccordionSectionBuilder target = new AccordionSectionBuilder();
            string expected = target.Text = "Content1";
            //get the control html as string
            returnHtml = AccordionHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetSection(returnHtml, "div/div");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the entire section's html
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void HtmlAttribute_SetsCompleteSection()
        {
            actual = string.Empty;
            AccordionSectionBuilder target = new AccordionSectionBuilder();
            target.Header = "first"; 
            target.Text = "Content1";
            string expected = "<div><h3>first</h3><div>Content1</div></div>";
            //get the control html as string
            actual = AccordionHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Returns the Html as string
        /// </summary>
        /// <param name="target">AccordionOptionBuilder object</param>
        /// <returns>accordion html as string</returns>
        public string AccordionHtmlBuilder(AccordionSectionBuilder target)
        {
            string Htmltext = string.Empty;
            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
                writer.RenderBeginTag(_startTag);
                target.Control.Render(writer);
                writer.RenderEndTag();
                Htmltext = stringWriter.ToString();
            }
            return Htmltext;
        }
    }
}
