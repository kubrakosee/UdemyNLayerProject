using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductByIdAsync(int categoryId);
        //eğer categoriye özgü metodlarınız varsa yine burda ytanımlayabilirsiniz
        //eğer sizin veritabında 30 tane tablonuz var 30 tane tablo içinde
        //her biri için ıproduct ı category oluşturmanız gerek yok
        //sadece ihtiyaç varsa yazabilirisniz ıservice kısmıda



    }
}
