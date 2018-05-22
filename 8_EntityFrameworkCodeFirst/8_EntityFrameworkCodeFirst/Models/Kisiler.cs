using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _8_EntityFrameworkCodeFirst
{

    // Kişiler - Adresler => 1-n ilişki
    // Birbiri ile ilişkili olan nitelikler(property) in başına 'virtual' kelimesi getirilir.

    [Table("Kisiler")]  // Tablo adı
    public class Kisiler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Primary sütun, identity
        public int Id { get; set; }

        [StringLength(20), Required]  // 20 karakterli, not-null
        public string Ad { get; set; }

        [StringLength(20), Required]
        public string Soyad { get; set; }

        public int Yas { get; set; }

        public virtual List<Adresler> Adresler { get; set; }
    }
}
