using Microsoft.AspNetCore.Mvc;
using ControllerExample.Models;

namespace ControllerExample.Controllers
{
    public class ActionResultController : Controller
    {
        [Route("/actionresult/{bookid?}")]
        public IActionResult Index([FromQuery] int? bookid, Book book)
        {
            //FromQuery to fetch model binding data from query string
            //FromRoute to fetch model binding data from route

            //return Content("<h1>from action result controller</h1>", "text/html");

            if (!bookid.HasValue)
            {
                Response.StatusCode = 400;
                return Content("book id is not supplied");
                //return NotFound();
            }

            //book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("book id cannot be null or empty");
                //return NotFound();
            }

            int.TryParse(Request.Query["bookid"], out int bookId);

            if (bookId < 0 || bookId > 1000)
            {
                Response.StatusCode = 400;
                return Content("book id cannot be less than 0 and more than 1000");
            }

            //return new RedirectToActionResult("index", "store", new { });

            return RedirectToAction("index", "store", new  { }); //this is short hand version of above
        }


    }
}
