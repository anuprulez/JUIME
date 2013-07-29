using System.Collections.Generic;
using System.Web.UI;

namespace Juime
{
    public class ControlBind
    {
        /// <summary>
        /// This method is used for binding the datasource for any control as 
        /// serialized values. The datasource is given as list of values
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public virtual void Render(HtmlTextWriter writer)
        {
            if (writer != null)
            {
                //gets the serialized values
                string serializedProperties = AttributeHelper.GetSerializedProperties(this);
                // binds the datasource with data-control-bind-source attribute
                writer.AddAttribute("data-control-bind-source", serializedProperties);

                //gets the html properties and adds them to the tag as attributes
                Dictionary<string, object> htmlProperties = AttributeHelper.GetHtmlProperties(this);
                foreach (KeyValuePair<string, object> property in htmlProperties)
                {
                    writer.AddAttribute(property.Key, property.Value.ToString());
                }
            }
        }
    }
}
