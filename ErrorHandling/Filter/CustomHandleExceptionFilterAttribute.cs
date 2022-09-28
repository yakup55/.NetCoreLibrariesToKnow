using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ErrorHandling.Filter
{
    public class CustomHandleExceptionFilterAttribute:ExceptionFilterAttribute
    {
        public string Errorpage { get; set; }
        public override void OnException(ExceptionContext context)
        {
            var result = new ViewResult() { ViewName = "Error1" };
            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState);

            result.ViewData.Add("Url", context.HttpContext.Request.Path.Value);

            result.ViewData.Add("Exception", context.Exception);
            context.Result = result;

        }
    }
}
