using System.IO;
using System.Web.UI;
using Juime.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juime.UnitTests
{ 
    /// <summary>
    ///This is a test class for AccordionBuilderTest and is intended
    ///to contain all AccordionBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccordionBuilderTest
    {
        private const string _startTag = "div";
        private string actual = string.Empty;

        /// <summary>
        /// Checks the Id of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void Constructor_SetsId()
        {
            actual = string.Empty;
            AccordionBuilder target = new AccordionBuilder("accordion");
            actual = "accordion";
            Assert.AreEqual(target.Control.Id, actual);
        }

        /// <summary>
        /// Checks the type of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void Constructor_SetsType()
        {
            actual = string.Empty;
            AccordionBuilder target = new AccordionBuilder("accordion");
            actual = "accordion";
            Assert.AreEqual(target.Control.ControlType, actual);
        }

        /// <summary>
        /// Checks the tag name of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void Constructor_SetsTagName()
        {
            actual = string.Empty;
            AccordionBuilder target = new AccordionBuilder("accordion");
            actual = "div";
            Assert.AreEqual(target.Control.TagName, actual);
        }

        /// <summary>
        /// Checks the Options object for Null
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void Constructor_SetsOptions()
        {
            AccordionBuilder target = new AccordionBuilder("accordion");
            Assert.IsNotNull(target.Control.Option);
        }

        /// <summary>
        /// Checks the Children object for Null
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void Constructor_SetsControls()
        {
            AccordionBuilder target = new AccordionBuilder("accordion");
            Assert.IsNotNull(target.Control.Controls);
        }
        
        /// <summary>
        /// Checks the entire div with attributes
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void Render_Begin_SetsDivWithAttributes()
        {
            actual = string.Empty;
            string expected = "<div id=\"accordion\" data-control-type=\"accordion\" data-control-options=\"{}\"></div>";
            AccordionBuilder target = new AccordionBuilder("accordion");
            actual = AccordionHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the data control options 
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void Render_Begin_SetsOptions()
        {
            actual = string.Empty;
            string expected = "<div id=\"accordion\" data-control-type=\"accordion\" data-control-options=\"{&quot;active&quot;:1}\"></div>";
            AccordionBuilder target = new AccordionBuilder("accordion");
            target.Options(option => option.Active = 1);
            actual = AccordionHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the sections
        /// </summary>
        [TestMethod()]
        [TestCategory("Accordion")]
        public void Render_Begin_SetsSection()
        {
            actual = string.Empty;
            string expected = "<div id=\"accordion\" data-control-type=\"accordion\" data-control-options=\"{}\"><h3>first</h3><div>Content1</div></div>";
            AccordionBuilder target = new AccordionBuilder("accordion");
            target.Sections(sections =>
            {
                        sections.Add(section =>
                        {
                            section.Header = "first";
                            section.Text = "Content1";
                        }
                    );
            });

            actual = AccordionHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Returns the Html as string
        /// </summary>
        /// <param name="target">AccordionOptionBuilder object</param>
        /// <returns>accordion html as string</returns>
        public string AccordionHtmlBuilder(AccordionBuilder target)
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
