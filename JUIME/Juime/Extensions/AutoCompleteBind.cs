using System.Collections.Generic;
using Juime.Attributes;

namespace Juime.Extensions
{
    /// <summary>
    /// This class is for the Bind of the Autocomplete
    /// </summary>
    public class AutoCompleteBind : ControlBind
    {
        /// <summary>
        /// gets/sets the value attribute for Autocomplete control
        /// </summary>
        [CustomHtmlAttribute("value")]
        public string Value
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
        // 
        /// <summary>
        /// gets/sets attribute's datasource is in JSON format
        /// </summary>
        [JsonSerializable("source")]
        public List<string> Source
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor that sets the DataType of the control
        /// </summary>
        public AutoCompleteBind()
        {
            this.DataType = "text";
        }
    }
}
