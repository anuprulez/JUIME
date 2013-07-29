using System;

namespace Juime.Attributes
{
    /// <summary>
    /// This class takes properties having CustomHtmlAttribute as their attribute class
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomHtmlAttribute : BaseAttribute
    {
        /// <summary>
        /// Constructor that takes the attribute name
        /// </summary>
        /// <param name="name"></param>
        public CustomHtmlAttribute(string name)
            :base(name)
        {
        }
    }
}
