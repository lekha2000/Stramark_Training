using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductWebApp.MasterPages
{
    public partial class RecipiantPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            queryStringExample();
            cookiesExample();
        }
        private void cookiesExample()
        {
            var cookie = Request.Cookies["MyUserInfo"];
            if(cookie == null)
            {
                lblMessage.Text = "This Page doesnt contain any user information. Please visit the InputPage first";
            }
            else
            {
                string msg = $"The Name Entered is {cookie.Values["name"]}<br/>" +
                        $"The Email Entered is {cookie.Values["email"]}<br/> The Contact No is {cookie.Values["phone"]}";
                lblMessage.Text = msg;
            }
        }

