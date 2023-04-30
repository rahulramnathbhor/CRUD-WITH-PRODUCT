using static CRUD_WITH_PRODUCT.Views.Product;

namespace CRUD_WITH_PRODUCT.Models
{
    public class Product
    {
        public class Category
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int CategoryId { get; set; }
            public Category Product { get; set; }
        }
    }
}
