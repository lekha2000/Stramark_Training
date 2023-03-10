using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDotNetExample
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
    public static class ProductRepo
    {
        private static List<Product> _repo = new List<Product>();
        static ProductRepo()
        {
            getAll();
        }
        public static List<Product> AllProducts => _repo;
        private static void getAll()
        {
            //List<Product> _repo = new List<Product>();
            _repo.Add(new Product
            {
                ProductId = 1,
                ProductName = "Iphone 14 Pro Max",
                Price = 1200000,
                ProductImage = @".\Images\Iphone14promax.jfif"
            });
            _repo.Add(new Product
            {
                ProductId = 2,
                ProductName = "Nokia",
                Price = 12000,
                ProductImage = @".\Images\Nokia.jfif"
            });
            _repo.Add(new Product
            {
                ProductId = 3,
                ProductName = "One Pluse Nord",
                Price = 35000,
                ProductImage = @".\Images\OnePluse.jfif"
            });
            _repo.Add(new Product
            {
                ProductId = 4,
                ProductName = "RealMe9Pro",
                Price = 20000,
                ProductImage = @".\Images\RealMe9pro.jfif"
            });
            _repo.Add(new Product
            {
                ProductId = 5,
                ProductName = "Samsung Galaxy S22",
                Price = 85000,
                ProductImage = @".\Images\SamsungGalaxyS22.jfif"
            });
            //return _repo;
           }
         public static void UpdateProduct(Product product)
        {
            var found = _repo.Find((p) => p.ProductId == product.ProductId);
            found.ProductName = product.ProductName;
            found.Price = product.Price;
        }
        public static void DeleteProduct(int id)
        {
            var found = _repo.Find((p) => p.ProductId == id);
            _repo.Remove(found);
        }
        internal static void AddNewProduct(Product product) => _repo.Add(product);
    }
}
