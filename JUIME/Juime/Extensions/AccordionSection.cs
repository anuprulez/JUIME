using System.Web.UI;

namespace Juime.Extensions
{
    /// <summary>
    /// This class is for all the sections of the Accordion
    /// </summary>
    public class AccordionSection : Control
    {
        
        /// <summary>
        /// Takes the content of the tab panel
        /// </summary>
        public string Text
        {
            get;
            set;
        }
        
        /// <summary>
        /// Takes the tab panel heading
        /// </summary>
        public string Header
        {
            get;
            set;
        }

        /// <summary>
        /// Builds the repeated html for the Accordion
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public override void Render(HtmlTextWriter writer)
        {
            if (writer != null)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.H3);
                writer.Write(this.Header);
                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.Write(this.Text);
                writer.RenderEndTag();
            }
        }
    }
}
