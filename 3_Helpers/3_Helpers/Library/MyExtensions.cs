using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace _3_Helpers.Library
{
    public static class MyExtensions
    {
        public static MvcHtmlString Button(this HtmlHelper helper, string id = "", ButtonType type = ButtonType.button,
            string text = "")
        {
            return MvcHtmlString.Create($"<button id='{id}', name='{id}', text='{type.ToString()}'>{text}</button>");
        }


        // TagBuilder kullanımı
        public static MvcHtmlString ButtonWithTagBuilder(this HtmlHelper helper, string id = "", string cssClass = "",
            ButtonType type = ButtonType.button, string text = "")
        {
            TagBuilder tag = new TagBuilder("button");  // Etiket oluşturur
            //tag.AddCssClass("btn btn-success");  // Ayrı ayrı da eklenebilir.
            tag.AddCssClass(cssClass);
            tag.GenerateId(id);
            tag.SetInnerText(text);
            tag.Attributes.Add(new KeyValuePair<string, string>("type", type.ToString()));
            tag.Attributes.Add(new KeyValuePair<string, string>("name", id));
            return MvcHtmlString.Create(tag.ToString());
        }

        // Fonksiyona HTML kodu şeklinde parametre vermek.
        public static MvcHtmlString Paragraph(this HtmlHelper helper, string id = "", int borderSize = 1,
            string borderType = "solid", Func<object, System.Web.WebPages.HelperResult> template = null)
        {
            string html = string.Format("<p id='{0}' name='{0}' style='border-width:{1}px;border-style:{2}'>{3}</p>",
                id, borderSize, borderType, template.Invoke(null));
            return MvcHtmlString.Create(html);
        }
    }

    public enum ButtonType
    {
        button = 0, submit = 1, reset = 2
    }
}