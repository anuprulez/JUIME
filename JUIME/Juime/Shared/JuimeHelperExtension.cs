using System.Web.Mvc;

namespace Juime
{
    public static class JuimeHelperExtension
    {
        /// <summary>
        /// This is the starting method for creating the extensions
        /// </summary>
        /// <param name="helper">The HtmlHelper</param>
        /// <returns>Juime class object with helper as parameter</returns>
        public static JuimeHelper Juime(this HtmlHelper helper)
        {
            return new JuimeHelper(helper);
        }
    }
}
