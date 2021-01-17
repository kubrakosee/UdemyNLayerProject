using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seeds
{
    //bu arkadaş category bağlı olacağından dolayı construction dan Idleri  almam lazım ki
    //veritabanına kaydederken category ıd sini belirlemem lazım
    class ProductSeed : IEntityTypeConfiguration<Product>
    {
        //int dizeler halinde alalım bana  category ıdler gelsin
        //ismine Ids verelim 2.aşama
        private readonly int[] _Ids;

        //construction oluşturdum 1.aşama
        public ProductSeed(int[] Ids)
        {
            _Ids = Ids;
            //artık category ıdler olucak
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //interfacesimiz implement edelim
            //şimdi gelelim default data burda build liyo olalım

            builder.HasData(

                new Product { Id = 1, Name = "Pilot Kalem", Price = 12.50m, Stock = 100, CategoryId = _Ids[0] },
                 new Product { Id = 2, Name = "Kurşun Kalem", Price = 40.50m, Stock = 200, CategoryId = _Ids[0] },
                  new Product { Id = 3, Name = "Tükenmez Kalem", Price = 500m, Stock = 300, CategoryId = _Ids[0] },
                 new Product { Id = 4, Name = "Küçük Boy Defter", Price = 12.50m, Stock = 100, CategoryId = _Ids[1] },
                  new Product { Id = 5, Name = "Orta Boy Defter", Price = 12.50m, Stock = 100, CategoryId = _Ids[1] },
                   new Product { Id = 6, Name = "Büyük Boy Defter", Price = 12.50m, Stock = 100, CategoryId = _Ids[1] }
                   //basılcak olan datalarımızı belirtmiş olduk

                );

        }
    }
}
