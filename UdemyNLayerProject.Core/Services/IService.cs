using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UdemyNLayerProject.Core.Services
{
    //generic bir sınıf olucak
    public interface IService<TEntity> where TEntity : class
    {
        //burda tanımlayacaklarım birebir Irepository tanımladıklarımla aynı olucak


        //en yaygın olan sorgular
        //tabi asenkron olucağı için 
        Task<TEntity> GetByIdAsync(int id);
        //burda da tüm ürünleri getirmesi için
        //ilgli ürünün tamamını çeksin
        Task<IEnumerable<TEntity>> GetAllAsync();
        //Find isimli metodumuz olsun
        //örneğin find(x=>x.Id=23)
        //buda benimm yazdığım sorguyu işaretliyecek

        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        //tek bir kaydı alanı dönme
        //category.SingleOrDefaultAsync(X=>X.name="kalem");
        //yani name i kalem olanları getir anlamına geliyor.
        //X=>X.name="kalem" burdaki ifade Expression<Func<TEntity, bool>> predicate buna karşılık geliyor.
        //x benim category veya producttı temsil ediyor
        //o da tentity oluyor name="kalem burdaki sorgudan da true ve false döneceği iin bool a denk geliyor

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        //bir nesnenin bir entity nin eklenmesi
        Task<TEntity> AddAsync(TEntity entity);

        //birde toplu şekilde kayıt getirelim
        //BİRDEN FAZLA DA KAYIT GERÇEKLEŞTİRMİŞ OLDUK


        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        //CRUD DA DA ÜRÜNÜ SİLMEK İLE DE İŞLEM YAPMAK GEREKEBİLİR

        void Remove(TEntity entity);

        //birden fazla kayıt silebiliriz.
        void RemoveRange(IEnumerable<TEntity> entities);

        //birde update işlemi olabilir
        TEntity Update(TEntity entity);
        //veritabaıyla en şok işlem yapılan metodları yazmka bulunmaktayız.
    }
}
