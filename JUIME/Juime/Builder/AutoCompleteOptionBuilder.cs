using System.Web.Routing;
using Juime.Extensions;

namespace Juime.Builder
{
    public class AutoCompleteOptionBuilder : ControlOptionBuilder<AutoCompleteOption, AutoCompleteOptionBuilder>
    {
        /// <summary>
        /// get/set Css class for the options of the Autocomplete
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
        /// get/set HtmlAttributes for the options of the Autocomplete
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
        /// get/set disabled attribute for the options of the Autocomplete
        /// </summary>
        public bool? Disabled
        {
            get
            {
                return base.OptionControl.Disabled;
            }
            set
            {
                base.OptionControl.Disabled = value;
            }
        }
    }
}


