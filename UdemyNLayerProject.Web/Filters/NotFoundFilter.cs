using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using UdemyNLayerProject.Web.ApiService;
//using UdemyNLayerProject.API.DTOs;
//using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Web.DTOs;

namespace UdemyNLayerProject.Web.Filters
{

    public class NotFoundFilter : ActionFilterAttribute
    {
        //burda veri tabanına bağlanmam gerekiyor
        private readonly CategoryApiService _categoryApiService;
        public NotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int İd = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _categoryApiService.GetByIdAsync(İd);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();


                //errorDto.Status = 404;

                errorDto.Errors.Add($"id'si{İd} olan kategori veritabanında bulunamadı.");

                //context.Result = new NotFoundObjectResult(errorDto);
                context.Result = new RedirectToActionResult("Error", "Home",errorDto);
            }
        }

    }
}
