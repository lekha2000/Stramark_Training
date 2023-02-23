using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ASPDotNetExample
{
    public partial class MyFirstCalcApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var number1 = double.Parse(textFirstNo.Text);
            var number2 = double.Parse(textSecondNo.Text);
            var option = dpList.SelectedValue;
            var result = getrecord(number1, number2, option);
            lblDisplay.Text = "The Result Is: " + result;
        }
