using System.Web.Routing;
using Juime.Extensions;

namespace Juime.Builder
{
    public class TabOptionBuilder : ControlOptionBuilder<TabOption, TabOptionBuilder>
    {
        /// <summary>
        /// get/set Css class for the options of the control
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
        /// get/set Html attributes for the options of the control
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
