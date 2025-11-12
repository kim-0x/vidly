
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidlyApp.Data;
using VidlyApp.Models;
using VidlyApp.ViewModels;

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
        var customer = _context.Customers
            .Include(c => c.MembershipType)
            .FirstOrDefault(c => c.Id == id);

        if (customer == null)
            return NotFound();

        return View(customer);
    }

    public IActionResult New()
    {
        var membershipTypes = _context.MembershipType.ToList();
        var viewModel = new CustomerViewModel
        {
            MembershipTypes = membershipTypes,
            FormTitle = "New Customer"
        };
        return View("Form", viewModel);
    }


    [HttpPost]
    public IActionResult Create(CustomerViewModel viewModel)
    {
        if (viewModel.Id > 0)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Id);
            customerInDb.Name = viewModel.Name;
            customerInDb.Birthdate = viewModel.Birthdate;
            customerInDb.IsSubscribedToNewsletter = viewModel.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = (byte)viewModel.MembershipTypeId;
        }
        else
        {
            var customer = new Customer
            {
                Name = viewModel.Name,
                Birthdate = viewModel.Birthdate,
                IsSubscribedToNewsletter = viewModel.IsSubscribedToNewsletter,
                MembershipTypeId = (byte)viewModel.MembershipTypeId
            };
            _context.Customers.Add(customer);
        }
                
        _context.SaveChanges();

        return RedirectToAction("Index", "Customers");
    }
    
    public IActionResult Edit(int id)
    {
        var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
        if (customer == null)
            return NotFound();

        var viewModel = new CustomerViewModel
        {
            Name = customer.Name,
            Birthdate = customer.Birthdate,
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter,
            MembershipTypeId = customer.MembershipTypeId,
            MembershipTypes = _context.MembershipType.ToList(),
            Id = customer.Id,
            FormTitle = "Edit Customer",
        };

        return View("Form", viewModel);
    }
}
