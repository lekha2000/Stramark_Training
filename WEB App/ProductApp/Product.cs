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
