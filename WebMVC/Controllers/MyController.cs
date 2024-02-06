using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Text;
using WebMVC.Filters;

namespace WebMVC.Controllers
{
    [MyActionFilter]
    public class MyController : Controller
    {
        
        [HttpGet]
        //[HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        public EmptyResult Void()
        {
            return new EmptyResult();
        }
        /* IActionResult
         *  FileContentResult
         *  StatusCodeResult
         *  JsonResult
         *  ViewResult
         *  PartialViewResult
         *  RedirectResult
         *  LocalRedirectResult
         *  RedirectToRouteResult
         *  RedirectToActionResult
         * 
         * 
         */

        public ContentResult ParamsObject(Models.Person p)
        {
            var c = new ContentResult();
            c.Content = $"<h2>Data from query name: {p.Name} age: {p.Age}</h2>";
            c.ContentType = "text/html";
            return c;
        }

        [ActionName("Json")]
        public IActionResult JsonAction(Models.Person p)
        {
            return this.Json(p);
        }
        
        public IActionResult Specialist()
        {
            //this.RedirectPermanent
            return this.Redirect("http://www.specialist.ru");
        }

        public IActionResult ToInfo()
        {
            return this.RedirectToAction("Info");
        }

        public IActionResult Secure()
        {
            //return this.StatusCode(403);
            return Unauthorized("Доступ запрещен");
        }

        public IActionResult GetFile ()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.txt");

            return PhysicalFile(path, "text/plain");
        }

        // ?name=Sergey&age=46
        public string Params(string name, int age)
        {
            return $"Data from query name: {name} age: {age}";
        }

        public string Info()
        {
            //HttpContext.Request
            //HttpContext.Response
            //this.ModelState
            int id = 0;
            if (this.RouteData.Values["id"]!=null)
                id = int.Parse(this.RouteData.Values["id"].ToString());
            
            StringBuilder sb = new StringBuilder();
            sb.Append($"Request with id: {id}\n");

            foreach (var header in HttpContext.Request.Headers)
                sb.Append($"{header.Key} : {header.Value}\n");


            return sb.ToString();
        
        }

        //[ActionName("Hello")]
        [NonAction]
        public string Test()
        {
            return "Test Action";
        }
    }
}
