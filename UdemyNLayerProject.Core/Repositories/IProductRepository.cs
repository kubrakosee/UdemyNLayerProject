using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        //ben öyle bir metod tanımlayım ki  Task<TEntity> GetByIdAsync(int id); yerine 
        //ben istiyorum ki burdaki Iproductrepository içerisinde
        //ben ıd e sahip product aldığım zaman
        //aynı zamanda o productın
        //category side gelsin bana

        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
