using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shop11A.Models;

namespace Shop11A.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public List<Product> products = new List<Product>
        {
            new Product{ Id = 1, Name = "Tablet PGMT 11a", Description = "Super mega giga tablet PGMT 11a", Price = 2000.11M, ImageUrl = "/images/t1.jpg" },
            new Product{ Id = 2, Name = "Tablet PGMT 11b", Description = "Super mega giga tablet PGMT 11b", Price = 2234.11M, ImageUrl = "/images/t2.jpg" },
            new Product{ Id = 3, Name = "Tablet PGMT 12b", Description = "Super mega giga tablet PGMT 12b", Price = 2500.11M, ImageUrl = "/images/t3.jpg" },

            new Product{ Id = 4, Name = "MehanoPhone 11a", Description = "Super mega giga MehanoPhone 11a", Price = 1500.11M, ImageUrl = "/images/p1.jpg" },
            new Product{ Id = 5, Name = "MehanoPhone 11b", Description = "Super mega giga MehanoPhone 11b", Price = 1600.11M, ImageUrl = "/images/p2.jpg" },
            new Product{ Id = 6, Name = "MehanoPhone 12b", Description = "Super mega giga MehanoPhone 12b", Price = 1700.11M, ImageUrl = "/images/p3.jpg" }
        };

        public IActionResult Index()
        {
            return View(products);
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
    }
}
