using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace OOL_LR_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = @"C:\Products\";
            string searchQuery = "apple";
            int maxPrice = 10;
            Predicate<Product> filterCriteria = (product) => { return product.Name.ToLower().Contains(searchQuery) && product.Price <= maxPrice; };
            Action<Product> displayProduct = (product) => { Console.WriteLine($"Name: {product.Name}, Price: {product.Price}"); };
            for (int i = 1; i <= 10; i++)
            {
                string filePath = Path.Combine(jsonPath, $"{i}.json");

                if (File.Exists(filePath))
                {
                    string jsonContent = File.ReadAllText(filePath);
                    var products = JsonConvert.DeserializeObject<Product[]>(jsonContent);

                    var filteredProducts = products.Where(filterCriteria);

                    foreach (var product in filteredProducts)
                    {
                        displayProduct(product);
                    }
                }
            }
        }
    }
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
