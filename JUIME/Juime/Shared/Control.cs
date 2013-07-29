using System.Collections.Generic;
using System.Web.UI;

namespace Juime
{
    public abstract class Control
    {
        /// <summary>
        /// get/set Id attribute of the control
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// get/set type of attribute of the control
        /// </summary>
        public string ControlType
        {
            get;
            set;
        }

        /// <summary>
        /// get/set data control options attribute of the control
        /// </summary>
        public ControlOptions Option
        {
            get;
            set;
        }

        /// <summary>
        /// get/set children of the control
        /// </summary>
        public List<Control> Controls
        {
            get;
            set;
        }

        /// <summary>
        /// get/set datasource attribute of the control
        /// </summary>
        public ControlBind Bind
        {
            get;
            set;
        }

        /// <summary>
        /// get/set tag name of the control
        /// </summary>
        public string TagName
        {
            get;
            set;
        }

        /// <summary>
        /// This method is used for adding attributes for the div tag before div's creation
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public virtual void RenderBegin(HtmlTextWriter writer)
        {
            if (writer != null)
            {
                // adds the attributes
                RenderAttributes(writer);

                // adds the options attributes
                if (Option != null)
                {
                    RenderOptions(writer);
                }
                // adds the bind attributes
                if (Bind != null)
                {
                    RenderBind(writer);
                }
                writer.RenderBeginTag(this.TagName);
            }
        }

        /// <summary>
        /// This method to be overridden if some custom html is needed for any control
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public virtual void RenderContent(HtmlTextWriter writer)
        {

        }

        /// <summary>
        /// This method is used for adding all children's html
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public virtual void RenderChildren(HtmlTextWriter writer)
        {
            foreach (Control childControl in Controls)
            {
                childControl.Render(writer);
            }
        }

        /// <summary>
        /// This mehtod adds the end tag
        /// </summary>
        /// <param name="writer">HtmlTextWriter object</param>
        public virtual void RenderEnd(HtmlTextWriter writer)
        {
            if (writer != null)
                writer.RenderEndTag();
        }

        /// <summary>
        /// This mehtod adds the options as attributes
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public virtual void RenderOptions(HtmlTextWriter writer)
        {
            Option.Render(writer);
        }

        /// <summary>
        /// This method adds the bind as attribute
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public virtual void RenderBind(HtmlTextWriter writer)
        {
            Bind.Render(writer);
        }

        /// <summary>
        /// This method adds the 'id' and 'data-control-type' attributes to the div tag
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public virtual void RenderAttributes(HtmlTextWriter writer)
        {
            if (writer != null)
            {
                writer.AddAttribute("id", this.Id);
                writer.AddAttribute("data-control-type", this.ControlType);
            }
        }

        /// <summary>
        /// Calls the respective render methods 
        /// for constructing the entire html for any control
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        public virtual void Render(HtmlTextWriter writer)
        {
            RenderBegin(writer);
            RenderContent(writer);
            if (Controls != null)
            {
                RenderChildren(writer);
            }
            RenderEnd(writer);          
        }        
    }
}
