using System.IO;
using System.Text;
using System.Web.Mvc;

namespace _10_ActionResultTurleri.Controllers
{
    public class FileResultsController : Controller
    {
        // GET: FileResults

        public ActionResult Dosyalarım()
        {
            return View();
        }

        // Dosyayı bir sayfada gösterir.
        public FileResult PdfView()
        {
            string path = Server.MapPath("~/Files/asp_net_mvc_poster.pdf");

            // dosya_yolu, contentType

            // contentType => (MIME type) İlgili dosya türünün standart kimlik tanımlayıcısı
            // Tarayıcının dosyayı uygun şekilde açmasına ipucu verir.
            return new FilePathResult(path, "application/pdf");
        }

        // Anlık olarak hafızada oluşturulan bir dosyayı(dosya fiziksel olarak oluşturulmadan) veya
        //  var olan bir dosyayı kullanıcıya indirtmek için kullanılır.
        public FileStreamResult TextFileDownload()
        {
            string text = "Bu bir deneme yazısıdır.";
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            MemoryStream memory = new MemoryStream();
            memory.Write(bytes, 0, bytes.Length);
            memory.Position = 0; //! Bu kısım önemli 
            // Position başa çekilmezse dosya boş gelir, text stringi dosyaya yazdırılmaz

            FileStreamResult streamResult = new FileStreamResult(memory, "text/plain");
            streamResult.FileDownloadName = "dosya.txt";

            return streamResult;
        }
    }
}