using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvcValidations.Models
{
    // Data Annotations

    public class Kullanici
    {
        /*
         * DisplayName => Property'nin sayfada görüntülenen adını değiştirir.
         * Required => Boş geçilemez
         * MaxLength/MinLength => Maksimum/Minimum uzunluk
         * DataType => İlgili tipe göre component oluşturulur. (Örn: Password => ***** gibi görünür)
         * EmailAddress => Component'e e mail adresine göre sorgular.
         * Compare => Componentler arası karşılaştırma
         * nameof(property) >= İlgili property adını stringe çevirir.Bu sayede Property adı değiştirilirse derleme
          sırasında hata alınarak fark edilir.
         * RegularExpression => Belirtilen regex ifadesine göre kontrol yapılır.
         * ErrorMessage => Her bir attribute' un hata mesajı değeri belirtilebilir. Belirtilmezse otomatik oluşur.
         * Range => Aralık belirtme
         */

        [DisplayName("Adınız")]
        public string Ad { get; set; }

        [DisplayName("Soyadınız")]
        public string Soyad { get; set; }

        // {0} => Her zaman property adını verir.Eğer DisplayName kullanılmış ise DisplayName' deki stringi verir.

        [DisplayName("Yaş"),
             Required(ErrorMessage = "Lütfen bir {0} değeri giriniz."),
             Range(1, 110, ErrorMessage = "{0} değeri {1} ile {2} arasında olmalıdır.")]
        public int Yas { get; set; }

        [DisplayName("Kullanıcı adı"),
            Required(ErrorMessage = "Lütfen bir {0} giriniz."),
            MinLength(5, ErrorMessage = "{0} min. {1} karakter olmalıdır."),
            MaxLength(25, ErrorMessage = "{0} max. {1} karakter olmalıdır.")]
        public string KullaniciAdi { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "Lütfen bir {0} giriniz."),
            MinLength(3, ErrorMessage = "{0} alanı min. {1} karakter olmalıdır."),
            MaxLength(16, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."),
            DataType(DataType.Password)]
        public string Sifre { get; set; }

        [DisplayName("Şifre (Tekrar)"),
            Required(ErrorMessage = "Lütfen {0} giriniz."),
            MinLength(3, ErrorMessage = "{0} alanı min. {1} karakter olmalıdır."),
            MaxLength(16, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."),
            Compare(nameof(Sifre), ErrorMessage = "{0} ile {1} eşleşmiyor."),
            DataType(DataType.Password)]
        public string Sifre2 { get; set; }

        [DisplayName("E-Posta"),
            Required(ErrorMessage = "Lütfen bir {0} giriniz."),
            MaxLength(60, ErrorMessage = "{0} max. {1} karakter olmalıdır."),
            EmailAddress(ErrorMessage = "Lütfen geçerli bir {0} giriniz.")]
        public string EPosta { get; set; }

        [DisplayName("E-Posta (Tekrar)"),
            Required(ErrorMessage = "Lütfen {0} giriniz."),
            MaxLength(60, ErrorMessage = "{0} adresi max. {1} karakter olmalıdır."),
            EmailAddress(ErrorMessage = "Lütfen geçerli bir {0} giriniz."),
            Compare(nameof(EPosta), ErrorMessage = "{0} ile {1} uyuşmuyor.")]
        public string EPosta2 { get; set; }

        [DisplayName("Spor Takımınız"),
            MaxLength(25, ErrorMessage = "{0} max. {1} karakter olabilir.")]
        public string Takiminiz { get; set; }
    }
}
