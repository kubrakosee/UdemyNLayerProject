using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        //burda tabi veritabıyla işem yapacağımız için
        //ıcategoryrepository ve ıproductrepository vericem
        IProductRepository Products { get; }
        ICategoryRepository Category { get; }


        //asenkron olab metod
        Task CommintAsync();
        //birde asenkron olamyan metodumuz var

        void Commit();
    }
}
