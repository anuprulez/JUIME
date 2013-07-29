using System.Collections.Generic;
using Juime.Extensions;

namespace Juime.Builder
{
    public class AutoCompleteBindBuilder : ControlBindBuilder<AutoCompleteBind, AutoCompleteBindBuilder>
    {
        /// <summary>
        /// get/set the Value attribute for the Autocomplete control 
        /// </summary>
        public string Value
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

        /// <summary>
        /// get/set the datasource attribute for the Autocomplete control 
        /// </summary>
        public List<string> Source
        {
            get
            {
                return base.BindControl.Source;
            }
            set
            {
                base.BindControl.Source = value;
            }
        }
    }
}
