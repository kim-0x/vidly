using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VidlyApp.Models;

namespace VidlyApp.Controllers;

public class CustomersController : Controller
{
    private readonly IEnumerable<Customer> _customers = new List<Customer>
    {
        new Customer { Id = 1, Name = "John Smith" },
        new Customer { Id = 2, Name = "Mary Williams" }
    };
    public IActionResult Index()
    {
        return View(_customers);
    }

    public IActionResult Detail(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
            return NotFound();
        
        return View(customer);
    }
}
