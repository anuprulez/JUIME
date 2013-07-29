using System;
using Juime.Extensions;

namespace Juime.Builder
{
    public class TabPanelFactory
    {
        private Tab tab;

        /// <summary>
        /// Constructor that sets the tab property
        /// </summary>
        /// <param name="tab"></param>
        public TabPanelFactory(Tab tab)
        {
            this.tab = tab;     
        }

        /// <summary>
        /// This method takes each panel structure of the Tab control
        /// </summary>
        /// <param name="addAction">Action of TabPanelBuilder type</param>
        /// <returns>TabPanelBuilder object</returns>
        public TabPanelBuilder Add(Action<TabPanelBuilder> addAction)
		{
            TabPanelBuilder builder = new TabPanelBuilder();
            this.tab.Controls.Add(builder.Control);
            if (addAction != null)
                addAction(builder);
            return builder;
		}
    }
}
