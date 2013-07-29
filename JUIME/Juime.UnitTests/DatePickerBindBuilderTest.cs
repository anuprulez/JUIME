using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Juime.Builder;
using Juime.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juime.UnitTests
{
    /// <summary>
    ///This is a test class for DatePickerBindBuilderTest and is intended
    ///to contain all DatePickerBindBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatePickerBindBuilderTest
    {
        private const string _startTag = "input";
        private string returnHtml = string.Empty;
        private string actual = string.Empty;

        /// <summary>
        /// Checks the Data type of the control
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void Constructor_SetsDataType()
        {
            actual = string.Empty;
            DatePickerBindBuilder target = new DatePickerBindBuilder();
            actual = "text";
            Assert.AreEqual(target.BindControl.DataType, actual);
        }

        /// <summary>
        /// Checks the value
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void HtmlAttribute_SetsBindValue()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            DatePickerBindBuilder target = new DatePickerBindBuilder();
            target.Value = new DateTime();
            string expected = "01-01-0001 00:00:00";
            //get the control html as string
            returnHtml = DatePickerHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "value", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the entire html
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void HtmlAttribute_SetsCompleteBind()
        {
            actual = string.Empty;
            DatePickerBindBuilder target = new DatePickerBindBuilder();
            target.Value = new DateTime();
            string expected = "<input data-control-bind-source=\"{}\" value=\"01-01-0001 00:00:00\" type=\"text\" />";
            //get the control html as string
            actual = DatePickerHtmlBuilder(target).StringReplace();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Returns the Html as string
        /// </summary>
        /// <param name="target">DatePickerBindBuilder object</param>
        /// <returns>DatePicker html as string</returns>
        public string DatePickerHtmlBuilder(DatePickerBindBuilder target)
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
