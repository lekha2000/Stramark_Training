using ASPDotNetExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductWebApp.MasterPages
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
        protected void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            var id = int.Parse(lstProduct.SelectedValue);
            var selected = ProductRepo.AllProducts.FirstOrDefault((p) => p.ProductId == id);
            txtId.Text = selected.ProductId.ToString();
            txtName.Text = selected.ProductName;
            txtPrice.Text = selected.Price.ToString();
            imgPic.ImageUrl = selected.ProductImage;
        }
        protected void btnEdit_Click(object sender,EventArgs e)
        {
               var product = new Product
            {
                ProductImage = imgPic.ImageUrl,
                Price = int.Parse(txtPrice.Text),
                ProductId = int.Parse(txtId.Text),
                ProductName = txtName.Text,
                Quantity = int.Parse(dpQuantity.Text)
            };
            
