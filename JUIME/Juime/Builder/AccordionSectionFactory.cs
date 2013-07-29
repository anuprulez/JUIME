using System;
using Juime.Extensions;

namespace Juime.Builder
{
    public class AccordionSectionFactory
    {
        private Accordion accordion;

        /// <summary>
        /// Constructor takes the Accordion object
        /// </summary>
        /// <param name="accordion">Accordion object</param>
        public AccordionSectionFactory(Accordion accordion)
        {
            this.accordion = accordion;     
        }

        /// <summary>
        /// This method takes the structure of each section
        /// </summary>
        /// <param name="addAction">Action of AccordionSectionBuilder type</param>
        /// <returns>AccordionSectionBuilder object</returns>
        public AccordionSectionBuilder Add(Action<AccordionSectionBuilder> addAction)
		{
            AccordionSectionBuilder builder = new AccordionSectionBuilder();
            this.accordion.Controls.Add(builder.Control);
            if (addAction != null)
                addAction(builder);
            return builder;
		}
    }
}
