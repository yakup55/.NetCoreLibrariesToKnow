using ErrorHandling.Filter;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Controllers
{
    //controllere taşırsak o controldeki metotlardaki hatayı Error1 sayfasına yolluyor
    [CustomHandleExceptionFilterAttribute(Errorpage ="Error1")]
    public class ProductController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
