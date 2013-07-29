using System;

namespace Juime.Attributes
{
    /// <summary>
    /// This is the base class for the attribute classes like CustomHtmlAttribute  
    /// and JsonSerializableAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class BaseAttribute : Attribute
    {
        /// <summary>
        /// Sets the name of attribute
        /// </summary>
        /// <param name="name">name</param>
        public BaseAttribute(string name)
        {
            this.StringName = name;
        }

        /// <summary>
        /// Returns the name
        /// </summary>
        public string StringName
        {
            get;
            set;
        }
    }
}
