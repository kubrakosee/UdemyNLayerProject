using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using UdemyNLayerProject.Web.DTOs;

namespace UdemyNLayerProject.Web.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;
        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDto;

            var response = await _httpClient.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await
                    response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDto = null;
            }
            return categoryDto;
        }
        //public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        //{
        //    IEnumerable<CategoryDto> categoryDtos;

        //    var response = await _httpClient.GetAsync("categories");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await
        //            response.Content.ReadAsStringAsync());
        //    }
        //    else
        //    {
        //        categoryDtos = null;
        //    }
        //    return categoryDtos;
        //}

        //public async Task<CategoryDto>AddAsync(CategoryDto categoryDto)
        //{
        //    var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto),Encoding.UTF8,"application/json");

        //    var response = await _httpClient.PostAsync("categories",stringContent);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        categoryDto = JsonConvert.DeserializeObject<CategoryDto>(await
        //            response.Content.ReadAsStringAsync());
        //        return categoryDto;
        //    }
        //    else
        //    {
        //        //loglama yap
        //        return null;
        //    }
        //}

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            //STRİNG CONTEXT OLUŞTURDUK CATEGORYDTO JSON OLARAK BANA DÖNDÜR DİYORUZ.
            var stringContext = new StringContent(JsonConvert.SerializeObject(categoryDto),Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync("categories",stringContext);

            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync());

                return categoryDto;

            }
            else
            {
                //loglama yap
                return null;
            }
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                //gelen data yı dönücem

                return JsonConvert.DeserializeObject<CategoryDto>(await
                    response.Content.ReadAsStringAsync());
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Update(CategoryDto categoryDto)
        {
            //STRİNG CONTEXT OLUŞTURDUK CATEGORYDTO JSON OLARAK BANA DÖNDÜR DİYORUZ.
            var stringContext = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("categories", stringContext);

            if (response.IsSuccessStatusCode)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        //public async Task<bool> Remove(int id)
        //{
        //    var response = await _httpClient.DeleteAsync($"categories/{id}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return true;

        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
