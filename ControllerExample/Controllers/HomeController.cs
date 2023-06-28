using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ControllerExample.Controllers
{
    [Controller] //optional
    public class HomeController : Controller //either suffix Controller to class name or add [Controller] attribute at the top of class name
    {
        [Route("/method1")]
        public string method1()
        {
            return DateTime.Now.ToString();
        }

        [Route("/")]
        public ContentResult Index() //dfault action
        {
            //return "index";

            //return new ContentResult()
            //{
            //    Content="This is index page",
            //    ContentType= "text/plain"
            //};

            return Content("<b>this is index page from content</b>", "text/html"); // to use Content type, derive from Controller class.
        }

        //JsonResult
        [Route("person")]
        public JsonResult Person()
        {

            Person person = new Person()
            {
                Guid = "C29F4AC6-DFC9-42CE-87F6-456E31A3533C",
                FirstName = "Kiyansh",
                LastName = "Trivedi",
                Age = DateTime.Now.Year - 2013
            };

            return Json(person);
            //alternate: return new JsonResult(person)
        }

        [Route("download")]
        public VirtualFileResult DownloadFile() // can also use IActionResult instead of using specific Result types 
        {
            //return new VirtualFileResult("/SuketuResume.pdf", "application/pdf"); //use when your file is present in wwwroot folder or its subfolder

            return File("/SuketuResume.pdf", "application/pdf");
        }

        [Route("download2")]
        public PhysicalFileResult Download2()
        {
            //return new PhysicalFileResult("C:\\Users\\HTRIVEDI1.CORPORATE\\Downloads\\12261_Certificate.pdf", "application/pdf");

            return PhysicalFile("C:\\Users\\HTRIVEDI1.CORPORATE\\Downloads\\12261_Certificate.pdf", "application/pdf");
        }

        [Route("download3")]
        public FileContentResult Download3()
        {
            var bytes = System.IO.File.ReadAllBytes("C:\\Users\\HTRIVEDI1.CORPORATE\\Downloads\\12261_Certificate.pdf");

            //return new FileContentResult(bytes, "application/pdf");            

            return File(bytes, "application/pdf");
        }


        [Route("home")]
        public string Home()
        {
            return DateTime.Now.ToString("hh:mm:ss");
        }

        [Route("contact-us")]
        public string contact()
        {
            return System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
        }
    }

    public class Person
    {
        public string Guid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
    }
}
