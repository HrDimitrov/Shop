using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Shop11A.Models;


namespace Shop11A.Controllers
{
    public class CategoriesController : Controller
    {
        public async Task<List<Category>> Index()
        {
			var categories = new List<Category>();

			  var category = new Category
			{
				Id = 1,
				Name = "Tablets",
				Products = await GetProducts()
			};

			categories.Add(category);

			return categories; 
        }

        public async Task<Category> Details(int? id)
        {


			var category = new Category
			{
				Id = 1,
				Name = "Tablets",
				Products = await GetProducts()
			};

			return category;
        }

		public async Task<List<Category>> GetCategories()
		{
			var categories = new List<Category>(); // Инициализиране на списък за съхраняване на продуктите.


			// Коригирана връзка с MySQL база данни
			using var connection = new MySqlConnection("Server=localhost;Port=3306;Database=shop;Uid=root;Pwd=;");
			await connection.OpenAsync();

			// SQL заявка за извличане на всички продукти
			using var command = new MySqlCommand("SELECT * FROM categories}", connection);
			using var reader = await command.ExecuteReaderAsync();

			// Четене на данни от резултата на заявката
			while (await reader.ReadAsync())
			{
				var category = new Category
				{
					Id = reader.GetInt32(0),           // Съответства на първата колона (Id)
					Name = reader.GetString(1),        // Съответства на втората колона (Name)
					Products = await GetProducts()
				};

				categories.Add(category); // Добавяне на продукта в списъка
			}

			return categories;
		}

			public async Task<List<Product>> GetProducts()
		{

			string id = HttpContext.Request.Query["id"];
			var products = new List<Product>(); // Инициализиране на списък за съхраняване на продуктите.


			// Коригирана връзка с MySQL база данни
			using var connection = new MySqlConnection("Server=localhost;Port=3306;Database=shop;Uid=root;Pwd=;");
			await connection.OpenAsync();

			// SQL заявка за извличане на всички продукти
			using var command = new MySqlCommand($"SELECT * FROM products WHERE CategoryId = {id}", connection);
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
					ImageUrl = reader.GetString(4),     // Съответства на петата колона (ImageUrl)

				};

				products.Add(product); // Добавяне на продукта в списъка
			}

			return products;
		}	
    }
}
