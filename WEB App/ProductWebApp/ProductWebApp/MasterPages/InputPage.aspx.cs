using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductWebApp.MasterPages
{
    public partial class InputPage : System.Web.UI.Page
    {
        static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            count++;
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            ///////////QueryString////////////////////
            //string url = $"RecipiantPage.aspx?name={txtName.Text} &email={txtEmail.Text} &contact={txtContact.Text}";
            //Response.Redirect(url);


