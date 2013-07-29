using System;
using Juime.Attributes;

namespace Juime.Extensions
{
    /// <summary>
    /// This class is for Bind of the datepicker
    /// </summary>
    public class DatePickerBind : ControlBind
    {
        /// <summary>
        /// gets/sets the value attribute for Autocomplete control
        /// </summary>
        [CustomHtmlAttribute("value")]
        public DateTime Value
        {
            get;
            set;
        }

        /// <summary>
        /// gets/sets the value attribute for Autocomplete control
        /// </summary>
        [CustomHtmlAttribute("type")]
        public string DataType
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor that sets the DataType of the control
        /// </summary>
        public DatePickerBind()
        {
            this.DataType = "text";
        }
    }
}
