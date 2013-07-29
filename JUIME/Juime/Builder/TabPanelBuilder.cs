using Juime.Extensions;

namespace Juime.Builder
{
    public class TabPanelBuilder : ControlBuilder<TabPanel, TabPanelBuilder>
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
