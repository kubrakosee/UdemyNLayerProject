using System;
using System.ComponentModel.DataAnnotations;

namespace UdemyNLayerProject.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        //VALİDATİONFİLTER HATA GÖREBİLMEMİZ İÇİN REQUİRED YAPAMIZ GEREKİR
        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "{0} alanı 1'den büyük bir değer olmalıdır.")]
        public int Stock { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "{0} alanı 1'den büyük bir değer olmalıdır.")]
        public decimal Price { get; set; }
        //tabi bu birde category bağlı olacak
        public int CategoryId { get; set; }
        //silme durumunu tutmak için 


    }
}
