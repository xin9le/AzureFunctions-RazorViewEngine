using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace RazorFunctionApp;



internal interface IHttpTrigger
{ }



internal static class HttpTriggerExtensions
{
    extension(IHttpTrigger @this)
    {
#pragma warning disable CA1822 // メンバーを static に設定します
        public ViewResult ViewResult(HttpContext http, string viewPath, object? model = null)
        {
            var services = http.RequestServices;
            var metadataProvider = services.GetRequiredService<IModelMetadataProvider>();
            var tempDataFactory = services.GetRequiredService<ITempDataDictionaryFactory>();
            var modelState = new ModelStateDictionary();
            return new()
            {
                ViewName = viewPath,
                ViewData = new ViewDataDictionary(metadataProvider, modelState) { Model = model },
                TempData = tempDataFactory.GetTempData(http),
                ContentType = "text/html; charset=utf-8",
            };
        }
    }
#pragma warning restore CA1822 // メンバーを static に設定します
}