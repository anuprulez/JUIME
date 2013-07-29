using Juime.Attributes;

namespace Juime.Extensions
{
    /// <summary>
    /// This class is for options of Autocomplete
    /// </summary>
    public class AutoCompleteOption : ControlOptions
    {
        /// <summary>
        /// Disabled attribute
        /// </summary>
        [JsonSerializable("disabled")]
        public bool? Disabled
        {
            get;
            set;
        }     
    }
}
