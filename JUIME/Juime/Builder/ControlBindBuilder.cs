
namespace Juime.Builder
{
    /// <summary>
    /// Base class for all the builders to bind the data
    /// </summary>
    /// <typeparam name="TControlBind">type of control bind</typeparam>
    /// <typeparam name="TBuilder">type of builder</typeparam>
    public abstract class ControlBindBuilder<TControlBind, TBuilder> : BaseBuilder<TBuilder>
        where TControlBind : ControlBind, new()
        where TBuilder : ControlBindBuilder<TControlBind, TBuilder>
    {
        private TControlBind bindControl;
        
        /// <summary>
        /// get/set BindControl property
        /// </summary>
		public TControlBind BindControl
		{
			get
			{
				return this.bindControl;
			}
			set
			{
				this.bindControl = value;
			}
		}

        /// <summary>
        /// Constructor that sets the bindcontrol property 
        /// </summary>
        public ControlBindBuilder()
        {
            this.bindControl = new TControlBind();
        }
    }
}
