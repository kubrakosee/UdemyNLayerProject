namespace UdemyNLayerProject.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }
        //tabi bu birde category bağlı olacak
        public int CategoryId { get; set; }
        //silme durumunu tutmak için 
        public bool IsDeleted { get; set; }
        //belki ben barkod tutucam
        public string InnerBarcode { get; set; }

        //tabi bu arkadaş category bağlı olacağından 
        //dolayı birde cotegory tablosuna references vermem
        //gerekir.Virtual verme sebebimiz entity framework
        //trayker işlemi yapıcak yani değişiklikleri izleyecek
        //o yüzden virtual olarak yapıyoruz.ve değişiklikleri hafıza da 
        //tutabilsin.

        public virtual Category Category { get; set; }







    }
}
