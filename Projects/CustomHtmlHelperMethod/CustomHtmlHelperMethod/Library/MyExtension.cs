using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CustomHtmlHelperMethod.Library
{
    public static class MyExtension
    {
        public static MvcHtmlString Button(this HtmlHelper helper , string id, ButtonType typ, string text)
        {
            string html = string.Format("<button id='{0} name='{0}' type='{1}'>{2}</button>",id,typ.ToString(),text);
            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString Paragraph(this HtmlHelper helper, string id ="",int borderSize=3,string borderType="solid",Func<object,HelperResult>template=null)
        {
            string html = string.Format("<p id='{0}' name='{0}' style='border-with:{1}px;border-style:{2}'>{3}</button>", id, borderSize,borderType, template.Invoke(null));
            return MvcHtmlString.Create(html);
        }

        public static MvcHtmlString ButtonWithTagBuilder(this HtmlHelper helper, string id, ButtonType typ, string text)
        {
            TagBuilder tag = new TagBuilder("button");
            tag.AddCssClass("btn");
            tag.AddCssClass("btn btn-success");
            tag.GenerateId(id);
            tag.SetInnerText(text);
            tag.Attributes.Add(new KeyValuePair<string,string>("type",typ.ToString()));
            tag.Attributes.Add(new KeyValuePair<string, string>("name", id));

            return MvcHtmlString.Create(tag.ToString());
        }
    }

    public enum ButtonType
    {
        button =0,
        submit =1,
        reset=2
    }

}