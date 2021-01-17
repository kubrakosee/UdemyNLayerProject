using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //sadece category özgü metod olucak
        //ben bir tane category ıd verdiğim zaman 
        //category sahip oldupu hem o ıd i dönsün hemde o category bağlı 
        //ürün gelsin ve bir dizi şeklinde dönsün
        Task<Category> GetWithProductByIdAsync(int categoryId);//şimdi benim yaptığım 
                                                               //ben buraya categoryıd vericeM HEM BANA CATEGORY DÖNÜCEK
                                                               //hemde category ye bağlı productlar dönücek   


    }
}
