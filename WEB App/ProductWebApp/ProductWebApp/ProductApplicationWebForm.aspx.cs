using ProductApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//linked ProductAppDLL to ProductAppWeb
namespace ProductWebApp
{
    public partial class ProductAppWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var componet = ProductFactory.GetComponenet();
                lstProduct.DataSource = componet.GetProducts();
                lstProduct.DataTextField = "ProductName";
                lstProduct.DataValueField = "ProductId";
                lstProduct.DataBind();
            }
        }
