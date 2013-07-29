using Juime.Extensions;

namespace Juime.Builder
{
    /// <summary>
    /// Represents all the section properties of the Accordion
    /// </summary>
    public class AccordionSectionBuilder : ControlBuilder<AccordionSection, AccordionSectionBuilder>
    {
        /// <summary>
        /// gets/sets properties for the sections of the control
        /// </summary>
        public string Header
        {
            get
            {
                return base.Control.Header;
            }
            set
            {
                base.Control.Header = value;
            }
        }

        /// <summary>
        /// gets/sets the content of the control
        /// </summary>
        public string Text
        {
            get
            {
                return base.Control.Text;
            }
            set
            {
                base.Control.Text = value;
            }
        }
    }
}
