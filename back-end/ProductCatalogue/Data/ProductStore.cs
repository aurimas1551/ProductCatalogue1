using ProductCatalogue.Models;

namespace ProductCatalogue.Data
{
    public class ProductStore
    {
        //Dummy data
        public static List<Product> productList = new List<Product>
        {
            new Product { Id = 1, Type = "Chair", Description = "The sleek and modern chair features a curved design and polished metal legs, adding a touch of sophistication to any room."},
            new Product { Id = 2, Type = "Chair", Description = "This comfortable armchair with plush cushioning and a high backrest is perfect for curling up with a good book or relaxing after a long day."},
            new Product { Id = 3, Type = "Table", Description = "This elegant dining table features a sturdy wooden construction and a polished surface, making it the perfect centerpiece for family gatherings and dinner parties."},
            new Product { Id = 4, Type = "Chair", Description = "A vintage-inspired wooden chair with intricate carved details and a rich mahogany finish, bringing an elegant and timeless charm to your home decor."},
            new Product { Id = 5, Type = "Table", Description = "The minimalist coffee table showcases a sleek glass top and metal legs, adding a touch of contemporary style to your living room while providing a convenient surface for beverages and magazines."},
            new Product { Id = 6, Type = "Chair", Description = "The ergonomic office chair offers adjustable features and lumbar support, promoting proper posture and reducing strain during long work hours."},
            new Product { Id = 7, Type = "Chair", Description = "This vibrant accent chair showcases a bold pattern and vibrant colors, instantly brightening up any space and becoming a focal point of conversation."},
            new Product { Id = 8, Type = "Table", Description = "Crafted from reclaimed wood, this rustic farmhouse table exudes charm and character, creating a warm and inviting atmosphere in your dining area."},
            new Product { Id = 9, Type = "Chair", Description = "Designed with versatility in mind, this folding chair is lightweight and easily portable, making it ideal for outdoor gatherings or additional seating for guests."},
            new Product { Id = 10, Type = "Table", Description = "The versatile folding table offers a practical solution for small spaces or impromptu gatherings, easily collapsible for storage and transportation."}
        };
    }
}
