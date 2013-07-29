using System.Collections.Generic;
using System.Web.Routing;
using System.Web.UI;
using Juime.Attributes;

namespace Juime
{
    public class ControlOptions
    {
        /// <summary>
        /// get/set Css class 
        /// </summary>
        [CustomHtmlAttribute("class")]
        public string CssClass
        {
            get;
            set;
        }

        /// <summary>
        /// get/set Html attributes
        /// </summary>
        public RouteValueDictionary HtmlAttributeList
        {
            get;
            set;
        }

        /// <summary>
        /// This method is used for making key-value pair of web control's options
        /// For example, in the case of Accordion, it has several options like 'collapsible', 'active'
        /// It takes the key(options names) with their values and add them as attributes in the div tag
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public virtual void Render(HtmlTextWriter writer)
        {
            if (writer != null)
            {
                // gets the serialized values of options
                string serializedProperties = AttributeHelper.GetSerializedProperties(this);
                // adding those serialized values as attributes
                writer.AddAttribute("data-control-options", serializedProperties);

                // gets the html properties
                Dictionary<string, object> htmlProperties = AttributeHelper.GetHtmlProperties(this);
                // adds the html properties as attributes in the tag
                foreach (KeyValuePair<string, object> property in htmlProperties)
                {
                    writer.AddAttribute(property.Key, property.Value.ToString());
                }

                if (HtmlAttributeList != null)
                {
                    foreach (KeyValuePair<string, object> htmlAttribute in HtmlAttributeList)
                    {
                        // adds html attributes to the tag
                        writer.AddAttribute(htmlAttribute.Key, htmlAttribute.Value.ToString());
                    }
                }
            }
        }
    }
}
