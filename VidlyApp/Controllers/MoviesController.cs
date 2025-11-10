using Microsoft.AspNetCore.Mvc;
using VidlyApp.Models;

namespace VidlyApp.Controllers;
public class MoviesController : Controller
{
    public ActionResult Index()
    {
        var movies = new List<Movie>
        {
            new Movie { Name = "Shrek" },
            new Movie { Name = "Wall-e" }
        };
        return View(movies);
    }
}