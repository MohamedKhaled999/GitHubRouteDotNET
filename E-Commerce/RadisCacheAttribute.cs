using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Abstractions;
using System.Net;
using System.Text;

namespace E_Commerce
{
    public class RadisCacheAttribute(int durationInSec) :ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IServiceManager>().CacheService;

            string cacheKey = GenerateCashKey(context.HttpContext.Request);
            var result = await cacheService.GetCachedValueAsync(cacheKey);
            if (result != null)
            {
                context.Result = new ContentResult
                {
                    Content = result,
                    ContentType = "Application/Json",
                    StatusCode = (int)HttpStatusCode.OK
                };

                return;
            }
            var contextResult = await next.Invoke();

            if (contextResult.Result is OkObjectResult okObject)
            {
                await cacheService.SetCachedValueAsync(cacheKey, okObject, TimeSpan.FromSeconds(durationInSec));
            }



        }

        private string GenerateCashKey(HttpRequest request)
        {
            var KeyBuilder = new StringBuilder();
            KeyBuilder.Append(request.Path);
            foreach (var item in request.Query.OrderBy(q => q.Key))
            {
                KeyBuilder.Append($"{item.Key}--{item.Value}");
            }
            return KeyBuilder.ToString()
              ;
        }

    }
}
