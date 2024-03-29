using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSecured.Models;

namespace WebSecured.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    //[Authorize(Roles ="users,admin")]
    //[AllowAnonymous]
    public IActionResult Privacy()
    {
        //if (this.User.IsInRole("users")) { ... }
        
        ViewBag.UserName = this.User.Identity.Name;
        ViewBag.AuthType = this.User.Identity.AuthenticationType;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
