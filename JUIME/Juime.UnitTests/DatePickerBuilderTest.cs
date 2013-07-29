using System;
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
    public class DatePickerBuilderTest
    {
        private const string _startTag = "input";
        private string returnHtml = string.Empty;
        private string actual = string.Empty;

        /// <summary>
        /// Checks the Id of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void Constructor_SetsId()
        {
            actual = string.Empty;
            DatePickerBuilder target = new DatePickerBuilder("datePicker");
            actual = "datePicker";
            Assert.AreEqual(target.Control.Id, actual);
        }

        /// <summary>
        /// Checks the type of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void Constructor_SetsType()
        {
            actual = string.Empty;
            DatePickerBuilder target = new DatePickerBuilder("datePicker");
            actual = "datepicker";
            Assert.AreEqual(target.Control.ControlType, actual);
        }

        /// <summary>
        /// Checks the tag name of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void Constructor_SetsTagName()
        {
            actual = string.Empty;
            DatePickerBuilder target = new DatePickerBuilder("datePicker");
            actual = "input";
            Assert.AreEqual(target.Control.TagName, actual);
        }

        /// <summary>
        /// Checks the Options object for Null
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void Constructor_SetsOptions()
        {
            DatePickerBuilder target = new DatePickerBuilder("datePicker");
            Assert.IsNotNull(target.Control.Option);
        }

        /// <summary>
        /// Checks the Bind object for Null
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void Constructor_SetsBind()
        {
            DatePickerBuilder target = new DatePickerBuilder("datePicker");
            Assert.IsNotNull(target.Control.Bind);
        }
        
        /// <summary>
        /// Checks the entire input with empty  attributes
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void Render_Begin_SetsDivWithAttributes()
        {
            actual = string.Empty;
            string expected = "<input id=\"datePicker\" data-control-type=\"datepicker\" data-control-options=\"{}\" data-control-bind-source=\"{}\" />";
            DatePickerBuilder target = new DatePickerBuilder("datePicker");
            actual = DatePickerHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the data control options 
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void Render_Begin_SetsOptions()
        {
            actual = string.Empty;
            string expected = "<input id=\"autocomplete\" data-control-type=\"datepicker\" data-control-options=\"{&quot;isRTL&quot;:true}\" data-control-bind-source=\"{}\" />";
            DatePickerBuilder target = new DatePickerBuilder("autocomplete");
            target.Options(option => option.IsRtl = true);
            actual = DatePickerHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the control with the Bind attributes
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void Render_Begin_SetsBind()
        {
            actual = string.Empty;
            string expected = "<input id=\"autocomplete\" data-control-type=\"datepicker\" data-control-options=\"{}\" data-control-bind-source=\"{}\" value=\"01-01-0001 00:00:00\" type=\"text\" />";
            DatePickerBuilder target = new DatePickerBuilder("autocomplete");
            target.Bind(item =>
                        {
                            item.Value = new DateTime(); 
                        }
            );

            actual = DatePickerHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Returns the Html as string
        /// </summary>
        /// <param name="target">DatePickerBuilder object</param>
        /// <returns>DatePicker html as string</returns>
        public string DatePickerHtmlBuilder(DatePickerBuilder target)
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
