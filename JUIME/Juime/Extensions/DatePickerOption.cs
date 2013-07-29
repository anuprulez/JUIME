using Juime.Attributes;

namespace Juime.Extensions
{
    /// <summary>
    /// This class is for options of the datepicker
    /// </summary>
    public class DatePickerOption : ControlOptions
    {
        /// <summary>
        /// Right to left attribute
        /// </summary>
        [JsonSerializable("isRTL")]
        public bool? IsRtl
        {
            get;
            set;
        }     
    }
}
