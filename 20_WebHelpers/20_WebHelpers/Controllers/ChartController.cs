using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace _20_WebHelpers.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult ChartGoster()
        {
            return View();
        }

        public ActionResult ChartOlustur(string tip = "Column", string cache = "chart1")
        {
            Chart chart = Chart.GetFromCache(cache);  // Cache kontrolü

            if (chart == null)
            {
                chart = new Chart(500, 500);
                chart.AddTitle("MyComputer - Ürün Satış Detay Grafiği");
                chart.AddLegend("Ürünler");  // Renklendirilmiş suutnların isimlerini gösterir.

                // A
                chart.AddSeries(name: "Bilgisayar A", chartType: tip,
                    xValue: new[] { 20, 40, 60 },
                    yValues: new[] { 800, 1200, 2000 });

                // B
                chart.AddSeries(name: "Bilgisayar B", chartType: tip,
                xValue: new[] { 20, 40, 60 },
                yValues: new[] { 900, 1600, 2500 });

                string dir = Server.MapPath("~/charts/");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string imagePath = $"{dir}{cache}.jpeg", xmlPath = $"{dir}{cache}.xml";
                chart.Save(imagePath, format: "jpeg");  // Grafiğin resmi
                chart.SaveXml(xmlPath);                 // xmxl formatı
                chart.SaveToCache(cache, 1, true);   // cache' e ekler
                                                        // name, ömrü(dk), resim yeniden görğntülendiğinde süre yenilenir.(true ise)


                // chart.Write();   // İlgili grafiğinin resminin olduğu sayfaya yönlendirir.
                // Bu kodlar sayfanın direkt içinde yazılırsa, sayfanın diğer kısımları görünmez.
            }

            return View(chart);
        }

        public ActionResult ChartOlustur2(string tip = "Pie", string cache = "chart2")
        {
            Chart chart = Chart.GetFromCache(cache);  // Cache kontrolü

            if (chart == null)
            {
                chart = new Chart(500, 500);
                chart.AddTitle("MyComputer - Ürün Satış Detay Grafiği");
                chart.AddLegend("Ürünler");  // Renklendirilmiş suutnların isimlerini gösterir.

                chart.AddSeries(name: "Ürünler", chartType: tip,
                    xValue: new[] { "Bilgisayar", "Fare", "Klavye" },
                    yValues: new[] { 100, 200, 500 });

                string dir = Server.MapPath("~/charts/");
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string imagePath = $"{dir}{cache}.jpeg", xmlPath = $"{dir}{cache}.xml";
                chart.Save(imagePath, format: "jpeg");  // Grafiğin resmi
                chart.SaveXml(xmlPath);                 // xmxl formatı
                chart.SaveToCache(cache, 1, true);   // cache' e ekler
                                                        // name, ömrü(dk), resim yeniden görğntülendiğinde süre yenilenir.(true ise)

                // chart.Write();   // İlgili grafiğinin resminin olduğu sayfaya yönlendirir.
                // Bu kodlar sayfanın direkt içinde yazılırsa, sayfanın diğer kısımları görünmez.
            }

            return View("ChartOlustur", chart);
        }
    }
}