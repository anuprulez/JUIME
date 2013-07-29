using Juime.Attributes;

namespace Juime.Extensions
{
    /// <summary>
    /// This class is for options of the Tab
    /// </summary>
    public class TabOption : ControlOptions
    {
        /// <summary>
        /// Collapsible attributes
        /// </summary>
        [JsonSerializable("collapsible")]
        public bool? Collapsible
        {
            get;
            set;
        }

        /// <summary>
        /// Active attribute
        /// </summary>
        [JsonSerializable("active")]
        public int? Active
        {
            get;
            set;
        }
    }
}
