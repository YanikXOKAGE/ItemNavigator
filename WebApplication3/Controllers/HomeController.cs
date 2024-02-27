using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Configuration;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    private readonly ApplicationDbContext _context;
    
    

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        
        var catalogs = _context.Catalogs.ToList();
        return View(catalogs);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult CatalogDetails(int id)
    {
        
        var catalog = _context.Catalogs.FirstOrDefault(c => c.catalog_id == id);

        if (catalog == null)
        {
            return NotFound();
        }

        return View(catalog);
    }
    
    
    public IActionResult CatalogItems(int catalogId)
    {
        var items = _context.CatalogItemRelations
            .Where(cir => cir.catalog_id == catalogId)
            .Select(cir => cir.Items)
            .ToList();

        if (items == null || items.Count == 0)
        {
            return NotFound(); 
        }

        return View(items);
    }
    
    public IActionResult ItemDetails(int itemId)
    {
        var item = _context.Items.FirstOrDefault(i => i.item_id == itemId);

        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }
}