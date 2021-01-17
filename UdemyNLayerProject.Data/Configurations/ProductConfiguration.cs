using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Configurations
{
    //aşağıdaki satırın configurations dosyası olması için entity impement etmesi lazım

    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //product üzerinden builsd işlemleri yapıcam
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");


            builder.Property(x => x.InnerBarcode).HasMaxLength(50);

            //şuanda burda veri tabanında tablolar oluşurken hangi parametlere göre
            //belirtmiş olduk.

            builder.ToTable("Products");


        }
    }
}
