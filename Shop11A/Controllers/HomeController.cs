using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shop11A.Models;
using System.Linq;
using Shop11A.Data;
using MySql.Data.MySqlClient;

namespace Shop11A.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Примерни продукти (ако не се получават от базата данни)
        public List<Product> productsold = new List<Product>
        {
            new Product{ Id = 1, Name = "Tablet PGMT 11a", Description = "Super mega giga tablet PGMT 11a", Price = 2000.11M, ImageUrl = "    " },
            new Product{ Id = 2, Name = "Tablet PGMT 11b", Description = "Super mega giga tablet PGMT 11b", Price = 2234.11M, ImageUrl = "/images/t2.jpg" },
            new Product{ Id = 3, Name = "Tablet PGMT 12b", Description = "Super mega giga tablet PGMT 12b", Price = 2500.11M, ImageUrl = "/images/t3.jpg" },
            new Product{ Id = 4, Name = "MehanoPhone 11a", Description = "Super mega giga MehanoPhone 11a", Price = 1500.11M, ImageUrl = "/images/p1.jpg" },
            new Product{ Id = 5, Name = "MehanoPhone 11b", Description = "Super mega giga MehanoPhone 11b", Price = 1600.11M, ImageUrl = "/images/p2.jpg" },
            new Product{ Id = 6, Name = "MehanoPhone 12b", Description = "Super mega giga MehanoPhone 12b", Price = 1700.11M, ImageUrl = "/images/p3.jpg" }
        };

        // Метод за получаване на продукти от базата данни
        public async Task<List<Product>> GetProducts()
        {
            var products = new List<Product>(); // Инициализиране на списък за съхраняване на продуктите.

            // Коригирана връзка с MySQL база данни
            using var connection = new MySqlConnection("Server=localhost;Port=3306;Database=shop;Uid=root;Pwd=;");
            await connection.OpenAsync();

            // SQL заявка за извличане на всички продукти
            using var command = new MySqlCommand("SELECT * FROM products", connection);
            using var reader = await command.ExecuteReaderAsync();

            // Четене на данни от резултата на заявката
            while (await reader.ReadAsync())
            {
                var product = new Product
                {
                    Id = reader.GetInt32(0),           // Съответства на първата колона (Id)
                    Name = reader.GetString(1),        // Съответства на втората колона (Name)
                    Description = reader.GetString(2), // Съответства на третата колона (Description)
                    Price = reader.GetDecimal(3),      // Съответства на четвъртата колона (Price)
                    ImageUrl = reader.GetString(4)     // Съответства на петата колона (ImageUrl)
                };

                products.Add(product); // Добавяне на продукта в списъка
            }

            return products; // Връщане на списъка с продукти
        }

        // Действие за извеждане на началната страница
        public async Task<IActionResult> Index()
        {
            var products = await GetProducts(); // Извличане на продукти от базата данни
            return View(products); // Предаване на продуктите към изгледа
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
