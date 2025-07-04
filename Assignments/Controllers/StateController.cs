using Microsoft.AspNetCore.Mvc;

namespace Assignments.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SaveSession(string name)
        {
           
            HttpContext.Session.SetString("Name", name);
            
            return Content("Data Session Save Success");
        }

        public IActionResult GetSession()
        {
         
            string name = HttpContext.Session.GetString("Name");
           

            return Content($"name={name} ");
        }
    }
}
