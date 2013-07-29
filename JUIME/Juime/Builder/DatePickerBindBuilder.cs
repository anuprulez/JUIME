using System;
using Juime.Extensions;

namespace Juime.Builder
{
    public class DatePickerBindBuilder : ControlBindBuilder<DatePickerBind, DatePickerBindBuilder>
    {
        /// <summary>
        /// get/set the value of the datepicker control
        /// </summary>
        public DateTime Value
        {
            get
            {
                return base.BindControl.Value;
            }
            set
            {
                base.BindControl.Value = value;
            }
        }
    }
}
