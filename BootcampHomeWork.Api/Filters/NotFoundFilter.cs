using BootcampHomework.Entities;
using BootcampHomeWork.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BootcampHomeWork.Api
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IBaseService<T> _service;

        public NotFoundFilter(IBaseService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //context.ActionArguments.Values.FirstOrDefault() methodun ilk Argumani alıyoruz.
            object idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            int id = (int)idValue;

            T entity = await _service.GetByIdAsync(id);

            //Bu id Sahip Entity varmı kontrol ediyoruz varsa next.ınvoke() ediyoruz.
            if (entity==null)
            {
                await next.Invoke();
                return;
            }
            //Bu Id sahip Entity yoksa CustomResponseDto<NoContentDto>.Fail ile id bulunamadı hatası dönüyoruz clienta.

            //contex.Result a NotfoundObjectResult un parametsine  CustomResponseDto<NoContentDto>.fail() veriyoruz.
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) Not Found"));
        }
    }

}
