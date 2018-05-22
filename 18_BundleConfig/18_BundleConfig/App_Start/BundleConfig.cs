using System.Web.Optimization;

namespace AspnetMvcBundles.App_Start
{
    public class BundleConfig
    {
        /* TODO Bundle'ları aktifleştirmek için Application_Start() metodu içinde RegisterBundles()
         metodunun çağrılması gerekir.*/

        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS - StyleBundle
            bundles.Add(new StyleBundle("~/css/all").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/css/basic").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css"));


            // JS - ScriptBundle

            // TODO version => Proje içinde hangi versiyon varsa onu alır. Birden fazla varsa hepsini alır.
            //bundles.Add(new ScriptBundle("~/js/all").Include(
            //    "~/Scripts/jquery-{version}.js"));

            // TODO Cdn kullanmak
            //! Cdn 'realese' modda çalışır. 
            // Cdn ile paketler projeye dahil edilmeden internet üzerinden indirilerek kullanılabilir.
            bundles.UseCdn = true;  // Cdn kullanımı
            string jqCdn = "https://code.jquery.com/jquery-2.2.4.jsfs";  // CdnAdresi
            bundles.Add(new ScriptBundle("~/js/all", jqCdn).Include(
                "~/Scripts/jquery-{version}.js"));
            // Release modda iken cdn' yüklenirken hata olursa, localdeki jquery' i yükleyebilmek
            //  için ayrı önlemler alınmalıdır. (layout sayfasına bakın.)


            //bundles.Add(new ScriptBundle("~/js/all").Include(
            //    "~/Scripts/jquery-{version}.js",
            //    "~/Scripts/bootstrap.js",
            //    "~/Scripts/modernizr-{version}.js"));


            //! Oluşturulan bundle sanal pathlerindeki dosyaları tek bir dosya olarak sıkıştırarak ekler.
            BundleTable.EnableOptimizations = true;
            // Release modda varsayılan olarak bu değer true olur.


            // TODO * karakterinin kullanımı
            /* Include("~/Scripts/Common/*.js")                 => valid (js uzantılı tüm dosyalar)
             * Include("~/Scripts/Common/T*.js")                => invalid
             * Include("~/Scripts/Common/*og.*")                => invalid
             * Include("~/Scripts/Common/T*")                   => valid (Scripts/Common altında T ile
           başlayan tüm dosyalar)
             * Include("~/Scripts/Common/*")                    => invalid
             * IncludeDirectory("~/Scripts/Common", "T*")       => valid (Scripts/Common/ altında T ile 
           başlayan tüm dosyalar)
             * IncludeDirectory("~/Scripts/Common", "T*", true) => valid (Scripts/Common klasöründe ve 
           bu klasörün tüm alt klasörlerinde T ile başlayan tüm dosyalar)
             */
        }
    }
}