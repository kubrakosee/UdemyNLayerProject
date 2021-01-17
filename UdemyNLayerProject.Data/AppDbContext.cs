using Microsoft.EntityFrameworkCore;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Data.Configurations;
using UdemyNLayerProject.Data.Seeds;

namespace UdemyNLayerProject.Data
{
    public class AppDbContext : DbContext
    //dbcontext ten miras alsın
    //tabi entity framework de kütüphanelere ihtiyaç var data sağ tıkla
    //depencesien kısmında manage packe e basıyorum sonra 4 tane manager indirdiğimiz zaman
    //dbcontext ctrl . tıklayıp entityframework ekliyoruz.

    {
        //default bir contructor yapıyoruz.ctor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //entity farmeworkle ben postgresql kullanıcam sql kullanıcam bunu burda belirticem
        //bu metod olmak zorunda

        {

        }
        //iki tane property oluşturucam
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        //bir tane de override yapılacağız (metod)
        //veritabanında tablolar oluşurken oluşmadan önce oluşucak metod

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            /* modelBuilder.Entity<Product>().Property(x=>x.Id).ıd//**///*normalde böyle yazılacakt*/ı*/
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //tabi yukardaki configuration da ilk önce tablolarım oluşucak burdaki configurATİON göre ayarlarımıza göre yapacak

            //product ve category seedlerini yaptıktan sonra en son category den sonra 
            //bu kısma geldik
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
            //burda da daha sonra datalarımız ile ilgili tablolar içersine eklenecek



            //person ekleme
            //boş bir tablo oluşsun
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x => x.SurName).HasMaxLength(100);

        }
    }


}
