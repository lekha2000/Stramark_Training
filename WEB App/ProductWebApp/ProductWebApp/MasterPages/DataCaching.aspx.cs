using ProductApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HostitalSoftware.WebForms
{
    public partial class DataCaching : System.Web.UI.Page
    {
        private void cacheObject()
        {
            if (Cache["myData"] == null)
            {
                var component = ProductFactory.GetComponenet();
                var data = component.GetProducts();
                var textFile = Server.MapPath("MyCache.txt");
                Cache["myData"] = data;
                Response.Write("Data Got form the Database");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            cacheObject();
            gdview.DataSource = Cache["myData"];
            DataBind();
        }
    }
}