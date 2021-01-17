using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Services
{
    public interface IProductService : IService<Product>
    {
        //diyelimki siz veri tabanı dışında productla ilgili 
        //iç bir metot oluşturmak istiyorsunuz
        /* bool ControlInnerBarcode(Product product);*/  //dıştaki Apı control işlemi gerçekleştirelim //bu tabiki örnek için yapıldı
                                                         //herhangi bir veritabnıyla bir işlevi yok
                                                         //gidicek iç taraftaki Apı la burdaki barkodla iç taraftaki  barkodu karşılaştıracak 
                                                         //eğer doğruysa true veye false dönecek
        Task<Product> GetWithCategoryByIdAsync(int productId);//buda tabii biz veritabanıyla işlem oluşturacağımız için böyle yaptık.
        //eğer bunun dışında veritabanı üzerinden dışarda çalışmasını istediğiniz
        //metotlarınız varsa onların yeri burası oluyor
    }
}
