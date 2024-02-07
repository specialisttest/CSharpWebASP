using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    //[Route("course")]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return Json(Course.All);
        }

        [Route("courses")]
        public ViewResult List()
        {
            //ViewBag.CoursesCount = Course.All.Count;
            ViewData["CoursesCount"] = Course.All.Count;
            return View(Course.All);
        }

        //[Route("coursesearch/{search}")]
        [Route("search/{search}")] // higher priority then MapControllerRoute
        public IActionResult Search(string search)
        {
            return Json(Course.All.Where(c=>c.Title.Contains(search, StringComparison.OrdinalIgnoreCase) 
            || c.Description.Contains(search, StringComparison.OrdinalIgnoreCase) ));
        }

        [Route("course/{id:int}")]
        public IActionResult Details(int id) 
        {
            return Json(Course.All.Where(c => c.Id == id).SingleOrDefault());
        }
    }
}
