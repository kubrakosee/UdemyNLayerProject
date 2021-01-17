using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Data.Repositories
{
    //tabi repository gene generic olucak(<TEntity>)generic de bu
    //daha sonra arkadaş neyi implement edicek IREPOSİTORY Yİ
    //tabi halen kırmızı altı çiziliyor neden çünkü halen implement etmedik
    //implement ettikten sonra bütün hepsini implement etti aşağı da görüldüğü gibi


    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //protected başka yerden miras aldığım için protected diyoruz.
        protected readonly DbContext _context;
        //private de sadece burda kullanıcağımız için böyle verdik
        private readonly DbSet<TEntity> _dbSet;
        //constructor ımızda bu alanda tanımlayalım
        public Repository(AppDbContext context)
        {
            //benim yukardaki _context imi burdaki contextle eşitliyorum
            //burdaki contextle veritabanına erişebiliyorum
            _context = context;

            //dbsetle le tablolarımı erişmiş olabilirim
            //burdaki dbsetimi gelen Tentity gelen göre ayarlıyacağım
            //db setimi eşitliyaceğim gelen Tentity deki dbset e göre ayarla
            _dbSet = context.Set<TEntity>();
        }


        public async Task AddAsync(TEntity entity)
        {
            //tabi başlama dan benim neye ihtiyaçım var dbcontext e ihtiyacım var
            //tabiki asenkron oluğu için async yazıcam 
            //awaitin işlem yaptığı şudur  bundan sonra yazıcağım metot bitene kadar bu satırda
            //bekle demiş oluyoruz.

            await _dbSet.AddAsync(entity);//dbsette işlem bitene kadar bu satırda kalmamı sağlar

        }


        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            //
            await _dbSet.AddRangeAsync(entities);
        }

        //Burda değiştirmeden önce find var onu değiştirirelim arkadaşlar çünkü döngü döndürücez(yani where sorgusu yapıcaz 
        //core katmanına git-ordan Irepository.cs e gel
        //ordaki find i where sorgusu yapıyorum
        //ben burda ifade gönderiyorum nasıl gönderiyorum
        //product.where(x=>x.name="kalem") name kalem olsunlar gelsin dediğim için
        //where oluşturduğum için find olmazdı.where olması daha uygun olacak
        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            //burda hata vericek kızıcak core da ırepository gidip task ı kaldıracaz çünkü(2.aşama)
            //generic değil ıenumerable o yüzde o kısımda task i kaldırıyoruz(2.aşama)
            //sonra burdan da task i ve async leri ve await kaldırırsam sorun kalkacak
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            //tüm datayı dönmüş oldum
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            //idye göre silme işlemi
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            //birşey dönmüyeceğim için void olarak belirtmiş oldum.
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            //birden fazla satır silinebilir
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            //bana ilk kaydı getir yoksa singleordefault getir diyorum.
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            //savechange ne tarafta kullanırsam entitystate bunu veri tabanına yansıtıcak
            _context.Entry(entity).State = EntityState.Modified;
            //özellikle çok satırlı sütunlu tablonuz varsa bu kivört ü kullanmam doğru olacaktır
            //entity.name=product.name
            //entity.price=product.price eşitle gibi tek tek yazmaktansa yukarda ki mantık daha kolay olur

            return entity;
        }
    }
}
