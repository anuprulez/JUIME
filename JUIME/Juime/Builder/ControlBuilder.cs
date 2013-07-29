using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;

namespace Juime.Builder
{
    /// <summary>
    /// Base class for all the Juime Controls
    /// </summary>
    /// <typeparam name="TControl">type of control</typeparam>
    /// <typeparam name="TBuilder">type of builder</typeparam>
    public abstract class ControlBuilder<TControl, TBuilder> : IHtmlString
        where TControl : Control, new()
        where TBuilder : ControlBuilder<TControl, TBuilder>
    {
        private TControl control;
        
        /// <summary>
        /// get/set Control property
        /// </summary>
		public TControl Control
		{
			get
			{
				return this.control;
			}
			set
			{
				this.control = value;
			}
		}

        /// <summary>
        /// Sets the Id, type and options of the controls
        /// </summary>
        /// <param name="controlName">name of control</param>
        /// <param name="controlType">type of control</param>
        protected ControlBuilder(string controlName, string controlType)
        {
            this.control = new TControl();
            this.control.Id = controlName;
            this.control.ControlType = controlType;
            this.control.Option = new ControlOptions();
        }

        /// <summary>
        /// Constructor that sets the control property
        /// </summary>
        protected ControlBuilder()
        {
            this.control = new TControl();
        }

        /// <summary>
        /// This method gives the entire html of the control
        /// </summary>
        /// <returns>html as string</returns>
        public string ToHtmlString()
        {
            string result;
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                Control.Render(new HtmlTextWriter(stringWriter));
                result = stringWriter.ToString();
            }
            return result;
        }

        /// <summary>
        /// This method returns the ToHtmlString method
        /// </summary>
        /// <returns>ToHtmlString()</returns>
        public override string ToString()
		{
			return this.ToHtmlString();
		}
    }
}
