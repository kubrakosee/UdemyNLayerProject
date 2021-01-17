using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UdemyNLayerProject.Core.Models
{
    public class Category
    {
        public Category()
        {
            //burdada default oluşturuyoruz
            //ilk ouştuğunda bize bir tane boş 
            //category eklemesi yani oluşturması için bunu yapıyoruz.
            Products = new Collection<Product>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        //veritabanından silmeyeceğimde kayıdını tutcam true yada false o yüzden
        //ısdeleted oluşturuyoruz.
        public bool IsDeleted { get; set; }

        //birden fazla category olabileceği için
        //bire çok ilişki olabileceği için 
        //bu yüzden buraya collection tanımlayacağım SONRA 
        //BUNU default olarak yukarda oluşturalım.
        public ICollection<Product> Products { get; set; }


    }

}
