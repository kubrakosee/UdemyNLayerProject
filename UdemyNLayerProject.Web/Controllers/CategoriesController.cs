using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//using UdemyNLayerProject.Core.Models;
//using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.DTOs;
using UdemyNLayerProject.Web.Filters;

namespace UdemyNLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        //category servise ihtiyacım var onu dl olarak ekleyelim

        //private readonly ICategoryService _categoryService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoriesController(IMapper mapper,CategoryApiService categoryApiService)
        {
            //_categoryService = categoryService;
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        public async Task<IActionResult>Index()
        {
            //ilk önce tüm categoryleri alalım
           
            var categories = await _categoryApiService.GetAllAsync();
            //return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            //ilk çalışıcağı zaman olacak yer burası
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            //burası da submit edileceği zaman çalışıcak yer burasıdır.
            //await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            await _categoryApiService.AddAsync(categoryDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
          await   _categoryApiService.Update(categoryDto);
            return RedirectToAction("Index");
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task< IActionResult> Delete(int id)
        {
            //var category =await  _categoryApiService.GetByIdAsync(id).Result;
            //var category = await _categoryApiService.GetByIdAsync(id);
           await _categoryApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
