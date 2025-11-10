
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyApp.Data;

namespace VidlyApp.Controllers;

public class CustomersController : Controller
{
    private ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var customers = _context.Customers
            .Include(c => c.MembershipType)
            .ToList();
        return View(customers);
    }

    public IActionResult Detail(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        
        if (customer == null)
            return NotFound();
        
        return View(customer);
    }
}
