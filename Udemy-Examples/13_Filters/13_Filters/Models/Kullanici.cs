using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13_Filters.Models
{
    [Table("SiteUsers")]
    public class SiteUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(20), DisplayName("Ad")]
        public string Ad { get; set; }

        [Required, StringLength(20), DisplayName("Soyad")]
        public string Soyad { get; set; }

        [Required, StringLength(20), DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required, StringLength(16), DisplayName("Şifre"), DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}