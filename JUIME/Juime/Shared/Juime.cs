using System.Web.Mvc;
using Juime.Builder;

namespace Juime
{
    public class JuimeHelper
    {
        /// <summary>
        /// get/set Html helper object
        /// </summary>
        public HtmlHelper HtmlHelper
        {
            get;
            set;
        }

        /// <summary>
        /// Class's constructor 
        /// Sets the htmlhelper  
        /// </summary>
        /// <param name="htmlHelper">The HtmlHelper</param>
        public JuimeHelper(HtmlHelper htmlHelper)
		{
			this.HtmlHelper = htmlHelper;
		}

        /// <summary>
        /// Method for creating Accordion
        /// </summary>
        /// <param name="controlName">Control name</param>
        /// <returns>AccordionBuilder object with control's name as parameter</returns>
        public virtual AccordionBuilder Accordion(string controlName)
        {
            return new AccordionBuilder(controlName);
        }

        /// <summary>
        /// Method for creating DatePicker
        /// </summary>
        /// <param name="controlName">Control name</param>
        /// <returns>DatePickerBuilder object with control's name as parameter</returns>
        public virtual DatePickerBuilder DatePicker(string controlName)
        {
            return new DatePickerBuilder(controlName);
        }

        /// <summary>
        /// Method for creating AutoComplete
        /// </summary>
        /// <param name="controlName">Control name</param>
        /// <returns>AutoCompleteBuilder object with control's name as parameter</returns>
        public virtual AutoCompleteBuilder AutoComplete(string controlName)
        {
            return new AutoCompleteBuilder(controlName);
        }

        /// <summary>
        /// Method for creating Tab
        /// </summary>
        /// <param name="controlName">Control name</param>
        /// <returns>TabBuilder object with control's name as parameter</returns>
        public virtual TabBuilder Tab(string controlName)
        {
            return new TabBuilder(controlName);
        }
    }
}
