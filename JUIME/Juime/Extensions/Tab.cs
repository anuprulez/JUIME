using System.Globalization;
using System.Web.UI;

namespace Juime.Extensions
{
    /// <summary>
    /// Tab widget
    /// </summary>
    public class Tab : Control
    {
        /// <summary>
        /// This overridden method is used when custom html code is required 
        /// for any control which cannot be obtained looping through 
        /// the child controls
        /// </summary>
        /// <param name="writer">HtmlTextWriter object</param>
        public override void RenderContent(HtmlTextWriter writer)
        {
            if (Controls != null && writer != null)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                foreach (TabPanel panel in Controls)
                {
                    panel.RenderHeader(writer);
                }
                writer.RenderEndTag();
            }
        }
    }
}
