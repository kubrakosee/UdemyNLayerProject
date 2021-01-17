using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWork;

namespace UdemyNLayerProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);


        }
    }








    //public  class ProductService : IProductService
    //  {
    ////beni burda unitofwork ihtiyaçım var
    ////veritabanına güncelleme işlemini bu service üzerinden gerçekleştirecem 
    ////repository tarafında herhangi bir şekilde savechange metodlarını kullanmadık
    ////işte veritabanına  yansıma işlemini burda service de gerçekleştirecem
    //private readonly IUnitOfWork _unitOfWork;
    ////arkasında consulactorı oluşturalım
    //public ProductService(IUnitOfWork unitOfWork)
    //{
    //    _unitOfWork = unitOfWork;

    //}

    //public async Task <Product>AddAsync(Product entity)
    //{
    //    await _unitOfWork.Products.AddAsync(entity);
    //    //veritabanına yansımasını gerçekleştiriyorum
    //    //commintasync savechange olarak çalışıyordu

    //    await _unitOfWork.CommintAsync();
    //    //burda aslında geri dönme olayı yapmamız gerekiyor 
    //    //bunu yapmamışız bunun için git Iservice.cs kısmına
    //    //task addasync(tentity entity);böyle di ben aslında 
    //    //o kısımda product dönsem iyi olur yani
    //    //task<TeNTİTY> addasync(tentity entity); dönelim
    //    //şimdi dönüşü yazabilirim 
    //    return entity;
    //}

    //public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
    //{
    //    //birden fazla veri girersen onları döndürmüş oliyim
    //    //geriye list olarak dönelim Iservice kısmına aşağıdaki örneği yapıldı
    //    // Task <IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
    //    await _unitOfWork.Products.AddRangeAsync(entities);
    //    await _unitOfWork.CommintAsync();
    //    return entities;
    //}

    //public async Task<IEnumerable<Product>> Where(Expression<Func<Product, bool>> predicate)
    //{
    //    //ıservice kısmına find olan vardı onu where yaptık
    //    return await _unitOfWork.Products.Where(predicate);

    //}

    //public async Task<IEnumerable<Product>> GetAllAsync()
    //{
    //    return await _unitOfWork.Products.GetAllAsync();
    //}

    //public async Task<Product> GetByIdAsync(int id)
    //{
    //    return await _unitOfWork.Products.GetByIdAsync(id);
    //}

    //public async Task<Product> GetWithCategoryByIdAsync(int productId)
    //{
    //    return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
    //}

    //public void Remove(Product entity)
    //{
    //    _unitOfWork.Products.Remove(entity);
    //    _unitOfWork.Commit();
    //}

    //public void RemoveRange(IEnumerable<Product> entities)
    //{
    //    _unitOfWork.Products.RemoveRange(entities);
    //    _unitOfWork.Commit();
    //}

    //public async Task<Product> SingleOrDefaultAsync(Expression<Func<Product, bool>> predicate)
    //{
    //    return await _unitOfWork.Products.SingleOrDefaultAsync(predicate);

    //}

    //public Product Update(Product entity)
    //{
    //    var updateProduct = _unitOfWork.Products.Update(entity);
    //    _unitOfWork.Commit();
    //    return updateProduct;

    //}
    //}
}
