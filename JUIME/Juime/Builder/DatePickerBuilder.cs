using System;
using Juime.Extensions;

namespace Juime.Builder
{
    /// <summary>
    /// Builder that builds the DatePicker widget
    /// </summary>
    public class DatePickerBuilder : ControlBuilder<DatePicker, DatePickerBuilder>
    {
        /// <summary>
        /// Gets the type of the control
        /// </summary>
        /// <param name="controlName"></param>
        public DatePickerBuilder(string controlName)
            : base(controlName, "datepicker")
        {
            this.Control.Bind = new ControlBind();
            this.Control.TagName = "input";
        }

        /// <summary>
        /// This method takes the options structure of the control
        /// </summary>
        /// <param name="addAction">Action of DatePickerOptionBuilder type</param>
        /// <returns>DatePickerOptionBuilder object</returns>
        public DatePickerBuilder Options(Action<DatePickerOptionBuilder> addAction)
        {
            DatePickerOptionBuilder builder = new DatePickerOptionBuilder();
            this.Control.Option = builder.OptionControl;
            if (addAction != null)
                addAction(builder);
            return this;
        }

        /// <summary>
        /// This method takes the bind structure of the control
        /// </summary>
        /// <param name="addAction">Action of DatePickerBindBuilder type</param>
        /// <returns>DatePickerBindBuilder object</returns>
        public DatePickerBuilder Bind(Action<DatePickerBindBuilder> addAction)
        {
            DatePickerBindBuilder builder = new DatePickerBindBuilder();
            this.Control.Bind = builder.BindControl;
            if (addAction != null)
                addAction(builder);
            return this;
        }        
    }
}
