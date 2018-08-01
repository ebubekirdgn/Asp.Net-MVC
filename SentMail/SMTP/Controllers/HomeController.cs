using SMTP.Models;
using System;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SMTP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(SMTPModel sMTPModel)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com"; //Gmail Smtp Server
                WebMail.SmtpPort = 587; //Gmail Port Numarası
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol
                WebMail.EnableSsl = true; // Korumalı protokol ile mail gönderme aktifleştiriyoruz.
                //EmailId used to send emails from application
                WebMail.UserName = "ebubekir.dogan@bil.omu.edu.tr";
                WebMail.Password = "**********";

                WebMail.From = "SenderGamilId@gmail.com"; //Gönderen e-posta adresi.

                WebMail.Send(to: sMTPModel.ToEmail, subject: sMTPModel.EmailSubject, body: sMTPModel.EMailBody, cc: sMTPModel.EmailCC, bcc: sMTPModel.EmailBCC, isBodyHtml: true); //Mail Gönderme
                ViewBag.Status = "Email başarılı bir şekilde gönderildi..";
            }
            catch (Exception)
            {
                ViewBag.Status = "Mail gönderilemedi.Lütfen daha sonra tekrar deneyiniz.";
            }

            return View();
        }
    }
}