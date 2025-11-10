using Microsoft.AspNetCore.Mvc;

namespace VidlyApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}