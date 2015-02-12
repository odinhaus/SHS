using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SHS.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString RequireJs(this HtmlHelper helper, string common, string module)
        {
            var require = new StringBuilder();

            string jsLocation = ConfigurationManager.AppSettings["JsLocation"];

            require.AppendLine("require( [ \"" + jsLocation + common + "\" ], function() {");
            require.AppendLine("    require( [ \"" + module + "\"] );");
            require.AppendLine("});");

            return new MvcHtmlString(require.ToString());
        }
    }
}