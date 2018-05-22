using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13_Filters.Models
{
    public class Log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, DisplayName("Ad")]
        public DateTime Tarih { get; set; }

        [Required, StringLength(25), DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [StringLength(100), DisplayName("Action")]
        public string ActionName { get; set; }

        [StringLength(100), DisplayName("Controller")]
        public string ControllerName { get; set; }

        [StringLength(255), DisplayName("Bilgi")]
        public string Bilgi { get; set; }

    }


}
