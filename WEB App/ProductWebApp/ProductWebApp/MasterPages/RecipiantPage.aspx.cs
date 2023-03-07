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
        private void queryStringExample()
        {
            if(Request.QueryString.Count == 0)
            {
                lblMessage.Text = "This Page doesnt contain any user information. Please visit the InputPage first";
            }
            else
            {
                try
                {
                    string msg = $"The Name Entered is {Request.QueryString["name"]}<br/>" +
                        $"The Email Entered is {Request.QueryString["emial"]}<br/> The Contact No is {Request.QueryString["contact"]}";
                    lblMessage.Text = msg;
                }
                catch (NullReferenceException)
                {
                    lblMessage.Text = "Querystring keys are not correct";
                }

