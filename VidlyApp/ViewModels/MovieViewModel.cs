using System.ComponentModel.DataAnnotations;
using VidlyApp.Models;

namespace VidlyApp.ViewModels;

public class MovieViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [Display(Name = "Number in Stock")]
    public int NumberInStock { get; set; }
    [Display(Name = "Release Date")]
    public DateTime? ReleaseDate { get; set; }
    public int GenreId { get; set; }

    [Display(Name = "Genre")]
    public required IEnumerable<Genre> Genres { get; set; }
    public string FormTitle { get; set; } = string.Empty;
}