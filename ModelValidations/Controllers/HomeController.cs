using Microsoft.AspNetCore.Mvc;
using ModelValidations.Models;

namespace ModelValidations.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index([FromBody]Person person)
        //to include specific model values in Model binding use Bind attribute. Only those values specified under Bind will be bound to the model, e.g. public IActionResult Index([Bind(nameof(Person.Name), nameof(Person.Email), nameof(Person.Password)), Person person])
        //to bind model from Json/xml inputs using Request body, use [FromBody] attribute
        // to send/format xml input, add below line in program.cs
        // builder.Services.AddControllers().AddXmlSerializerFormatters();
        {
            if (ModelState.IsValid)
            {
                return Content($"{person}");
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                //alternate way

                errors = ModelState.Values.SelectMany(values => values.Errors).Select(error => error.ErrorMessage).ToList();

                var errorlist = string.Join("\n", errors);
                return BadRequest($"Your request is malformed, IDIOT \n {errorlist}");
            }

        }
    }
}
