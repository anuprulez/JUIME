using System.IO;
using System.Web.UI;
using Juime.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juime.UnitTests
{ 
    /// <summary>
    ///This is a test class for TabBuilderTest and is intended
    ///to contain all TabBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TabBuilderTest
    {
        private const string _startTag = "div";
        private string returnHtml = string.Empty;
        private string actual = string.Empty;

        /// <summary>
        /// Checks the Id of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void Constructor_SetsId()
        {
            actual = string.Empty;
            TabBuilder target = new TabBuilder("tab");
            actual = "tab";
            Assert.AreEqual(target.Control.Id, actual);
        }

        /// <summary>
        /// Checks the type of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void Constructor_SetsType()
        {
            actual = string.Empty;
            TabBuilder target = new TabBuilder("tab");
            actual = "tab";
            Assert.AreEqual(target.Control.ControlType, actual);
        }

        /// <summary>
        /// Checks the tag name of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void Constructor_SetsTagName()
        {
            actual = string.Empty;
            TabBuilder target = new TabBuilder("tab");
            actual = "div";
            Assert.AreEqual(target.Control.TagName, actual);
        }

        /// <summary>
        /// Checks the Options object for Null
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void Constructor_SetsOptions()
        {
            TabBuilder target = new TabBuilder("tab");
            Assert.IsNotNull(target.Control.Option);
        }

        /// <summary>
        /// Checks the Children object for Null
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void Constructor_SetsControls()
        {
            TabBuilder target = new TabBuilder("tab");
            Assert.IsNotNull(target.Control.Controls);
        }
        
        /// <summary>
        /// Checks the entire div with attributes
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void Render_Begin_SetsDivWithAttributes()
        {
            actual = string.Empty;
            string expected = "<div id=\"tab\" data-control-type=\"tab\" data-control-options=\"{}\"><ul></ul></div>";
            TabBuilder target = new TabBuilder("tab");
            actual = TabHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the data control options 
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void Render_Begin_SetsOptions()
        {
            actual = string.Empty;
            string expected = "<div id=\"tab\" data-control-type=\"tab\" data-control-options=\"{&quot;active&quot;:1}\"><ul></ul></div>";
            TabBuilder target = new TabBuilder("tab");
            target.Options(option => option.Active = 1);
            actual = TabHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the sections
        /// </summary>
        [TestMethod()]
        [TestCategory("Tab")]
        public void Render_Begin_SetsSection()
        {
            actual = string.Empty;
            string expected = "<div id=\"tab\" data-control-type=\"tab\" data-control-options=\"{}\"><ul><li><a href=\"#tabs-1\">First Tab</a></li></ul><div id=\"tabs-1\">Sample Content for First Tab</div></div>";
            TabBuilder target = new TabBuilder("tab");
            target.Panels(panels =>
                {
                    panels.Add(panel =>
                    {
                        panel.Header = "First Tab";
                        panel.Text = "Sample Content for First Tab";
                    }
                );
            });

            actual = TabHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Returns the Html as string
        /// </summary>
        /// <param name="target">tabOptionBuilder object</param>
        /// <returns>tab html as string</returns>
        public string TabHtmlBuilder(TabBuilder target)
        {
            string Htmltext = string.Empty;
            using (StringWriter stringWriter = new StringWriter())
            {
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
                target.Control.Render(writer);
                Htmltext = stringWriter.ToString();
            }
            return Htmltext;
        }
    }
}
