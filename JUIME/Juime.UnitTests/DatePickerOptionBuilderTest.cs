using System.IO;
using System.Web.UI;
using Juime.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Juime.UnitTests
{
    /// <summary>
    ///This is a test class for DatePickerOptionBuilderTest and is intended
    ///to contain all DatePickerOptionBuilderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DatePickerOptionBuilderTest
    {
        private const string _startTag = "input";
        private string returnHtml = string.Empty;
        private string actual = string.Empty;
        
        /// <summary>
        /// Checks the Css class
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void HtmlAttribute_SetsCssClassAttribute()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            DatePickerOptionBuilder target = new DatePickerOptionBuilder();
            string expected = target.CssClass = "Sample";
            //get the control html as string
            returnHtml = DatePickerHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "class", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the Html attributes
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void HtmlAttribute_SetsCustomHtmlAttribute()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            DatePickerOptionBuilder target = new DatePickerOptionBuilder();
            target.HtmlAttributeList = new { CustomHtmlAttribute = "Sample"};
            string expected = "Sample";
            //get the control html as string
            returnHtml = DatePickerHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "CustomHtmlAttribute", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the Rtl attribute
        /// </summary>
        [TestMethod()]
        [TestCategory("DatePicker")]
        public void HtmlAttribute_SetsRtlAttribute()
        {
            actual = string.Empty;
            returnHtml = string.Empty;
            DatePickerOptionBuilder target = new DatePickerOptionBuilder();
            target.IsRtl = true;
            string expected = "{\"isRTL\":true}";
            //get the control html as string
            returnHtml = DatePickerHtmlBuilder(target);
            //returns the value of the attribute
            actual = Utility.GetAttribute(returnHtml, "data-control-options", _startTag);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Returns the Html as string
        /// </summary>
        /// <param name="target">DatePickerOptionBuilder object</param>
        /// <returns>Datepicker html as string</returns>
        public string DatePickerHtmlBuilder(DatePickerOptionBuilder target)
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
