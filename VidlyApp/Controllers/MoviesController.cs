using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyApp.Data;
using VidlyApp.Models;
using VidlyApp.ViewModels;

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
            .OrderBy(m => m.Name)
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

    public ActionResult New()
    {
        var genres = _context.Genre.ToList();
        var viewModel = new MovieViewModel
        {
            FormTitle = "New Movie",
            Genres = genres
        };
        return View("Form", viewModel);
    }

    [HttpPost]
    public ActionResult Save(MovieViewModel viewModel)
    {
        if (viewModel.Id == 0)
        {
            var movie = new Movie
            {
                Name = viewModel.Name,
                GenreId = viewModel.GenreId,
                NumberInStock = viewModel.NumberInStock,
                ReleaseDate = viewModel.ReleaseDate.HasValue ? viewModel.ReleaseDate.Value : DateTime.Now,
                DateAdded = DateTime.Now
            };
            _context.Movies.Add(movie);
        }
        else
        {
            var movieInDb = _context.Movies.Single(m => m.Id == viewModel.Id);
            movieInDb.Name = viewModel.Name;
            movieInDb.GenreId = viewModel.GenreId;
            movieInDb.NumberInStock = viewModel.NumberInStock;
            movieInDb.ReleaseDate = viewModel.ReleaseDate.HasValue ? viewModel.ReleaseDate.Value : movieInDb.ReleaseDate;
        }
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var movie = _context.Movies
            .SingleOrDefault(c => c.Id == id);
        if (movie == null)
            return NotFound();

        var viewModel = new MovieViewModel
        {
            Name = movie.Name,
            GenreId = movie.GenreId,
            NumberInStock = movie.NumberInStock,
            ReleaseDate = movie.ReleaseDate,
            Id = movie.Id,
            Genres = _context.Genre.ToList(),
            FormTitle = "Edit Movie"
        };

        return View("Form", viewModel);
    }
}