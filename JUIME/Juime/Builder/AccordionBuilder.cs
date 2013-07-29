using System;
using System.Collections.Generic;
using Juime.Extensions;

namespace Juime.Builder
{
    /// <summary>
    /// Builder that builds the Accordion widget
    /// </summary>
    public class AccordionBuilder : ControlBuilder<Accordion, AccordionBuilder>
    {
        /// <summary>
        /// Gets the type of the control
        /// </summary>
        /// <param name="controlName"></param>
        public AccordionBuilder(string controlName)
            : base(controlName,"accordion")
        {
            this.Control.Controls = new List<Control>();
            this.Control.TagName = "div";
        }

        /// <summary>
        /// This method takes the options structure of the control
        /// </summary>
        /// <param name="addAction">Action of AccordionOptionBuilder type</param>
        /// <returns>AccordionOptionBuilder object</returns>
        public AccordionBuilder Options(Action<AccordionOptionBuilder> addAction)
        {
            AccordionOptionBuilder builder = new AccordionOptionBuilder();
            this.Control.Option = builder.OptionControl;
            if(null != addAction)
                addAction(builder);
            return this;
        }

        /// <summary>
        /// This method takes the sections structure of the control
        /// </summary>
        /// <param name="addAction">Action of AccordionSectionFactory type</param>
        /// <returns>AccordionSectionFactory object</returns>
        public AccordionBuilder Sections(Action<AccordionSectionFactory> addAction)
        {
            AccordionSectionFactory factory = new AccordionSectionFactory(base.Control);
            if (null != addAction)
                addAction(factory);
            return this;
        }        
    }
}
