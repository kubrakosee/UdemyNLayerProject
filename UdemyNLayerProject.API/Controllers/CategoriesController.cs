using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        //şimdi en sonda burda automatter ekleyelim
        //interface yapalım
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {

            _categoryService = categoryService;
            //yukarda ımapper belirledikten sonra consulactoramıza da yazalım
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //getall tüm dataları çekicek
            var categories = await _categoryService.GetAllAsync();
            //return Ok(categories);
            //objeleri birbiriyle dönüştürme işlemini
            //için bir kütüphane kullanmam gerekir
            //şimdi yapmam gereken mapper da dönüştürme işlemi yapmak

            // return Ok(categories); yerine 
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categories = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(categories));
        }
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _categoryService.GetWithProductByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductDto>(category));

        }

        [HttpPost]

        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return Created(string.Empty, _mapper.Map<CategoryDto>(newCategory));
        }
        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var category = _categoryService.Update(_mapper.Map<Category>(categoryDto));

            //update de içinde birşey dönmemesi gerekir bu yüzden nocontent diyoruz.
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return NoContent();
        }

    }
}