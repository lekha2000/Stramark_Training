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
protected void lstProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            var component = ProductFactory.GetComponenet();
            var pId = int.Parse(lstProduct.SelectedItem.Value);
            var selectedProduct = component.GetProducts().Find((p) => p.ProductId == pId);
            populateData(selectedProduct);
        }
private void populateData(tblProduct product)
        {
            txtId.Text = product.ProductId.ToString();
            txtName.Text = product.ProductName;
            txtPrice.Text = product.ProductPrice.ToString();
            imgPic.ImageUrl = product.ProductImage;
            dpQuantity.Text = product.Quantity.ToString();

        }
protected void btnEdit_click(object sender,EventArgs e)
        {
            var componenet = ProductFactory.GetComponenet();
            var products = new tblProduct
            {
                ProductImage = uploadFile(),
                ProductPrice = int.Parse(txtPrice.Text),
                ProductId = int.Parse(txtId.Text),
                ProductName = txtName.Text,
                Quantity = int.Parse(dpQuantity.Text)

            };
            componenet.UpdateProduct(products);
            Response.Redirect("ProductAppWebForm.aspx");
        }
        private string uploadFile()
        {
            string imgName = string.Empty;
            string imgPath = string.Empty;

if(fileUploader.PostedFile.FileName != String.Empty)
            {
                imgName = fileUploader.PostedFile.FileName;
                imgPath = @".\Images\" + imgName;
                fileUploader.SaveAs(Server.MapPath(imgPath));
            }
            return imgPath;
        }
protected void btnAdd_click(object sender, EventArgs e)
        {
            var imgPath = uploadFile();
            var product = new tblProduct
