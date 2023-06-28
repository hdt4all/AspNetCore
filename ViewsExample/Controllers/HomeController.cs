using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/home")]
        public IActionResult Index()
        {
            return View(); //default view name is Index.cshtml if you dont provide the name. will be searched at /Views/Home/Index.cshtml

            //return View("abc"); //view name abc. will be searched at /Views/Home/abc.cshtml
        }
    }
}
