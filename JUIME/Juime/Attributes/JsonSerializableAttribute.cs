using System;

namespace Juime.Attributes
{
    /// <summary>
    /// This class takes properties having JsonSerializableAttribute as their attribute class
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class JsonSerializableAttribute : BaseAttribute
    {
        /// <summary>
        /// Constructor that takes the attribute name
        /// </summary>
        /// <param name="name"></param>
        public JsonSerializableAttribute(string name)
            : base(name)
        {
        }        
    }
}
