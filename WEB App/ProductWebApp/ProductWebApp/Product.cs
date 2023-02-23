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
