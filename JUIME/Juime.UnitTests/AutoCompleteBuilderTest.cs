using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Juime.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juime.UnitTests
{ 
    /// <summary>
    ///This is a test class for AutoCompleteBuilderTest and is intended
    ///to contain all AutoCompleteBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AutoCompleteBuilderTest
    {
        private const string _startTag = "input";
        private string returnHtml = string.Empty;
        private string actual = string.Empty;

        /// <summary>
        /// Checks the Id of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void Constructor_SetsId()
        {
            actual = string.Empty;
            AutoCompleteBuilder target = new AutoCompleteBuilder("autocomplete");
            actual = "autocomplete";
            Assert.AreEqual(target.Control.Id, actual);
        }

        /// <summary>
        /// Checks the type of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void Constructor_SetsType()
        {
            actual = string.Empty;
            AutoCompleteBuilder target = new AutoCompleteBuilder("autocomplete");
            actual = "autocomplete";
            Assert.AreEqual(target.Control.ControlType, actual);
        }

        /// <summary>
        /// Checks the tag name of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void Constructor_SetsTagName()
        {
            actual = string.Empty;
            AutoCompleteBuilder target = new AutoCompleteBuilder("autocomplete");
            actual = "input";
            Assert.AreEqual(target.Control.TagName, actual);
        }

        /// <summary>
        /// Checks the Options object for Null
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void Constructor_SetsOptions()
        {
            AutoCompleteBuilder target = new AutoCompleteBuilder("autocomplete");
            Assert.IsNotNull(target.Control.Option);
        }

        /// <summary>
        /// Checks the Bind object for Null
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void Constructor_SetsBind()
        {
            AutoCompleteBuilder target = new AutoCompleteBuilder("autocomplete");
            Assert.IsNotNull(target.Control.Bind);
        }
        
        /// <summary>
        /// Checks the entire input with empty attributes
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void Render_Begin_SetsDivWithAttributes()
        {
            actual = string.Empty;
            string expected = "<input id=\"autocomplete\" data-control-type=\"autocomplete\" data-control-options=\"{}\" data-control-bind-source=\"{}\" />";
            AutoCompleteBuilder target = new AutoCompleteBuilder("autocomplete");
            actual = AutoCompleteHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the complete input with data control options 
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void Render_Begin_SetsOptions()
        {
            actual = string.Empty;
            string expected = "<input id=\"autocomplete\" data-control-type=\"autocomplete\" data-control-options=\"{&quot;disabled&quot;:true}\" data-control-bind-source=\"{}\" />";
            AutoCompleteBuilder target = new AutoCompleteBuilder("autocomplete");
            target.Options(option => option.Disabled = true);
            actual = AutoCompleteHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the complete input with Bind
        /// </summary>
        [TestMethod()]
        [TestCategory("AutoComplete")]
        public void Render_Begin_SetsBind()
        {
            actual = string.Empty;
            string expected = "<input id=\"autocomplete\" data-control-type=\"autocomplete\" data-control-options=\"{}\" data-control-bind-source=\"{&quot;source&quot;:[&quot;India&quot;,&quot;US&quot;]}\" value=\"--country--\" type=\"text\" />";
            AutoCompleteBuilder target = new AutoCompleteBuilder("autocomplete");
            target.Bind(item =>
                        {
                            item.Value = "--country--";
                            item.Source = new List<string> { "India", "US" };
                        }
            );

            actual = AutoCompleteHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Returns the Html as string
        /// </summary>
        /// <param name="target">AutoCompleteBuilder object</param>
        /// <returns>AutoComplete html as string</returns>
        public string AutoCompleteHtmlBuilder(AutoCompleteBuilder target)
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
