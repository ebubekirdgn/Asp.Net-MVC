using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMTP.Models
{
    public class SMTPModel
    {
        [DataType(DataType.EmailAddress), Display(Name = "Alıcı Mail Adresi :")]
        [Required]
        public string ToEmail { get; set; }

        [Display(Name = "Mesajınız :")]
        [DataType(DataType.MultilineText)]
        public string EMailBody { get; set; }

        [Display(Name = "Konu :")]
        public string EmailSubject { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "CC")]
        public string EmailCC { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Gönderici Mail Adres")]
        public string EmailBCC { get; set; }
    }
}