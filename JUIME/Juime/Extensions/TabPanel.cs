using System.Globalization;
using System.Web.UI;

namespace Juime.Extensions
{
    /// <summary>
    /// This class is for panels of the Tab
    /// </summary>
    public class TabPanel : Control
    {
        /// <summary>
        /// get/set the content of the panels of the tab
        /// </summary>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// get/set the title of the panels of the tab
        /// </summary>
        public string Header
        {
            get;
            set;
        }

        /// <summary>
        /// Creates the divs to be rendered as tabs' content
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public override void Render(HtmlTextWriter writer)
        {
            RenderText(writer);
        }

        /// <summary>
        /// Creates the header part of the panel
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public void RenderText(HtmlTextWriter writer)
        {
            if (writer != null)
            {
                int CountDiv = 0;
                string htmlText = string.Empty;
                string div = "</div>";
                htmlText = writer.InnerWriter.ToString();
                // gets the count of closing div
                CountDiv = (htmlText.Length - htmlText.Replace(div, "").Length) / div.Length;
                // creates div for panels
                writer.AddAttribute("id", "tabs-" + (CountDiv + 1).ToString(CultureInfo.InvariantCulture));
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.Write(this.Text);
                writer.RenderEndTag();
            }
        }

        /// <summary>
        /// Creates the header part of the panel
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public void RenderHeader(HtmlTextWriter writer)
        {
            if (writer != null)
            {
                int CountLi = 0;
                string li = "</li>";
                string htmlText = string.Empty;
                htmlText = writer.InnerWriter.ToString();
                // gets the count of closing li tag
                CountLi = (htmlText.Length - htmlText.Replace(li, "").Length) / li.Length;
                //creates as many li as number of tabs
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.AddAttribute("href", "#tabs-" + (CountLi + 1).ToString(CultureInfo.InvariantCulture));
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.Write(this.Header);
                writer.RenderEndTag();
                writer.RenderEndTag();
            }
        }
    }
}
