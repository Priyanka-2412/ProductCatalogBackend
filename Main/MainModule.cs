using ProductCatalogBackend.DAO;
using ProductCatalogBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogBackend.Main
{
    class MainModule
    {
        static void Main()
        {
            IProductCatalogService service = new ProductCatalogServiceImpl();

            Console.WriteLine("Product Catalog Tool");
            Console.WriteLine("1. Add Category\n2. Add Attribute\n3. Add Product\n4. View Products\n5. Exit");

            while (true)
            {
                Console.Write("\nEnter choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        service.AddCategory(new Category { Name = "Smartphones" });
                        Console.WriteLine("Category added.");
                        break;
                    case "2":
                        service.AddAttribute(new AttributeDefinition { CategoryId = 1, Name = "RAM", DataType = "string" });
                        Console.WriteLine("Attribute added.");
                        break;
                    case "3":
                        var product = new Product { CategoryId = 1, Name = "Galaxy S21" };
                        var attrs = new List<ProductAttribute>
                    {
                        new ProductAttribute { AttributeId = 1, Value = "8GB" }
                    };
                        service.AddProduct(product, attrs);
                        Console.WriteLine("Product added.");
                        break;
                    case "4":
                        var products = service.GetProductsByCategory(1);
                        foreach (var p in products)
                            Console.WriteLine($"Product {p.Id}: {p.Name}");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
