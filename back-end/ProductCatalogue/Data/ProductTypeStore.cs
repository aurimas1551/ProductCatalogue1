using ProductCatalogue.Models;

namespace ProductCatalogue.Data
{
    public class ProductTypeStore
    {
        //Dummy data
        public static List<ProductType> productTypesList = new List<ProductType>
        {
            new ProductType { Id = 1, Name = "Chair" },
            new ProductType { Id = 2, Name = "Table" }
        };
    }
}
