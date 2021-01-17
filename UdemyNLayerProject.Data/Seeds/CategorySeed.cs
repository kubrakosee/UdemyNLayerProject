using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seeds
{
    class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _Ids;

        public CategorySeed(int[] Ids)
        {
            _Ids = Ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category { Id = _Ids[0], Name = "Kalemler" },

                new Category { Id = _Ids[1], Name = "Defterler" }

                );
            //sonra bunu yaptıktan sonra product ve category appdbcontext kısmına geç protected override OnModelCreating olana gir
        }
    }
}
