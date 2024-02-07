using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MyCoins.Models;

namespace MyCoins.Controllers;

public class HomeController : Controller {
    readonly static CoinsData data = new CoinsData();

    public IActionResult Index() {
        return View(data.Coins);
    }
    public IActionResult ById(int id) {
        return View(data.Coins.ElementAt(id-1));
    }
    public IActionResult Edit(int id) {
        return View(data.Coins.ElementAt(id-1));
    }
    [HttpPost]
    public IActionResult Save([FromForm] Coin coin) {
        if(ModelState.IsValid) {
            data.ReplaceCoinData(coin);
            return RedirectToAction("Index");
        }
        else return View("Edit", coin);   }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
