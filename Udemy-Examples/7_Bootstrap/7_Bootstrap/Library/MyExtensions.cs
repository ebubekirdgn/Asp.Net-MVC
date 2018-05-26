using System;
using _7_Bootstrap.Models;
using System.Web.Mvc;

namespace _7_Bootstrap.Library
{
    public static class MyExtensions
    {

        // Custom Html Helper
        public static MvcHtmlString Alert(this HtmlHelper helper, string id = "alert1", string color = "success", string text = "")
        {
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass($"alert alert-{color}");
            tag.GenerateId(id);
            tag.Attributes.Add(new System.Collections.Generic.KeyValuePair<string, string>("role", "alert"));
            tag.SetInnerText(text);
            return MvcHtmlString.Create(tag.ToString());
        }


        // Generic Custom Html Helper

        // System.Linq.Expressions.Expression<Func<TModel, TProperty>> expression => Model nesnesi alıp geriye
        // property dönecek olan bir function
        public static MvcHtmlString AlertFor<TModel, TProperty>(this HtmlHelper<TModel> helper, System.Linq.Expressions.Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("div");
            tag.AddCssClass("alert");
            tag.Attributes.Add(new System.Collections.Generic.KeyValuePair<string, string>("role", "alert"));

            // Dönen değeri elde etmek için önce derlenmesi gerekli
            // valueGetter artık bir fonksiyondur. Çünkü AlertFor bir fonksiyon alıyor.
            var valueGetter = expression.Compile();
            // helper.ViewData.Model => Model nesnesi, message => Fonksiyondan dönen değer(TProperty)
            var message = valueGetter(helper.ViewData.Model) as _Message;

            if (message.Id == Guid.Empty) message.Id = Guid.NewGuid();

            if (message.Level < 1) message.Level = 1;
            else if (message.Level > 4) message.Level = 4;

            switch (message.Level)
            {
                case 1:
                    tag.AddCssClass("alert-success");
                    break;
                case 2:
                    tag.AddCssClass("alert-info");
                    break;
                case 3:
                    tag.AddCssClass("alert-warning");
                    break;
                case 4:
                    tag.AddCssClass("alert-danger");
                    break;
            }

            // MergeAttributes => Key-Value şeklinde dictinionary'deki attribute'ları etikete ekler.
            // RouteValueDictionary() => belirtilen attributeları key-value şeklinde dictionary'e dönüştürür.
            tag.MergeAttributes(new System.Web.Routing.RouteValueDictionary(htmlAttributes));
            tag.SetInnerText(message.Text);

            // GenerateId metodu rakamla başlayan id leri eklemeyeceğinden idlerin başına "id_" eki getirildi.
            tag.GenerateId("id_" + message.Id.ToString());
            return MvcHtmlString.Create(tag.ToString());
        }
    }
}
