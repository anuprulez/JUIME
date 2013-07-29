using System.IO;
using System.Web.UI;
using Juime.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juime.UnitTests
{
    /// <summary>
    ///This is a test class for TabPanelBuilderTest and is intended
    ///to contain all TabPanelBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TabPanelBuilderTest
    {
        private const string _startTag = "div";
        private string returnHtml = string.Empty;
        private string actual = string.Empty;

        /// <summary>
        /// Checks the Href attribute panel header
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void HtmlAttribute_SetsPanelHeaderHref()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            TabPanelBuilder target = new TabPanelBuilder();
            target.Header = "first";
            string expected = "#tabs-1";
            //get the control html as string
            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
                target.Control.RenderHeader(writer);                
                returnHtml = stringWriter.ToString();
            }
            actual = Utility.GetAttribute(returnHtml, "href", "li/a");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the innertext of panel header
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void HtmlAttribute_SetsPanelHeaderInnertext()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            TabPanelBuilder target = new TabPanelBuilder();
            string expected = target.Header = "first";
            //get the control html as string
            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
                target.Control.RenderHeader(writer);
                returnHtml = stringWriter.ToString();
            }
            actual = Utility.GetSection(returnHtml, "li/a");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the innertext of panel item 
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void HtmlAttribute_SetsPanelText()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            TabPanelBuilder target = new TabPanelBuilder();
            string expected = target.Text = "lorem ipsum";             
            //get the control html as string
            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
                target.Control.RenderText(writer);
                returnHtml = stringWriter.ToString().StringReplace();
            }
            actual = Utility.GetSection(returnHtml, "div");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the entire section's html
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void HtmlAttribute_SetsCompletePanel()
        {
            actual = string.Empty;
            TabPanelBuilder target = new TabPanelBuilder();
            target.Header = "first"; 
            target.Text = "Content1";
            string expected = "<ul><li><a href=\"#tabs-1\">first</a></li></ul><div id=\"tabs-1\">Content1</div>";

            //gets the complete html as string
            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
                writer.RenderBeginTag("ul");
                target.Control.RenderHeader(writer);
                writer.RenderEndTag();
                target.Control.RenderText(writer);
                actual = stringWriter.ToString().StringReplace();
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
