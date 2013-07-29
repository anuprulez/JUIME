using Juime.Attributes;

namespace Juime.Extensions
{
    /// <summary>
    /// This class is for the options of the Accordion
    /// </summary>
    public class AccordionOption : ControlOptions
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
