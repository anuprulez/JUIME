using System.Web.Routing;
using Juime.Extensions;

namespace Juime.Builder
{
    public class DatePickerOptionBuilder : ControlOptionBuilder<DatePickerOption, DatePickerOptionBuilder>
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
        /// get/set Right to left property for the options of the control
        /// </summary>
        public bool? IsRtl
        {
            get
            {
                return base.OptionControl.IsRtl;
            }
            set
            {
                base.OptionControl.IsRtl = value;
            }
        }
    }
}


