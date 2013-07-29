using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;
using Juime.Attributes;

namespace Juime
{
    internal static class AttributeHelper
    {        
        /// <summary>
        /// This method is used to get the properties and their values
        /// </summary>
        /// <typeparam name="TResult">type of the properties</typeparam>
        /// <param name="properties">collection of properties</param>
        /// <returns>A dictionary object</returns>
        public static Dictionary<string, object> GetProperties<TResult>(object properties)
            where TResult : BaseAttribute
        {
            Dictionary<string, object> htmlProperties = new Dictionary<string, object>();
            PropertyInfo[] propertiesInfo = properties.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in propertiesInfo)
            {
                object propertyValue = propertyInfo.GetValue(properties);
                if (propertyValue != null)
                {
                    var htmlProperty = propertyInfo.GetCustomAttributes(false)
                                                    .OfType<TResult>()
                                                    .FirstOrDefault();
                    if (htmlProperty != null)
                    {
                        htmlProperties.Add(htmlProperty.StringName, propertyValue);
                    }
                }
            }
            return htmlProperties;
        }

        /// <summary>
        /// Gets the html properties 
        /// </summary>
        /// <param name="properties">collection of properties</param>
        /// <returns>A dictionary of html properties with their values</returns>
        public static Dictionary<string, object> GetHtmlProperties(object properties)
        {
            return GetProperties<CustomHtmlAttribute>(properties);            
        }

        /// <summary>
        /// Gets the properties in serialized form
        /// </summary>
        /// <param name="properties">collection of properties</param>
        /// <returns>JavaScriptSerializer object</returns>
        public static string GetSerializedProperties(object properties)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();            
            return serializer.Serialize(GetProperties<JsonSerializableAttribute>(properties));
        }
    }
}
