using System.Web.Routing;
using Juime.Extensions;

namespace Juime.Builder
{
    /// <summary>
    /// Represents all the options for the Accordion
    /// </summary>
    public class AccordionOptionBuilder : ControlOptionBuilder<AccordionOption, AccordionOptionBuilder>
    {
        /// <summary>
        /// get/set properties for the options of the control
        /// </summary>
        public string CssClass
        {
            get
            {
                return base.OptionControl.CssClass;
            }
            set
            {
                base.OptionControl.CssClass = value;
            }
        }

        /// <summary>
        /// gets/sets all the html attributes specified
        /// </summary>
        public object HtmlAttributeList
        {
            get
            {
                return base.OptionControl.HtmlAttributeList;
            }
            set
            {
                base.OptionControl.HtmlAttributeList = new RouteValueDictionary(value);
            }
        }

        /// <summary>
        /// gets/sets the Collapsible attribute
        /// </summary>
        public bool? Collapsible
        {
            get
            {
                return base.OptionControl.Collapsible;
            }
            set
            {
                base.OptionControl.Collapsible = value;
            }
        }

        /// <summary>
        /// gets/sets the Active attribute
        /// </summary>
        public int? Active
        {
            get
            {
                return base.OptionControl.Active;
            }
            set
            {
                base.OptionControl.Active = value;
            }
        }
    }
}


