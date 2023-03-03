using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductWebApp.MasterPages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                lblUSerInfo.Text = "Welcome  " + Page.User.Identity.Name;
            }

else
            {
                lblUSerInfo.Text = "Welcome Anoymous User";
            }
            lblYear.Text = DateTime.Now.Year.ToString();
        }
protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtName.Text, txtpass.Text)){
                FormsAuthentication.RedirectFromLoginPage(txtName.Text, false);

            }
            else
            {
                lblError.Text = "Login Failed";
            }
        }
    }
}
