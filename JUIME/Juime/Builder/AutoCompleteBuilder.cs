using System;
using Juime.Extensions;

namespace Juime.Builder
{
    /// <summary>
    /// Builder that builds the AutoComplete widget
    /// </summary>
    public class AutoCompleteBuilder : ControlBuilder<AutoComplete, AutoCompleteBuilder>
    {
        /// <summary>
        /// Constructor that sets the bind and tag attributes
        /// </summary>
        /// <param name="controlName"></param>
        public AutoCompleteBuilder(string controlName)
            : base(controlName, "autocomplete")
        {
            this.Control.Bind = new ControlBind();
            this.Control.TagName = "input";
        }

        /// <summary>
        /// This method takes the options structure of the Autocomplete
        /// </summary>
        /// <param name="addAction">Action of AutoCompleteOptionBuilder type</param>
        /// <returns>AutoCompleteBuilder object</returns>
        public AutoCompleteBuilder Options(Action<AutoCompleteOptionBuilder> addAction)
        {
            AutoCompleteOptionBuilder builder = new AutoCompleteOptionBuilder();
            this.Control.Option = builder.OptionControl;
            if (addAction != null)
                addAction(builder);
            return this;
        }

        /// <summary>
        /// This method takes the options structure of the Autocomplete
        /// </summary>
        /// <param name="addAction">Action of AutoCompleteBindBuilder type</param>
        /// <returns>AutoCompleteBindBuilder object</returns>
        public AutoCompleteBuilder Bind(Action<AutoCompleteBindBuilder> addAction)
        {
            AutoCompleteBindBuilder builder = new AutoCompleteBindBuilder();
            this.Control.Bind = builder.BindControl;
            if (addAction != null)
                addAction(builder);
            return this;
        }        
    }
}
