using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IHFF
{
    public static class CustomHelpers
    {
        public static MvcHtmlString CustomDisplayFor(this HtmlHelper htmlHelper, string source)
        {
            int maxLength = 600;


            if (source.Length > maxLength)
            {
                while(source[maxLength] != ' ')
                {
                    maxLength++;
                }
                
                string str = (source.Substring(0, maxLength));

                Guid guid = Guid.NewGuid();

                str += "<div data-toggle=\"collapse\" style=\"cursor: pointer;\" data-target=\"#" + guid + "\">...</div>";
                str += "<div id=\"" + guid + "\" class=\"collapse\">";

                str += source.Substring(maxLength, (source.Length - maxLength) - 1);
                str += "</div>";
                return new MvcHtmlString(str);
            }

            else
            {
                return new MvcHtmlString(source);
            }
        }
    }
}