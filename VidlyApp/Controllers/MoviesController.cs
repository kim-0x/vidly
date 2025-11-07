using Microsoft.AspNetCore.Mvc;
using VidlyApp.Models;

namespace VidlyApp.Controllers;
public class MoviesController : Controller
{
    public ActionResult Random()
    {
        var movie = new Movie() { Name = "Shrek!" };
        return View(movie);
    }
}