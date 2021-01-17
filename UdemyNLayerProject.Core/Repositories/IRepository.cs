using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Core.Repositories
{
    //burda sadece T denilebiir biz 
    //entity olduğunu anlaşılsın diye 
    //böyle yapıyoruz.
    public interface IRepository<TEntity> where TEntity : class
        //ben buraaya ne verirsem bu class olamk zorunda

    {
        //en yaygın olan sorgular
        //tabi asenkron olucağı için 
        Task<TEntity> GetByIdAsync(int id);
        //burda da tüm ürünleri getirmesi için
        //ilgli ürünün tamamını çeksin
        Task<IEnumerable<TEntity>> GetAllAsync();
        //Find isimli metodumuz olsun
        //örneğin find(x=>x.Id=23)
        //buda benimm yazdığım sorguyu işaretliyecek

        //repository.cs den gelmemi istediği yer burası(değiştirilecek kısım burda find vardı onu where yaptım.
        //2.aşamada task ı başındaydı onu kaldırdık
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        //tek bir kaydı alanı dönme
        //category.SingleOrDefaultAsync(X=>X.name="kalem");
        //yani name i kalem olanları getir anlamına geliyor.
        //X=>X.name="kalem" burdaki ifade Expression<Func<TEntity, bool>> predicate buna karşılık geliyor.
        //x benim category veya producttı temsil ediyor
        //o da tentity oluyor name="kalem burdaki sorgudan da true ve false döneceği iin bool a denk geliyor

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        //bir nesnenin bir entity nin eklenmesi
        Task AddAsync(TEntity entity);

        //birde toplu şekilde kayıt getirelim
        //BİRDEN FAZLA DA KAYIT GERÇEKLEŞTİRMİŞ OLDUK


        Task AddRangeAsync(IEnumerable<TEntity> entities);

        //CRUD DA DA ÜRÜNÜ SİLMEK İLE DE İŞLEM YAPMAK GEREKEBİLİR

        void Remove(TEntity entity);

        //birden fazla kayıt silebiliriz.
        void RemoveRange(IEnumerable<TEntity> entities);

        //birde update işlemi olabilir
        TEntity Update(TEntity entity);
        //veritabaıyla en şok işlem yapılan metodları yazmka bulunmaktayız.



    }
}
