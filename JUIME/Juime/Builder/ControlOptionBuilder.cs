
namespace Juime.Builder
{
    /// <summary>
    /// Base class for all the builders to incorporate the options
    /// </summary>
    /// <typeparam name="TControlOption">type of control options</typeparam>
    /// <typeparam name="TBuilder">type of builder</typeparam>
    public abstract class ControlOptionBuilder<TControlOption, TBuilder> : BaseBuilder<TBuilder>
        where TControlOption : ControlOptions, new()
        where TBuilder : ControlOptionBuilder<TControlOption, TBuilder>
    {
        private TControlOption optionControl;
        
        /// <summary>
        /// get/set OptionControl property
        /// </summary>
		public TControlOption OptionControl
		{
			get
			{
				return this.optionControl;
			}
			set
			{
				this.optionControl = value;
			}
		}

        /// <summary>
        /// Constructor that sets the Option Control 
        /// </summary>
        protected ControlOptionBuilder()
        {
            this.optionControl = new TControlOption();
        }
    }
}
