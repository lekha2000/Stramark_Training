using HostitalSoftware.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HostitalSoftware.Models;


namespace HostitalSoftware.WebForms
{
    public partial class RegPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Helper.PopulateDoctors(dpDoctors, Application["Doctors"]);
            }

        }
protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var repo = Application["Patients"] as PatientRepo;
            var pat = new Patient
            {
                DateofBirth = DateTime.Parse(txtDob.Text),
                DoctorId = int.Parse(dpDoctors.SelectedValue),
                PatientMobile = long.Parse(txtMobile.Text),
                PatientName = txtName.Text
            };
            repo.RegisterNewPatient(pat);
            lblMessage.Text = "Patient Added Successfully";
        }
    }
}
