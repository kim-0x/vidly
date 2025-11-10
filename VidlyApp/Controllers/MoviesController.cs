using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyApp.Data;

namespace VidlyApp.Controllers;
public class MoviesController : Controller
{
    private readonly ApplicationDbContext _context;
    public MoviesController(ApplicationDbContext context)
    {
        _context = context;
    }
    public ActionResult Index()
    {
        var movies = _context.Movies
            .Include(m => m.Genre)
            .ToList();

        return View(movies);
    }

    public ActionResult Detail(int id)
    {
        var movie = _context.Movies
            .Include(m => m.Genre)
            .SingleOrDefault(m => m.Id == id);

        if (movie == null)
            return NotFound();

        return View(movie);
    }
}