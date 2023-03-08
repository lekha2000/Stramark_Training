using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp
{

    public interface IProduct
    {
        void AddProduct(tblProduct product);
        void UpdateProduct(tblProduct product);
        void DeleteProduct(int id);
        List<tblProduct> GetProducts();
    }
    public static class ProductFactory
    {
        public static IProduct GetComponenet() => new ProductDB();
    }

    class ProductDB : IProduct
    {
        static Entities context = new Entities();
        public void AddProduct(tblProduct product)
        {
            context.tblProducts.Add(product);
            context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var found = context.tblProducts.First((p) => p.ProductId == id);
            context.tblProducts.Remove(found);
            context.SaveChanges();
        }
