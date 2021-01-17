using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.UnitOfWork;
using UdemyNLayerProject.Data.Repositories;

namespace UdemyNLayerProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;



        //product repository i vericem product repository varsa
        //al eğer ??(null) ise git yeni bir productrepository
        //oluştur
        public IProductRepository Products => _productRepository =
            _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Category => _categoryRepository = _categoryRepository ??
            new CategoryRepository(_context);

        //ctor oluşturduk
        public UnitOfWork(AppDbContext appDbContext)
        {
            //appdbcontext ile dolduruyorum
            _context = appDbContext;
        }
        public async Task CommintAsync()
        {
            await _context.SaveChangesAsync();
        }

        //commint yerine savechange de diyebiliriz ama karışmaması açısından böyle kalsın

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}

