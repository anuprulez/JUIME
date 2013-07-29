using System;
using System.Collections.Generic;
using Juime.Extensions;

namespace Juime.Builder
{
    /// <summary>
    /// Builder that builds the Tab widget
    /// </summary>
    public class TabBuilder : ControlBuilder<Tab, TabBuilder>
    {
        /// <summary>
        /// Gets the type of the control
        /// </summary>
        /// <param name="controlName">name of the control</param>
        public TabBuilder(string controlName)
            : base(controlName,"tab")
        {
            this.Control.Controls = new List<Control>();
            this.Control.TagName = "div";
        }

        /// <summary>
        ///  This method takes the options structure of the control
        /// </summary>
        /// <param name="addAction">Action of TabOptionBuilder type</param>
        /// <returns>TabOptionBuilder object</returns>
        public TabBuilder Options(Action<TabOptionBuilder> addAction)
        {
            TabOptionBuilder builder = new TabOptionBuilder();
            this.Control.Option = builder.OptionControl;
            if (addAction != null)
                addAction(builder);
            return this;
        }

        /// <summary>
        ///  This method takes the panels structure of the control
        /// </summary>
        /// <param name="addAction">Action of TabPanelFactory type</param>
        /// <returns>TabBuilder object</returns>
        public TabBuilder Panels(Action<TabPanelFactory> addAction)
        {
            TabPanelFactory factory = new TabPanelFactory(base.Control);
            if (addAction != null) 
                addAction(factory);
            return this;
        }        
    }
}
