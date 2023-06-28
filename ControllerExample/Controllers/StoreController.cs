using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controllers
{
    public class StoreController : Controller
    {
        [Route("book")]
        public IActionResult Index()
        {
            return Content("<h1>Redirected to Store</h1>", "text/html");
        }
    }
}
