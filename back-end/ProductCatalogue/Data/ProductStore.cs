using ProductCatalogue.Models;

namespace ProductCatalogue.Data
{
    public class ProductStore
    {
        //Dummy data
        public static List<Product> productList = new List<Product>
        {
            new Product { Id = 1, Type = "Chair", Description = "Wooden simple chair"},
            new Product { Id = 2, Type = "Chair", Description = "Metal kitchen chair"},
            new Product { Id = 3, Type = "Table", Description = "Wooden simple four legged table"}
        };
    }
}
