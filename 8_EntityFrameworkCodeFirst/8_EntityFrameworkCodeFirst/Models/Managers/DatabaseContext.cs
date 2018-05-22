using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace _8_EntityFrameworkCodeFirst.Models.Managers
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Adresler> Adresler { get; set; }

        // Veritabanı için initializer sınıf
        public DatabaseContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

    }

    // Veritabanını ayağı kaldıran(başlatan) sınıf
    // CreateDatabaseIfNotExists<DatabaseContext> => Veritabanı yoksa belirtilen sınıftan oluşturur.
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        //// Veritabanı oluşturulmadan önce çalışan sınıf
        //public override void InitializeDatabase(DatabaseContext context)
        //{
        //    base.InitializeDatabase(context);
        //}

        // Veirtabanı oluşturulduktan sonra çalışan sınıf
        protected override void Seed(DatabaseContext context)
        {
            // insert (kisi)
            for (int i = 0; i < 10; i++)
            {
                Kisiler kisi = new Kisiler();
                kisi.Ad = FakeData.NameData.GetFirstName();
                kisi.Soyad = FakeData.NameData.GetSurname();
                kisi.Yas = FakeData.NumberData.GetNumber(10, 90);

                context.Kisiler.Add(kisi);  // Kisi nesnesi context sınıfa ekleniyor.
            }
            context.SaveChanges();  // Değişiklikler veritabanına uygulanır.

            // select
            List<Kisiler> tumKisiler = context.Kisiler.ToList();


            // insert (adres)
            foreach (var kisi in tumKisiler)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1, 5); i++)
                {
                    Adresler adres = new Adresler();
                    adres.AdresTanim = FakeData.PlaceData.GetAddress();
                    adres.Kisi = kisi;
                    context.Adresler.Add(adres);
                }
            }
            context.SaveChanges();

        }
    }
}