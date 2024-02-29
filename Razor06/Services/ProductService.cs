using Razor06.Models;

namespace Razor06.Services
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();

        public ProductService() {

            LoadProduct();
        }
        public Product SearchProduct(int id)
        {
            var qr = from product in products
                     where product.Id == id
                     select product;
            return qr.FirstOrDefault();
        }
        public List<Product> GetProducts() => products;
        public void LoadProduct() { 
        
        products.Clear();
            products.Add(new Product()
            {
                Id = 1,
                Name = "Iphone",
                Description = "Day la san pham cua Apple",
                Price = 1000,
            }) ;
           
            products.Add(new Product()
            {
                Id = 2,
                Name = "Samsung Galaxy",
                Description = "Day la san pham cua Samsung",
                Price = 1002,
            });
            
            products.Add(new Product()
            {
                Id = 3,
                Name = "Oppa a50",
                Description = "Day la san pham cua Oppo",
                Price = 1003,
            });
        }

    }
}
