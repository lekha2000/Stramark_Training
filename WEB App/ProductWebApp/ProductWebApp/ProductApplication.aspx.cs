using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ASPDotNetExample
{
    public partial class ProductApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = ProductRepo.AllProducts;
                foreach (var item in data)
                {
                    lstProduct.Items.Add(new ListItem
                    {
                        Text = item.ProductName,
                        Value = item.ProductId.ToString()
                    });
                }
              }
        }
